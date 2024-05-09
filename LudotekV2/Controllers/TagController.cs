using Ludotek.Services;
using Ludotek.Services.Dto;
using Ludotek2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ludotek2.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TagController : GlobalController
    {
        /// <summary>
        /// Le business Tag
        /// </summary>
        private readonly ITagService tagService;

        /// <summary>
        /// Constructeur avec injection de dépendance
        /// </summary>
        /// <param name="business">la classe business injectée</param>
        public TagController(ITagService tagService)
        {
            this.tagService = tagService;
        }

        /// <summary>
        /// Retourne l'ensemble des tags existants
        /// </summary>
        /// <returns>L'ensemble des tags existants</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Appel au business
            List<TagDto> tags = tagService.Get();
            // Conversion en model
            List<TagViewModel> tagsModel = _mapper.Map<List<TagViewModel>>(tags);

            return Result(tagsModel.Cast<GlobalModel>().ToList());
        }

        /// <summary>
        /// Retourne l'ensemble des items d'un tag donné
        /// </summary>
        /// <param name="nomTag">Le tag à chercher</param>
        /// <returns>L'ensemble des items du tag</returns>
        [HttpGet]
        [Route("{nomTag}/items")]
        public IActionResult Get(string nomTag)
        {
            // Appel au business
            List<ItemDto> items = tagService.Get(nomTag);
            // Conversion en model
            List<ItemViewModel> itemsModel = _mapper.Map<List<ItemViewModel>>(items);

            return Result(itemsModel.Cast<GlobalModel>().ToList());
        }

        /// <summary>
        /// Retourne les items à partir d'un nom et d'un tag donnés
        /// </summary>
        /// <param name="nomTag">Le tag à chercher</param>
        /// <param name="nomItem">Le nom d'item</param>
        /// <returns>Les items du tag et du nom donnés</returns>
        [HttpGet]
        [Route("{nomTag}/items/{nomItem}")]
        public IActionResult Get(string nomTag, string nomItem)
        {
            // Appel au business
            List<ItemDto> items = tagService.Get(nomTag, nomItem);
            // Conversion en model
            List<ItemViewModel> itemsModel = _mapper.Map<List<ItemViewModel>>(items);

            return Result(itemsModel.Cast<GlobalModel>().ToList());
        }
    }
}