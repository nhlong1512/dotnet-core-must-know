namespace PatchAPI.Dtos.Response
{
    public class BookResponse
    {
        public Guid BookId { get; set; }
        public string Title { get; set; } = null!;
        public int TotalPages { get; set; }
        public decimal Rating { get; set; }
    }
}
