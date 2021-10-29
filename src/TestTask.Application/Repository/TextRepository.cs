using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestTask.Database;
using TestTask.Domain.Entity;
using TestTask.Shared;

namespace TestTask.Application.Repository
{
    public class TextRepository : ITextRepository
    {
        private readonly PlatformContext _context;

        public TextRepository(PlatformContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<Text>> GetTextList() => await _context.Texts.ToListAsync();

        public async Task<Text> GetText(int id) => await _context.Texts.FindAsync(id);

        public async Task Create(Text item)
        {
            await _context.Texts.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Text item)
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
            _context.Texts.Remove(await _context.Texts.FindAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task Save() => await _context.SaveChangesAsync();

        public async Task<bool> IsExists(int id) => await _context.Texts.AnyAsync(x => x.Id == id);
    }
}
