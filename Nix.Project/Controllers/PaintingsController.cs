using AutoMapper;
using Business.Layer.DTO;
using Business.Layer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Nix.Project.Models;

namespace Nix.Project.Controllers
{
    public class PaintingsController : Controller
    {
        private readonly IPaintingService _paintingService;
        private readonly IMapper _mapper;
        private readonly ILogger<PaintingsController> _logger;

        public PaintingsController(IPaintingService paintingService, IMapper mapper, ILogger<PaintingsController> logger)
        {
            _paintingService = paintingService;
            _mapper = mapper;
            _logger = logger;
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

        public async Task<IActionResult> CreateNew(string id)
        {

            var paintDets = await _paintingService.GetByIdAsync(id);

            var details = _mapper.Map<PaintingDTO, PaintingVM>(paintDets);

            return View(details);
        }
    }
}
