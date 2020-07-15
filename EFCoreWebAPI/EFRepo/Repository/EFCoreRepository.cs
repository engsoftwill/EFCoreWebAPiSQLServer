using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repo.Repository
{
    class EFCoreRepository : IEFCoreRepository
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

        public void Remove<T>(T Entity) where T : class
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

        
    }
}
