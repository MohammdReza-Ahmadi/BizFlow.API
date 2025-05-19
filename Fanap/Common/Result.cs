namespace BizFlow.API.Common;

public class Result
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public List<string>? Errors { get; set; }

    public static Result Ok(string message = "Success")
    {
        return new Result { Success = true, Message = message };
    }

    public static Result Fail(string message, List<string>? errors = null)
    {
        return new Result { Success = false, Message = message, Errors = errors };
    }
}


public class Result<T> : Result
{
    public T? Data { get; set; }

    public static Result<T> Ok(T data, string message = "Success")
    {
        return new Result<T> { Success = true, Message = message, Data = data };
    }

    public static new Result<T> Fail(string message, List<string>? errors = null)
    {
        return new Result<T> { Success = false, Message = message, Errors = errors };
    }
}

