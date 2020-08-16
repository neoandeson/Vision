using DataService.Dtos;
using DataService.Models;
using DataService.Services.ModelServices;
using System;
using System.Collections.Generic;
using System.Text;
using static DataService.Utilities.Constants;

namespace DataService.Services.LogicServices
{
    public interface IBuyInService
    {
        ServiceResponse<BuyOrderDTO> BuyIn(BuyOrderDTO rqDTO, int authUserID);
    }
    
    public class BuyInService : IBuyInService
    {
        private readonly IAccountStateService _accountStateService;
        private readonly IPriceSectionService _priceSectionService;
        private readonly IBuyOrderService _buyOrderService;

        public BuyInService(IAccountStateService accountStateService, IPriceSectionService priceSectionService, IBuyOrderService buyOrderService)
        {
            _accountStateService = accountStateService;
            _priceSectionService = priceSectionService;
            _buyOrderService = buyOrderService;
        }

        /// <summary>
        /// Create new BuyOrder with corresponding PriceSection
        /// if PriceSection is note exist create PriceSection and corresponding AccountState
        /// created new PriceSection and AccountState has default string field value is empty
        /// </summary>
        /// <param name="priceSectionService"></param>
        /// <param name="rqDTO"></param>
        /// <returns></returns>
        public ServiceResponse<BuyOrderDTO> BuyIn(BuyOrderDTO rqDTO, int authUserID)
        {
            ServiceResponse<BuyOrderDTO> rs = new ServiceResponse<BuyOrderDTO>();

            AccountState accountState = _accountStateService.GetBySymbol(rqDTO.Symbol);
            if (accountState != null)
            {
                PriceSection priceSection = _priceSectionService.GetByAccountStateAndPrice(accountState.Id, rqDTO.Price);
                if (priceSection == null)
                {
                    priceSection = _priceSectionService.CreateByAccountStateAndPrice(rqDTO.Symbol, accountState.Id, rqDTO.Price).Data.MapToModel(authUserID);
                }

                rs.Data = _buyOrderService.CreateBuyOrderWithPriceSession(rqDTO, priceSection.Id, authUserID).MapToDTO();

                _priceSectionService.UpdateInfo(priceSection.Id);
            }
            else
            {
                accountState = _accountStateService.CreateWithSymbol(rqDTO.Symbol).Data;

                PriceSectionDTO priceSectionDTO = _priceSectionService.CreateByAccountStateAndPrice(rqDTO.Symbol, accountState.Id, rqDTO.Price).Data;

                rs.Data = _buyOrderService.CreateBuyOrderWithPriceSession(rqDTO, priceSectionDTO.Id, authUserID).MapToDTO();

                _priceSectionService.UpdateInfo(priceSectionDTO.Id);
            }

            rs.IsSuccess = true;
            rs.Message = ResponseMessage.BuyInSuccessfully;

            return rs;
        }
    }
}
