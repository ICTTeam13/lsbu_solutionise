using lsbu_solutionise.Data;
using lsbu_solutionise.Models;
using lsbu_solutionise.Sevices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lsbu_solutionise.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly EmailService _emailService;

        public AdminController(ApplicationDbContext context, EmailService emailService)
        {
            _emailService = emailService;
            _context = context;
        }

        // GET: AdminController
        public async Task<ActionResult> Index()
        {
            var customer = await _context.Customer.ToListAsync();
            var customerData = customer.Select(e => new AdminViewModel { CustomerID = e.Id, AppointmentDate = e.BookingDateTime, BusinessName = e.BusinessName, CustomerName = $"{e.FirstName} {e.LastName}", Status = (e.Status ?? "Pending"),CustomerEmail = e.Email }).OrderByDescending(e => e.CreationDatimetime).ToList();
            return View(customerData);
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
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

            CustomerViewModel customerVM = new CustomerViewModel();
            customerVM.FirstName = customer.FirstName;
            customerVM.LastName = customer.LastName;
            customerVM.ContactNumber = customer.ContactNumber;
            customerVM.BusinessAddress = customer.BusinessAddress ?? "";
            customerVM.BusinessName = customer.BusinessName;
            customerVM.BookingDateTime = customer.BookingDateTime;
            customerVM.BusinessContact = customer.BusinessContact ?? "";
            return View(customerVM);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, CustomerViewModel customerVM)
        {
            #region body
            string body = @"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{
            font-family: Arial, sans-serif;
            background-color: #f9f9f9;
            margin: 0;
            padding: 20px;
        }}
        .email-container {{
            background-color: #ffffff;
            border: 1px solid #dddddd;
            border-radius: 5px;
            padding: 20px;
            max-width: 600px;
            margin: 0 auto;
        }}
        .header {{
            font-size: 24px;
            font-weight: bold;
            color: #333333;
            margin-bottom: 20px;
        }}
        .content {{
            font-size: 16px;
            color: #555555;
            line-height: 1.6;
        }}
        .footer {{
            font-size: 12px;
            color: #aaaaaa;
            margin-top: 20px;
        }}
    </style>
</head>
<body>
    <div class='email-container'>
        <div class='header'>Welcome, {0}!</div>
        <div class='content'>
            <p>Dear,</p>
            <p>We are pleased to confirm your booking.</p>
            <p><strong>Booking Date and Time:</strong> {1}</p>
            <p>If you have any questions, feel free to reply to this email or visit our <a href='https://localhost:7038'>website</a>.</p>
        </div>
        <div class='footer'>
            &copy; 2024 LSBU Solutionise. All rights reserved.
        </div>
    </div>
</body>
</html>";

            #endregion
            if (id != customerVM.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    var customer = await _context.Customer.FindAsync(id);
                    if (customer == null)
                    {
                        return NotFound();
                    }

                    
                    customer.FirstName = customerVM.FirstName;
                    customer.LastName = customerVM.LastName;                    
                    customer.ContactNumber = customerVM.ContactNumber;                    
                    customer.BusinessName = customerVM.BusinessName;
                    customer.BookingDateTime = customerVM.BookingDateTime;
                    customer.BusinessAddress = customerVM.BusinessAddress;
                    customer.BusinessContact = customerVM.BusinessContact;
                    customer.Status = "Approved";

                    _context.Update(customer);
                    await _context.SaveChangesAsync();

                    var msg = string.Format(body, $"{customer.FirstName} {customer.LastName}", customer.BookingDateTime.ToString("f"));
                    await _emailService.SendEmailAsync(customer.Email, "Appointment Updated", msg);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customerVM.Id))
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
            return View(customerVM);
        }

        // GET: AdminController/Reminder/5
        public async Task<ActionResult> Reminder(Guid id)
        {

            #region body
            string body = @"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{
            font-family: Arial, sans-serif;
            background-color: #f9f9f9;
            margin: 0;
            padding: 20px;
        }}
        .email-container {{
            background-color: #ffffff;
            border: 1px solid #dddddd;
            border-radius: 5px;
            padding: 20px;
            max-width: 600px;
            margin: 0 auto;
        }}
        .header {{
            font-size: 24px;
            font-weight: bold;
            color: #333333;
            margin-bottom: 20px;
        }}
        .content {{
            font-size: 16px;
            color: #555555;
            line-height: 1.6;
        }}
        .footer {{
            font-size: 12px;
            color: #aaaaaa;
            margin-top: 20px;
        }}
    </style>
</head>
<body>
    <div class='email-container'>
        <div class='header'>Hello, {0}!</div>
        <div class='content'>
            <p>Dear,</p>
            <p>We are reminding you about your booking.</p>
            <p><strong>Booking Date and Time:</strong> {1}</p>
            <p>If you have any questions, feel free to reply to this email or visit our <a href='https://localhost:7038'>website</a>.</p>
        </div>
        <div class='footer'>
            &copy; 2024 LSBU Solutionise. All rights reserved.
        </div>
    </div>
</body>
</html>";

            #endregion
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            var msg = string.Format(body, $"{customer.FirstName} {customer.LastName}", customer.BookingDateTime.ToString("f"));
            await _emailService.SendEmailAsync(customer.Email, "Reminder", msg);

            return RedirectToAction(nameof(Index));
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private bool CustomerExists(Guid id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
