using DataService.Dtos;
using DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static DataService.Utilities.Constants;

namespace DataService.Services.ModelServices
{
    public interface IPriceSectionService : IServiceBase<PriceSectionDTO, PriceSectionDTO>
    {
        ServiceResponse<PriceSectionDTO> CreateByAccountStateAndPrice(string symbol, int accountStateId, decimal price);
        PriceSection GetByAccountStateAndPrice(int accountStateId, decimal price);
        ServiceResponse<List<PriceSectionDTO>> GetAllByAccountStateId(int accountStateId);
        ServiceResponse<List<PriceSectionDTO>> GetAllBySymbol(string symbol);
        ServiceResponse<PriceSectionDTO> UpdateInfo(int id);
        void UpdateAllInfo();
    }

    public class PriceSectionService : IPriceSectionService
    {
        private readonly VisionContext _dbContext;
        private readonly int _authUserID = CurrentUser.AuthUserID;

        public PriceSectionService(VisionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ServiceResponse<PriceSectionDTO> Create(PriceSectionDTO rqDTO)
        {
            ServiceResponse<PriceSectionDTO> rs = new ServiceResponse<PriceSectionDTO>();

            PriceSection priceSection = rqDTO.MapToModel(_authUserID);

            _dbContext.PriceSection.Add(priceSection);
            _dbContext.SaveChanges();

            rs.Data = priceSection.MapToDTO();
            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<PriceSectionDTO> CreateByAccountStateAndPrice(string symbol, int accountStateId, decimal price)
        {
            ServiceResponse<PriceSectionDTO> rs = new ServiceResponse<PriceSectionDTO>();

            PriceSection priceSection = new PriceSection()
            {
                Symbol = symbol,
                AccountStateId = accountStateId,
                MatchedVol = 0,
                Note = "",
                Price = price,
                T0 = 0,
                T1 = 0,
                T2 = 0,
                UserId = 1,
                Volume = 0,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Status = PriceSectionStatus.Active
            };

            _dbContext.PriceSection.Add(priceSection);
            _dbContext.SaveChanges();

            rs.Data = priceSection.MapToDTO();
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

        public ServiceResponse<List<PriceSectionDTO>> GetAllBySymbol(string symbol)
        {
            ServiceResponse<List<PriceSectionDTO>> rs = new ServiceResponse<List<PriceSectionDTO>>();

            AccountState accountState = _dbContext.AccountState.FirstOrDefault(a => a.Symbol == symbol);
            if(accountState != null)
            {
                rs.Data = _dbContext.PriceSection.Where(p => p.AccountStateId == accountState.Id && p.T0 != 0).AsQueryable().Select(x => x.MapToDTO()).ToList();
                rs.IsSuccess = true;
            }

            return rs;
        }

        public PriceSection GetByAccountStateAndPrice(int accountStateId, decimal price)
        {
            return _dbContext.PriceSection.FirstOrDefault(p => p.AccountStateId == accountStateId && p.Price == price);
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

        public void UpdateAllInfo()
        {
            var priceSections = _dbContext.PriceSection.Where(s => s.Status == PriceSectionStatus.Active).ToList();

            foreach (var section in priceSections)
            {
                UpdateInfo(section.Id);
            }
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
