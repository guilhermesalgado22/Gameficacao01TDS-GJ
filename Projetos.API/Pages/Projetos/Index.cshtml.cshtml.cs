using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Projetos.API.Models;
using Projetos.API.Data;

namespace Projetos.API.Pages.Projetos
{
    public class Index : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string FiltroNome { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Ordenacao { get; set; }

        private readonly AppDbContext _context;
        public List<ProjetoModel> ProjetoList { get; set; } = new();

        public Index(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var query = _context.Projetos.AsQueryable();

            if (!string.IsNullOrEmpty(FiltroNome))
            {
                query = query.Where(p => p.Nome.Contains(FiltroNome));
            }

            switch (Ordenacao)
            {
                case "NomeAsc":
                    query = query.OrderBy(p => p.Nome);
                    break;
                case "DataInicioDesc":
                    query = query.OrderByDescending(p => p.DataInicio);
                    break;
                default:
                    query = query.OrderBy(p => p.Nome);
                    break;
            }

            ProjetoList = await query.ToListAsync();

            return Page();
        }
    }
}
