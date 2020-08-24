using DataService.Dtos;
using DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static DataService.Utilities.Constants;

namespace DataService.Services.ModelServices
{
    public interface ISystemConfigService
    {
        SystemConfig Get();
        void UpdateLastUpdateTDate();
    }

    public class SystemConfigService : ISystemConfigService
    {
        private readonly VisionContext _dbContext;
        private readonly int _authUserID = CurrentUser.AuthUserID;

        public SystemConfigService(VisionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public SystemConfig Get()
        {
            SystemConfig systemConfig = _dbContext.SystemConfig.FirstOrDefault(c => c.Name == "LastUpdateTDate");
            
            return systemConfig;
        }

        public void UpdateLastUpdateTDate()
        {
            SystemConfig systemConfig = _dbContext.SystemConfig.FirstOrDefault(c => c.Name == "LastUpdateTDate");
            if(systemConfig != null)
            {
                systemConfig.UpdateDate = DateTime.Now;

                _dbContext.SaveChanges();
            }
        }
    }
}
