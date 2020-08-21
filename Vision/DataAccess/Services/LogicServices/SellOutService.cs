using DataService.Dtos;
using DataService.Models;
using DataService.Services.ModelServices;
using DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using static DataService.Utilities.Constants;

namespace DataService.Services.LogicServices
{
    public interface ISellOutService
    {
        ServiceResponse<string> SellOut(SellOrderDTO sellOrderDTO, SellOutViewModel[] rqVMs, int authUserID);
    }
    
    public class SellOutService : ISellOutService
    {
        private readonly IAccountStateService _accountStateService;
        private readonly IPriceSectionService _priceSectionService;
        private readonly IBuyOrderService _buyOrderService;
        private readonly ISellOrderService _sellOrderService;
        private readonly IOrderHistoryService _orderHistoryService;

        public SellOutService(IAccountStateService accountStateService, IPriceSectionService priceSectionService, IBuyOrderService buyOrderService, ISellOrderService sellOrderService, IOrderHistoryService orderHistoryService)
        {
            _accountStateService = accountStateService;
            _priceSectionService = priceSectionService;
            _buyOrderService = buyOrderService;
            _sellOrderService = sellOrderService;
            _orderHistoryService = orderHistoryService;
        }

        /// <summary>
        /// Create SellOrders
        /// </summary>
        /// <param name="rqVMs"></param>
        /// <param name="authUserID"></param>
        /// <returns></returns>
        public ServiceResponse<string> SellOut(SellOrderDTO sellOrderDTO, SellOutViewModel[] rqVMs, int authUserID)
        {
            ServiceResponse<string> rs = new ServiceResponse<string>();

            //Create Sell Order
            var createRepose = _sellOrderService.Create(sellOrderDTO);
            if (createRepose.Data != null)
            {
                SellOrderDTO createdSellOrderDTO = createRepose.Data;

                //Create history and mapping
                foreach (var vm in rqVMs)
                {
                    PriceSectionDTO priceSectionDTO = _priceSectionService.Get(vm.PriceSectionId).Data;
                    if (priceSectionDTO != null)
                    {
                        OrderHistoryDTO orderHistory = new OrderHistoryDTO()
                        {
                            PriceSectionId = priceSectionDTO.Id,
                            SellOrderId = createdSellOrderDTO.Id,
                            Symbol = priceSectionDTO.Symbol,
                            BuyPrice = priceSectionDTO.Price,
                            SellPrice = createdSellOrderDTO.Price,
                            Volume = priceSectionDTO.Volume,
                            Margin = (priceSectionDTO.Price - createdSellOrderDTO.Price),
                            BuyTradingFee = 0,//TODO: map
                            SellTradingFee = createdSellOrderDTO.TradingFee,
                            SellTax = createdSellOrderDTO.Tax,
                            TotalFee = 0 + createdSellOrderDTO.TradingFee + createdSellOrderDTO.Tax,
                            Revenue = (priceSectionDTO.Price - createdSellOrderDTO.Price) * priceSectionDTO.Volume
                        };

                        _orderHistoryService.Create(orderHistory);
                    }
                    rs.IsSuccess = true;
                    rs.Message = ResponseMessage.SellOutSuccessfully;
                }
            }

            return rs;
        }

        private void MapBuyIn(int priceSectionId, int volume)
        {
            List<BuyOrderDTO> listBuyOrderDTO = _buyOrderService.GetAllByPriceSectionIdAvailableToSell(priceSectionId).Data;

            foreach (var buyOrder in listBuyOrderDTO)
            {
                if(volume == 0) break;

                int soldVolume = Math.Abs(volume - buyOrder.T0);

            }
        }
    }
}
