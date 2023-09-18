namespace BlogSite.CrossCutting;

public class Result
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;
    
    public static Result Success()
    {
        return new Result
        {
            IsSuccess = true
        };
    }
    
    public static Result Failure(string message)
    {
        return new Result
        {
            IsSuccess = false,
            Message = message
        };
    }
}

public class Result<T> : Result
{
    public T Value { get; set; } = default!;
    
    public static Result<T> Success(T value)
    {
        return new Result<T>
        {
            IsSuccess = true,
            Value = value
        };
    }
    
    public new static Result<T> Failure(string message)
    {
        return new Result<T>
        {
            IsSuccess = false,
            Message = message
        };
    }
}