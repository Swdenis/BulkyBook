using System;
using System.Linq;
using BulkyBook.DataAccess;
using DataAccess.Repository.IRepository;
using Models;

namespace DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        private readonly ApplicationDbContext _db;

        public void Update(Category category)
        {
            var objFromDb = _db.Categories.FirstOrDefault(s => s.Id == category.Id);
            if(objFromDb != null)
            {
                objFromDb.Name = category.Name;
            }
            
        }
    }
}
