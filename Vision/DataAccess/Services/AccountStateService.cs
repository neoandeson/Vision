﻿using DataService.Dtos;
using DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataService.Services
{
    public interface IAccountStateService : IServiceBase<AccountStateDTO, AccountStateDTO>
    {

    }

    public class AccountStateService : IAccountStateService
    {
        private readonly VisionContext _dbContext;

        public AccountStateService(VisionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ServiceResponse<AccountStateDTO> Create(AccountStateDTO rqDTO)
        {
            ServiceResponse<AccountStateDTO> rs = new ServiceResponse<AccountStateDTO>();

            AccountState accountState = rqDTO.MapToModel();

            rs.Data = _dbContext.AccountState.Add(accountState).Entity.MapToDTO();
            _dbContext.SaveChanges();
            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<AccountStateDTO> Delete(int id)
        {
            ServiceResponse<AccountStateDTO> rs = new ServiceResponse<AccountStateDTO>();

            AccountState accountState = _dbContext.AccountState.Find(id);
            if(accountState != null)
            {
                _dbContext.AccountState.Remove(accountState);
                _dbContext.SaveChanges();
            }

            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<AccountStateDTO> Get(int id)
        {
            ServiceResponse<AccountStateDTO> rs = new ServiceResponse<AccountStateDTO>();

            rs.Data = _dbContext.AccountState.Find(id).MapToDTO();
            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<List<AccountStateDTO>> GetAll()
        {
            ServiceResponse<List<AccountStateDTO>> rs = new ServiceResponse<List<AccountStateDTO>>();

            rs.Data = _dbContext.AccountState.AsQueryable().Select(x => x.MapToDTO()).ToList();
            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<AccountStateDTO> Update(AccountStateDTO rqDTO)
        {
            ServiceResponse<AccountStateDTO> rs = new ServiceResponse<AccountStateDTO>();

            AccountState accountState = _dbContext.AccountState.Find(rqDTO.Id);
            if(accountState == null)
            {
                rs.Data = null;
                rs.IsSuccess = false;
                rs.Message = "Account state id " + rqDTO.Id + " is not existed";
            }

            accountState.UpdateFieldFromDTO(rqDTO);
            _dbContext.AccountState.Update(accountState);
            _dbContext.SaveChanges();

            rs.IsSuccess = true;

            return rs;
        }
    }
}
