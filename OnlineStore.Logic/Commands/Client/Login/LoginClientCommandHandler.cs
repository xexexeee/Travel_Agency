using MediatR;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Logic.Commands.Client.Login
{
    public class LoginClientCommandHandler : IRequestHandler<LoginClientCommand, string>
    {
        private readonly IContext context;
        private readonly IClientRepository clientrepository;

        public LoginClientCommandHandler(IContext context, IClientRepository clientrepository)
        {
            this.context = context;
            this.clientrepository = clientrepository;
        }

        public async Task<string> Handle(LoginClientCommand command, CancellationToken cancellationToken)
        {
            var token = await clientrepository.LoginClientAsync(context, command, cancellationToken);
            return token;
        }
    }
}
