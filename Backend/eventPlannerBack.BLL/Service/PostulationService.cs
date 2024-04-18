using AutoMapper;
using eventPlannerBack.BLL.Behaviors;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.VModels.NotificationDTO;
using eventPlannerBack.Models.VModels.PostulationDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.BLL.Service
{
    public class PostulationService : IGenericService<PostulationCreationDTO, PostulationDTO>, IPostulationService
    {
        private readonly IGenericRepository<PostulationCreationDTO, PostulationDTO, Postulation> _repository;
        private readonly IMapper _mapper;
        private readonly ValidationBehavior<PostulationCreationDTO> _validationBehavior;
        public PostulationService(
            IGenericRepository<PostulationCreationDTO, PostulationDTO, Postulation> repository,
            IMapper mapper,
            ValidationBehavior<PostulationCreationDTO> validationBehavior)
        {
            _repository = repository;
            _mapper = mapper;
            _validationBehavior = validationBehavior;
        }

        public async Task<bool> Delete(string id)
        {
            return await _repository.Delete(id);
        }

        public async Task<IEnumerable<PostulationDTO>> GetAll()
        {
            var query = await _repository.GetAll();
            var list = await query.ToListAsync();
            return _mapper.Map<IEnumerable<PostulationDTO>>(list);
        }

        public async Task<PostulationDTO> GetById(string id)
        {
            return await _repository.GetByID(id);
        }

        public async Task<PostulationDTO> SignIn(PostulationCreationDTO model)
        {
            await _validationBehavior.ValidateFields(model);

            return await _repository.Insert(model);
        }

        public async Task<PostulationDTO> Update(string id, PostulationCreationDTO model)
        {
            return await _repository.Update(id, model);
        }
    }
}
