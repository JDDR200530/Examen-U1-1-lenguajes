using EXAMEN_U1_1_Lenguajes.Database.Dto.Common;
using EXAMEN_U1_1_Lenguajes.Database.Dto.Request_for_Permission;

namespace EXAMEN_U1_1_Lenguajes.Service.Interface
{
    public interface IServiceRequestforPermision
    {
        Task<ResponseDto<RequestforPermisionDto>> CreateAsync(RequestforPermisionCreateDto dto);
        Task<ResponseDto<RequestforPermisionDto>> DeleteAsync(Guid id);
        Task<ResponseDto<RequestforPermisionDto>> EditAsync(RequestforPermisionEditDto dto, Guid id);
        Task<ResponseDto<List<RequestforPermisionDto>>> GetPermisionListByIdAsync(Guid id);
        Task<ResponseDto<string>> ValidatePermisionAsync(Guid adminId, Guid permissionId, bool isValid);
    }
}
