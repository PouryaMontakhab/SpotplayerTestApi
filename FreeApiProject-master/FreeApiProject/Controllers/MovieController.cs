using FreeApiProject.Data;
using FreeApiProject.Models;
using FreeApiProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IHttpClientService _httpClient;
        private readonly MovieContext _context;

        public MovieController(
            IHttpClientService httpClient,
            MovieContext context)
        {
            _httpClient = httpClient;
            //_httpClient.AddBaseUrl("https://swapi.dev/api/");
            _httpClient.AddBaseUrl("https://panel.spotplayer.ir/license/edit/");
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = await _httpClient.GetAsync<Films>($"films");
            return Ok(query);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = await _httpClient.GetAsync<Film>($"films/{id}");
            return Ok(query);
        }
        [HttpPost]
        public async Task<IActionResult> AddToFavorite(Favorite model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return Ok(_context.Set<Favorite>().FirstOrDefault(a => a.Title == model.Title));
        }
        [HttpGet(nameof(GetMovies))]
        public async Task<IActionResult> GetMovies()
        {
            return Ok(_context.Set<Favorite>().ToList());
        }
        [HttpPost(nameof(CreateLicense))]
        public async Task<IActionResult> CreateLicense()
        {
            var license = new License
            {
                Course = new List<string> { "623869d3c0fc7cae224611f9" },
                Name = "TestLicenseAPI",
                Watermark = new Watermark
                {
                    Texts = new List<InnerText> { new InnerText { Text ="09394017324"} }
                }
            };
            var query = await _httpClient.PostAsync("", license);
            return Ok();
        }
    }
}
