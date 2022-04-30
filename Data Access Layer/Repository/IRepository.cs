using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    public interface IRepository <T> where T:BaseEntity
    {
        void Insert(T entity) { }
        void Update(T entity) { }
        void Delete(T entity) { }
        public T GetModel(T entity);
        IEnumerable<T> SelectAll();
        public T SelectOneById(int Id);
    }
}
