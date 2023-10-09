using EspacioTarea;
using Microsoft.AspNetCore.Mvc;

namespace tl2_tp07_2023_LucianoCV01.Controllers;

[ApiController]
[Route("[controller]")]
public class TareaController : ControllerBase
{
    private ManejoDeTareas manejoDeTareas;
    private readonly ILogger<TareaController> _logger;

    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        AccesoADatos accesoADatos = new();
        manejoDeTareas = new(accesoADatos);
    }

    [HttpPost("AgregarTarea")]
    public ActionResult<Tarea> AgregarTarea(Tarea t)
    {
        var nuevaTarea = manejoDeTareas.AgregarTarea(t);
        return Ok(nuevaTarea);
    }
    [HttpGet]
    [Route("GetTareaPorId")]
    public ActionResult<Tarea> GetTareaPorId(int id)
    {
        var tareaBuscada = manejoDeTareas.GetTareaPorId(id);
        return Ok(tareaBuscada);
    }
    [HttpPut("ActualizarTarea")]
    public ActionResult<Tarea> ActualizarTarea(Tarea tareaActualizada)
    {
        var tareaAct = manejoDeTareas.ActualizarTarea(tareaActualizada);
        return Ok(tareaAct);
    }
    [HttpDelete("EliminarTarea")]
    public ActionResult<List<Tarea>> EliminarTarea(int idTarea)
    {
        var listaTareas = manejoDeTareas.EliminarTarea(idTarea);
        return Ok(listaTareas);
    }
    [HttpGet]
    [Route("GetListadoTareas")]
    public ActionResult<List<Tarea>> GetListadoTareas()
    {
        var listaTareas = manejoDeTareas.GetListadoTareas();
        return Ok(listaTareas);
    }
    [HttpGet]
    [Route("GetListadoTareasCompletadas")]
    public ActionResult<List<Tarea>> GetListadoTareasCompletadas()
    {
        var listaTareas = manejoDeTareas.GetListadoTareasCompletadas();
        return Ok(listaTareas);
    }
}