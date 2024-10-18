using System.ComponentModel.DataAnnotations.Schema;

namespace EXAMEN_U1_1_Lenguajes.Database.Dto.Request_for_Permission
{
    public class RequestforPermisionEditDto
    {

        public string type_of_permit { get; set; }

        public string Reason { get; set; }
    }
}
