using System;
using System.Linq;
using BulkyBook.DataAccess;
using DataAccess.Repository.IRepository;
using Models;

namespace DataAccess.Repository
{
    public class CoverTypeRepository: Repository<CoverType>,ICoverTypeRepository
    {
        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        private readonly ApplicationDbContext _db;

        public void Update(CoverType coverType)
        {
            var objFromDb = _db.CoverTypes.FirstOrDefault(s => s.Id == coverType.Id);
            if (objFromDb!= null)
            {
                objFromDb.Name = coverType.Name;
            }
        }
    }
}
