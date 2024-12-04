using Microsoft.AspNetCore.Mvc;
using Grpc.Net.Client;
using GrpcCustomersService;

namespace Muresan_Razvan_Lab2.Controllers
{
    public class CustomersGrpcController : Controller
    {
        private readonly GrpcChannel channel;
        public CustomersGrpcController()
        {
            channel = GrpcChannel.ForAddress("https://localhost:7218");
        }

        [HttpGet]
        public IActionResult Index()
        {
            var client = new CustomerService.CustomerServiceClient(channel);
            CustomerList cust = client.GetAll(new Empty());
            return View(cust);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GrpcCustomersService.Customer customer)
        {
            if (ModelState.IsValid)
            {
                var client = new
                CustomerService.CustomerServiceClient(channel);
                var createdCustomer = client.Insert(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        public IActionResult Edit(int id)
        {
            var client = new CustomerService.CustomerServiceClient(channel);
            var customer = client.Get(new CustomerId { Id = id });

            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(GrpcCustomersService.Customer customer)
        {
            if (ModelState.IsValid)
            {
                var client = new CustomerService.CustomerServiceClient(channel);
                var updatedCustomer = client.Update(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        public IActionResult Delete(int id)
        {
            var client = new CustomerService.CustomerServiceClient(channel);
            var customer = client.Get(new CustomerId { Id = id });
            return View(customer);
        }
        [HttpPost]
        public IActionResult Delete(GrpcCustomersService.Customer customer)
        {
            var client = new CustomerService.CustomerServiceClient(channel);
            var deletedCustomer = client.Delete(new CustomerId { Id = customer.CustomerId });
            return RedirectToAction(nameof(Index));
        }
    }
}
