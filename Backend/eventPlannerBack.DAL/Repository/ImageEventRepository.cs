using eventPlannerBack.DAL.Dbcontext;
using eventPlannerBack.DAL.Interfaces;
using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.VModels.EventsDTO;
using eventPlannerBack.Models.VModels.ImagesDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPlannerBack.DAL.Repository
{
    public class ImageEventRepository : IImageEventRepository
    {
        private readonly AplicationDBcontext _dbcontext;
        public ImageEventRepository(AplicationDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<ImageEvent> Create(ImageEvent image)
        {
            try
            {
                _dbcontext.Add(image);
                await _dbcontext.SaveChangesAsync();
                return image;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
