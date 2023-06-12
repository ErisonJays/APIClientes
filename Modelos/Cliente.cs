using System.ComponentModel.DataAnnotations;

namespace APIClientes.Modelos
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombres { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        public string Direcciones { get; set; }

        [Required]
        public string Telefono { get; set; }


    }
}
