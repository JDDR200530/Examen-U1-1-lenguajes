using AutoMapper;
using EXAMEN_U1_1_Lenguajes.Database.Dto.Empleados;
using EXAMEN_U1_1_Lenguajes.Entity;
using System.Security.AccessControl;

namespace EXAMEN_U1_1_Lenguajes.Database.Dto.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapsForEmpleados();
        }

        private void MapsForEmpleados()
        {
            CreateMap<EmpleadoEntity, EmpleadoDto>();
            CreateMap<EmpleadoCreateDto, EmpleadoEntity>();
            CreateMap<EmpleadoEditDto, EmpleadoEntity>();

        }
    }
}
