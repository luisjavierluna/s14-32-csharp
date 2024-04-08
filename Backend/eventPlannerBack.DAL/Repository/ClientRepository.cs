using AutoMapper;
using eventPlannerBack.API.Exceptions;
using eventPlannerBack.DAL.Dbcontext;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entidades;
using eventPlannerBack.Models.VModels.ClientDTO;
using Microsoft.EntityFrameworkCore;

namespace eventPlannerBack.DAL.Repository
{
    public class ClientRepository:IGenericRepository<ClientCreationDTO, ClientDTO, Client>
    {
        private readonly AplicationDBcontext _dbcontext;
        private readonly IMapper mapper;

        public ClientRepository(AplicationDBcontext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<ClientDTO> Update(int id, ClientCreationDTO model)
        {
            try 
            { 
                var client = await _dbcontext.Clients.Where(c=> c.Id == id).FirstOrDefaultAsync();

                if(client == null) throw new NotFoundException();

                client.TaxCode = model.TaxCode;

                _dbcontext.Update(client);

                await _dbcontext.SaveChangesAsync();

                return mapper.Map<ClientDTO>(client);

            }catch (Exception) 
            {
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var datos = await _dbcontext.Clients.Where(c => c.Id == id).FirstOrDefaultAsync();

                if (datos == null) throw new NotFoundException();

                _dbcontext.Remove(datos);

                await _dbcontext.SaveChangesAsync();

                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ClientDTO> Insert(ClientCreationDTO model)
        {
            try 
            {
                var client = mapper.Map<Client>(model);
                _dbcontext.Add(client);
                await _dbcontext.SaveChangesAsync();

                return mapper.Map<ClientDTO>(client);
            
            } catch (Exception) 
            { 
               throw; 
            
            }
            
        }

        public async Task<ClientDTO> GetByID(int id)
        {
            var client = await _dbcontext.Clients.Where(c=> c.Id == id).FirstOrDefaultAsync();

            if (client == null)throw new NotFoundException();
            
            return mapper.Map<ClientDTO>(client);

        }

        public async Task<IQueryable<Client>> GetAll()
        {
            try
            {
                IQueryable<Client> queryClient = _dbcontext.Clients;
                return queryClient;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
