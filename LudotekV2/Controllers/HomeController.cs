using AutoMapper;
using Ludotek.Services;
using Ludotek.Services.Dto;
using Ludotek.Services.Interfaces;
using LudotekV2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LudotekV2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        protected readonly IMapper _mapper;
        protected readonly IConfiguration _configuration;

        /// <summary>
        /// Le business Ludotheque
        /// </summary>
        private readonly ILudothequeService _ludothequeService;

        /// <summary>
        /// Le business Wheel
        /// </summary>
        private readonly IWheelService _wheelService;

        public HomeController(
            ILogger<HomeController> logger, 
            ILudothequeService ludothequeService,
            IWheelService wheelService,
            IMapper mapper,
            IConfiguration configuration)
        {
            _logger = logger;
            _ludothequeService = ludothequeService;
            _wheelService = wheelService;
            _mapper = mapper;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            // Appel au business
            List<ItemDto> items = _ludothequeService.GetByType("Jeu vidéo");

            List<ItemViewModel> itemsModel = _mapper.Map<List<ItemViewModel>>(items);

            return View(itemsModel);
        }

        public IActionResult FilmsSeries()
        {
            // Appel au business
            List<ItemDto> films = _ludothequeService.GetByType("Film");
            List<ItemDto> series = _ludothequeService.GetByType("Série");

            List<ItemDto> items = [.. films, .. series];

            List<ItemViewModel> itemsModel = _mapper.Map<List<ItemViewModel>>(items);

            return View(itemsModel);
        }

        public IActionResult Animes()
        {
            // Appel au business
            List<ItemDto> items = _ludothequeService.GetByType("Anime");

            List<ItemViewModel> itemsModel = _mapper.Map<List<ItemViewModel>>(items);

            return View(itemsModel);
        }

        public async Task<IActionResult> Wheel()
        {
            // Récupération du no mde la roue
            var nomRoue = _configuration["WheelName"];

            // Appel au business
            WheelDto wheel = await _wheelService.GetWheel(nomRoue);

            WheelViewModel wheelModel = _mapper.Map<WheelViewModel>(wheel);

            return View(wheelModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
