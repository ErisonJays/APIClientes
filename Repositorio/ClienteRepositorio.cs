using APIClientes.Data;
using APIClientes.Modelos;
using APIClientes.Modelos.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace APIClientes.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio   //Hederar de la interfaz | los metodos se crean de manera automatica solo hay que modificarlos
    {
        private readonly ApplicationDbContextcs _db;
        private IMapper _mapper;
        public ClienteRepositorio(ApplicationDbContextcs db, IMapper mapper) //constructor
        {
            _db = db;
            _mapper = mapper;
        }
        
        public async Task<ClienteDto> CreateUpdate(ClienteDto clienteDto)
        {
            Cliente cliente = _mapper.Map<ClienteDto, Cliente>(clienteDto);

            if(cliente.Id > 0)
            {
                _db.Clientes.Update(cliente);
            }
            else
            {
                await _db.Clientes.AddAsync(cliente);
            }

            await _db.SaveChangesAsync();
            return _mapper.Map<Cliente, ClienteDto>(cliente);
        }

        public async Task<bool> DeleteCliente(int id)
        {
            try
            {
               Cliente cliente = await _db.Clientes.FindAsync(id);
                

                if (cliente == null)             {
                   return false;
                }
                _db.Clientes.Remove(cliente);
                await _db.SaveChangesAsync();

                return true;
                
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<ClienteDto> GetClienteById(int id)
        {
            Cliente cliente = await _db.Clientes.FindAsync(id);

            return _mapper.Map<ClienteDto>(cliente);
        }

        public async Task<List<ClienteDto>> GetClienteDtos()
        {
            List<Cliente> lista = await _db.Clientes.ToListAsync();

            return _mapper.Map<List<ClienteDto>>(lista); //mapear la lista de tipo cliente a clienteDto
        }
    }
}
