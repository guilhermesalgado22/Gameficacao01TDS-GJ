using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Projetos.API.Models
{
    public class SprintModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdSprint { get; set; }

        [Required(ErrorMessage = "A data de início da sprint é obrigatória.")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "A data de término da sprint é obrigatória.")]
        public DateTime DataTermino { get; set; }

        // Lista de tarefas a serem concluídas durante a sprint
        public virtual ICollection<TarefaModel> Tarefas { get; set; }

        [ForeignKey("ProjetoModel")]
        public int IdProjeto { get; set; }
        public virtual ProjetoModel Projeto { get; set; }
    }
}
