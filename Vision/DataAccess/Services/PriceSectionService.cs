using DataService.Dtos;
using DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataService.Services
{
    public interface IPriceSectionService : IServiceBase<PriceSectionDTO, PriceSectionDTO>
    {
        ServiceResponse<List<PriceSectionDTO>> GetAllByAccountStateId(int accountStateId);
        ServiceResponse<PriceSectionDTO> UpdateInfo(int id);
    }

    public class PriceSectionService : IPriceSectionService
    {
        private readonly VisionContext _dbContext;

        public PriceSectionService(VisionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ServiceResponse<PriceSectionDTO> Create(PriceSectionDTO rqDTO)
        {
            ServiceResponse<PriceSectionDTO> rs = new ServiceResponse<PriceSectionDTO>();

            PriceSection PriceSection = rqDTO.MapToModel();

            rs.Data = _dbContext.PriceSection.Add(PriceSection).Entity.MapToDTO();
            _dbContext.SaveChanges();
            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<PriceSectionDTO> Delete(int id)
        {
            ServiceResponse<PriceSectionDTO> rs = new ServiceResponse<PriceSectionDTO>();

            PriceSection PriceSection = _dbContext.PriceSection.Find(id);
            if(PriceSection != null)
            {
                _dbContext.PriceSection.Remove(PriceSection);
                _dbContext.SaveChanges();
            }

            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<PriceSectionDTO> Get(int id)
        {
            ServiceResponse<PriceSectionDTO> rs = new ServiceResponse<PriceSectionDTO>();

            rs.Data = _dbContext.PriceSection.Find(id).MapToDTO();
            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<List<PriceSectionDTO>> GetAll()
        {
            ServiceResponse<List<PriceSectionDTO>> rs = new ServiceResponse<List<PriceSectionDTO>>();

            rs.Data = _dbContext.PriceSection.AsQueryable().Select(x => x.MapToDTO()).ToList();
            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<List<PriceSectionDTO>> GetAllByAccountStateId(int accountStateId)
        {
            ServiceResponse<List<PriceSectionDTO>> rs = new ServiceResponse<List<PriceSectionDTO>>();

            rs.Data = _dbContext.PriceSection.Where(p => p.AccountStateId == accountStateId).AsQueryable().Select(x => x.MapToDTO()).ToList();
            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<PriceSectionDTO> Update(PriceSectionDTO rqDTO)
        {
            ServiceResponse<PriceSectionDTO> rs = new ServiceResponse<PriceSectionDTO>();

            PriceSection PriceSection = _dbContext.PriceSection.Find(rqDTO.Id);
            if(PriceSection == null)
            {
                rs.Data = null;
                rs.IsSuccess = false;
                rs.Message = "Price section id " + rqDTO.Id + " is not existed";
            }

            PriceSection.UpdateFieldFromDTO(rqDTO);
            _dbContext.PriceSection.Update(PriceSection);
            _dbContext.SaveChanges();

            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<PriceSectionDTO> UpdateInfo(int id)
        {
            ServiceResponse<PriceSectionDTO> rs = new ServiceResponse<PriceSectionDTO>();

            PriceSection priceSection = _dbContext.PriceSection.Find(id);
            if(priceSection != null)
            {
                IQueryable<BuyOrder> buyOrder = _dbContext.BuyOrder.Where(b => b.PriceSectionId == priceSection.Id).AsQueryable();

                int totalVolume = 0;
                int totalMatchedVol = 0;
                int totalT2 = 0;
                int totalT1 = 0;
                int totalT0 = 0;
                foreach (var order in buyOrder)
                {
                    totalVolume += order.Volume;
                    totalMatchedVol += order.MatchedVol;
                    totalT2 += order.T2;
                    totalT1 += order.T1;
                    totalT0 += order.T0;
                }

                priceSection.Volume = totalVolume;
                priceSection.MatchedVol = totalMatchedVol;
                priceSection.T2 = totalT2;
                priceSection.T1 = totalT1;
                priceSection.T0 = totalT0;

                _dbContext.PriceSection.Update(priceSection);
                _dbContext.SaveChanges();
            }
            rs.IsSuccess = true;

            return rs;
        }
    }
}
