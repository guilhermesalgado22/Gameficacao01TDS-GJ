using Projetos.API.Models;
using Projetos.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Projetos.API.Pages.Projetos
{
    public class Criar : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public ProjetoModel Projeto { get; set; } = new();

        public Criar(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyProjeto = new ProjetoModel();

            if (await TryUpdateModelAsync<ProjetoModel>(emptyProjeto,
            "Projeto",
            p => p.Nome, p => p.Descricao, p => p.DataInicio, p => p.DataConclusaoPrevista))
            {
                _context.Projetos.Add(emptyProjeto);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Projetos/Index");
            }

            return Page();
        }
    }
}
