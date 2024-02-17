using System;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {

        // tum repos'leri tek bir yerden yontemek
        IArticleRepo Articles { get; }
        ICategoryRepo Categories { get; }
        ICommentRepo Comments { get; }
        // tek bir save aysnc ile ard arda yapilan islemleri kayit edebiliriyoruz 
        Task<int> saveAsync();

    }
}
