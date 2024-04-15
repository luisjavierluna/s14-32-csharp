using AutoMapper;
using eventPlannerBack.API.Exceptions;
using eventPlannerBack.DAL.Dbcontext;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.VModels.ContractorDTO;
using Microsoft.EntityFrameworkCore;

namespace eventPlannerBack.DAL.Repository
{
    public class ContractorRepository : IGenericRepository<ContractorCreationDTO, ContractorDTO, Contractor>
    {
        private readonly AplicationDBcontext _context;
        private readonly IMapper _mapper;

        public ContractorRepository(AplicationDBcontext dbcontext, IMapper mapper)
        {
            _context = dbcontext;
            _mapper = mapper;
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                var contractor = await _context.Contractors.Where(c => c.Id == id).FirstOrDefaultAsync();

                if (contractor == null) throw new NotFoundException();

                _context.Remove(contractor);
                await _context.SaveChangesAsync();

                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IQueryable<Contractor>> GetAll()
        {
            try
            {
                IQueryable<Contractor> queryContractor = _context.Contractors;
                return queryContractor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ContractorDTO> GetByID(string id)
        {
            var contractor = await _context.Contractors.Where(c => c.Id == id).FirstOrDefaultAsync();

            if (contractor == null) throw new NotFoundException();

            return _mapper.Map<ContractorDTO>(contractor);
        }

        public async Task<ContractorDTO> Insert(ContractorCreationDTO model)
        {
            try
            {
                var contractor = _mapper.Map<Contractor>(model);
                _context.Add(contractor);
                await _context.SaveChangesAsync();

                return _mapper.Map<ContractorDTO>(contractor);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ContractorDTO> Update(string id, ContractorCreationDTO model)
        {
            try
            {
                var contractor = await _context.Contractors.Where(c => c.Id == id).FirstOrDefaultAsync();

                if (contractor == null) throw new NotFoundException();

                contractor.CUIT = model.CUIT;

                _context.Update(contractor);

                await _context.SaveChangesAsync();

                return _mapper.Map<ContractorDTO>(contractor);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
