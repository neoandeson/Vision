using DataService.Dtos;
using DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataService.Services
{
    public interface IPriceSectionService : IServiceBase<PriceSectionDTO, PriceSectionDTO>
    {

    }

    public class PriceSectionService : IPriceSectionService
    {
        private readonly VisionContext _dbContext;

        public PriceSectionService(VisionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ServiceResponse<PriceSectionDTO> Create(PriceSectionDTO rqDTO)
        {
            ServiceResponse<PriceSectionDTO> rs = new ServiceResponse<PriceSectionDTO>();

            PriceSection PriceSection = rqDTO.MapToModel();

            rs.Data = _dbContext.PriceSection.Add(PriceSection).Entity.MapToDTO();
            _dbContext.SaveChanges();
            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<PriceSectionDTO> Delete(int id)
        {
            ServiceResponse<PriceSectionDTO> rs = new ServiceResponse<PriceSectionDTO>();

            PriceSection PriceSection = _dbContext.PriceSection.Find(id);
            if(PriceSection != null)
            {
                _dbContext.PriceSection.Remove(PriceSection);
                _dbContext.SaveChanges();
            }

            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<PriceSectionDTO> Get(int id)
        {
            ServiceResponse<PriceSectionDTO> rs = new ServiceResponse<PriceSectionDTO>();

            rs.Data = _dbContext.PriceSection.Find(id).MapToDTO();
            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<List<PriceSectionDTO>> GetAll()
        {
            ServiceResponse<List<PriceSectionDTO>> rs = new ServiceResponse<List<PriceSectionDTO>>();

            rs.Data = _dbContext.PriceSection.AsQueryable().Select(x => x.MapToDTO()).ToList();
            rs.IsSuccess = true;

            return rs;
        }

        public ServiceResponse<PriceSectionDTO> Update(PriceSectionDTO rqDTO)
        {
            ServiceResponse<PriceSectionDTO> rs = new ServiceResponse<PriceSectionDTO>();

            PriceSection PriceSection = _dbContext.PriceSection.Find(rqDTO.Id);
            if(PriceSection == null)
            {
                rs.Data = null;
                rs.IsSuccess = false;
                rs.Message = "Price section id " + rqDTO.Id + " is not existed";
            }

            PriceSection.UpdateFieldFromDTO(rqDTO);
            _dbContext.PriceSection.Update(PriceSection);
            _dbContext.SaveChanges();

            rs.IsSuccess = true;

            return rs;
        }
    }
}
