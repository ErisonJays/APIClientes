using APIClientes.Modelos.Dto;

namespace APIClientes.Repositorio
{
    public interface IClienteRepositorio
    {
        Task<List<ClienteDto>> GetClienteDtos();
        Task<ClienteDto> GetClienteById(int id);

        Task<ClienteDto> CreateUpdate(ClienteDto clienteDto);

        Task<bool> DeleteCliente(int id);
    }
}
