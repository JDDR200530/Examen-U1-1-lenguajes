using EXAMEN_U1_1_Lenguajes.Database.Dto.Common;
using EXAMEN_U1_1_Lenguajes.Database.Dto.Empleados;
using EXAMEN_U1_1_Lenguajes.Entity;
using EXAMEN_U1_1_Lenguajes.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EXAMEN_U1_1_Lenguajes.Controllers
{
    public class EmpleadoController : ControllerBase
    {
        private List<EmpleadoEntity> empleados;
        private readonly IServiceEmpleados serviceEmpleados;

        public EmpleadoController(IServiceEmpleados serviceEmpleados)
        {
            this.serviceEmpleados = serviceEmpleados;
        }
        [HttpGet]

        public async Task<ActionResult<ResponseDto<List<EmpleadoDto>>>> GetAll()
        {
            var response = await serviceEmpleados.GetEmpleadoListAsync();
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<List<EmpleadoDto>>>> Get(Guid id)
        {
            var response = await serviceEmpleados.GetByIdAsynsc(id);
            return StatusCode(response.StatusCode, response);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<List<EmpleadoDto>>>> Edit(EmpleadoEditDto dto, Guid id) 
        {
            var response = await serviceEmpleados.EditAsync(dto, id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult>Delete(Guid id)
        {
            var response = await serviceEmpleados.DeleteAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
