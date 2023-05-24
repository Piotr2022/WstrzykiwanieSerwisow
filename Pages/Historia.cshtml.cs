using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RokPrzestepnyZBaza.Data;
using RokPrzestepnyZBaza.Model;
using Microsoft.Extensions.Configuration;
using RokPrzestepnyZBaza.Interfaces;

namespace RokPrzestepnyZBaza.Pages
{
    public class HistoriaModel : PageModel
    {
        private readonly ILogger<HistoriaModel> _logger;
        private readonly RokPrzestepnyDbContext _context;
        private readonly IConfiguration Configuration;
        private readonly ILeapYearInterface _wpisyService;


        public HistoriaModel(ILogger<HistoriaModel> logger, RokPrzestepnyDbContext context, IConfiguration configuration, ILeapYearInterface wpisyService)
        {
            _logger = logger;
            _context = context;
            Configuration = configuration;
            pageIndexValue = 1;
            _wpisyService = wpisyService;
        }



        public PaginatedList<WpisPrzestepnosci> lista { get; set; }


        [BindProperty]
        public int? pageIndexValue { get; set; }

        public async Task OnGetAsync(int? pageIndex)
        {
            
            IQueryable<WpisPrzestepnosci> wpisyIQ = _wpisyService.GetWpisPrzestepnoscis();
            wpisyIQ = wpisyIQ.OrderByDescending(w => w.Data);



            pageIndexValue = pageIndex;

            var pageSize = Configuration.GetValue("PageSize", 20);
            lista = await PaginatedList<WpisPrzestepnosci>.CreateAsync(wpisyIQ.AsNoTracking(),pageIndex ?? 1, pageSize);
        }
    }
}
