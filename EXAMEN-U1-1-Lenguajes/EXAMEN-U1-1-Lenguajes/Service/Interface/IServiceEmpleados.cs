using EXAMEN_U1_1_Lenguajes.Database.Dto.Common;
using EXAMEN_U1_1_Lenguajes.Database.Dto.Empleados;

namespace EXAMEN_U1_1_Lenguajes.Service.Interface
{
    public interface IServiceEmpleados
    {
        Task<ResponseDto<EmpleadoDto>> CreateAsync(EmpleadoCreateDto dto);
        Task<ResponseDto<EmpleadoDto>> EditAsync(EmpleadoEditDto dto, Guid id);
        Task<ResponseDto<EmpleadoDto>> GetByIdAsynsc(Guid id);
        Task<ResponseDto<List<EmpleadoDto>>> GetEmpleadoListAsync();
        Task<ResponseDto<EmpleadoDto>> DeleteAsync(Guid id);
    }
}
