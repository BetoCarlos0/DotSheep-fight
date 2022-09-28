using DotSheepFight.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq.Expressions;

namespace DotSheepFight.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DotSheepFightContext _context;
        private string _filePath;

        public HomeController(ILogger<HomeController> logger, DotSheepFightContext context, IWebHostEnvironment env)
        {
            _logger = logger;
            _context = context;
            _filePath = env.WebRootPath;
        }

        public IActionResult Index()
        {
            var user = new User();
            //if (HttpContext.Request.Headers["User-Agent"]) ;
            return View(user);
        }

        [HttpGet]
        public User GetUserAgent(string userAgent)
        {
            var user = new User();
            return user;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId, Name, Foto")] User user)
        {
            if (!ValidaImagem(user.Foto))
                return View(user);

            await UploadFoto(user);

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ValidaImagem(IFormFile formFile)
        {
            switch (formFile.ContentType)
            {
                case "image/jpeg": return true;
                case "image/bmp":  return true;
                case "image/gif":  return true;
                case "image/png":  return true;
                default: return false;
            }
        }

        private async Task UploadFoto(User user)
        {
            if (user.Foto != null)
            {
                var extension = Path.GetExtension(user.Foto.FileName);

                user.FotoUrl = Path.Combine("images", $"{user.UserId}-{user.Name}" + extension);
                var fulPath = Path.Combine(_filePath, user.FotoUrl);
                var fileStream = new FileStream(fulPath, FileMode.Create);

                await user.Foto.CopyToAsync(fileStream);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}