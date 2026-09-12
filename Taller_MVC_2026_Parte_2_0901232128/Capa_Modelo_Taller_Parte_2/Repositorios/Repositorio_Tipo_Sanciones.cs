using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Taller_Parte_2.Contratos;
using Capa_Modelo_Taller_Parte_2.Entidades;

namespace Capa_Modelo_Taller_Parte_2.Repositorios
{
    public class Repositorio_Tipo_Sanciones : RepositorioMaestro, IRepositorioTipoSanciones
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;
        public Repositorio_Tipo_Sanciones()
        {
            selectAll = "SELECT * FROM tipo_sancion";
            insert = "INSERT INTO tipo_sancion values (NULL, ?, ?)";
            update = "UPDATE tipo_sacion SET nombre_tipo=?, descripcion=? WHERE id_tipo_sancion=?";
            delete = "DELETE FROM tipo_sancion WHERE id_tipo_sancion=?";
        }
        public int Agregar(TipoSancion entidad)
        {
            var _parametros = new List<OdbcParameter>();
            _parametros.Add(new OdbcParameter("p_nombre_tipo", entidad.nombre_tipo));
            _parametros.Add(new OdbcParameter("p_descripcion", entidad.descripcion));

            return EjecucionNonQuery(insert, _parametros, CommandType.Text);
        }
        public int Editar(TipoSancion entidad)
        {
            var _parametros = new List<OdbcParameter>();
            _parametros.Add(new OdbcParameter("p_nombre_tipo", entidad.nombre_tipo));
            _parametros.Add(new OdbcParameter("p_descripcion", entidad.descripcion));

            return EjecucionNonQuery(update, _parametros, CommandType.Text);
        }
        public int Remover(TipoSancion entidad)
        {
            var _parametros = new List<OdbcParameter>();
            _parametros.Add(new OdbcParameter("p_id_tipo_sancion", entidad.id_tipo_sancion));

            return EjecucionNonQuery(delete, _parametros, CommandType.Text);
        }
        public IEnumerable<TipoSancion> GetAll()
        {
            var lstTipoSancion = new List<TipoSancion>();
            var tblTabla = EjecucionConsulta(selectAll, CommandType.Text);
            foreach (DataRow row in tblTabla.Rows)
            {
                var tipo_sancion = new TipoSancion();
                tipo_sancion.id_tipo_sancion = Convert.ToInt32(row[0]);
                tipo_sancion.nombre_tipo = row[1].ToString();
                tipo_sancion.descripcion = row[2].ToString();
                lstTipoSancion.Add(tipo_sancion);
            }
            tblTabla.Clear();
            tblTabla = null;
            return lstTipoSancion;
        }
    }
}
