using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programmersBlog.Data.Abstract
{
    public interface IUnitOfWork: IAsyncDisposable
    {

        // tum repos'leri tek bir yerden yontemek
        IArticleRepo aticles { get; }
        ICategoryRepo categories { get; }
        ICommentRepo comments { get; }
        // tek bir save aysnc ile ard arda yapilan islemleri kayit edebiliriyoruz 
        Task<int> saveAsync();

    }
}
