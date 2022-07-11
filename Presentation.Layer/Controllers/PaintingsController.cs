using AutoMapper;
using Business.Layer.DTO;
using Business.Layer.Interfaces;
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
        private readonly IPaintingService _paintingService;
        private readonly IMapper _mapper;
        private readonly ILogger<PaintingsController> _logger;
        private IWebHostEnvironment webHostEnvironment;
        public PaintingsController(IPaintingService paintingService, IMapper mapper, ILogger<PaintingsController> logger, IWebHostEnvironment _webHostEnvironment)
        {
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
        //[HttpGet("{id}")]
        public async Task<IActionResult> Details(string id)
        {

            var paintDets = await _paintingService.GetByIdAsync(id);

            var details = _mapper.Map<PaintingDTO, PaintingVM>(paintDets);

            return View(details);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {


            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create([Bind] PaintingVM model)
        {
            //string? uniqueFileName = null;

            //if (model.FormFile != null)
            //{
            //    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
            //    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FormFile.FileName;
            //    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            //    using (var fileStream = new FileStream(filePath, FileMode.Create))
            //    {
            //        model.FormFile.CopyTo(fileStream);
            //    }
                
            //}
            

            //model.ImgURL= uniqueFileName;
            

            
            var data = _mapper.Map<PaintingDTO>(model);
            await _paintingService.AddNewPaintingAsync(data);
           
            return View();
        }
        

        //    if (model.FormFile != null)
        //    {
        //        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FormFile.FileName;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            model.FormFile.CopyTo(fileStream);
        //        }
        //    }
        //    return uniqueFileName;
        //}

    }
}
