using APIClientes.Data;
using APIClientes.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace APIClientes.Repositorio
{
    public class UserRepositorio : IUserRepositorio
    {
        private readonly ApplicationDbContextcs _db;

        public UserRepositorio(ApplicationDbContextcs db)
        {
            _db = db;
        }

        public Task<string> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Register(User user, string password)
        {
            try
            {
                if (await UserExiste(user.UserName))
                {
                    return -1;
                }

                CrearPasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt); //encriptar la clave

                user.PassWordHash = passwordHash;
                user.PassWordSalt = passwordSalt;

                await _db.Users.AddAsync(user);
                await _db.SaveChangesAsync();
                return user.Id;
                
            }
            catch (Exception)
            {

                return -500;
            }
        }

        public async Task<bool> UserExiste(string username)
        {
            if (await _db.Users.AnyAsync(x=> x.UserName.ToLower().Equals(username.ToLower())))
            {
                return true;

            }
            return false;
        }

        private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }
    }
}
