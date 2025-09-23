using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NetFoundy.AsynchronousProgramming;

internal class SmLibraryModel
{
    private string _message;
    [JsonPropertyName("message")]
    public string Message
    {
        get { return _message; }
        set { _message = value; }
    }
}

internal class SmLibraryService
{
    private HttpClient _httpClient;
    public SmLibraryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public Task<SmLibraryModel> GetLibrariesTask()
    {
        GetLibraries stateMachine = new GetLibraries();
        stateMachine._builder = AsyncTaskMethodBuilder<SmLibraryModel>.Create();
        stateMachine._this = this;
        stateMachine._state = -1;
        stateMachine._builder.Start(ref stateMachine);
        return stateMachine._builder.Task;
    }
    
    private sealed class GetLibraries : IAsyncStateMachine
    {
        public int _state;
        public AsyncTaskMethodBuilder<SmLibraryModel> _builder;
        public SmLibraryService _this;
        
        private HttpResponseMessage _response;
        private Stream _stream;
        private SmLibraryModel _libraries;
        
        private HttpResponseMessage _response_alt;
        private Stream _stream_alt;
        private SmLibraryModel _libraries_alt;
        
        private TaskAwaiter<HttpResponseMessage> _awaiter_response;
        private TaskAwaiter<Stream> _awaiter_stream;
        private ValueTaskAwaiter<SmLibraryModel> _awaiter_libraries;
        
        public void MoveNext()
        {
            int num = _state;
            SmLibraryModel result;
            try
            {
                TaskAwaiter<HttpResponseMessage> awaiter_response;
                TaskAwaiter<Stream> awaiter_stream;
                ValueTaskAwaiter<SmLibraryModel> awaiter_libraries;
                switch (num)
                {
                    default:
                        awaiter_response = _this._httpClient.GetAsync("https://dog.ceo/api/breeds/image/random").GetAwaiter();
                        if(!awaiter_response.IsCompleted)
                        {
                            num = _state = 0;
                            _awaiter_response = awaiter_response;
                            GetLibraries stateMachine = this;
                            _builder.AwaitUnsafeOnCompleted(ref awaiter_response, ref stateMachine);
                            return;
                        }
                        goto IL_2;
                    case 0:
                        awaiter_response = _awaiter_response;
                        _awaiter_response = default(TaskAwaiter<HttpResponseMessage>);
                        num = _state = -1;
                        goto IL_2;
                    case 1:
                        awaiter_stream = _awaiter_stream;
                        _awaiter_stream = default(TaskAwaiter<Stream>);
                        num = _state = -1;
                        goto IL_1;
                    case 2:
                    {
                        awaiter_libraries = _awaiter_libraries;
                        _awaiter_libraries = default(ValueTaskAwaiter<SmLibraryModel>);
                        num = _state = -1;
                        break;
                    }
                    IL_1:
                        _stream_alt = awaiter_stream.GetResult();
                        _stream = _stream_alt;
                        _stream_alt = null;
                        awaiter_libraries = JsonSerializer.DeserializeAsync<SmLibraryModel>(_stream).GetAwaiter();
                        if (!awaiter_libraries.IsCompleted)
                        {
                            num = _state = 2;
                            _awaiter_libraries = awaiter_libraries;
                            GetLibraries stateMachine = this;
                            _builder.AwaitUnsafeOnCompleted(ref awaiter_libraries, ref stateMachine);
                            return;
                        }
                        break;
                    IL_2:
                        _response_alt = awaiter_response.GetResult();
                        _response = _response_alt;
                        _response_alt = null;
                        _response.EnsureSuccessStatusCode();
                        awaiter_stream = _response.Content.ReadAsStreamAsync().GetAwaiter();
                        if(!awaiter_stream.IsCompleted)
                        {
                            num = _state = 1;
                            _awaiter_stream = awaiter_stream;
                            GetLibraries stateMachine = this;
                            _builder.AwaitUnsafeOnCompleted(ref awaiter_stream, ref stateMachine);
                            return;
                        }
                        goto IL_1;
                }
                _libraries_alt = awaiter_libraries.GetResult();
                _libraries = _libraries_alt;
                _libraries_alt = null;
                SmLibraryModel list = _libraries;
                if (list == null)
                {
                    throw new InvalidOperationException("Failed to deserialize libraries");
                }
                result = list;
            }
            catch (Exception exception)
            {
                _state = -2;
                _response = null;
                _stream = null;
                _libraries = null;
                _builder.SetException(exception);
                return;
            }
            _state = -2;
            _response = null;
            _stream = null;
            _libraries = null;
            _builder.SetResult(result);
        }

        public void SetStateMachine(IAsyncStateMachine stateMachine)
        {
            
        }
    }
}