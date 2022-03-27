using Inventory.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save();

        IGenericRepository<T> GenericRepository<T>() where T : BaseEntity;
    }
}
