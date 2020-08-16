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
    }
}
