namespace PatchAPI.Dtos.RequestDtos
{
    public class BookRequest
    {
        public string Title { get; set; } = null!;
        public int TotalPages { get; set; }
        public decimal Rating { get; set; }
    }
}
