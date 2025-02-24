using Library_Management.API.Data;
using Library_Management.API.Mapping;
using Library_Management.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_Management.API.Controllers;

[ApiController]
[Route("api/loans")]
public class LoanController : ControllerBase
{
    private readonly LibDbContext _db;

    public LoanController(LibDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> CreateLoan(NewLoanRequest request)
    {
        Loan loan = request.ToModel();
        await _db.AddAsync(loan);
        await _db.SaveChangesAsync();
        return Ok(loan);    
    }

    [HttpGet]
    public IActionResult GetAllLoans()
    {
        return Ok(_db.Loans.ToList());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLoanById(Guid id)
    {
        Loan? loan =  await _db.Loans.FirstOrDefaultAsync(x => x.Id == id);

        if(loan is null)
            return NotFound();

        return Ok(loan);
    }
}