namespace MindCareWeb.DTOs
{
    public class TarefaCreateDto
    {
        public string NomeTarefa { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public int? CriadorId { get; set; }
    }
}
