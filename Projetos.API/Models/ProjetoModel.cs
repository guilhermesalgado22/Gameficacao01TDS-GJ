using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projetos.API.Models
{
    public enum StatusProjeto
    {
        Pendente,
        EmAndamento,
        Concluido
    }

    public class ProjetoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdProjeto { get; set; }

        [Required(ErrorMessage = "O nome do projeto é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do projeto é obrigatória.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A data de início é obrigatória.")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "A data de conclusão prevista é obrigatória.")]
        public DateTime DataConclusaoPrevista { get; set; }

        [Required(ErrorMessage = "O status do projeto é obrigatório.")]
        public StatusProjeto Status { get; set; }

        [ForeignKey("ClienteModel")]
        public int IdCliente { get; set; }
        public virtual ClienteModel Cliente { get; set; }

        // Supondo que um projeto possa ter várias tarefas associadas
        private ICollection<TarefaModel> _tarefas;
        public ICollection<TarefaModel> Tarefas
        {
            get
            {
                if (_tarefas == null)
                {
                    _tarefas = new List<TarefaModel>();
                }
                return _tarefas;
            }
            set
            {
                _tarefas = value;
            }
        }

        // Supondo que um projeto possa estar associado a uma equipe específica
        [ForeignKey("EquipeModel")]
        public int IdEquipe { get; set; }
        //public virtual EquipeModel Equipe { get; set; }

        public ICollection<EquipeModel> Equipes { get; set; }

    }
}
