using AutoMapper;
using eventPlannerBack.API.Exceptions;
using eventPlannerBack.DAL.Dbcontext;
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

namespace eventPlannerBack.DAL.Repository
{
    public class PostulationRepository : IGenericRepository<PostulationCreationDTO, PostulationDTO, Postulation>
    {
        private readonly AplicationDBcontext _context;
        private readonly IMapper _mapper;
        public async Task<bool> Delete(string id)
        {
            try
            {
                var postulation = await _context.Postulations.Where(c => c.Id == id).FirstOrDefaultAsync();

                if (postulation == null) throw new NotFoundException();

                _context.Remove(postulation);
                await _context.SaveChangesAsync();

                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IQueryable<Postulation>> GetAll()
        {
            try
            {
                IQueryable<Postulation> queryPostulation = _context.Postulations;
                return queryPostulation;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PostulationDTO> GetByID(string id)
        {
            var postulation = await _context.Postulations.Where(c => c.Id == id).FirstOrDefaultAsync();

            if (postulation == null) throw new NotFoundException();

            return _mapper.Map<PostulationDTO>(postulation);
        }

        public async Task<PostulationDTO> Insert(PostulationCreationDTO model)
        {
            try
            {
                var postulation = _mapper.Map<Postulation>(model);
                _context.Add(postulation);
                await _context.SaveChangesAsync();

                return _mapper.Map<PostulationDTO>(postulation);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PostulationDTO> Update(string id, PostulationCreationDTO model)
        {
            try
            {
                var postulation = await _context.Postulations.Where(c => c.Id == id).FirstOrDefaultAsync();

                if (postulation == null) throw new NotFoundException();

                
                postulation.StatusPostulation = model.StatusPostulation;
                postulation.Message = model.Message;               
                postulation.EventId = model.EventId;              
                postulation.VocationId = model.VocationId;               
                postulation.ContractorId = model.ContractorId;
                //REVER
                //postulation.Contractor = model.Contractor;
                //postulation.Event = model.Event;
                //postulation.Vocation = model.Vocation;
                _context.Update(postulation);
                await _context.SaveChangesAsync();

                return _mapper.Map<PostulationDTO>(postulation);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
