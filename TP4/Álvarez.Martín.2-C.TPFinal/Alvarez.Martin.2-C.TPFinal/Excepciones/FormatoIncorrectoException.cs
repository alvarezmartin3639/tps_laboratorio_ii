using System;

namespace Excepciones
{
    public class FormatoIncorrectoException : Exception
    {
        /// <summary>
        /// Excepción personalizada, se utiliza cuando el usuario utiliza una formato invalido
        /// </summary>
        /// <param name="message">El mensaje a mostrar cuando se captura la excepción</param>
        public FormatoIncorrectoException() : base("Formato incorrecto, lo ingresado no corresponde al tipo de formato requerido")
        {

        }
        /// <summary>
        /// Excepción personalizada, se utiliza cuando el usuario utiliza una formato invalido
        /// </summary>
        /// <param name="message">El mensaje a mostrar cuando se captura la excepción</param>
        public FormatoIncorrectoException(string message) : base(message)
        {

        }

        /// <summary>
        /// Excepción personalizada, se utiliza cuando el usuario utiliza un formato invalido
        /// </summary>
        /// <param name="message">El mensaje a mostrar cuando se captura la excepción</param>
        /// <param name="innerException">Las excepciones anidadas</param>
        public FormatoIncorrectoException(string message, Exception innerException) : base(message, innerException)
        {

        }

    }
}
