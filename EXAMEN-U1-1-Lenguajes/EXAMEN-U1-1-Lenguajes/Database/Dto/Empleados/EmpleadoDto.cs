namespace EXAMEN_U1_1_Lenguajes.Database.Dto.Empleados
{
    public class EmpleadoDto
    {
        public Guid id_empleado { get; set; }

        public string Name_Empleado { get; set; }

        public string Post { get; set; }

        public string Email { get; set; }

        public DateTime Date_of_Admission { get; set; }

    }
}
