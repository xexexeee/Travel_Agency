using OnlineStore.Logic.Commands.Feedback;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Logic.Repositories.Interfaces
{
    public interface IFeedbackRepository
    {
        public Task<Guid> CreateAsync(IContext context, CreateFeedbackCommand request,  CancellationToken cancellationToken);
    }
}
