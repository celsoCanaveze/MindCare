namespace MindCareWeb.DTOs
{
    public class UsuarioTarefaCreateDto
    {
        public int UsuarioId { get; set; }
        public int TarefaId { get; set; }
        public string? Conquista { get; set; } = "0";
        public int ProgressoPercentual { get; set; } = 0;
    }
}
