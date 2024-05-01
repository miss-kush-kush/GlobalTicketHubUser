using DLL.Dtos.FeedbackDtos;
using Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Mapper
{
    public static class FeedbackMapper
    {
        public static FeedbackDto ToFeedbackDto(this Feedback FeedbackModel)
        {
            return new FeedbackDto
            {
                Id = FeedbackModel.Id,
                UserId = FeedbackModel.UserId,
                FirstName = FeedbackModel.User.FirstName,
                LastName = FeedbackModel.User.LastName,
                Comment = FeedbackModel.Comment,
                Rating = FeedbackModel.Rating,
                DatePosted = FeedbackModel.DatePosted,
            };
        }

        
    }
}
