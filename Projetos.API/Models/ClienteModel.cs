using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projetos.API.Models
{
    public class ClienteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdCliente { get; set; }

        [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
        public string NomeCliente { get; set; }

        [Required(ErrorMessage = "O e-mail do cliente é obrigatório.")]
        [EmailAddress(ErrorMessage = "Insira um e-mail válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A informação de contato é obrigatória.")]
        public string InformacaoContato { get; set; }

        // Supondo que um cliente possa ter vários projetos associados
        private ICollection<ProjetoModel> _projetos;
        public ICollection<ProjetoModel> Projetos
        {
            get
            {
                if (_projetos == null)
                {
                    _projetos = new List<ProjetoModel>();
                }
                return _projetos;
            }
            set
            {
                _projetos = value;
            }
        }
    }
}