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
                        //Prepare history model
                        int mapVolume = vm.SoldVolume;
                        while (mapVolume > 0)
                        {
                            List<BuyOrderDTO> listBuyOrderDTO = _buyOrderService.GetAllByPriceSectionIdAvailableToSell(priceSectionDTO.Id).Data;

                            foreach (var buyOrderDTO in listBuyOrderDTO)
                            {
                                if (mapVolume == 0) break;

                                //Still mapVolume
                                if (mapVolume > buyOrderDTO.T0)
                                {
                                    mapVolume -= buyOrderDTO.T0;
                                    buyOrderDTO.T0 = 0;
                                    buyOrderDTO.Sold = buyOrderDTO.Volume;

                                    //Create OrderHistory
                                    CreateOrderHistory(priceSectionDTO, createdSellOrderDTO, buyOrderDTO, buyOrderDTO.T0);
                                    //Update Sold in BuyOrder
                                    _buyOrderService.Update(buyOrderDTO);
                                }
                                else
                                //Out mapvolume
                                if (mapVolume < buyOrderDTO.Volume)
                                {

                                    //Create OrderHistory
                                    CreateOrderHistory(priceSectionDTO, createdSellOrderDTO, buyOrderDTO, buyOrderDTO.T0 - mapVolume);
                                    
                                    mapVolume = 0;
                                    buyOrderDTO.T0 = buyOrderDTO.T0 - mapVolume;
                                    buyOrderDTO.Sold += buyOrderDTO.T0 - mapVolume;

                                    //Update Sold in BuyOrder
                                    _buyOrderService.Update(buyOrderDTO);
                                }

                            }
                        }

                        
                    }
                    rs.IsSuccess = true;
                    rs.Message = ResponseMessage.SellOutSuccessfully;
                }
            }

            return rs;
        }

        private void CreateOrderHistory(PriceSectionDTO priceSectionDTO, SellOrderDTO createdSellOrderDTO, BuyOrderDTO buyOrderDTO, int sellVolume)
        {
            OrderHistoryDTO orderHistory = new OrderHistoryDTO()
            {
                PriceSectionId = priceSectionDTO.Id,
                SellOrderId = createdSellOrderDTO.Id,
                Symbol = priceSectionDTO.Symbol,
                BuyPrice = priceSectionDTO.Price,
                SellPrice = createdSellOrderDTO.Price,
                Volume = sellVolume,
                Margin = (priceSectionDTO.Price - createdSellOrderDTO.Price),
                BuyTradingFee = (buyOrderDTO.TradingFee / buyOrderDTO.Volume) * sellVolume,
                SellTradingFee = (createdSellOrderDTO.TradingFee / createdSellOrderDTO.Volume) * sellVolume,
                SellTax = createdSellOrderDTO.Tax,
                TotalFee = buyOrderDTO.TradingFee + createdSellOrderDTO.TradingFee + createdSellOrderDTO.Tax,
                Revenue = ((priceSectionDTO.Price - createdSellOrderDTO.Price) * sellVolume) - (buyOrderDTO.TradingFee + createdSellOrderDTO.TradingFee + createdSellOrderDTO.Tax)
            };

            _orderHistoryService.Create(orderHistory);
        }
    }
}
