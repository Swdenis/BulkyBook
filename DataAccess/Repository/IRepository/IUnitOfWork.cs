using System;
namespace DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get;  }
        ISP_call SP_Call { get; }
    }

}
