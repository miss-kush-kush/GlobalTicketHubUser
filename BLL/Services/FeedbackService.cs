using BLL.Interfaces;
using DLL.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.UserEntities;

namespace BLL.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly AppDbContext _context;
        public FeedbackService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Feedback>> GetAllAsync()
        {
            return await _context.Feedbacks.ToListAsync();
        }
        public async Task<Feedback> SaveFeedbackAsync(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return feedback;
        }
    }
}
