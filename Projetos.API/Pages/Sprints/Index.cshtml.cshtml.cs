using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projetos.API.Data;
using Projetos.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Projetos.API.Pages.Sprints
{
    public class Index : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public DateTime? FiltroDataInicio { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Ordenacao { get; set; }

        private readonly AppDbContext _context;
        public List<SprintModel> SprintList { get; set; } = new();

        public Index(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var query = _context.Sprints.AsQueryable();

            if (FiltroDataInicio.HasValue)
            {
                query = query.Where(s => s.DataInicio == FiltroDataInicio.Value);
            }

            switch (Ordenacao)
            {
                case "DataInicioAsc":
                    query = query.OrderBy(s => s.DataInicio);
                    break;
                case "DataTerminoDesc":
                    query = query.OrderByDescending(s => s.DataTermino);
                    break;
                default:
                    query = query.OrderBy(s => s.DataInicio);
                    break;
            }

            SprintList = await query.ToListAsync();

            return Page();
        }
    }
}
