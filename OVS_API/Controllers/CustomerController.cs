using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OVS_API.EF;
using OVS_API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OVS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private OVSContext _db;

        public CustomerController(OVSContext db)
        {
            _db = db;
        }

       [Route("ViewAll")]
       [HttpGet]
       public IActionResult ViewAll()
        {
            var customers = _db.Customers.ToList();

            if (customers is null)
                return BadRequest("There exists no customers");

            return Ok(customers);

        }

        [Route("View/{id}")]
        [HttpGet]
        public IActionResult View(int id)
        {
            var customer = _db.Customers.Find(id);

            if (customer is null)
                return BadRequest("This customer does not exist");

            return Ok(customer);
        }

        [Route("Register")]
        [HttpPost]
        public IActionResult Register(CustomerClass model )
        {
            Customer customer = new Customer();
            customer.CustomerName = model.Customer;
            customer.CustomerSurname = model.Customer;
            customer.CustomerCellphoneNumber = model.Customer;
            customer.CustomerDateOfBirth = model.Customer;
            customer.CustomerEmailAddress = model.Customer;
            customer.CustomerPhysicalAddress = model.Customer;

            _db.Customers.Add(customer);
            _db.SaveChanges();

            return Ok(customer);

        }
    }
}
