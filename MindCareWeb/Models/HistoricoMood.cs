using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindCareWeb.Models
{
    [Table("HISTORICO_MOOD")]
    public class HistoricoMood
    {
        [Key]
        [Column("ID_HISTORICO")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("ID_USUARIO")]
        public int UsuarioId { get; set; }
        [ForeignKey(nameof(UsuarioId))]
        public Usuario? Usuario { get; set; }

        [Column("HUMOR")]
        public int? Humor { get; set; }

        [Column("DATA_REGISTRO")]
        public DateTime DataRegistro { get; set; }

        [Column("OBSERVACAO")]
        [MaxLength(400)]
        public string? Observacao { get; set; }
    }
}
