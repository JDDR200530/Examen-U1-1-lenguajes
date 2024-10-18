using EXAMEN_U1_1_Lenguajes.Database.Dto.Common;
using EXAMEN_U1_1_Lenguajes.Database.Dto.Empleados;
using EXAMEN_U1_1_Lenguajes.Database.Dto.Request_for_Permission;
using EXAMEN_U1_1_Lenguajes.Entity;
using EXAMEN_U1_1_Lenguajes.Service;
using EXAMEN_U1_1_Lenguajes.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EXAMEN_U1_1_Lenguajes.Controllers
{
 

        [ApiController]
        [Route("api/[controller]")]
        public class PermisoController : ControllerBase

        {
        private List<PermisosEntity> permisos;
        private readonly IServiceRequestforPermision _serviceRequestforPermision;

            public PermisoController(IServiceRequestforPermision serviceRequestforPermision)
            {
                _serviceRequestforPermision = serviceRequestforPermision;
            }

            // Método HTTP GET para obtener permisos por ID
            [HttpGet("{id}")]
            public async Task<IActionResult> GetPermisionListById(Guid id)
            {
                var result = await _serviceRequestforPermision.GetPermisionListByIdAsync(id);
                if (!result.Status)
                {
                    return NotFound(result.Message);
                }

                return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<RequestforPermisionDto>>> Create(RequestforPermisionCreateDto dto)
        {
            var response = await _serviceRequestforPermision.CreateAsync(dto);
            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
                response.Data
            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<List<RequestforPermisionDto>>>> Edit(RequestforPermisionEditDto dto, Guid id)
        {
            var response = await _serviceRequestforPermision.EditAsync(dto, id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var response = await _serviceRequestforPermision.DeleteAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
 
}
