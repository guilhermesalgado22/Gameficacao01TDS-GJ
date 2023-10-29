using System.Linq;
using Projetos.API.Data;
using Projetos.API.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Projetos.API.Pages
{
    public class Index : PageModel
    {
        private readonly AppDbContext _context;

        public Index(AppDbContext context)
        {
            _context = context;
        }

        public int TotalProjetos { get; set; }
        public int TotalEquipes { get; set; }
        public int TotalMembros { get; set; }
        // Você pode adicionar propriedades para sprints, tarefas, etc.

        public void OnGet()
        {
            TotalProjetos = _context.Projetos.Count();
            TotalEquipes = _context.Equipes.Count();
            TotalMembros = _context.Membros.Count();
            // Você pode continuar contando outras entidades como sprints, tarefas, etc.
        }
    }
}
