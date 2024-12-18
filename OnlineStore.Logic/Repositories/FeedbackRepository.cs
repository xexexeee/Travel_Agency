using OnlineStore.Logic.Commands.Feedback;
using OnlineStore.Logic.Repositories.Interfaces;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStore.Storage.MS_SQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Logic.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public async Task<Guid> CreateAsync(IContext context, CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            Guid id = Guid.NewGuid();
            var feedback = new Feedback()
            {
                Name = request.Name,
                Description = request.Description,
            };
            await context.Feedbacks.AddAsync(feedback, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return id;
        }
    }
}
