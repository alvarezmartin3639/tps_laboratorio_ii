using Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Extension
{
    public static class ListExtension
    {
        public static List<Atencion> OrganizarListaDeAtenciones(this List<Atencion> lista)
        {
            return lista.GroupBy((x) => x.IdDeAtencion).Select((y) => y.First()).ToList();
        }

    }
}
