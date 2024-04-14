using CreditCalculator.After.Application;
using Microsoft.AspNetCore.Mvc;

namespace CreditCalculator.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditCalculatorController(CustomerService customerService) : ControllerBase
    {

        [HttpPost]
        public bool CreateCustomer(CustomerInput input) => customerService.AddCustomer(input.FirstName, input.LastName, input.Email, input.DateOfBirth, input.CompanyId);

        public record CustomerInput(string FirstName, string LastName, string Email, DateTime DateOfBirth, int CompanyId);

    }
}