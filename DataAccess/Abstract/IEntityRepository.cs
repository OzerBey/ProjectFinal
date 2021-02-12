using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.Abstract;

namespace DataAccess.Abstract 
{
    //Generic constraint (generic kısıtlama)
    //class : referans tip olabilr demektire
    //IEntity olabilir veya IEntityi implemente eden bir nesne olabilir
    //new() : new'lenebilr olmali 
    public interface IEntityRepository<T> where T:class,IEntity,new() //generic kısıtlama
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);// Linq Expression filter=null filtre vermesende tüm datayı istiyor demektir
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
