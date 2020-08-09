﻿using DataService.Dtos;
using DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataService.Services
{
    public interface ISellOrderService : IServiceBase<SellOrderDTO, SellOrderDTO>
    {

    }

    public class SellOrderService : ISellOrderService
    {
        private readonly VisionContext _dbContext;

        public SellOrderService(VisionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ServiceResponse<SellOrderDTO> Create(SellOrderDTO rqDTO)
        {
            ServiceResponse<SellOrderDTO> rs = new ServiceResponse<SellOrderDTO>();

            SellOrder SellOrder = rqDTO.MapToModel();

            rs.Data = _dbContext.SellOrder.Add(SellOrder).Entity.MapToDTO();
            _dbContext.SaveChanges();
            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<SellOrderDTO> Delete(int id)
        {
            ServiceResponse<SellOrderDTO> rs = new ServiceResponse<SellOrderDTO>();

            SellOrder SellOrder = _dbContext.SellOrder.Find(id);
            if (SellOrder != null)
            {
                _dbContext.SellOrder.Remove(SellOrder);
                _dbContext.SaveChanges();
            }

            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<SellOrderDTO> Get(int id)
        {
            ServiceResponse<SellOrderDTO> rs = new ServiceResponse<SellOrderDTO>();

            rs.Data = _dbContext.SellOrder.Find(id).MapToDTO();
            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<List<SellOrderDTO>> GetAll()
        {
            ServiceResponse<List<SellOrderDTO>> rs = new ServiceResponse<List<SellOrderDTO>>();

            rs.Data = _dbContext.SellOrder.AsQueryable().Select(x => x.MapToDTO()).ToList();
            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<SellOrderDTO> Update(SellOrderDTO rqDTO)
        {
            ServiceResponse<SellOrderDTO> rs = new ServiceResponse<SellOrderDTO>();

            SellOrder SellOrder = _dbContext.SellOrder.Find(rqDTO.Id);
            if (SellOrder == null)
            {
                rs.Data = null;
                rs.IsSuccess = false;
                rs.Message = "Price section id " + rqDTO.Id + " is not existed";
            }

            SellOrder.UpdateFieldFromDTO(rqDTO);
            _dbContext.SellOrder.Update(SellOrder);
            _dbContext.SaveChanges();

            rs.IsSuccess = true;

            return rs;
        }
    }
}
