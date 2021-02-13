using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    //is kodlarinin bulundugu yer
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        //Constructor injection
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            //Works codes
            return _categoryDal.GetAll();
        }

        public Category GetById(int categoryId)
        {
            //Select * from Categories where CategoryId = 3
            return _categoryDal.Get(c => c.CategoryId == categoryId);
        }
    }
}
