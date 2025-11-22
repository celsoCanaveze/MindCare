using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindCareWeb.Models
{
    [Table("TAREFA")]
    public class Tarefa
    {
        [Key]
        [Column("ID_TAREFA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("NOME_TAREFA")]
        [Required, MaxLength(150)]
        public string NomeTarefa { get; set; } = string.Empty;

        [Column("DESCRICAO")]
        [MaxLength(400)]
        public string? Descricao { get; set; }

        [Column("ID_USUARIO_CRIADOR")]
        public int? CriadorId { get; set; }

        [ForeignKey(nameof(CriadorId))]
        public Usuario? Criador { get; set; }
    }
}
