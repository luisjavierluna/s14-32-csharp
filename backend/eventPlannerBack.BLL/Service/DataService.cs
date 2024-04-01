using AutoMapper;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.VModels.DatosDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace eventPlannerBack.BLL.Service
{
    public class DataService : IGenericService<DataCreationDTO, DataDTO>, IDataService
    {
        private readonly IGenericRepository<DataCreationDTO, DataDTO, Data> _dataRepo;
        private readonly IMapper mapper;

        public DataService(IGenericRepository<DataCreationDTO, DataDTO, Data> dataRepo, IMapper mapper)
        {
            _dataRepo = dataRepo;
            this.mapper = mapper;
        }

        public async Task<DataDTO> SignIn(DataCreationDTO model)
        {
            return await _dataRepo.Insert(model);
        }

        public async Task<DataDTO> Update(int id, DataCreationDTO model)
        {
            return await _dataRepo.Update(id, model);
        }

        public async Task<bool> Delete(int id)
        {
            return await _dataRepo.Delete(id);
        }

        public Task<DataDTO> GetById(int id)
        {
            return _dataRepo.GetByID(id);
        }

        public async Task<IEnumerable<DataDTO>> GetAll()
        {
          var query = await _dataRepo.GetAll();                    
          var list = await query.ToListAsync();
            return mapper.Map<IEnumerable<DataDTO>>(list);
        }
       
    }

}
