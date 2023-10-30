namespace SideDesk.ClientRegister.Domain.General.Result
{
    public class Result<T> : IResult<T> where T : class
    {
        public T Model { get; private set; }
        public bool Success { get; private set; }
        public IEnumerable<string> Messages { get; private set; }

        public static Result<T> CreateSuccess(T model, string message = "")
        {
            return new Result<T>
            {
                Messages = new List<string> { message },
                Model = model,
                Success = true
            };
        }

        public static Result<T> CreateFailure(string message)
        {
            return new Result<T>
            {
                Messages = new List<string> { message },
                Success = false,
            };
        }

        public static Result<T> CreateFailure(string message, Exception error)
        {
            return new Result<T>
            {
                Messages = new List<string>
                {
                    $"Message: {message}",
                    $"Exception: {error.GetBaseException().Message}",
                    $"StackTrace: {error.GetBaseException().StackTrace}"
                },

                Success = false
            };
        }
    }
}
