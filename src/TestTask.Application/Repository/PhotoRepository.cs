using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestTask.Database;
using TestTask.Domain.Entity;
using TestTask.Shared;

namespace TestTask.Application.Repository
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly PlatformContext _context;

        public PhotoRepository(PlatformContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<Photo>> GetPhotoList() => await _context.Photos.ToListAsync();

        public async Task<Photo> GetPhoto(int id) => await _context.Photos.FindAsync(id);

        public async Task Create(Photo item)
        { 
            await _context.Photos.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Photo item)
        {
            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return;
            }
        }

        public async Task Delete(int id)
        {
            _context.Photos.Remove(await _context.Photos.FindAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task Save() => await _context.SaveChangesAsync();

        public async Task<bool> IsExists(int id) => await _context.Photos.AnyAsync(x => x.Id == id);
    }
}