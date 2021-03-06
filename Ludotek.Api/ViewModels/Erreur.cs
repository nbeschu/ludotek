﻿using Ludotek.Api.Dto;

namespace Ludotek.Api.ViewModels
{
    public class Erreur
    {
        /// <summary>
        /// Code erreur
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Libellé erreur
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Converteur Dto -> Model
        /// </summary>
        /// <param name="dto">Le Dto à convertir</param>
        /// <returns>Le Model converti</returns>
        public static Erreur ToModel(ErreurDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new Erreur
            {
                Code = dto.Code,
                Libelle = dto.Libelle
            };
        }
    }
}