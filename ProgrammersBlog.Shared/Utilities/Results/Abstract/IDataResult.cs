namespace ProgrammersBlog.Shared.Utilities.Results.Abstract
{
    public interface IDataResult<out T> : IResult
    {
        // Entiti'leri hem tek hem list hali ile gondermek icin out kullandik
        public T data { get; }


    }
}
