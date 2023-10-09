namespace EspacioTarea
{
    public class Tarea
    {
        // Campos
        // static int autonumerico = 0;
        int id;
        string titulo;
        string descripcion;
        Estado estado;

        // Constructores
        public Tarea()
        {
        }

        // Propiedades
        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public Estado Estado { get => estado; set => estado = value; }

        // Metodos
        // public int GetAutonumerico(){
        //     return autonumerico;
        // }
        // public void SetAutonumerico(int num){
        //     autonumerico = num;
        // }
    }
    public enum Estado
    {
        Pendiente,
        EnProgreso,
        Completada
    }
}
