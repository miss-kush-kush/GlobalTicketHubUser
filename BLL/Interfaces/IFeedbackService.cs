using Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFeedbackService
    {
        Task<List<Feedback>> GetAllAsync();
        Task<Feedback> SaveFeedbackAsync(Feedback feedback);
    }
}
