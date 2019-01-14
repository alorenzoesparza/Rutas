namespace Rutas.Common.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(40, ErrorMessage = "El campo{0} debe tener como máximo {1} caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(140, ErrorMessage = "El campo{0} debe tener como máximo {1} caracteres")]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        ////[Required(ErrorMessage = "El campo {0} es obligatorio")]
        //[DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        //public decimal Precio { get; set; }

        [Display(Name = "Está activo")]
        public bool EsActivo { get; set; }

        ////[Required(ErrorMessage = "El campo {0} es obligatorio")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Fecha de Alta")]
        //public DateTime? FechaAlta { get; set; }
        [NotMapped]
        [Display(Name = "Nombre")]
        public string NombreCompleto
        {
            get
            {
                return $"{Apellidos}, {Nombre}";
            }
        }
    }
}
