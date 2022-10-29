using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StoreApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var reservationList = new List<Book>();
            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync(_configuration.GetConnectionString("APIsConnectionString"));
                if (!response.IsSuccessStatusCode) return NotFound();
                string apiResponse = await response.Content.ReadAsStringAsync();
                reservationList = JsonConvert.DeserializeObject<List<Book>>(apiResponse);
            }
            return View(reservationList);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> BookDetails(Guid? Id)
        {
            var book = new Book();
            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync(_configuration.GetConnectionString("APIsConnectionString") + "/" + Id);
                if (!response.IsSuccessStatusCode) return NotFound();
                string apiResponse = await response.Content.ReadAsStringAsync();
                book = JsonConvert.DeserializeObject<Book>(apiResponse);
            }
            return View(book);
        }

        [HttpGet]
        public ViewResult AddBook() => View();

        [HttpPost]
        public async Task<IActionResult> AddBook([Bind("Id,Name,Description,Price")] Book book)
        {
            var newBook = book;
            newBook.Id = Guid.NewGuid();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(newBook), Encoding.UTF8, "application/json");
                using var response = await httpClient.PostAsync(_configuration.GetConnectionString("APIsConnectionString"), content);
                if (!response.IsSuccessStatusCode) return NotFound();
                else return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook([Bind("Id,Name,Description,Price")] Book book)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");

                using var response = await httpClient.PutAsync(_configuration.GetConnectionString("APIsConnectionString"), content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode) return NotFound();
                else return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> DeleteBook(Guid? bookId) 
        {
            using (var httpClient = new HttpClient()) 
            { 
                using var response = await httpClient.DeleteAsync(_configuration.GetConnectionString("APIsConnectionString") + "/" + bookId);
                if (!response.IsSuccessStatusCode) return NotFound();
                else return RedirectToAction("Index", "Home");
            }
        }
    }
}
