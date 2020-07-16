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
        Task<IEnumerable<Hero>> GetAllHeroes(bool includbattle = false);
        Task<Hero> GetAHeroById(int id, bool includbattle = false);
        Task<Hero[]> GetHerosByName(string name, bool includbattle = false);
        Task<IEnumerable<Battle>> GetAllBattles(bool includehero = false);
        Task<Battle> GetABattleById(int id, bool includehero = false);

    }
}
