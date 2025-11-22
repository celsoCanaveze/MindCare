using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindCareWeb.Models
{
    [Table("USUARIO_TAREFA")]
    public class UsuarioTarefa
    {
        [Key]
        [Column("ID_USUARIO_TAREFA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("ID_USUARIO")]
        public int UsuarioId { get; set; }
        [ForeignKey(nameof(UsuarioId))]
        public Usuario? Usuario { get; set; }

        [Column("ID_TAREFA")]
        public int TarefaId { get; set; }
        [ForeignKey(nameof(TarefaId))]
        public Tarefa? Tarefa { get; set; }

        [Column("CONQUISTA")]
        [MaxLength(1)]
        public string Conquista { get; set; } = "0";

        [Column("DATA_INICIO")]
        public DateTime DataInicio { get; set; }

        [Column("DATA_FIM")]
        public DateTime? DataFim { get; set; }

        [Column("PROGRESSO_PERCENTUAL")]
        public int ProgressoPercentual { get; set; } = 0;
    }
}
