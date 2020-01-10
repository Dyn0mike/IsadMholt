using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IsadMholt.Models;

namespace IsadMholt.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ISAD251_MHoltContext _context;

        public CustomersController(ISAD251_MHoltContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customer.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.IdCustomer == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCustomer,CookieID")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(customer);
        }
        //Sign in as Admin
        public IActionResult SetAdminCookie()
        {
            Response.Cookies.Append("user", "Admin");
            Response.Cookies.Append("uniqueID", Guid.NewGuid().ToString());
            ViewBag.LoggingOut = false;
            return View("../Home/Admin");
        }

        public async Task<IActionResult> newCustomer(int uID)
        {

            
            Customer customer = new Customer();
            
            List<Customer> ListOfCustomers = Getcustomers();
            int NumOfCustomers = ListOfCustomers.Count();
            customer.CookieID = Guid.NewGuid().ToString();
            customer.IdCustomer = NumOfCustomers + 1;
            Response.Cookies.Append("user", customer.IdCustomer.ToString());
            Response.Cookies.Append("uniqueID", customer.CookieID);
            ViewBag.LoggingOut = false;

            //open a new order for customer.
            OpenOrder(customer.IdCustomer);

            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return View("../Home/Index");
                //return RedirectToAction(nameof(Index));
            }
            return View("../Home/Index");
        }

        private void OpenOrder(int idCustomer)
        {
            Orders NewOrder = new Orders();
            List<Orders> ListOfOrders = GetOrders();
            NewOrder.IdCustomer = idCustomer;
        }

        //Poll DB for users to do auto incrments.
        private List<Customer> Getcustomers()
        {
            return _context.Customer.ToList();
        }

        //Poll DB for orders to do auto incrments.
        private List<Orders> GetOrders()
        {
            return _context.Orders.ToList();
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCustomer,CookieID")] Customer customer)
        {
            if (id != customer.IdCustomer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.IdCustomer))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.IdCustomer == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.IdCustomer == id);
        }
    }
}
