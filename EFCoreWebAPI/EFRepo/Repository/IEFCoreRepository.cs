using EFCore.Dominio;
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
        void Delete<T>(T Entity) where T : class;
        Task<bool> SaveChangeAsync();
        Task<IEnumerable<Hero>> GetAllHeroes();
        Task<Hero> GetAHeroById(int id);
        Task<Hero> GetHeroByName(string name);

    }
}
