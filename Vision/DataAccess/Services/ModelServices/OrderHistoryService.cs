using DataService.Dtos;
using DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static DataService.Utilities.Constants;

namespace DataService.Services.ModelServices
{
    public interface IOrderHistoryService : IServiceBase<OrderHistoryDTO, OrderHistoryDTO>
    {
    }

    public class OrderHistoryService : IOrderHistoryService
    {
        private readonly VisionContext _dbContext;
        private readonly int _authUserID = CurrentUser.AuthUserID;

        public OrderHistoryService(VisionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ServiceResponse<OrderHistoryDTO> Create(OrderHistoryDTO rqDTO)
        {
            ServiceResponse<OrderHistoryDTO> rs = new ServiceResponse<OrderHistoryDTO>();

            OrderHistory accountState = rqDTO.MapToModel(_authUserID);

            _dbContext.OrderHistory.Add(accountState);
            _dbContext.SaveChanges();

            rs.Data = accountState.MapToDTO();
            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<OrderHistoryDTO> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<OrderHistoryDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<List<OrderHistoryDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<OrderHistoryDTO> Update(OrderHistoryDTO rqDTO)
        {
            throw new NotImplementedException();
        }
    }
}
