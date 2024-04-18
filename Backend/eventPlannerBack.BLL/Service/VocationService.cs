using AutoMapper;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.VModels.VocationDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.BLL.Service
{
    public class VocationService : IVocationService
    {
        private readonly IVocationRepository _vocationRepository;
        private readonly IMapper _mapper;

        public VocationService(IVocationRepository vocationRepository, IMapper mapper)
        {
            _vocationRepository = vocationRepository;
            _mapper = mapper;
        }
        public async Task<bool> Delete(string id)
        {
            try
            {
                return await _vocationRepository.Delete(id);

            }
            catch
            {
                throw;
            }
            
        }

        public async Task<IEnumerable<VocationDTO>> GetAll()
        {
            try
            {
                
                var query = await _vocationRepository.GetAll();

                var lista = await query.ToListAsync();

                return _mapper.Map<IEnumerable<VocationDTO>>(lista);

            }
            catch
            {
                throw;
            }
        }

        public async Task<VocationDTO> GetById(string id)
        {
            try
            {
                return await _vocationRepository.GetByID(id);
                
            }
            catch
            {
                throw;
            }

        }

        public async Task<VocationDTO> SignIn(VocationCreationDTO model)
        {
            try
            {
                return await _vocationRepository.Insert(model);

            }
            catch
            {
                throw;
            }
        }

        public async Task<VocationDTO> Update(string id, VocationCreationDTO model)
        {
            try
            {
                return await _vocationRepository.Update(id, model);
            }
            catch
            {
                throw;
            }
        }
    }
}
