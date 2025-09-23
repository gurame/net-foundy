using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace NetFoundy.AsynchronousProgramming;

public class GurameTask
{
    private readonly Lock _lock = new();
    private bool _completed;
    private Exception? _exception;
    private Action? _action;
    private ExecutionContext? _context;
    public bool Completed
    {
        get
        {
            lock (_lock)
            {
                return _completed;
            }
        }
    }

    public static GurameTask Run(Action action)
    {
        var task = new GurameTask();

        ThreadPool.QueueUserWorkItem(_ =>
        {
            try
            {
                action();
                task.SetResult();
            }
            catch (Exception e)
            {
                task.SetException(e);
            }
        });
        
        return task;
    }

    public GurameTask ContinueWith(Action action)
    {
        //Monitor.Wait(_lock);
        GurameTask task = new();
        
        lock (_lock)
        {
            if (_completed)
            {
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        action();
                        task.SetResult();
                    }
                    catch (Exception e)
                    {
                        task.SetException(e);
                    }
                });
            }
            else
            {
                _action = action;
                _context = ExecutionContext.Capture();
            }
        }
        
        return task;
    }

    public void Wait()
    {
        ManualResetEventSlim? eventSlim = null;
        lock (_lock)
        {
            if (!_completed)
            {
                eventSlim = new ManualResetEventSlim();
                ContinueWith(() => eventSlim.Set());
            }
        }
        
        eventSlim?.Wait();
        
        if (_exception != null)
        {
            ExceptionDispatchInfo.Throw(_exception);
        }
    }

    public GurameTaskAwaiter GetAwaiter() => new(this);
    public static GurameTask Delay(TimeSpan delay)
    {
        GurameTask task = new();
        
        new Timer(_=> task.SetResult()).Change(delay, Timeout.InfiniteTimeSpan);
        
        return task;
    }
    
    private void SetResult() => CompleteTask(null);
    private void SetException(Exception exception) => CompleteTask(exception);
    private void CompleteTask(Exception? exception)
    {
        lock (_lock)
        {
            if (_completed)
                throw new InvalidOperationException("Task already completed.");
            
            _completed = true;
            _exception = exception;

            if (_action != null)
            {
                if (_context is null)
                {
                    _action.Invoke();
                }
                else
                {
                    ExecutionContext.Run(_context, state => ((Action)state).Invoke(), _action);
                }
            }
        }
    }
}

public readonly struct GurameTaskAwaiter : INotifyCompletion
{
    private readonly GurameTask _task;
    internal GurameTaskAwaiter(GurameTask task) => _task = task;
    
    public bool IsCompleted => _task.Completed;
    
    public void OnCompleted(Action continuation) => _task.ContinueWith(continuation);
    
    public GurameTaskAwaiter GetAwaiter() => this;
    
    public void GetResult() => _task.Wait();
    
}