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
    public class TextRepository : ITextRepository
    {
        private readonly PlatformContext _context;

        public TextRepository(PlatformContext context) => _context = context;

        public async Task DisposeAsync() => await _context.DisposeAsync();

        public async Task<List<Text>> GetTextListAsync() => await _context.Texts.Include(x => x.Author).ToListAsync();

        public async Task<Text> GetTextAsync(int id) => await _context.Texts.FindAsync(id);

        public async Task CreateAsync(Text item) => await _context.Texts.AddAsync(item);

        public async Task UpdateAsync(Text item) => await Task.Run(() => { _context.Texts.Update(item); });

        public async Task DeleteAsync(int id) =>
                await Task.Run(() => { _context.Texts.Remove(_context.Texts.Find(id)); });

        public async Task SaveAsync() => await _context.SaveChangesAsync();

        public async Task<bool> IsExists(Text item) => await _context.Texts.AnyAsync(x => x.Id == item.Id);
    }
}