using System;
namespace DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get;  }
        IApplicationUserRepository ApplicationUser { get; }
        ICoverTypeRepository CoverType { get; }
        IProductRepository Product { get; }
        ICompanyRepository Company { get; }
        ISP_call SP_Call { get; }

        void Save();
    }

}
