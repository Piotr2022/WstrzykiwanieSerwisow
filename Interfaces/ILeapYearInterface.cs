using RokPrzestepnyZBaza.Model;

namespace RokPrzestepnyZBaza.Interfaces
{
    public interface ILeapYearInterface
    {
        public IQueryable<WpisPrzestepnosci> GetWpisPrzestepnoscis();

        public void SaveWpisPrzestepnoscis(WpisPrzestepnosci wpisPrzestepnosci);

    }
}
