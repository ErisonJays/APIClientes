namespace APIClientes.Modelos.Dto
{
    public class UserDto
    {
        //no le pasaremos el passwordHash ni el passwordSalt del modelo cliente, esos campos son para encriptar la clave
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
