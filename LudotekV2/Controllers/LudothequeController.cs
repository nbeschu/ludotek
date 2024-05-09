using Ludotek.Services;
using Ludotek.Services.Dto;
using Ludotek2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ludotek2.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LudothequeController : GlobalController
    {
        /// <summary>
        /// Le business Ludotheque
        /// </summary>
        private readonly ILudothequeService ludothequeService;

        /// <summary>
        /// Constructeur avec injection de dépendance
        /// </summary>
        /// <param name="business">la classe business injectée</param>
        public LudothequeController(ILudothequeService ludothequeService)
        {
            this.ludothequeService = ludothequeService;
        }

        /// <summary>
        /// Retourne l'intégralité de la ludothèque
        /// </summary>
        /// <returns>L'intégralité de la ludothèque</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Appel au business
            List<ItemDto> items = ludothequeService.Get();

            List<ItemViewModel> itemsModel = _mapper.Map<List<ItemViewModel>>(items);

            return Result(itemsModel.Cast<GlobalModel>().ToList());
        }

        /// <summary>
        /// Retourne un item de la ludothèque
        /// </summary>
        /// <param name="nomItem">l'item recherché</param>
        /// <returns>L'item trouvé</returns>
        [HttpGet("{nomItem}")]
        public IActionResult Get(string nomItem)
        {
            // Appel au business
            List<ItemDto> items = ludothequeService.Get(nomItem);

            // Conversion en model
            List<ItemViewModel> itemsModel = _mapper.Map<List<ItemViewModel>>(items);

            return Result(itemsModel.Cast<GlobalModel>().ToList());
        }

        [HttpPost]
        public void Post([FromBody]string filename)
        {
            //TODO
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]ItemViewModel item)
        {
            ItemDto itemDto = _mapper.Map<ItemDto>(item);

            // Appel au business
            ludothequeService.UpdateItem(id, itemDto);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //TODO
        }
    }
}
