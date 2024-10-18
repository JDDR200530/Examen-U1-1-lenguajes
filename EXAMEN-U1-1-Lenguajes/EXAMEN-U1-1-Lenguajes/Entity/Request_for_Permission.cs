using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace EXAMEN_U1_1_Lenguajes.Entity
{
    public class Request_for_Permission
    {
        public Guid Id { get; set; }

        public Guid id_empleado { get; set; }
        [ForeignKey(nameof(id_empleado))]

        public string Name_Empleado {  get; set; }
        [ForeignKey(nameof(Name_Empleado))]

        public string type_of_permit { get; set; }

        public DateTime Start_Date { get; set; }

        public DateTime End_Date { get; set; }
  
        public string Reason { get; set; }

        public string State {  get; set; }
 
    }
}
