using AutoMapper;
using eventPlannerBack.BLL.Behaviors;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.VModels.DatosDTO;
using Microsoft.EntityFrameworkCore;

namespace eventPlannerBack.BLL.Service
{
    public class DataService : IGenericService<DataCreationDTO, DataDTO>, IDataService
    {
        private readonly IGenericRepository<DataCreationDTO, DataDTO, Data> _dataRepo;
        private readonly IMapper _mapper;
        private readonly ValidationBehavior<DataCreationDTO> _validationBehavior;

        public DataService(
            IGenericRepository<DataCreationDTO, DataDTO, Data> dataRepo, 
            IMapper mapper,
            ValidationBehavior<DataCreationDTO> validationBehavior)
        {
            _dataRepo = dataRepo;
            _mapper = mapper;
            _validationBehavior = validationBehavior;
        }

        public async Task<DataDTO> SignIn(DataCreationDTO model)
        {
            await _validationBehavior.ValidateFields(model);
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
            return _mapper.Map<IEnumerable<DataDTO>>(list);
        }
       
    }

}
