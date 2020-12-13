using DataService.Dtos;
using DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static DataService.Utilities.Constants;

namespace DataService.Services.ModelServices
{
    public interface IOrderService : IServiceBase<OrderDTO, OrderDTO>
    {
    }

    public class OrderService : IOrderService
    {
        private readonly VisionContext _dbContext;
        private readonly int _authUserID = CurrentUser.AuthUserID;

        public OrderService(VisionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ServiceResponse<OrderDTO> Create(OrderDTO rqDTO)
        {
            ServiceResponse<OrderDTO> rs = new ServiceResponse<OrderDTO>();

            Order Order = rqDTO.MapToModel(_authUserID);

            _dbContext.Order.Add(Order);
            _dbContext.SaveChanges();

            rs.Data = Order.MapToDTO();
            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<OrderDTO> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<OrderDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<List<OrderDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<OrderDTO> Update(OrderDTO rqDTO)
        {
            throw new NotImplementedException();
        }
    }
}
