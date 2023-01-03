namespace InternalApi.Helpers
{
    public class Result<T> 
    {
        public T Payload { get;  }
        public string FailureReason { get;  }

        public bool IsSuccess => FailureReason == null;

        public Result(T payload)
        {
            Payload = payload;
        }

        public Result(string failureReason)
        {
            FailureReason = failureReason;
        }

        public static Result<T> Success(T payload)
            => new Result<T>(payload);

        public static Result<T> Failure(string reason)
            => new Result<T>(reason);

        public static implicit operator bool(Result<T> result) => result.IsSuccess;

    }
}