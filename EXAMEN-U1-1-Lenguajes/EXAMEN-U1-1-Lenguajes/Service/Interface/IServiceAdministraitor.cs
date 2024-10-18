using EXAMEN_U1_1_Lenguajes.Database.Dto.Administraitor;
using EXAMEN_U1_1_Lenguajes.Database.Dto.Common;

namespace EXAMEN_U1_1_Lenguajes.Service.Interface
{
    public interface IServiceAdministraitor
    {
        Task<ResponseDto<AdministraitorDto>> CreateAsync(AdministraitorCreateDto dto);
        Task<ResponseDto<AdministraitorDto>> DeleteAsync(Guid id);
        Task<ResponseDto<AdministraitorDto>> EditAsync(AdministraitorEditDto dto, Guid id);
        Task<ResponseDto<List<AdministraitorDto>>> GetAdministradorListAsync();
        Task<ResponseDto<AdministraitorDto>> GetByIdAsynsc(Guid id);
    }
}
