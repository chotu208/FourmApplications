using FourmApplication.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmApplication.Repositary
{ 
    public interface ICategoriesRepositary
    {
        void InsertCategory(Categories c);
        void UpdateCategory(Categories c);  
        void DeleteCategory(int cid);  
        List<Categories> GetCategories();   
        Categories GetCategoryByCategoryID(int Cid);
    }
    public class CategoriesRepositary : ICategoriesRepositary
    {
        private FourmAppDBContext _dbContext;
         public CategoriesRepositary()
         {
            _dbContext = new FourmAppDBContext();   
         }
            

        
        public void DeleteCategory(int cid)
        {
            _dbContext.Categories.Remove(_dbContext.Categories.Find(cid));
            _dbContext.SaveChanges();   
        }

        public List<Categories> GetCategories()
        {
           return _dbContext.Categories.ToList();
        }

        public Categories GetCategoryByCategoryID(int Cid)
        {
          return  _dbContext.Categories.Find(Cid);
            
        }

        public void InsertCategory(Categories c)
        {
           _dbContext.Categories.Add(c);
            _dbContext.SaveChanges();
        }

        public void UpdateCategory(Categories c)
        {
          Categories category =  _dbContext.Categories.Where(x => x.CategoryID == c.CategoryID).FirstOrDefault();
            if(category != null)
            {
                category.CategoryName = c.CategoryName;
                _dbContext.SaveChanges();
            }
        }
    }
}
