﻿using Ludotek.Repositories.Context;
using Ludotek.Repositories.Interfaces;
using Ludotek.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace Ludotek.Repositories.Respositories
{
    public class LudothequeRepository : ILudothequeRepository
    {
        /// <summary>
        /// Le repository
        /// </summary>
        public readonly LudotekContext context;

        /// <summary>
        /// Constructeur avec injection de dépendance
        /// </summary>
        public LudothequeRepository(LudotekContext dbContext)
        {
            context = dbContext;
        }

        /// <summary>
        /// Vérifie s'il existe des items dans la ludothèque
        /// </summary>
        /// <returns>True s'il existe des items dans la ludothèque, false sinon</returns>
        public bool HasItems()
        {
            return context.Items.Count() > 0;
        }

        /// <summary>
        /// Retourne l'intégralité de la ludothèque
        /// </summary>
        /// <returns>L'intégralité de la ludothèque</returns>
        public List<Item> Get()
        {
            var result = context.Items
                .Include(e => e.Tags)
                .OrderBy(x => x.Nom)
                .ToList();

            return result;
        }

        /// <summary>
        /// Retourne les items de la ludothèque du type donné
        /// </summary>
        /// <returns>Les items de la ludothèque du type donnée</returns>
        public List<Item> GetByType(string type)
        {
            var result = context.Items
                .Include(e => e.Tags)
                .OrderBy(x => x.Nom)
                .Where(x => x.Type == type)
                .ToList();

            return result;
        }

        /// <summary>
        /// Retourne un item de la ludothèque
        /// </summary>
        /// <param name="id">l'item recherché</param>
        /// <returns>L'item trouvé</returns>
        public Item Get(int id)
        {
            var result = new Item();

            result = context.Items
                .Where(x => x.Id == id)
                .Include(e => e.Tags)
                .FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Retourne les items de la ludothèque correspondant à la recherche
        /// </summary>
        /// <param name="nomItem">l'item recherché</param>
        /// <returns>Les items trouvés</returns>
        public List<Item> Get(string nomItem)
        {
            var result = new List<Item>();

            result = context.Items
                .Where(x => x.Nom.Contains(nomItem))
                .Include(e => e.Tags)
                .OrderBy(x => x.Nom)
                .ToList();

            return result;
        }

        /// <summary>
        /// Retourne un item de la ludothèque en vu d'une création
        /// </summary>
        /// <param name="nomItem">l'item recherché</param>
        /// <returns>L'item trouvé</returns>
        public Item GetForCreate(string nomItem)
        {
            var result = new Item();

            result = context.Items
                .Where(x => x.Nom == nomItem)
                .Include(e => e.Tags)
                .FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Ajoute une item avec ses tags
        /// </summary>
        /// <param name="item">L'item avec ses tags</param>
        public void Insert(Item item)
        {
            context.Items.Add(item);
            context.SaveChanges();
        }

        /// <summary>
        /// Ajoute une liste d'item à la ludothèque
        /// </summary>
        /// <param name="items">Les items avec ses tags</param>
        public void Insert(List<Item> items)
        {
            context.Items.AddRange(items);
            context.SaveChanges();
        }

        /// <summary>
        /// Met à jour un item avec ses tags
        /// </summary>
        /// <param name="item">l'item avec ses tags</param>
        public void Update(Item item)
        {
            context.Update(item);
            context.SaveChanges();
        }

        /// <summary>
        /// Upsert une liste d'item à la ludothèque
        /// </summary>
        /// <param name="items">Les items avec ses tags</param>
        public void Upsert(List<Item> items)
        {
            List<string> noms = items.Select(x => x.Nom).ToList();
            var existingEntities = context.Items.Where(e => noms.Contains(e.Nom)).AsNoTracking().ToList();

            foreach (var entity in existingEntities)
            {
                Item? item = items.FirstOrDefault(x => x.Nom == entity.Nom && x.Plateforme == entity.Plateforme);
                if (item != null)
                {
                    entity.Copy(item);
                    items.Remove(item);
                }
            }

            if (items.Count > 0)
            {
                context.Items.AddRange(items);
            }

            if (existingEntities.Count > 0)
            {
                context.Items.UpdateRange(existingEntities);
            }

            context.SaveChanges();
        }
    }
}
