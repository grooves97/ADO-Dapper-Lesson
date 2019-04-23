using DCA.Models;
using System;
using System.Collections.Generic;

namespace DCA.DataAcces.Abstract
{
    public interface IRepository<T> : IDisposable where T: Entity
    {
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        ICollection<T> GetAll();
        ICollection<T> GetWith(Func<T,bool> predicate);
    }
}
