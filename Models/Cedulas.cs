using System.ComponentModel.DataAnnotations;

namespace H_J_Trablas.Models
{
    public class Cedulas
    {public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public bool Casado {  get; set; }

        [Range(0,9999.99)]
        public decimal Estado { get; set; }
    }
}
