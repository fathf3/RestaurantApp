using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BusinessLayer.Abstracts
{
    public interface IGenericService<T> where T : class
    {
        void TAdd(T entity);
        public void TDelete(T entity);
        public void TUpdate(T entity);
        public T TGetById(int id);
        public List<T> TGetListAll();
    }
}
