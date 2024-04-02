using AutoMapper;
using eventPlannerBack.API.Exceptions;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.DAL.Dbcontext;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.VModels.DatosDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.DAL.Repository
{
    public class DataRepository:IGenericRepository<DataCreationDTO, DataDTO, Data>
    {
        private readonly AplicationDBcontext _dbcontext;
        private readonly IMapper mapper;

        public DataRepository(AplicationDBcontext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<DataDTO> Update(int id, DataCreationDTO model)
        {
            try 
            { 
                var data = await _dbcontext.Data.Where(c=> c.Id == id).FirstOrDefaultAsync();

                if(data == null) throw new NotFoundException();

                data.Name = model.Name;

                data.Surname = model.Surname;

                data.Adress = model.Adress;              

                data.DNI = model.DNI;

                data.Phone = model.Phone;            
               
                _dbcontext.Update(data);

                await _dbcontext.SaveChangesAsync();

                return mapper.Map<DataDTO>(data);

            }catch (Exception) 
            {
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var datos = await _dbcontext.Data.Where(c => c.Id == id).FirstOrDefaultAsync();

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

        public async Task<DataDTO> Insert(DataCreationDTO model)
        {
            try 
            {
                var data = mapper.Map<Data>(model);
                _dbcontext.Add(data);
                await _dbcontext.SaveChangesAsync();

                return mapper.Map<DataDTO>(data);
            
            } catch (Exception) 
            { 
               throw; 
            
            }
            
        }

        public async Task<DataDTO> GetByID(int id)
        {
            var data = await _dbcontext.Data.Where(c=> c.Id == id).FirstOrDefaultAsync();

            if (data == null)throw new NotFoundException();
            
            return mapper.Map<DataDTO>(data);

        }

        public async Task<IQueryable<Data>> GetAll()
        {
            try
            {
                IQueryable<Data> queryData = _dbcontext.Data;
                return queryData;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
