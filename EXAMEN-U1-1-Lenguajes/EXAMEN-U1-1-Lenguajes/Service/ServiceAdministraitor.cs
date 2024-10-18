using AutoMapper;
using EXAMEN_U1_1_Lenguajes.Database;
using EXAMEN_U1_1_Lenguajes.Database.Dto.Administraitor;
using EXAMEN_U1_1_Lenguajes.Database.Dto.Common;
using EXAMEN_U1_1_Lenguajes.Database.Dto.Empleados;
using EXAMEN_U1_1_Lenguajes.Entity;
using EXAMEN_U1_1_Lenguajes.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace EXAMEN_U1_1_Lenguajes.Service
{
    public class ServiceAdministraitor : IServiceAdministraitor
    {
        private readonly RequestforPermitsDbContext context;
        private readonly ILogger<ServiceAdministraitor> logger;
        private readonly IMapper mapper;

        public ServiceAdministraitor(RequestforPermitsDbContext context, ILogger<ServiceAdministraitor> logger, IMapper mapper)
        {

            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<ResponseDto<List<AdministraitorDto>>> GetAdministradorListAsync() 
        {
            var administrador = await context.Administraitors.ToListAsync();
            var administradoDtos = mapper.Map< List < AdministraitorDto >> (administrador);
            return new ResponseDto<List<AdministraitorDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Lista de Administradores",
                Data = administradoDtos,
            };
        }

        public async Task<ResponseDto<AdministraitorDto>> GetByIdAsynsc(Guid id) 
        {
            try
            {
                var administradorEntity = await context.Administraitors.FirstOrDefaultAsync(o => o.Id == id);
                if (administradorEntity == null)
                {
                    return new ResponseDto<AdministraitorDto>
                    {
                        StatusCode = 404,
                        Status = false,
                        Message = $"El registro {id} no fue encontrado"
                    };
                }
                var administradoDto = mapper.Map<AdministraitorDto>(administradorEntity);
                return new ResponseDto<AdministraitorDto>
                {
                    StatusCode = 200,
                    Status = true,
                    Message = "Registro Encontrado",
                    Data = administradoDto,
                };

            }
          
            catch (Exception ex) 
            {
                logger.LogError(ex, "Error al obtener el Id");
                return new ResponseDto<AdministraitorDto>
                {
                    StatusCode = 500,
                    Status = false,
                    Message = $"Se produjo un error al obtener Id"
                };
            }
        }
        public async Task<ResponseDto<AdministraitorDto>> CreateAsync(AdministraitorDto dto)
        {
            var empleadoEntity = mapper.Map<AdministraitorEntity>(dto);
            empleadoEntity.Id = new Guid();

            context.Administraitors.Add(empleadoEntity);

            //Guardar los cambios realizados
            await context.SaveChangesAsync();

            var empleadoDto = mapper.Map<AdministraitorDto>(empleadoEntity);

            return new ResponseDto<AdministraitorDto>
            {
                StatusCode = 201,
                Status = true,
                Message = "El Empleado se a creado correctamente",
                Data = empleadoDto,
            };
        }
        public async Task<ResponseDto<AdministraitorDto>> EditAsync(AdministraitorEditDto dto, Guid id)
        {
            var administradorEntity = await context.Administraitors.FirstOrDefaultAsync(o => o.Id == id);
            if (administradorEntity == null)
            {
                return new ResponseDto<AdministraitorDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = $"El empleado {id} no fue encontrado"
                };
            }
            context.Administraitors.Update(administradorEntity);
            await context.SaveChangesAsync();
            var administradorDto = mapper.Map<AdministraitorDto>(administradorEntity);
            return new ResponseDto<AdministraitorDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "El empleado sea editado correctamente",
                Data = administradorDto,
            };
        }

        public async Task<ResponseDto<AdministraitorDto>> DeleteAsync(Guid id)
        {
            var administradorEntity = await context.Administraitors.FirstOrDefaultAsync(o => o.Id == id);
            if (administradorEntity == null)
            {
                return new ResponseDto<AdministraitorDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = $"El empleado {id} no fue encontrado"
                };
            }
            context.Administraitors.Remove(administradorEntity);
            await context.SaveChangesAsync();
            return new ResponseDto<AdministraitorDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "El empleado se a borrado correctamento "
            };
        }

        public Task<ResponseDto<AdministraitorDto>> CreateAsync(AdministraitorCreateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
