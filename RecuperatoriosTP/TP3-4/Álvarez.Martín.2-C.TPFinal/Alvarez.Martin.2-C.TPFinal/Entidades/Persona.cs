namespace Entidades
{
    public enum sexoEnum { Hombre, Mujer, Otro };
    public class Persona
    {
        private int dni;
        private int edad;
        private string nombre;
        private sexoEnum sexo;


        #region CONSTRUCTORES

        /// <summary>
        /// Construye una Persona
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Construye una Persona, indicando sus datos personales
        /// </summary>
        /// <param name="dni">Su identificador único como ciudadano</param>
        /// <param name="edad">Su edad</param>
        /// <param name="nombre">Su nombre</param>
        /// <param name="sexo">Su sexo, puede ser Hombre, Mujer u Otro</param>
        public Persona(int dni, int edad, string nombre, sexoEnum sexo)
        {
            this.Dni = dni;
            this.Edad = edad;
            this.Nombre = nombre;
            this.Sexo = sexo;
        }

        #endregion


        #region DESCRIPTORES DE ACCESO

        /// <summary>
        /// Propiedad que administra el atributo dni, este es un identificador único de todo ciudadano
        /// </summary>
        public int Dni { get => dni; set => dni = value; }

        /// <summary>
        /// Propiedad que administra el atributo edad
        /// </summary>
        public int Edad { get => edad; set => edad = value; }

        /// <summary>
        /// Propiedad que adminsitra el atributo nombre
        /// </summary>
        public string Nombre { get => nombre; set => nombre = value; }

        /// <summary>
        /// Propiedad que administra el atributo sexo, este es un enumerado con las etiquetas "Hombre","Mujer" y "Otro"
        /// </summary>
        public sexoEnum Sexo { get => sexo; set => sexo = value; }

        #endregion

    }
}
