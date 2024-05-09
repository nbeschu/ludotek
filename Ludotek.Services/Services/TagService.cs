using AutoMapper;
using Ludotek.Repositories.Interfaces;
using Ludotek.Repositories.Models;
using Ludotek.Services.Dto;
using Microsoft.Extensions.Localization;

namespace Ludotek.Services.Services
{
    public class TagService : BaseService<TagService>, ITagService
    {
        /// <summary>
        /// Le Repository Tag
        /// </summary>
        private readonly ITagRepository tagRepository;

        /// <summary>
        /// Constructeur avec injection de dépendance
        /// </summary>
        public TagService(
            IStringLocalizer<TagService> localizer,
            IMapper mapper,
            ITagRepository tagRepository) : base(localizer, mapper)
        {
            this.tagRepository = tagRepository;
        }

        /// <summary>
        /// Retourne l'intégralité des tags existants
        /// </summary>
        /// <returns>L'intégralité des tags existants</returns>
        public List<TagDto> Get()
        {
            // Appel au Repository
            List<Tag> tagsModel = tagRepository.Get();

            if (tagsModel == null)
            {
                new List<TagDto>();
            }

            var tags = _mapper.Map<List<TagDto>>(tagsModel);

            return tags;
        }

        /// <summary>
        /// Retourne les items de la ludothèque correspondant à la recherche
        /// </summary>
        /// <param name="nomTag">Le tag recherché</param>
        /// <returns>Les items trouvés</returns>
        public List<ItemDto> Get(string nomTag)
        {
            Tag tag = tagRepository.Get(nomTag);

            if (tag == null)
            {
                return new List<ItemDto>();
            }

            List<ItemDto> result = _mapper.Map<List<ItemDto>>(tag.Items);

            return result;
        }

        /// <summary>
        /// Retourne les items de la ludothèque correspondant à la recherche
        /// </summary>
        /// <param name="nomTag">Le tag recherché</param>
        /// <param name="nomItem">Le nom d'item recherché</param>
        /// <returns>Les items trouvés</returns>
        public List<ItemDto> Get(string nomTag, string nomItem)
        {
            Tag tag = tagRepository.Get(nomTag);

            if (tag == null)
            {
                return new List<ItemDto>();
            }

            var itemsFound = tag.Items.Where(x => x.Nom == nomItem);
            List<ItemDto> result = _mapper.Map<List<ItemDto>>(itemsFound);

            return result;
        }
    }
}
