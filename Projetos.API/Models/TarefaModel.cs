using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projetos.API.Models
{
    public enum StatusTarefa
    {
        Pendente,
        EmAndamento,
        Concluida
    }

    public class TarefaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdTarefa { get; set; }

        [Required(ErrorMessage = "O nome da tarefa é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição da tarefa é obrigatória.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O status da tarefa é obrigatório.")]
        public StatusTarefa Status { get; set; }

        [Required(ErrorMessage = "O responsável pela tarefa é obrigatório.")]
        [ForeignKey("EquipeModel")]
        public int IdResponsavel { get; set; }
        public virtual EquipeModel Responsavel { get; set; }

        public DateTime? DataVencimento { get; set; }

        [ForeignKey("ProjetoModel")]
        public int IdProjeto { get; set; }
        public virtual ProjetoModel Projeto { get; set; }
    }
}
