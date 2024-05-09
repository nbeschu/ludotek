using AutoMapper;
using Ludotek.Services;
using Ludotek.Services.Dto;
using Ludotek.Services.Services;
using Ludotek2.Models;
using LudotekV2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LudotekV2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        protected readonly IMapper _mapper;

        /// <summary>
        /// Le business Ludotheque
        /// </summary>
        private readonly ILudothequeService _ludothequeService;

        public HomeController(
            ILogger<HomeController> logger, 
            ILudothequeService ludothequeService,
            IMapper mapper)
        {
            _logger = logger;
            _ludothequeService = ludothequeService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            // Appel au business
            List<ItemDto> items = _ludothequeService.Get();

            List<ItemViewModel> itemsModel = _mapper.Map<List<ItemViewModel>>(items);

            return View(itemsModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
