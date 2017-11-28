using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project208.Services.Abstract;
using Project208.Services.DTOs.CustomerDTOs;
using Project208.WebUI.Models;
using System.Threading.Tasks;

namespace Project208.WebUI.Controllers.APIs
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private ICustomerService customerService;
        private IMapper mapper;

        public CustomersController(ICustomerService cusServiceParam, IMapper mapperParam)
        {
            customerService = cusServiceParam;
            mapper = mapperParam;
        }

        // PUT: api/customers/
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCustomer(CustomerDetailViewModel customerVM)
        {
            if (ModelState.IsValid)
            {
                var customer = await customerService.UpdateCustomerAsync(mapper.Map<CustomerDetailViewModel, CustomerDTO>(customerVM));

                if (customer != null)
                    return Ok(customer);
                else
                    return NotFound("Không tồn tại khách hàng này trong hệ thống.");
            }
            else
            {
                return BadRequest("Không thể cập nhật thông tin khách hàng.");
            }   
        }

        // DELETE: api/customers/1
        [HttpDelete("{customerId}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            var customer = await customerService.DeleteCustomerAsync(customerId);
        
            if (customer != null)
                return Ok(customer);

            return NotFound("Không tồn tại khách hàng này trong hệ thống.");
        }

        // POST: api/customers/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCustomer(CreateCustomerViewModel customerVM)
        {
            if (ModelState.IsValid)
            {
                var customer = await customerService.CreateCustomerAsync(mapper.Map<CreateCustomerViewModel, CustomerDTO>(customerVM));
                return Ok(customer);
            }
            else
            {
                return BadRequest("Không thể thêm khách hàng mới.");
            }
        }

        // GET: api/customers/?locationId=1&searchString=
        [HttpGet]
        public async Task<IActionResult> GetCustomersByFilterdata(int locationId, string searchString)
        {
            var customers = await customerService.GetCustomersByFilterDataAsync(locationId, searchString);

            if (customers != null)
                return Ok(customers);

            return NotFound("Không tìm thấy danh sách khách hàng.");
        }

        // GET: api/customers/info
        [HttpGet("info")]
        public async Task<IActionResult> GetCustomersInfo() => Ok(await customerService.GetCustomersInfoAsync());
    }
}
