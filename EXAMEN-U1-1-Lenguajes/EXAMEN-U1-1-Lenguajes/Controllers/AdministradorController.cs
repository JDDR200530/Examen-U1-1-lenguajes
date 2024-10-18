using EXAMEN_U1_1_Lenguajes.Database.Dto.Administraitor;
using EXAMEN_U1_1_Lenguajes.Database.Dto.Common;
using EXAMEN_U1_1_Lenguajes.Database.Dto.Empleados;
using EXAMEN_U1_1_Lenguajes.Entity;
using EXAMEN_U1_1_Lenguajes.Service;
using EXAMEN_U1_1_Lenguajes.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EXAMEN_U1_1_Lenguajes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdministradorController : ControllerBase
    {
        private List<AdministraitorEntity> administraitors;
        private readonly IServiceAdministraitor serviceAdministraitor;

        public AdministradorController(IServiceAdministraitor serviceAdministraitor)
        {
            this.serviceAdministraitor = serviceAdministraitor;
        }
        [HttpGet]

        public async Task<ActionResult<ResponseDto<List<AdministraitorDto>>>> GetAll()
        {
            var response = await serviceAdministraitor.GetAdministradorListAsync();
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<List<AdministraitorDto>>>> Get(Guid id)
        {
            var response = await serviceAdministraitor.GetByIdAsynsc(id);
            return StatusCode(response.StatusCode, response);

        }
        [HttpPost]
        public async Task<ActionResult<ResponseDto<AdministraitorDto>>> Create(AdministraitorCreateDto dto)
        {
            var response = await serviceAdministraitor.CreateAsync(dto);
            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
                response.Data
            });
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<List<AdministraitorDto>>>> Edit( AdministraitorEditDto dto, Guid id)
        {
            var response = await serviceAdministraitor.EditAsync(dto, id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var response = await serviceAdministraitor.DeleteAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
