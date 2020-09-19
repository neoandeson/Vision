using DataService.Dtos;
using DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static DataService.Utilities.Constants;
using DataService.Utilities;

namespace DataService.Services.ModelServices
{
    public interface IBuyOrderService : IServiceBase<BuyOrderDTO, BuyOrderDTO>
    {
        ServiceResponse<List<BuyOrderDTO>> GetAllByPriceSectionId(int priceSectionId);
        ServiceResponse<List<BuyOrderDTO>> GetAllByPriceSectionIdAvailableToSell(int priceSectionId);
        BuyOrder CreateBuyOrderWithPriceSession(BuyOrderDTO rqDTO, int priceSessionId, int authUserID);

        void UpdateManualTDays();
        void UpdateAutoTDays();
    }

    public class BuyOrderService : IBuyOrderService
    {
        private readonly VisionContext _dbContext;
        private readonly IHolidayService _holidayService;
        private readonly int _authUserID = CurrentUser.AuthUserID;

        public BuyOrderService(VisionContext dbContext, IHolidayService holidayService)
        {
            _dbContext = dbContext;
            _holidayService = holidayService;
        }

        public ServiceResponse<BuyOrderDTO> Create(BuyOrderDTO rqDTO)
        {
            throw new NotImplementedException();
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

        public BuyOrder CreateBuyOrderWithPriceSession(BuyOrderDTO rqDTO, int priceSessionId, int authUserID)
        {
            //Default when buy in volume is in MatchedVol
            rqDTO.MatchedVol = rqDTO.Volume;
            BuyOrder buyOrder = rqDTO.MapToModel(authUserID);
            buyOrder.Status = BuyOrderStatus.Active;
            buyOrder.PriceSectionId = priceSessionId;
            buyOrder.CreateDate = DateTime.Now;
            buyOrder.UpdateDate = DateTime.Now;

            _dbContext.BuyOrder.Add(buyOrder);
            _dbContext.SaveChanges();

            return buyOrder;
        }

        public void UpdateManualTDays()
        {
            var activeBuyOrders = _dbContext.BuyOrder.Where(o => o.Status == BuyOrderStatus.Active).ToList();
            var holidays = _holidayService.GetAllHolidays();

            foreach (var order in activeBuyOrders)
            {
                int diffDate = ModelUtils.BusinessDaysUntil(order.Date, DateTime.Now, holidays);

                if(diffDate > 3)
                {
                    order.T0 = order.Volume;
                    order.T1 = 0;
                    order.T2 = 0;
                    order.MatchedVol = 0;
                } else
                {
                    switch (diffDate)
                    {
                        case 3:
                            order.T0 = order.Volume;
                            order.T1 = 0;
                            order.T2 = 0;
                            order.MatchedVol = 0;
                            break;
                        case 2:
                            order.T1 = order.Volume;
                            order.T2 = 0;
                            order.T0 = 0;
                            order.MatchedVol = 0;
                            break;
                        case 1:
                            order.T2 = order.Volume;
                            order.MatchedVol = 0;
                            order.T0 = 0;
                            order.T1 = 0;
                            break;
                        default: break;
                    }
                }
                

                _dbContext.BuyOrder.Update(order);
            }

            _dbContext.SaveChanges();
        }

        public void UpdateAutoTDays()
        {
            var activeBuyOrders = _dbContext.BuyOrder.Where(o => o.Status == BuyOrderStatus.Active).ToList();
            var holidays = _holidayService.GetAllHolidays();

            foreach (var order in activeBuyOrders)
            {
                int diffDate = ModelUtils.BusinessDaysUntil(order.Date, DateTime.Now, holidays);

                if (diffDate > 3)
                {
                    order.T0 = order.Volume;
                    order.T1 = 0;
                    order.T2 = 0;
                    order.MatchedVol = 0;
                }
                else
                {
                    switch (diffDate)
                    {
                        case 3:
                            order.T0 = order.Volume;
                            order.T1 = 0;
                            order.T2 = 0;
                            order.MatchedVol = 0;
                            break;
                        case 2:
                            order.T1 = order.Volume;
                            order.T2 = 0;
                            order.T0 = 0;
                            order.MatchedVol = 0;
                            break;
                        case 1:
                            order.T2 = order.Volume;
                            order.MatchedVol = 0;
                            order.T0 = 0;
                            order.T1 = 0;
                            break;
                        default: break;
                    }
                }


                _dbContext.BuyOrder.Update(order);
            }

            _dbContext.SaveChanges();
        }

        public ServiceResponse<List<BuyOrderDTO>> GetAllByPriceSectionIdAvailableToSell(int priceSectionId)
        {
            ServiceResponse<List<BuyOrderDTO>> rs = new ServiceResponse<List<BuyOrderDTO>>();

            rs.Data = _dbContext.BuyOrder.Where(p => p.PriceSectionId == priceSectionId && p.Sold < p.Volume).AsQueryable().Select(x => x.MapToDTO()).ToList();
            rs.IsSuccess = true;

            return rs;
        }
    }
}
