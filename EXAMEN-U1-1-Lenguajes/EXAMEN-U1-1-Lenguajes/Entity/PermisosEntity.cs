using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace EXAMEN_U1_1_Lenguajes.Entity
{
    public class PermisosEntity
    {
        [Key]
        [Column("Id")]
        public Guid Id_P { get; set; }
        [Column("Id_Employed")]
        public Guid id_empleado { get; set; }
        [ForeignKey(nameof(id_empleado))]
        [Display(Name = "Name")]
        [Required(ErrorMessage = "El {0} del empleado es requerido")]
        [StringLength(50)]
        [Column("Name_Employed")]
        public string Name_Empleado {  get; set; }
        [ForeignKey(nameof(Name_Empleado))]

        [Display(Name = "Type")]
        [Required(ErrorMessage ="El {0} para el perimiso es requerido")]
        public string type_of_permit { get; set; }

        public DateTime Start_Date { get; set; }

        public DateTime End_Date { get; set; }
  
        public string Reason { get; set; }

        public string State {  get; set; }
        public enum PermissionStatus
        {
            Pending = 0,  
            Accepted = 1, 
            Rejected = 2  
        }

        public PermissionStatus Status { get; set; } = PermissionStatus.Pending;

    }
}
