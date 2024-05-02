using AutoMapper;
using eventPlannerBack.API.Exceptions;
using eventPlannerBack.DAL.Dbcontext;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.Enums;
using eventPlannerBack.Models.VModels.PostulationDTO;
using Microsoft.EntityFrameworkCore;

namespace eventPlannerBack.DAL.Repository
{
    public class PostulationRepository : IGenericRepository<PostulationCreationDTO, PostulationDTO, Postulation>, IPostulationRepository
    {
        private readonly AplicationDBcontext _context;
        private readonly IMapper _mapper;

        public PostulationRepository(AplicationDBcontext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

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

        public async Task<IQueryable<Postulation>> GetMyPostulations(string contractorId)
        {
            try
            {
                IQueryable<Postulation> queryPostulation = _context.Postulations
                    .Where(x => x.ContractorId == contractorId);

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
                postulation.Id = Guid.NewGuid().ToString();
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


                postulation.StatusPostulation = StatusPostulation.PENDING;
                postulation.Message = model.Message;
                postulation.EventId = model.EventId; // TEMPORAL
                postulation.VocationId = model.VocationId; // TEMPORAL
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
        public async Task Refuse(string id, string clientId)
        {
            try
            {
                var postulation = await _context.Postulations.Where(c => c.Id == id).Include(p => p.Event).FirstOrDefaultAsync();
                if (postulation == null) throw new NotFoundException();
                if (postulation.Event.ClientId != clientId) throw new NotFoundException();
                postulation.StatusPostulation = StatusPostulation.REFUSED;
                _context.Update(postulation);
                await _context.SaveChangesAsync();
            }
            catch { throw; }
        }

        public async Task Accept(string id, string clientId)
        {
            try
            {
                var postulation = await _context.Postulations.Where(c => c.Id == id).Include(p => p.Event).FirstOrDefaultAsync();
                if (postulation == null) throw new NotFoundException();
                if (postulation.Event.ClientId != clientId) throw new NotFoundException();
                postulation.StatusPostulation = StatusPostulation.ACCEPTED;
                _context.Update(postulation);
                await _context.SaveChangesAsync();
            }
            catch { throw; }
        }
    }
}
