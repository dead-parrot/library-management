namespace Library_Management.API.Models
{
    public class NewLoanRequest
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }  
    }
}