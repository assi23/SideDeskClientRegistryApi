namespace SideDesk.ClientRegister.Domain.General.Result
{
    public interface IResult<T> where T : class
    {
        public bool Success { get; }
        public T Model { get; }
        public IEnumerable<string> Messages { get; }
    }
}
