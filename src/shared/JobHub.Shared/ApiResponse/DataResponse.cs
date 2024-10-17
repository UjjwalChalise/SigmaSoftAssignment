using JobHub.Shared.Enums;

namespace JobHub.Shared.ApiResponse;

public class DataResponse
{
    public DataResponse() { }

    public DataResponse(ResponseTypeOption responseType, string message, string data)
        => (ResponseType, Message, Data) = (responseType, message, data);

    public ResponseTypeOption ResponseType { get; set; }
    public string Message { get; set; }
    public string Data { get; set; }

    public static DataResponse Success(string message = null)
        => new() { ResponseType = ResponseTypeOption.Success, Message = message };

    public static DataResponse Failure(string message)
        => new() { ResponseType = ResponseTypeOption.Failed, Message = message };

    public static DataResponse Exception(string message)
        => new() { ResponseType = ResponseTypeOption.Exception, Message = message };

}

public class DataResponse<T> : DataResponse
{
    public DataResponse() { }

    public DataResponse(ResponseTypeOption responseType, string message, T data)
       => (ResponseType, Message, Data) = (responseType, message, data);

    public new T Data { get; set; }

    public new static DataResponse<T> Success(string message = null)
        => new() { ResponseType = ResponseTypeOption.Success, Message = message };

    public new static DataResponse<T> Success(string message, T data)
        => new() { ResponseType = ResponseTypeOption.Success, Message = message, Data = data };

    public new static DataResponse<T> Failure(string message)
        => new() { ResponseType = ResponseTypeOption.Failed, Message = message };

    public new static DataResponse<T> Failure(string message, T data)
        => new() { ResponseType = ResponseTypeOption.Failed, Message = message, Data = data };

}

