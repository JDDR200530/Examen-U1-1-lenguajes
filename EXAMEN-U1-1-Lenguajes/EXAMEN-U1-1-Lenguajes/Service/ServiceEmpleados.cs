using AutoMapper;
using EXAMEN_U1_1_Lenguajes.Database;
using EXAMEN_U1_1_Lenguajes.Database.Dto.Common;
using EXAMEN_U1_1_Lenguajes.Database.Dto.Empleados;
using EXAMEN_U1_1_Lenguajes.Entity;
using EXAMEN_U1_1_Lenguajes.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EXAMEN_U1_1_Lenguajes.Service
{
    public class ServiceEmpleado : IServiceEmpleados
    {
        private readonly RequestforPermitsDbContext context;
        private readonly ILogger<ServiceEmpleado> logger;
        private readonly IMapper mapper;

        public ServiceEmpleado(RequestforPermitsDbContext context, ILogger<ServiceEmpleado> logger, IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<ResponseDto<List<EmpleadoDto>>> GetEmpleadoListAsync()
        {
            var empleadosEntity = await context.Empleados.ToListAsync();

            var empleadoDtos = mapper.Map<List<EmpleadoDto>>(empleadosEntity);

            return new ResponseDto<List<EmpleadoDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Lista de Empleados obtenido correctamenta  ",
                Data = empleadoDtos
            };
        }

        public async Task<ResponseDto<EmpleadoDto>> GetByIdAsynsc(Guid id)
        {
            try
            {
                var empleadosEntity = await context.Empleados.FirstOrDefaultAsync(o => o.id_empleado == id);
                if (empleadosEntity == null)
                {
                    return new ResponseDto<EmpleadoDto>
                    {
                        StatusCode = 404,
                        Status = false,
                        Message = $"El registro {id} no fue encontrado"
                    };

                }

                var empleadoDto = mapper.Map<EmpleadoDto>(empleadosEntity);
                return new ResponseDto<EmpleadoDto>
                {
                    StatusCode = 200,
                    Status = true,
                    Message = "Registro encontrado correctamente",
                    Data = empleadoDto,
                };
            }

            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener el pedido por ID");
                return new ResponseDto<EmpleadoDto>
                {
                    StatusCode = 500,
                    Status = false,
                    Message = $"Se produjo un error al obtener el pedido"
                };
            }
        }

        public async Task<ResponseDto<EmpleadoDto>> CreateAsync(EmpleadoCreateDto dto)
        {
            var empleadoEntity = mapper.Map<EmpleadoEntity>(dto);
            empleadoEntity.id_empleado = new Guid();

            context.Empleados.Add(empleadoEntity);

            //Guardar los cambios realizados
            await context.SaveChangesAsync();

            var empleadoDto = mapper.Map<EmpleadoDto>(empleadoEntity);

            return new ResponseDto<EmpleadoDto>
            {
                StatusCode = 201,
                Status = true,
                Message = "El Empleado se a creado correctamente",
                Data = empleadoDto,
            };
        }

        public async Task<ResponseDto<EmpleadoDto>> EditAsync(EmpleadoEditDto dto, Guid id)
        {
            var empleadoEntity = await context.Empleados.FirstOrDefaultAsync(o => o.id_empleado == id);
            if (empleadoEntity == null)
            {
                return new ResponseDto<EmpleadoDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = $"El empleado {id} no fue encontrado"
                };
            }
            context.Empleados.Update(empleadoEntity);
            await context.SaveChangesAsync();
            var empleadoDto = mapper.Map<EmpleadoDto>(empleadoEntity);
            return new ResponseDto<EmpleadoDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "El empleado sea editado correctamente",
                Data = empleadoDto,
            };
        }

        public async Task<ResponseDto<EmpleadoDto>> DeleteAsync(Guid id)
        {
            var empleadoEntity = await context.Empleados.FirstOrDefaultAsync(o =>o.id_empleado==id);
            if (empleadoEntity == null)
            {
                return new ResponseDto<EmpleadoDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = $"El empleado {id} no fue encontrado"
                };
            }
            context.Empleados.Remove(empleadoEntity);
            await context.SaveChangesAsync();
            return new ResponseDto<EmpleadoDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "El empleado se a borrado correctamento "
            };
        }

      
    }
}
