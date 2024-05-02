using eventPlannerBack.Models.Entities;
using eventPlannerBack.Models.VModels.ImagesDTO;

namespace eventPlannerBack.DAL.Interfaces
{
    public interface IImageEventRepository
    {
        Task<ImageEvent> Create(ImageEvent image);
    }
}
