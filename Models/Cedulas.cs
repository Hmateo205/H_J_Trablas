using System.ComponentModel.DataAnnotations;

namespace H_J_Trablas.Models
{
    public class Cedulas
    {public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }
        
        [Required]
        public string? Cedula { get; set; }

        public bool Soltero { get; set; }

        public bool Casado {  get; set; }

        [Required]
        public string? Hijos { get; set; }
    }
}
