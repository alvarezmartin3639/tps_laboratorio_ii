using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>

    public abstract class Vehiculo

    {
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
       public enum ETamanio
        {
            Chico, Mediano, Grande
        }
       protected EMarca marca;
       protected string chasis;
       protected ConsoleColor color;

        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        public abstract ETamanio Tamanio { get; }

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        /// <summary>
        /// Sobrecarga operador string para retornar los datos del objeto Vehiculo
        /// </summary>
        /// <param name="p">El objeto a mostrar</param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();


            //MUESTRO EL TYPE EN MAYUS, REMOVIENDO LA CADENA 'ENTIDADES.'.
            //SI EL TYPE NO COINCIDE CON EL NOMBRE DE CLASE SE BORRA EN LA DERIVADA CON UN STRING.REMOVE.
            sb.AppendFormat("\n{0}", p.ToString().Remove(0, 10).ToUpper());
            sb.AppendLine("\n---------------------");
            sb.AppendFormat("CHASIS: {0}\r\n", p.chasis);
            sb.AppendFormat("MARCA : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR : {0}\r\n", p.color.ToString());
            sb.AppendLine("---------------------");
            sb.AppendFormat("TAMAÑO : {0}", p.Tamanio);
            sb.AppendLine("\n---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }

        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }

        /// <summary>
        /// Constructor parametrizado de Vehiculo
        /// </summary>
        /// <param name="chasis"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        /// <returns></returns>

        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }

    }
}
