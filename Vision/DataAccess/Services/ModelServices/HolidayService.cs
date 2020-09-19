using DataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static DataService.Utilities.Constants;

namespace DataService.Services.ModelServices
{
    public interface IHolidayService : IServiceBase<DateTime, bool>
    {
        bool CheckDayIsHoliday(DateTime checkDate);
    }

    public class HolidayService : IHolidayService
    {
        private readonly VisionContext _dbContext;
        private readonly int _authUserID = CurrentUser.AuthUserID;

        public HolidayService(VisionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CheckDayIsHoliday(DateTime checkDate)
        {
            bool result = false;
            var tmp = _dbContext.Holiday.FirstOrDefault(h => (h.DateTime.Day == checkDate.Day) && (h.DateTime.Month == checkDate.Month));
            if (tmp != null) result = true;
            return result;
        }

        public ServiceResponse<bool> Create(DateTime rqDTO)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> Get(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<List<bool>> GetAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> Update(DateTime rqDTO)
        {
            throw new NotImplementedException();
        }
    }
}
