using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //GenericRepository<Category> repository = new GenericRepository<Category>();

        //public List<Category> GetAllBL()
        //{
        //    return repository.List();
        //}

        //public void CategoryAddBL(Category c)
        //{
        //    if (c.Name.Length <= 3 || c.Name == "" || c.Description == "" || c.Name.Length >= 51)
        //    {
        //        //hata mesajı throw
        //    }
        //    else
        //    {
        //        repository.Insert(c);
        //    }
        //}

        ICategoryDAL _categoryDAL;

        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public List<Category> GetList()
        {
            return _categoryDAL.List();
        }

        public void CategoryAdd(Category category)
        {
            _categoryDAL.Insert(category);

        }
    }
}
