using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv:Vehiculo
    {

        /// <summary>
        /// SUV son 'Grande'
        /// </summary>
        /// <returns></returns>

        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }

        /// <summary>
        /// Muestra un Suv
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            return base.Mostrar();
        }

        /// <summary>
        /// Constructor parametrizado de Suv
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
      

       
    }
}
