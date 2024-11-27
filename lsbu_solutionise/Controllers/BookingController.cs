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

                await _emailService.SendEmailAsync("aammir.raja@gmail.com", "Test", "Test");
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
