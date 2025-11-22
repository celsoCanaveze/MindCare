using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindCareWeb.Models
{
    [Table("USUARIO")]
    public class Usuario
    {
        [Key]
        [Column("ID_USUARIO")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("NOME")]
        [Required, MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Column("EMAIL")]
        [MaxLength(150)]
        public string? Email { get; set; }

        [Column("DATA_INSCRICAO")]
        public DateTime DataInscricao { get; set; }

        [Column("ULTIMA_ATUALIZACAO")]
        public DateTime? UltimaAtualizacao { get; set; }

        public ICollection<UsuarioTarefa>? UsuarioTarefas { get; set; }
        public ICollection<HistoricoMood>? Historicos { get; set; }
    }
}
