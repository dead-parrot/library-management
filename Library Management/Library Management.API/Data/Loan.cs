namespace Library_Management.API.Data
{
    public class Loan
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public DateTime InitialLoanDate { get; set; }
        public DateTime FinalLoanDate { get; private set; }

        public Loan(Guid bookId, Guid userId, DateTime initialLoanDate)
        {
            Id = Guid.NewGuid();
            BookId = bookId;
            UserId = userId;
            //Colocar uma validação de permissão de somente em dias úteis
            InitialLoanDate = initialLoanDate;
            //Talvez criar uma classe para representar data de empréstimo
            //para aumentar a coesão dessa operação:
            FinalLoanDate = initialLoanDate.AddDays(14);
            if(FinalLoanDate.DayOfWeek == DayOfWeek.Sunday) 
            {
                FinalLoanDate = FinalLoanDate.AddDays(1);
            }
            else if(FinalLoanDate.DayOfWeek == DayOfWeek.Saturday)
            {
                FinalLoanDate = FinalLoanDate.AddDays(2);
            }
        }
    }
}