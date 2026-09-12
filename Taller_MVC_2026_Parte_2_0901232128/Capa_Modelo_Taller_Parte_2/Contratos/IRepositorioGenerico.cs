using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Taller_Parte_2.Contratos
{
    public interface IRepositorioGenerico<Entity> where Entity : class
    {
        int Agregar(Entity entidad);
        int Editar(Entity entidad);
        int Remover(Entity entidad);
        IEnumerable<Entity> GetAll();

    }
}
