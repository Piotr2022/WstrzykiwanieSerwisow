using Microsoft.EntityFrameworkCore;
using RokPrzestepnyZBaza.Data;
using RokPrzestepnyZBaza.Interfaces;
using RokPrzestepnyZBaza.Model;

namespace RokPrzestepnyZBaza.Services
{
    public class WpisyPrzestepnosciService : ILeapYearInterface
    {
        private readonly RokPrzestepnyDbContext _context;

        public WpisyPrzestepnosciService(RokPrzestepnyDbContext context)
        {
            _context = context;
        }

        public IQueryable<WpisPrzestepnosci> GetWpisPrzestepnoscis()
        {
            return from w in _context.WpisyPrzestepnosci select w;
        }

        public void SaveWpisPrzestepnoscis(WpisPrzestepnosci wpisPrzestepnosci)
        {
            _context.WpisyPrzestepnosci.Add(wpisPrzestepnosci);
            _context.SaveChanges();
        }
    }
}
