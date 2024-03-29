﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {

        /// <summary>
        /// Ciclomotor son 'Chico'
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }

        }

        /// <summary>
        /// Constructor parametrizado de Ciclomotor
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color):base(chasis,marca,color)
        {
        }
      
        /// <summary>
        /// Muestra un Ciclomotor
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            //PUESTO PARA RESPETAR ESQUEMA
            return base.Mostrar();
        }
    }
}
