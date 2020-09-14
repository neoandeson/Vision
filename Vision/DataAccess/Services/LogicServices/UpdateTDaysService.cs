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
        private readonly IHolidayService _holidayService;
        private readonly ISystemConfigService _systemConfig;

        public UpdateTDaysService(IBuyOrderService buyOrderService, IPriceSectionService priceSectionService, ISystemConfigService systemConfig, IHolidayService holidayService)
        {
            _buyOrderService = buyOrderService;
            _priceSectionService = priceSectionService;
            _holidayService = holidayService;
            _systemConfig = systemConfig;
        }

        public void Update()
        {
            Models.SystemConfig lastUpdateTDate = _systemConfig.Get();

            if(lastUpdateTDate != null && lastUpdateTDate.UpdateDate.HasValue)
            {
                DateTime dt_lastUpdateTDate = lastUpdateTDate.UpdateDate.Value;
                DateTime today = DateTime.Now;

                //Not update in holiday
                if (_holidayService.CheckDayIsHoliday(today)) return;

                if (dt_lastUpdateTDate < today && dt_lastUpdateTDate.Day != today.Day)
                {
                    _buyOrderService.UpdateManualTDays();
                    _priceSectionService.UpdateAllInfo();

                    //_systemConfig.UpdateLastUpdateTDate(); TODO: uncomment
                }
            }
        }
    }
}
