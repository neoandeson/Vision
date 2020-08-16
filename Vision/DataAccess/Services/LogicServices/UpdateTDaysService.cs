using DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataService.Services.ModelServices;

namespace DataService.Services.LogicServices
{

    public interface IUpdateTDaysService
    {
        void Update();
    }

    public class UpdateTDaysService : IUpdateTDaysService
    {
        private readonly IBuyOrderService _buyOrderService;
        private readonly IPriceSectionService _priceSectionService;
        private readonly ISystemConfigService _systemConfig;

        public UpdateTDaysService(IBuyOrderService buyOrderService, IPriceSectionService priceSectionService, ISystemConfigService systemConfig)
        {
            _buyOrderService = buyOrderService;
            _priceSectionService = priceSectionService;
            _systemConfig = systemConfig;
        }

        public void Update()
        {
            Models.SystemConfig lastUpdateTDate = _systemConfig.Get();

            if(lastUpdateTDate != null && lastUpdateTDate.UpdateDate.HasValue)
            {
                DateTime dt_lastUpdateTDate = lastUpdateTDate.UpdateDate.Value;
                DateTime today = DateTime.Now;
                if (dt_lastUpdateTDate < today && dt_lastUpdateTDate.Day != today.Day)
                {
                    _buyOrderService.UpdateTDays();
                    _priceSectionService.UpdateAllInfo();
                }
            }
        }
    }
}
