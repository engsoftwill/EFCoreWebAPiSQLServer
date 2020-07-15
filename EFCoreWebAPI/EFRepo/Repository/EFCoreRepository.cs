using EFCore.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repo.Repository
{
    public class EFCoreRepository : IEFCoreRepository
    {
        private readonly HeroContext _context;

        public EFCoreRepository(HeroContext context)
        {
            _context = context;
        }
        public void Add<T>(T Entity) where T : class
        {
            _context.Add(Entity);
        }

        public void Delete<T>(T Entity) where T : class
        {
            _context.Remove(Entity);
        }
        public void Update<T>(T Entity) where T : class
        {
            _context.Update(Entity);
        }

      

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<IEnumerable<Hero>> GetAllHeroes()
        {
            IQueryable<Hero> query = _context.Heroes.Include(x => x.Weapons)
                .Include(x => x.Secretidentity);
            query = query.Include(x => x.HeroBattles).ThenInclude(y => y.Battle);

            query = query.AsNoTracking().OrderBy(x => x.Id);
            return await query.ToArrayAsync();
        }

        public Task<Hero> GetAHeroById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Hero> GetHeroByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
