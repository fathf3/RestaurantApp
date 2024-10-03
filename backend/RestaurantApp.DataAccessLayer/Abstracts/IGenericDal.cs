using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DataAccessLayer.Abstracts
{
    public interface IGenericDal<T> where T : class
    {
        void Add(T entity);
        public void Delete(T entity);
        public void Update(T entity);
        public T GetById(int id);
        public List<T> GetListAll();


    }
}
