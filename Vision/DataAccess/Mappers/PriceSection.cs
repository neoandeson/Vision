﻿using DataService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models
{
    public partial class PriceSection
    {
        public PriceSectionDTO MapToDTO()
        {
            PriceSectionDTO dto = new PriceSectionDTO()
            {
                Id = this.Id,
                Symbol = this.Symbol,
                AccountStateId = this.AccountStateId,
                Price = this.Price,
                Volume = this.Volume,
                MatchedVol = this.MatchedVol,
                T2 = this.T2,
                T1 = this.T1,
                T0 = this.T0,
                Note = this.Note
            };

            return dto;
        }

        public void UpdateFieldFromDTO(PriceSectionDTO dto)
        {
            this.Id = dto.Id;
            this.Symbol = dto.Symbol;
            this.AccountStateId = dto.AccountStateId;
            this.Price = dto.Price;
            this.Volume = dto.Volume;
            this.MatchedVol = dto.MatchedVol;
            this.T2 = dto.T2;
            this.T1 = dto.T1;
            this.T0 = dto.T0;
            this.Note = dto.Note;
        }
    }
}
