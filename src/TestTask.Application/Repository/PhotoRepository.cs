#region Using derectives

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestTask.Database;
using TestTask.Domain.Entity;
using TestTask.Shared;

#endregion

namespace TestTask.Application.Repository
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly PlatformContext _context;

        public PhotoRepository(PlatformContext context) => _context = context;

        public async Task DisposeAsync() => await _context.DisposeAsync();

        public async Task<List<Photo>> GetPhotoListAsync() =>
                await _context.Photos.Include(x => x.Author).ToListAsync();

        public async Task<Photo> GetPhotoAsync(int id) => await _context.Photos.FindAsync(id);

        public async Task CreateAsync(Photo item) => await _context.Photos.AddAsync(item);

        public async Task UpdateAsync(Photo item) => await Task.Run(() => { _context.Photos.Update(item); });

        public async Task DeleteAsync(int id) =>
                await Task.Run(() => { _context.Photos.Remove(_context.Photos.Find(id)); });

        public async Task SaveAsync() => await _context.SaveChangesAsync();

        public async Task<bool> IsExists(Photo item) => await _context.Photos.AnyAsync(x => x.Id == item.Id);
    }
}