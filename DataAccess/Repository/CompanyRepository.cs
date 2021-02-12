using System;
using System.Linq;
using BulkyBook.DataAccess;
using DataAccess.Repository.IRepository;
using Models;

namespace DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        private readonly ApplicationDbContext _db;

        public void Update(Company company)
        {
            var objFromDb = _db.Companies.FirstOrDefault(s => s.Id == company.Id);
            if(objFromDb != null)
            {
                objFromDb.Name = company.Name;
            }
            
        }
    }
}
