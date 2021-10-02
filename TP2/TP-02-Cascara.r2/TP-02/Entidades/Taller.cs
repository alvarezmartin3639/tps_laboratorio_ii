using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Taller
    {
        private List<Vehiculo> vehiculos;
        private int espacioDisponible;
        public enum ETipo
        {
            Ciclomotor, Sedan, SUV, Todos
        }

        #region "Constructores"
        /// <summary>
        /// Constructor del objeto Taller
        /// </summary>
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }

       /// <summary>
       /// Constructor del objeto Taller
       /// </summary>
       /// <param name="espacioDisponible"> El numero de espacios maximo en la lista</param>
        public Taller(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Listar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public string Listar(Taller taller, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", taller.vehiculos.Count, taller.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in taller.vehiculos)
            {
                //Verifico que el tipo y el enumerado coincidan y lo retorno
                switch (tipo)
                {
                    case ETipo.Ciclomotor:
                        if (v.GetType() == typeof(Ciclomotor))
                        {
                            sb.AppendLine(((Ciclomotor)v).Mostrar());
                        }
                        break;

                    case ETipo.Sedan:
                        if (v.GetType() == typeof(Sedan))
                        {
                            sb.AppendLine(((Sedan)v).Mostrar());
                        }
                        break;

                    case ETipo.SUV:
                        if (v.GetType() == typeof(Suv))
                        {
                            sb.AppendLine(((Suv)v).Mostrar());
                        }
                        break;
                    case ETipo.Todos:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns></returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            //Verifico espacio disponible
            if(taller.vehiculos.Count < taller.espacioDisponible)
            {
                //Recorro lista para evitar duplicados
                foreach (Vehiculo v in taller.vehiculos)
                {
                    if (v == vehiculo)
                    {
                        return taller;
                    }
                }

                taller.vehiculos.Add(vehiculo);
            }

            return taller;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns></returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            
                //Recorro para buscar vehiculo a borrar
                foreach (Vehiculo v in taller.vehiculos)
                {
                    if (v == vehiculo)
                    {
                    taller.vehiculos.Remove(v);
                    break;
                    }
                }

            return taller;
        }
        #endregion
    }
}
