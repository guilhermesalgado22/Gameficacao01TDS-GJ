using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projetos.API.Models;

    public class EquipeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdEquipe { get; set; }

        [Required(ErrorMessage = "O nome da equipe é obrigatório.")]
        public string NomeEquipe { get; set; }

        // Supondo que cada membro da equipe possa ter um nome e um papel associados.
        // Poderíamos também criar uma classe separada MembroModel se houver mais atributos associados a um membro.
        public ICollection<MembroEquipe> Membros { get; set; }

        [ForeignKey("ProjetoModel")]
        public int? IdProjeto { get; set; }
        public virtual ProjetoModel Projeto { get; set; }
    }

    public class MembroEquipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMembro { get; set; }

        [Required(ErrorMessage = "O nome do membro é obrigatório.")]
        public string NomeMembro { get; set; }

        [Required(ErrorMessage = "O papel do membro na equipe é obrigatório.")]
        public string Papel { get; set; }  // Exemplos de papéis: "Desenvolvedor", "Analista", "Scrum Master", etc.

        [ForeignKey("EquipeModel")]
        public int IdEquipe { get; set; }
        public virtual EquipeModel Equipe { get; set; }
    }

