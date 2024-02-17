using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Data.Abstract
{
    // kod tekrarindan kacinmak icin sikca  data katmaninda kullanacagimiz metotlari buraya yaziyoruz
    public interface IEntityRepo<T> where T : class, IEntity, new()
    {
        // Adilandirmada aysnc kullandik cunku bu metotlar baska programci tarafindan var olup dusunulup bu sekilde kullanilabilir bu da hata olusturur 
        // metod 1 bir enttiy getirmek 
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeproperties); // var kullanici = repositry.GetAsync(k=>k.Id==15) Kesin olarak belirlenmiş bir lambda ifadesini,ifade ağacıni veri yapısı olusturur , [] cunku biz article'larin ve article yorumlarini getirmek isteyebiliriz 
        // metod 2 list of entity getirmek IList 
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeproperties);
        // add dekele search  entity metodu
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entuty);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate=null);
    }
}
