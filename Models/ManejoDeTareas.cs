namespace EspacioTarea
{
    public class ManejoDeTareas
    {
        AccesoADatos accesoADatos;
        public ManejoDeTareas(AccesoADatos accesoADatos)
        {
            this.accesoADatos = accesoADatos;
        }

        // Metodos
        public Tarea AgregarTarea(Tarea t)
        {
            var listaTareas = accesoADatos.Obtener();
            if (listaTareas == null)
            {
                listaTareas = new();
            }
            t.Id = listaTareas.Count()+1;
            listaTareas.Add(t);
            accesoADatos.Guardar(listaTareas);
            return t;
        }
        public Tarea GetTareaPorId(int id)
        {
            var listaTareas = accesoADatos.Obtener();
            Tarea buscada = listaTareas.FirstOrDefault(t => t.Id == id);
            return buscada;
        }
        public Tarea ActualizarTarea(Tarea tareaActualizada)
        {
            var listaTareas = accesoADatos.Obtener();
            Tarea buscada = listaTareas.FirstOrDefault(t => t.Id == tareaActualizada.Id);
            buscada.Id = tareaActualizada.Id;
            buscada.Titulo = tareaActualizada.Titulo;
            buscada.Descripcion = tareaActualizada.Descripcion;
            buscada.Estado = tareaActualizada.Estado;
            accesoADatos.Guardar(listaTareas);
            return buscada;
        }
        public List<Tarea> EliminarTarea(int idTarea)
        {
            var listaTareas = accesoADatos.Obtener();
            Tarea buscada = listaTareas.FirstOrDefault(t => t.Id == idTarea);
            listaTareas.Remove(buscada);
            accesoADatos.Guardar(listaTareas);
            return listaTareas;
        }
        public List<Tarea> GetListadoTareas()
        {
            var listaTareas = accesoADatos.Obtener();
            return listaTareas;
        }
        public List<Tarea> GetListadoTareasCompletadas()
        {
            var listaTareas = accesoADatos.Obtener();
            var tareasCompletadas = listaTareas.FindAll(t => t.Estado == Estado.Completada);
            return tareasCompletadas;
        }

    }
}