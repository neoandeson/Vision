using DataService.Dtos;
using DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataService.Services
{
    public interface IBuyOrderService : IServiceBase<BuyOrderDTO, BuyOrderDTO>
    {
        ServiceResponse<List<BuyOrderDTO>> GetAllByPriceSectionId(int priceSectionId);
    }

    public class BuyOrderService : IBuyOrderService
    {
        private readonly VisionContext _dbContext;
        private readonly IPriceSectionService _priceSectionService;

        public BuyOrderService(VisionContext dbContext, PriceSectionService priceSectionService)
        {
            _dbContext = dbContext;
            _priceSectionService = priceSectionService;
        }

        public ServiceResponse<BuyOrderDTO> Create(BuyOrderDTO rqDTO)
        {
            ServiceResponse<BuyOrderDTO> rs = new ServiceResponse<BuyOrderDTO>();

            AccountState accountState = _dbContext.AccountState.FirstOrDefault(a => a.Symbol == rqDTO.Symbol);
            if(accountState != null)
            {
                PriceSection priceSection = _dbContext.PriceSection.FirstOrDefault(p => p.AccountStateId == accountState.Id && p.Price == rqDTO.Price);
                if(priceSection == null)
                {
                    priceSection = new PriceSection()
                    {
                        AccountStateId = accountState.Id,
                        MatchedVol = 0,
                        Note = "",
                        Price = rqDTO.Price,
                        T0 = 0,
                        T1 = 0,
                        T2 = 0,
                        UserId = 1,
                        Volume = 0
                    };
                    _dbContext.PriceSection.Add(priceSection);
                    _dbContext.SaveChanges();
                }

                BuyOrder buyOrder = rqDTO.MapToModel();
                buyOrder.PriceSectionId = priceSection.Id;
                rs.Data = _dbContext.BuyOrder.Add(buyOrder).Entity.MapToDTO();
                _dbContext.SaveChanges();

                _priceSectionService.UpdateInfo(priceSection.Id);
            }

            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<BuyOrderDTO> Delete(int id)
        {
            ServiceResponse<BuyOrderDTO> rs = new ServiceResponse<BuyOrderDTO>();

            BuyOrder BuyOrder = _dbContext.BuyOrder.Find(id);
            if (BuyOrder != null)
            {
                _dbContext.BuyOrder.Remove(BuyOrder);
                _dbContext.SaveChanges();
            }

            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<BuyOrderDTO> Get(int id)
        {
            ServiceResponse<BuyOrderDTO> rs = new ServiceResponse<BuyOrderDTO>();

            rs.Data = _dbContext.BuyOrder.Find(id).MapToDTO();
            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<List<BuyOrderDTO>> GetAll()
        {
            ServiceResponse<List<BuyOrderDTO>> rs = new ServiceResponse<List<BuyOrderDTO>>();

            rs.Data = _dbContext.BuyOrder.AsQueryable().Select(x => x.MapToDTO()).ToList();
            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<List<BuyOrderDTO>> GetAllByPriceSectionId(int priceSectionId)
        {
            ServiceResponse<List<BuyOrderDTO>> rs = new ServiceResponse<List<BuyOrderDTO>>();

            rs.Data = _dbContext.BuyOrder.Where(p => p.PriceSectionId == priceSectionId).AsQueryable().Select(x => x.MapToDTO()).ToList();
            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<BuyOrderDTO> Update(BuyOrderDTO rqDTO)
        {
            ServiceResponse<BuyOrderDTO> rs = new ServiceResponse<BuyOrderDTO>();

            BuyOrder BuyOrder = _dbContext.BuyOrder.Find(rqDTO.Id);
            if (BuyOrder == null)
            {
                rs.Data = null;
                rs.IsSuccess = false;
                rs.Message = "Price section id " + rqDTO.Id + " is not existed";
            }

            BuyOrder.UpdateFieldFromDTO(rqDTO);
            _dbContext.BuyOrder.Update(BuyOrder);
            _dbContext.SaveChanges();

            rs.IsSuccess = true;

            return rs;
        }
    }
}
