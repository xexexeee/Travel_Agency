using FluentValidation;
using MediatR;
using OnlineStore.Logic.Repositories.Interfaces;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Logic.Commands.Feedback
{
    public class CreateFeedbackCommand : IRequest<Guid>
    {
        public string Name {  get; set; }
        public string Description { get; set; }
    }
    public class CreateFeedbackCommandValidate : AbstractValidator<CreateFeedbackCommand>
    {
        public CreateFeedbackCommandValidate()
        {
            RuleFor(req => req.Name).NotEmpty().MaximumLength(255);
            RuleFor(req => req.Description).NotEmpty().MaximumLength(500).WithMessage("Maximum length is 500 symbols");
        }

    }
    public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, Guid>
    {
        private readonly IContext context;
        private readonly IFeedbackRepository feedbackRepository;

        public CreateFeedbackCommandHandler(IContext context, IFeedbackRepository feedbackRepository)
        {
            this.context = context;
            this.feedbackRepository = feedbackRepository;
        }

        public async Task<Guid> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var id = await feedbackRepository.CreateAsync(context, request, cancellationToken);
            return id;
        }
    }
}
