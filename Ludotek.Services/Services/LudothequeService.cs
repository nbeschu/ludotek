using AutoMapper;
using Ludotek.Repositories.Interfaces;
using Ludotek.Repositories.Models;
using Ludotek.Services.Dto;
using Microsoft.Extensions.Localization;

namespace Ludotek.Services.Services
{
    public class LudothequeService : BaseService<LudothequeService>, ILudothequeService
    {
        /// <summary>
        /// Le Repository Ludotheque
        /// </summary>
        private readonly ILudothequeRepository ludothequeRepository;

        /// <summary>
        /// Le Repository Tag
        /// </summary>
        private readonly ITagRepository tagRepository;

        /// <summary>
        /// Constructeur avec injection de dépendance
        /// </summary>
        public LudothequeService(
            IStringLocalizer<LudothequeService> localizer,
            IMapper mapper,
            ILudothequeRepository ludothequeRepository,
            ITagRepository tagRepository) : base(localizer, mapper)
        {
            this.ludothequeRepository = ludothequeRepository;
            this.tagRepository = tagRepository;
        }

        #region Méthodes publiques

        /// <summary>
        /// Retourne l'intégralité de la ludothèque
        /// </summary>
        /// <returns>L'intégralité de la ludothèque</returns>
        public List<ItemDto> Get()
        {
            // Appel au Repository
            List<Item> ludothequeModel = ludothequeRepository.Get();

            if (ludothequeModel == null)
            {
                // Pas d'item trouvé -> On renvoi une liste vide
                return new List<ItemDto>();
            }

            var ludotheque = _mapper.Map<List<ItemDto>>(ludothequeModel);

            return ludotheque;
        }

        /// <summary>
        /// Retourne les items de la ludothèque du type donné
        /// </summary>
        /// <returns>Les items de la ludothèque du type donnée</returns>
        public List<ItemDto> GetByType(string type)
        {
            // Appel au Repository
            List<Item> ludothequeModel = ludothequeRepository.GetByType(type);

            if (ludothequeModel == null)
            {
                // Pas d'item trouvé -> On renvoi une liste vide
                return new List<ItemDto>();
            }

            var ludotheque = _mapper.Map<List<ItemDto>>(ludothequeModel);

            return ludotheque;
        }

        /// <summary>
        /// Retourne une liste d'item correspondant au nom cherché
        /// </summary>
        /// <param name="nomItem">Le nom recherché</param>
        /// <returns>La liste des items trouvés</returns>
        public List<ItemDto> Get(string nomItem)
        {
            // Apell au Repository
            var ludothequeModel = ludothequeRepository.Get(nomItem);

            if (ludothequeModel == null)
            {
                // Pas d'item trouvé -> On renvoi une liste vide
                return new List<ItemDto>();
            }

            var ludotheque = _mapper.Map<List<ItemDto>>(ludothequeModel);

            return ludotheque;
        }

        /// <summary>
        /// Met à jour un item existant
        /// </summary>
        /// <param name="id">L'item existant</param>
        /// <param name="fromApi">L'item contenant les nouvelles données</param>
        /// <returns>L'item mis à jour</returns>
        public ItemDto UpdateItem(int id, ItemDto fromApi)
        {
            // Apell au Repository
            Item fromBdd = ludothequeRepository.Get(id);

            if (fromBdd != null)
            {
                // On met à jour l'existant avec les données en entrée de l'API
                Update(fromBdd, fromApi);

                var item = _mapper.Map<ItemDto>(fromBdd);

                return item;
            }
            else
            {
                return new ItemDto
                {
                    Erreur = CreateErreur("LudoErr01", id.ToString())
                };
            }
        }

        #endregion

        #region Méthodes privées

        /// <summary>
        /// Met à jour un item existant
        /// </summary>
        /// <param name="fromBdd">L'item existant</param>
        /// <param name="fromApi">L'item contenant les nouvelles données</param>
        private void Update(Item fromBdd, ItemDto fromApi)
        {
            fromBdd.Nom = fromApi.Nom;
            fromBdd.Tags = _mapper.Map<List<Tag>>(fromApi.Tags);

            //// On recopie l'item d'origine dans l'objet relation
            //foreach (var ludoTag in fromBdd.ItemTag)
            //{
            //    ludoTag.Item = fromBdd;
            //}

            // Maj en BDD
            ludothequeRepository.Update(fromBdd);
        }

        //private void UpdateTags(LudothequeDto item, List<string> inputTags)
        //{
        //    var itemTags = new List<LudoTagDto>();

        //    foreach (var tag in inputTags)
        //    {
        //        itemTags.Add(new LudoTagDto
        //        {
        //            Ludotheque = item,
        //            //Tag = CheckTag(tag) TODO : vérifier l'existence du tag
        //        });
        //    }

        //    // On ajoute les nouveaux tags à l'item
        //    item.LudoTag = itemTags;

        //    // Maj en BDD
        //    ludothequeRepository.Update(item);
        //}

        #endregion
    }
}
