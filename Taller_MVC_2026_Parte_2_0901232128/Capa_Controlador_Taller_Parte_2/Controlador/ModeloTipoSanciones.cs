using Capa_Controlador_Taller_Parte_2.Estados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Taller_Parte_2.Entidades;
using Capa_Modelo_Taller_Parte_2.Repositorios;
using Capa_Modelo_Taller_Parte_2.Contratos;
using System.ComponentModel.DataAnnotations;

namespace Capa_Controlador_Taller_Parte_2.Controlador
{
    public class ModeloTipoSanciones
    {
        private int _id_tipo_sancion;
        private string _nombre_tipo;
        private string _descripcion;
        private IRepositorioTipoSanciones Repositorio_Tipo_Sanciones;

        public EstadoEntidad Estado { private get; set; }
        private List<ModeloTipoSanciones> ListaTipoSanciones;

        public int id_tipo_sancion { get => _id_tipo_sancion; set => _id_tipo_sancion = value; }

        [Required(ErrorMessage = "El campo Nombre debe ser solo letras")]
        [RegularExpression("^[a-zA-Zá-ú ]+$", ErrorMessage = "Numero de identificacion debe ser numerico")]
        public string nombre_tipo { get => _nombre_tipo; set => _nombre_tipo = value; }

        [Required]
        [RegularExpression("^[a-zA-Zá-ú ]+$", ErrorMessage = "El campo Descripcion debe ser solo letras")]
        [StringLength(maximumLength: 500, MinimumLength = 0)]
        public string descripcion { get => _descripcion; set => _descripcion = value; }

        public ModeloTipoSanciones()
        {
            Repositorio_Tipo_Sanciones = new Repositorio_Tipo_Sanciones();

        }
        public string GrabarCambios()
        {
            string mensaje = null;
            try
            {
                var modeloDatosTipoSancion = new TipoSancion();
                modeloDatosTipoSancion.id_tipo_sancion = _id_tipo_sancion;
                modeloDatosTipoSancion.nombre_tipo = _nombre_tipo;
                modeloDatosTipoSancion.descripcion = _descripcion;
                switch (Estado)
                {
                    case EstadoEntidad.Added:
                        Repositorio_Tipo_Sanciones.Agregar(modeloDatosTipoSancion);
                        mensaje = "Grabacion exitosa";
                        break;
                    case EstadoEntidad.Modified:
                        Repositorio_Tipo_Sanciones.Editar(modeloDatosTipoSancion);
                        mensaje = "Actualizacion exitosa";
                        break;
                    case EstadoEntidad.Deleted:
                        Repositorio_Tipo_Sanciones.Remover(modeloDatosTipoSancion);
                        mensaje = "Eliminacion exitosa";
                        break;
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.ToString();
            }
            return mensaje;
        }
        public List<ModeloTipoSanciones> GetAll()
        {
            var modeloDatosTipoSancion = Repositorio_Tipo_Sanciones.GetAll();
            ListaTipoSanciones = new List<ModeloTipoSanciones>();
            foreach (TipoSancion item in modeloDatosTipoSancion)
            {
                ListaTipoSanciones.Add(new ModeloTipoSanciones
                {
                    _id_tipo_sancion = item.id_tipo_sancion,
                    _nombre_tipo = item.nombre_tipo,
                    _descripcion = item.descripcion,
                });
            }
            return ListaTipoSanciones;
        }
        public IEnumerable<ModeloTipoSanciones> FindbyId(string filter)
        {
            return ListaTipoSanciones.FindAll(e => e._nombre_tipo.Contains(filter));
        }
    }
}
