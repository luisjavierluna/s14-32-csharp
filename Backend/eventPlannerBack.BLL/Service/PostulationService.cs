﻿using AutoMapper;
using eventPlannerBack.BLL.Behaviors;
using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.VModels.PostulationDTO;
using Microsoft.EntityFrameworkCore;

namespace eventPlannerBack.BLL.Service
{
    public class PostulationService : IGenericService<PostulationCreationDTO, PostulationDTO>, IPostulationService
    {
        private readonly IGenericRepository<PostulationCreationDTO, PostulationDTO, Postulation> _genericPostulationRepository;
        private readonly INotificationService _notificationService;
        private readonly IPostulationRepository _postulationRepository;
        private readonly IMapper _mapper;
        private readonly ValidationBehavior<PostulationCreationDTO> _validationBehavior;
        public PostulationService(
            IGenericRepository<PostulationCreationDTO, PostulationDTO, Postulation> genericPostulationRepository,
            INotificationService notificationService,
            IMapper mapper,
            ValidationBehavior<PostulationCreationDTO> validationBehavior,
            IPostulationRepository postulationRepository)
        {
            _genericPostulationRepository = genericPostulationRepository;
            _notificationService = notificationService;
            _mapper = mapper;
            _validationBehavior = validationBehavior;
            _postulationRepository = postulationRepository;
        }

        public async Task<bool> Delete(string id)
        {
            return await _genericPostulationRepository.Delete(id);
        }

        public async Task<IEnumerable<PostulationDTO>> GetAll()
        {
            var query = await _genericPostulationRepository.GetAll();
            var list = await query.ToListAsync();
            return _mapper.Map<IEnumerable<PostulationDTO>>(list);
        }

        public async Task<IEnumerable<PostulationDTO>> GetMyPostulations(string contractorId)
        {
            var query = await _postulationRepository.GetMyPostulations(contractorId);
            var list = await query.ToListAsync();
            return _mapper.Map<IEnumerable<PostulationDTO>>(list);
        }

        public async Task<PostulationDTO> GetById(string id)
        {
            return await _genericPostulationRepository.GetByID(id);
        }

        public async Task<PostulationDTO> SignIn(PostulationCreationDTO model)
        {
            await _validationBehavior.ValidateFields(model);

            await _notificationService.BuildClientNotification(model.EventId, model.ContractorId);

            return await _genericPostulationRepository.Insert(model);
        }

        public async Task<PostulationDTO> Update(string id, PostulationCreationDTO model)
        {
            return await _genericPostulationRepository.Update(id, model);
        }

        public async Task Refuse(string id, string clientId)
        {
            var postulation = await _genericPostulationRepository.GetByID(id);

            await _notificationService.BuildContractorNotification(postulation, "rejected");

            await _postulationRepository.Refuse(id, clientId);
        }

        public async Task Accept(string id, string clientId)
        {
            var postulation = await _genericPostulationRepository.GetByID(id);

            await _notificationService.BuildContractorNotification(postulation, "accepted");

            await _postulationRepository.Accept(id, clientId);
        }
    }
}
