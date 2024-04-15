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
        private readonly AplicationDBcontext _context;
        private readonly IMapper mapper;

        public ClientRepository(AplicationDBcontext dbcontext, IMapper mapper)
        {
            _context = dbcontext;
            this.mapper = mapper;
        }

        public async Task<ClientDTO> Update(string id, ClientCreationDTO model)
        {
            try 
            { 
                var client = await _context.Clients.Where(c=> c.Id == id).FirstOrDefaultAsync();

                if(client == null) throw new NotFoundException();

                client.DNI = model.DNI;

                _context.Update(client);

                await _context.SaveChangesAsync();

                return mapper.Map<ClientDTO>(client);

            }catch (Exception) 
            {
                throw;
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                var client = await _context.Clients.Where(c => c.Id == id).FirstOrDefaultAsync();

                if (client == null) throw new NotFoundException();

                _context.Remove(client);

                await _context.SaveChangesAsync();

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
                _context.Add(client);
                await _context.SaveChangesAsync();

                return mapper.Map<ClientDTO>(client);
            
            } catch (Exception) 
            { 
               throw; 
            
            }
            
        }

        public async Task<ClientDTO> GetByID(string id)
        {
            var client = await _context.Clients.Where(c=> c.Id == id).FirstOrDefaultAsync();

            if (client == null)throw new NotFoundException();
            
            return mapper.Map<ClientDTO>(client);

        }

        public async Task<IQueryable<Client>> GetAll()
        {
            try
            {
                IQueryable<Client> queryClient = _context.Clients;
                return queryClient;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
