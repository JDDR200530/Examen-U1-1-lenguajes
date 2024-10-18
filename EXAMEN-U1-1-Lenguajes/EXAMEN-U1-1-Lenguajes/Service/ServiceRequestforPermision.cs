using AutoMapper;
using EXAMEN_U1_1_Lenguajes.Database;
using EXAMEN_U1_1_Lenguajes.Database.Dto.Common;
using EXAMEN_U1_1_Lenguajes.Database.Dto.Empleados;
using EXAMEN_U1_1_Lenguajes.Database.Dto.Request_for_Permission;
using EXAMEN_U1_1_Lenguajes.Entity;
using EXAMEN_U1_1_Lenguajes.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace EXAMEN_U1_1_Lenguajes.Service
{
    public class ServiceRequestforPermision : IServiceRequestforPermision
    {
        private readonly RequestforPermitsDbContext context;
        private readonly ILogger<ServiceRequestforPermision> logger;
        private readonly IMapper mapper;

        public ServiceRequestforPermision(RequestforPermitsDbContext context, ILogger<ServiceRequestforPermision> logger, IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
        }


        public async Task<ResponseDto<List<RequestforPermisionDto>>> GetPermisionListByIdAsync(Guid id)
        {
            var empleado = await context.Empleados.FirstOrDefaultAsync(e => e.id_empleado == id);

            if (empleado != null)
            {
                var permisosEmpleado = await context.Permissions
                    .Where(p => p.id_empleado == id)
                    .ToListAsync();

                var permisosDtos = mapper.Map<List<RequestforPermisionDto>>(permisosEmpleado);

                return new ResponseDto<List<RequestforPermisionDto>>
                {
                    StatusCode = 200,
                    Status = true,
                    Message = $"Permisos para el empleado con ID {id}",
                    Data = permisosDtos
                };
            }

            var administrador = await context.Administraitors.FirstOrDefaultAsync(a => a.Id == id);

            if (administrador != null)
            {
                var permisosAdmin = await context.Permissions.ToListAsync();
                var permisosDtos = mapper.Map<List<RequestforPermisionDto>>(permisosAdmin);

                return new ResponseDto<List<RequestforPermisionDto>>
                {
                    StatusCode = 200,
                    Status = true,
                    Message = "Todas las solicitudes para el administrador",
                    Data = permisosDtos
                };
            }

            return new ResponseDto<List<RequestforPermisionDto>>
            {
                StatusCode = 404,
                Status = false,
                Message = $"No se encontró ningún empleado o administrador con ID {id}"
            };
        }

        public async Task<ResponseDto<RequestforPermisionDto>> CreateAsync(RequestforPermisionCreateDto dto)
        {
            var PermisoEntity = mapper.Map<PermisosEntity>(dto);
            PermisoEntity.Id_P = Guid.NewGuid();

            context.Permissions.Add(PermisoEntity);

            await context.SaveChangesAsync();

            var empleadoDto = mapper.Map<RequestforPermisionDto>(PermisoEntity);

            return new ResponseDto<RequestforPermisionDto>
            {
                StatusCode = 201,
                Status = true,
                Message = "El permiso se ha creado correctamente",
                Data = empleadoDto,
            };
        }

        public async Task<ResponseDto<RequestforPermisionDto>> EditAsync(RequestforPermisionEditDto dto, Guid id)
        {
            var PermisoEntity = await context.Permissions.FirstOrDefaultAsync(o => o.Id_P == id);
            if (PermisoEntity == null)
            {
                return new ResponseDto<RequestforPermisionDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = $"El permiso con ID {id} no fue encontrado"
                };
            }


            PermisoEntity = mapper.Map(dto, PermisoEntity);

            context.Permissions.Update(PermisoEntity);
            await context.SaveChangesAsync();

            var permisoDto = mapper.Map<RequestforPermisionDto>(PermisoEntity);

            return new ResponseDto<RequestforPermisionDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "El permiso ha sido editado correctamente",
                Data = permisoDto,
            };
        }

        public async Task<ResponseDto<RequestforPermisionDto>> DeleteAsync(Guid id)
        {
            var permisoEntity = await context.Permissions.FirstOrDefaultAsync(o => o.Id_P == id);
            if (permisoEntity == null)
            {
                return new ResponseDto<RequestforPermisionDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = $"El permiso con ID {id} no fue encontrado"
                };
            }

            context.Permissions.Remove(permisoEntity);
            await context.SaveChangesAsync();

            return new ResponseDto<RequestforPermisionDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "El permiso ha sido borrado correctamente"
            };
        }


     

        public Task<ResponseDto<string>> ValidatePermisionAsync(Guid adminId, Guid permissionId, bool isValid)
        {
            throw new NotImplementedException();
        }
    }
}