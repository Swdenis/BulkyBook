using System;
namespace DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get;  }
        ICoverTypeRepository CoverType { get; }
        IProductRepository Product { get; }
        ISP_call SP_Call { get; }

        void Save();
    }

}
