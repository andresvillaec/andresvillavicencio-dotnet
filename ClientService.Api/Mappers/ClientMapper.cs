using ClientService.Api.Dtos;
using ClientService.Api.Mappers.Interfaces;
using ClientService.Api.Models;

namespace ClientService.Api.Mappers
{
    public class ClientMapper : IClientMapper
    {
        public Client ParseToClient(ClientDto clientDto)
        {
            return new Client
            {
                Id = clientDto.Id,
                DocumentNumber = clientDto.DocumentNumber,
                Name = clientDto.Name,
                Address = clientDto.Address,
                Age = clientDto.Age,
                Gender = clientDto.Gender,
                Password = clientDto.Password,
                Phone = clientDto.Phone,
                Status = clientDto.Status,
            };
        }

        public ClientDto ParseToClientDto(Client client)
        {
            return new ClientDto
            {
                Id= client.Id,
                DocumentNumber = client.DocumentNumber,
                Name = client.Name,
                Address = client.Address,
                Age = client.Age,
                Gender = client.Gender,
                Password = client.Password,
                Phone = client.Phone,
                Status = client.Status,
            };
        }
    }
}
