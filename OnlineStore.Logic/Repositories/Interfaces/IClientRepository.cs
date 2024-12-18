using OnlineStore.Logic.Commands.Client.Login;
using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Commands.Client.Create;
using OnlineStrore.Logic.Commands.Client.Update;

namespace OnlineStrore.Logic.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllClientsAsync(IContext context, CancellationToken cancellationToken);

        Task<Client> GetClientAsync(IContext context, Guid id, CancellationToken cancellationToken);

        Task<Client> GetClientByEmailAsync(IContext context, string email, CancellationToken cancellationToken);

        Task<string> CreateClientAsync(IContext context, CreateClientCommand request, CancellationToken cancellationToken);

        Task<string> LoginClientAsync(IContext context, LoginClientCommand request, CancellationToken cancellationtoken);

        Task<Guid> UpdateClientAsync(IContext context, UpdateClientCommand request, CancellationToken cancellationToken);

        Task DeleteClientAsync(IContext context, Guid id, CancellationToken cancellationToken);


    }
}
