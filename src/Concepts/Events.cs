namespace NetFoundy.Concepts;

class Events
{
    public static void Run()
    {
        var publisher = new Publisher();
        var subscriber = new Subscriber();
        publisher.OnStart += (e) => Console.WriteLine(e.Message);
        publisher.Start();
        publisher.OnChange += subscriber.HandleEvent;
        publisher.OnChange += (sender, e) => Console.WriteLine("Another event handled: {0}", e.Message);
        publisher.TriggerEvent("Hello, World!");
    }
}

internal class Subscriber
{
    public void HandleEvent(object? sender, MessageEventArgs e)
    {
        Console.WriteLine("Event handled: {0}", e.Message);
    }
}

internal class Publisher
{
    public Action<MessageEventArgs>? OnStart;
    public event EventHandler<MessageEventArgs>? OnChange;

    public void Start()
    {
        OnStart?.Invoke(new MessageEventArgs("Publisher created"));
    }
    public void TriggerEvent(string message)
    {
        OnChange?.Invoke(this, new MessageEventArgs(message));
    }
}

internal class MessageEventArgs : EventArgs
{
    public string Message { get; set; }
    public MessageEventArgs(string message)
    {
        Message = message;
    }
}