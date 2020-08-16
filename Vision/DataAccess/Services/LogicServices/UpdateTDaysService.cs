using DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Services.LogicServices
{

    public interface IUpdateTDaysService
    {
        void Update();
    }

    public class UpdateTDaysService : IUpdateTDaysService
    {
        private readonly VisionContext _dbContext;

        public UpdateTDaysService(VisionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update()
        {
            
        }
    }
}
