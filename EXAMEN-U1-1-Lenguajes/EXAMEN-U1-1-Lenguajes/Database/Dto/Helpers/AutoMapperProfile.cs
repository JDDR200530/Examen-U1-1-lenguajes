using AutoMapper;
using EXAMEN_U1_1_Lenguajes.Database.Dto.Administraitor;
using EXAMEN_U1_1_Lenguajes.Database.Dto.Empleados;
using EXAMEN_U1_1_Lenguajes.Database.Dto.Request_for_Permission;
using EXAMEN_U1_1_Lenguajes.Entity;
using System.Security.AccessControl;

namespace EXAMEN_U1_1_Lenguajes.Database.Dto.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapsForEmpleados();
            MapsForAdministrador();
            MapsForPermisos();
        }

        private void MapsForEmpleados()
        {
            CreateMap<EmpleadoEntity, EmpleadoDto>();
            CreateMap<EmpleadoCreateDto, EmpleadoEntity>();
            CreateMap<EmpleadoEditDto, EmpleadoEntity>();

        }

        private void MapsForAdministrador()
        {
            CreateMap<AdministraitorEntity, Administraitor.AdministraitorDto>();
            CreateMap<AdministraitorCreateDto, AdministraitorEntity>();
            CreateMap<AdministraitorEditDto, AdministraitorEntity>();
        }

        private void MapsForPermisos()
        {
            CreateMap<PermisosEntity, RequestforPermisionDto>();
            CreateMap<RequestforPermisionCreateDto, PermisosEntity>();
            CreateMap<RequestforPermisionEditDto, PermisosEntity>();
     } 
    }
}
