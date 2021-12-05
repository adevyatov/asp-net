namespace WebApi.Models.Dto.Request
{
    /// <summary>
    ///     2.2.2 - Класс DTO для передачи аргументов из конструктора в сервис
    /// </summary>
    public class OrderDto
    {
        public string? OrderBy { get; set; }

        public string Direction { get; set; } = "desc";
    }
}
