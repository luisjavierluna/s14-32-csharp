using AutoMapper;
using eventPlannerBack.API.Exceptions;
using eventPlannerBack.DAL.Dbcontext;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.VModels.VocationDTO;
using Microsoft.EntityFrameworkCore;

namespace eventPlannerBack.DAL.Repository
{
    public class VocationRepository : IVocationRepository
    {
        private readonly AplicationDBcontext _appDbContext;
        private readonly IMapper _mapper;

        public VocationRepository(AplicationDBcontext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;

        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                var vocation = await _appDbContext.Vocations.Where( x => x.Id == id).FirstOrDefaultAsync();
                if (vocation == null) throw new NotFoundException();

                _appDbContext.Remove(vocation);

                await _appDbContext.SaveChangesAsync();

                return true;

            }
            catch(Exception)
            {
                throw;
            }

        }

        public async Task<IQueryable<Vocation>> GetAll()
        {
            try
            {
                IQueryable<Vocation> queryVocations = _appDbContext.Vocations;
                return queryVocations;              

            }
            catch(Exception) 
            {
                throw;
            }
            
        }

        public async Task<VocationDTO> GetByID(string id)
        {
            try
            {
                var vocation = await _appDbContext.Vocations.Where( x => x.Id == id).FirstOrDefaultAsync();

                if (vocation == null) throw new NotFoundException();

                return _mapper.Map<VocationDTO>(vocation);


            }
            catch (Exception)
            {
                throw;
            }            
        }

        public async Task<VocationDTO> Insert(VocationCreationDTO model)
        {
            try
            {
                var vocationAdd = _mapper.Map<Vocation>(model);
                _appDbContext.Add(vocationAdd);
                await _appDbContext.SaveChangesAsync();
                return _mapper.Map<VocationDTO>(vocationAdd);

            }
            catch(Exception)
            {
                throw;
            }

        }

        public async Task<VocationDTO> Update(string id, VocationCreationDTO model)
        {
            try
            {
                var vocation = await _appDbContext.Vocations.Where(x=> x.Id == id).FirstOrDefaultAsync();
                if (vocation == null) throw new NotFoundException();
                
                vocation.Name = model.Name; 
                vocation.Description = model.Description;

                _appDbContext.Update(vocation);
                await _appDbContext.SaveChangesAsync();

                return _mapper.Map<VocationDTO>(vocation);

            }
            catch
            {
                throw;
            }       

        }
    }
}
