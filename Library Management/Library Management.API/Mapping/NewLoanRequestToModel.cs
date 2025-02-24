using Library_Management.API.Data;
using Library_Management.API.Models;

namespace Library_Management.API.Mapping
{
    public static class NewLoanRequestToModel
    {
        public static Loan ToModel(this NewLoanRequest request)
        {
            return new Loan(request.BookId, request.UserId, DateTime.Now);
        }
    }
}