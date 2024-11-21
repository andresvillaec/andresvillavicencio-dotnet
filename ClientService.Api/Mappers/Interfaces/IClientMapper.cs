using ClientService.Api.Dtos;
using ClientService.Api.Models;

namespace ClientService.Api.Mappers.Interfaces
{
    public interface IClientMapper
    {
        public Client ParseToClient(ClientDto clientDto);

        public ClientDto ParseToClientDto(Client client);
    }
}
