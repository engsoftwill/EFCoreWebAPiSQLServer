using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repo.Repository
{
    public interface IEFCoreRepository
    {
        void Add<T>(T Entity) where T : class;
        void Update<T>(T Entity) where T : class;
        void Remove<T>(T Entity) where T : class;
        Task<bool> SaveChangeAsync();
    }
}
