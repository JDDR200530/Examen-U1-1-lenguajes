using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EXAMEN_U1_1_Lenguajes.Entity
{
    public class EmpleadoEntity
    {
        [Key]
        [Column("Id")]
        public Guid id_empleado {  get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} del empleado es requerido")]
        [StringLength(50)]
        [Column("Name Employee")]
        public string Name_Empleado { get; set; }
        [Display(Name = "Cargo")]
        [Required(ErrorMessage = ("El {0} del empleado es requerido"))]
        [Column("Post Employee")]
        [ForeignKey(nameof(Name_Empleado))]
        public string Post {  get; set; }

        [Display(Name = "Correo Electronio")]
        [MinLength(11)]
        [Required(ErrorMessage = "El {0} del empleado debe tener al menos {1} caracteres")]
        [StringLength(150)]
        [Column("Mail")]
        public string Email {  get; set; }


        public DateTime Date_of_Admission { get; set; }
        public virtual IEnumerable<Request_for_Permission> Request { get; set; } 


    }
}
