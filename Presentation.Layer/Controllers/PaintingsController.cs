using AutoMapper;
using Business.Layer.DTO;
using Business.Layer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nix.Project.Models;
using Presentation.Layer.Helpers;
using System.IO;
using System.Net.Http.Headers;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Nix.Project.Controllers
{
    public class PaintingsController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPaintingService _paintingService;
        private readonly IMapper _mapper;
        private readonly ILogger<PaintingsController> _logger;
        private IWebHostEnvironment webHostEnvironment;
        public PaintingsController(IPaintingService paintingService, IMapper mapper, ILogger<PaintingsController> logger, IWebHostEnvironment _webHostEnvironment, IUserService userService)
        {
            _userService = userService;
            _paintingService = paintingService;
            _mapper = mapper;
            _logger = logger;
            webHostEnvironment = _webHostEnvironment;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allpaintings = await _paintingService.GetAllAsync();

            return View(_mapper.Map<List<PaintingDTO>, List<PaintingVM>>(allpaintings));
        }
       
        [HttpGet]
        public async Task<IActionResult> DetailsAsync(Guid id)
        {

            var paintDets = await _paintingService.GetByIdAsync(id);

            var dets = _mapper.Map<PaintingDTO, PaintingVM>(paintDets);

            return View(dets);
        }

        [HttpGet]
        public IActionResult Create()
        {


            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(PaintingVM model)
        {
            
                string uniqueFileName = UploadedFile(model);

                PaintingDTO paintingDTO= new PaintingDTO
                {
                    ApplicationUserId = (await _userService.GetUserIdAsync(this.User)),
                    Price = model.Price,
                    Name = model.Name,
                    Autor = model.Autor,
                    Size = model.Size,
                    About = model.About,
                    Medium = model.Medium,
                    ImgURL = uniqueFileName,
                    Style = model.Style,
                    Subject = model.Subject,
                };
                await _paintingService.AddNewPaintingAsync(paintingDTO);

             
            return View();
        }

        private string UploadedFile(PaintingVM model)
        {
            string? uniqueFileName = null;

            if (model.FormFile != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FormFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.FormFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

    }
}
