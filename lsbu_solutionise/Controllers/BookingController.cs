using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection;
using MimeKit;
using MailKit.Net.Smtp;
using lsbu_solutionise.Sevices;
using lsbu_solutionise.Models;

namespace lsbu_solutionise.Controllers
{
    public class BookingController : Controller
    {
        private readonly EmailService _emailService;
        public BookingController(EmailService emailService) 
        {
            _emailService = emailService;
        }
        // GET: BookingController
        public ActionResult Index()
        {

            return View();
        }

        // GET: BookingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AppointmentViewModel collection)
        {
            try
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
                //string body = $"You appointment is confirmed on {collection.BookingDateTime.ToString()}. Your Contact Number is : {collection.PhoneNumber}";
                var msg = string.Format(body, collection.Name, collection.BookingDateTime.ToString("f"));
                await _emailService.SendEmailAsync(collection.Email, "Appointment Confirmed", msg);
                return RedirectToAction("Index", "Home");
            }

            catch (Exception)
            {
                return View();

            }
        }
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: BookingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            //
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
