using DataService.Dtos;
using DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static DataService.Utilities.Constants;
using DataService.ViewModels;

namespace DataService.Services.ModelServices
{
    public interface IAccountStateService : IServiceBase<AccountStateDTO, AccountStateDTO>
    {
        AccountState GetBySymbol(string symbol);
        ServiceResponse<AccountState> CreateWithSymbol(string symbol);
        ServiceResponse<AccountStateDTO> UpdateVM(AccountStateViewModel updateVM);
    }

    public class AccountStateService : IAccountStateService
    {
        private readonly VisionContext _dbContext;
        private readonly IBuyOrderService _buyOrderService;
        private readonly int _authUserID = CurrentUser.AuthUserID;

        public AccountStateService(VisionContext dbContext, IBuyOrderService buyOrderService)
        {
            _dbContext = dbContext;
            _buyOrderService = buyOrderService;
        }

        public ServiceResponse<AccountStateDTO> Create(AccountStateDTO rqDTO)
        {
            ServiceResponse<AccountStateDTO> rs = new ServiceResponse<AccountStateDTO>();

            AccountState accountState = rqDTO.MapToModel(_authUserID);

            _dbContext.AccountState.Add(accountState);
            _dbContext.SaveChanges();

            rs.Data = accountState.MapToDTO();
            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<AccountState> CreateWithSymbol(string symbol)
        {
            ServiceResponse<AccountState> rs = new ServiceResponse<AccountState>();

            AccountState accountState = new AccountState()
            {
                Symbol = symbol,
                Description = string.Empty,
                Note = string.Empty,
                TotalDividend = 0,
                CurrentPrice = 0,
                CurrentValue = 0,
                TotalBuy = 0,
                TotalSell = 0,
                TotalTax = 0,
                TotalBuyFee = 0,
                TotalSellFee = 0,
                Type = string.Empty,
                Department = string.Empty,
                UserId = _authUserID,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Status = AccountStateStatus.Active
            };

            rs.Data = _dbContext.AccountState.Add(accountState).Entity;
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

        public AccountState GetBySymbol(string symbol)
        {
            return _dbContext.AccountState.FirstOrDefault(a => a.Symbol == symbol);
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

            accountState.UpdateFieldFromDTO(rqDTO, _authUserID);
            _dbContext.AccountState.Update(accountState);
            _dbContext.SaveChanges();

            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<AccountStateDTO> UpdateVM(AccountStateViewModel updateVM)
        {
            ServiceResponse<AccountStateDTO> rs = new ServiceResponse<AccountStateDTO>();

            AccountState accountState = _dbContext.AccountState.Find(updateVM.Id);
            if (accountState == null)
            {
                rs.Data = null;
                rs.IsSuccess = false;
                rs.Message = "Account state symbol " + updateVM.Symbol + " is not existed";
            }

            accountState.Description = updateVM.Description;
            accountState.Note = updateVM.Note;
            accountState.Type = updateVM.Type;
            accountState.Department = updateVM.Department;

            _dbContext.AccountState.Update(accountState);
            _dbContext.SaveChanges();

            rs.IsSuccess = true;
            rs.Message = ResponseMessage.UpdateAccountStateSuccessfully;

            return rs;
        }
    }
}
