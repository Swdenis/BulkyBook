using System;
using BulkyBook.DataAccess;
using DataAccess.Repository.IRepository;
using Models;

namespace DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            CoverType = new CoverTypeRepository(_db);
            Product = new ProductRepository(_db);
            Company = new CompanyRepository(_db);
            SP_Call = new SP_Call(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
        }

        private readonly ApplicationDbContext _db;

        public ICategoryRepository Category { get; private set; }

        public ISP_call SP_Call { get; private set; }

        public ICoverTypeRepository CoverType { get; private set; }

        public ICompanyRepository Company { get; private set; }

        public IProductRepository Product { get; private set; }

        public IApplicationUserRepository ApplicationUser { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
