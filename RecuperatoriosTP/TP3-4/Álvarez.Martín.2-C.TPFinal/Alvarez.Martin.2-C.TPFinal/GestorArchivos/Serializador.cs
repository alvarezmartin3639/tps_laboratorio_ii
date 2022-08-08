using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace GestorArchivos
{
    public class Serializador<T> : IArchivos<T> where T : class
    {


        /// <summary>
        /// Propiedad que retorna un path validado para ser .Json
        /// </summary>
        /// <exception cref="Exception">Cuando se elige una extensión invalida.</exception>

        public string PathJsonValido
        {
            get
            {
                try
                {
                    return this.GenerarPathConExtensionValida("json");
                }
                catch (Exception ex)
                { throw new Exception("Se encontró un problema en la propiedad PathJsonValido de la clase Serializador", ex); }
            }
        }

        /// <summary>
        /// Propiedad que retorna un path validado para ser .Xml
        /// </summary>
        /// <exception cref="Exception">Cuando se elige una extensión invalida.</exception>
        public string PathXmlValido
        {
            get
            {
                try
                {
                    return this.GenerarPathConExtensionValida("xml");
                }
                catch (Exception ex)
                { throw new Exception("Se encontró un problema en la propiedad PathXmlValido de la clase Serializador", ex); }
            }
        }

        /// <summary>
        /// Propiedad que retorna un path validado para ser .Xml o .Json
        /// </summary>
        /// <exception cref="Exception">Cuando se elige una extensión invalida.</exception>
        public SaveFileDialog PathXmlOJsonValido()
        {

            try
            {
                using (SaveFileDialog rutaDelArchivoParaAbrir = new SaveFileDialog())
                {
                    rutaDelArchivoParaAbrir.Filter = "Xml Files (*.xml)|*.xml | Json Files (*.json)|*.json ";
                    rutaDelArchivoParaAbrir.DefaultExt = "xml";
                    rutaDelArchivoParaAbrir.AddExtension = true;

                    if (rutaDelArchivoParaAbrir.ShowDialog() == DialogResult.OK)
                        return rutaDelArchivoParaAbrir;

                    throw new Exception("Error al seleccionar ruta xml o json");
                }
            }
            catch (Exception ex)
            { throw new Exception("Se encontró un problema en la propiedad PathXmlOJsonValido de la clase Serializador", ex); }


        }

        /// <summary>
        /// Método usado para generar un Path, se le pasa por parametro unicamente el nombre de la extensión sin puntuación.
        /// </summary>
        /// <param name="nombreExtensionSinPunto">La extensión usada, sin puntos.</param>
        /// <returns> </returns>
        /// <exception cref="Exception">Cuando sucede un error al crear un Path.</exception>
        public string GenerarPathConExtensionValida(string nombreExtensionSinPunto)
        {
            try
            {
                using (SaveFileDialog rutaDelArchivoParaAbrir = new SaveFileDialog())
                {
                    rutaDelArchivoParaAbrir.Filter = $"{nombreExtensionSinPunto} Files (*.{nombreExtensionSinPunto})|*.{nombreExtensionSinPunto}";
                    rutaDelArchivoParaAbrir.DefaultExt = nombreExtensionSinPunto;
                    rutaDelArchivoParaAbrir.AddExtension = true;

                    if (rutaDelArchivoParaAbrir.ShowDialog() == DialogResult.OK)
                        return rutaDelArchivoParaAbrir.FileName;

                    throw new Exception($"Error al seleccionar ruta {nombreExtensionSinPunto}");
                }
            }
            catch (Exception ex)
            { throw new Exception("Se encontró un problema en el metodo  generarPathConExtensionValida de la clase Serializador", ex); }


        }

        /// <summary>
        /// Escribe y serializa un archivo Xml o Json
        /// </summary>
        /// <param name="dato">Lo que se va a guardar en el archivo</param>
        /// <param name="path">La ruta donde se va a guardar el archivo</param>
        /// <exception cref="NotSupportedException">Cuando se elige una extensión invalida.</exception>
        /// <exception cref="Exception">Cuando sucede una excepcion al escribir.</exception>
        public void Escribir(T dato, string path)
        {
            try
            {
                if (Path.GetExtension(path) == ".xml")
                {
                    EscribirXml(dato, path);
                }
                else if (Path.GetExtension(path) == ".json")
                {
                    EscribirJson(dato, path);
                }
                else
                {
                    throw new NotSupportedException("Formato incorrecto, los formatos validos son .xml o .json");
                }
            }
            catch (Exception ex)
            { throw new Exception("Se encontró un problema en el metodo Escribir de la clase Serializador", ex); }
        }

        /// <summary>
        /// Lee y deserializa un archivo Xml o Json
        /// </summary>
        /// <param name="path">La ruta donde se va a guardar el archivo</param>
        /// <returns>un objeto serialziado, este puede ser json o xml</returns>
        /// <exception cref="NotSupportedException">Cuando se elige una extensión invalida.</exception>
        /// <exception cref="Exception">Cuando sucede una excepcion al leer Xml o Json.</exception>
        /// 
        public T Leer(string path)
        {
            try
            {
                if (Path.GetExtension(path) == ".xml")
                {
                    return LeerXml(path);
                }
                else if (Path.GetExtension(path) == ".json")
                {
                    return LeerJson(path);
                }
                else
                {
                    throw new NotSupportedException($"{Path.GetExtension(path)} Es una extension Invalida");
                }
            }
            catch (Exception ex)
            { throw new Exception("Se encontró un problema en el metodo Leer de la clase Serializador", ex); }
        }


        /// <summary>
        /// Lee un archivo Json, devolviendo el objeto deserealizado
        /// </summary>
        /// <param name="path">La ruta donde se va a guardar el archivo</param>
        /// <returns>un objeto serialziado, este puede ser json o xml</returns>
        /// <exception cref="Exception">Cuando sucede una excepcion al leer Json.</exception>
        private static T LeerJson(string path)
        {
            try
            {
                ArchivoTexto archivoTexto = new ArchivoTexto();

                string texto = archivoTexto.Leer(path);
                return JsonSerializer.Deserialize<T>(texto);
            }
            catch (Exception ex)
            { throw new Exception("Se encontró un problema en el metodo LeerJson de la clase Serializador", ex); }

        }

        /// <summary>
        /// Lee un Xml retornando un objeto serializado
        /// </summary>
        /// <param name="path">La ruta donde se va a guardar el archivo</param>
        /// <returns>un objeto serialziado, este puede ser json o xml</returns>
        /// <exception cref="Exception">Cuando sucede una excepcion al leer Xml.</exception>
        private static T LeerXml(string path)
        {
            try
            {
                using (XmlTextReader xmlTextReader = new XmlTextReader(path))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    return (T)xmlSerializer.Deserialize(xmlTextReader);
                }
            }
            catch (Exception ex)
            { throw new Exception("Se encontró un problema en el metodo LeerXml de la clase Serializador", ex); }

        }

        /// <summary>
        /// Escribe un objeto pasado por parametro en un archivo .xml
        /// </summary>
        /// <param name="dato">Lo que se va a guardar en el archivo</param>
        /// <param name="path">La ruta donde se va a guardar el archivo</param>
        /// <exception cref="Exception">Cuando sucede una excepcion al Escribir Xml.</exception>
        private static void EscribirXml(T dato, string path)
        {
            try
            {

                using (XmlTextWriter xmlTextWriter = new XmlTextWriter(path, Encoding.UTF8))
                {
                    xmlTextWriter.Formatting = Formatting.Indented;
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(xmlTextWriter, dato);
                }
            }
            catch (Exception ex)
            { throw new Exception("Se encontró un problema en el metodo EscribirXml de la clase Serializador", ex); }

        }

        /// <summary>
        ///  Escribe un objeto pasado por parametro en un archivo .json
        /// </summary>
        /// <param name="dato">Lo que se va a guardar en el archivo</param>
        /// <param name="path">La ruta donde se va a guardar el archivo</param>
        /// <exception cref="Exception">Cuando sucede una excepcion al escribir Json.</exception>
        private static void EscribirJson(T dato, string path)
        {
            try
            {
                ArchivoTexto archivoTexto = new ArchivoTexto();

                archivoTexto.Escribir(JsonSerializer.Serialize(dato, typeof(T)), path);
            }
            catch (Exception ex)
            { throw new Exception("Se encontró un problema en el metodo EscribirJson de la clase Serializador", ex); }
        }

        /// <summary>
        ///  Escribe un objeto pasado por parametro en un archivo .xml o .json
        /// </summary>
        /// <param name="dato">Lo que se va a guardar en el archivo</param>
        public void EscribirPreguntandoRutaDelArhivo(T dato)
        {
            try
            {
                using (SaveFileDialog rutaDelArchivoParaAbrir = new SaveFileDialog())
                {
                    if (rutaDelArchivoParaAbrir.ShowDialog() == DialogResult.OK)
                    {
                        Escribir(dato, rutaDelArchivoParaAbrir.FileName);
                    }
                }
            }
            catch (Exception ex)
            { throw new Exception("Se encontró un problema en el metodo EscribirPreguntandoRutaDelArchivo de la clase Serializador", ex); }
        }

        /// <summary>
        /// Pregunta el path donde guardar un objeto Json
        /// </summary>
        /// <param name="dato">Lo que va a guardar en el archivo</param>
        /// <returns></returns>
        public void EscribirJsonPreguntandoRuta(T dato)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = $"json Files (*.json)|*.json";
                saveFileDialog.DefaultExt = "json";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Serializador<T>.EscribirJson(dato, saveFileDialog.FileName);
                }
            }
        }
        /// <summary>
        /// Da la opcion al usuario a elegir un archivo .json o .xml y lo deserealiza retornandoló como objeto
        /// </summary>
        /// <returns>un objeto serialziado, este puede ser json o xml</returns>
        /// <exception cref="Exception">Cuando sucede una excepcion al leer.</exception>
        public T LeerPreguntandoRutaDelArhivo()
        {
            try
            {
                using (OpenFileDialog rutaDelArchivoParaAbrir = new OpenFileDialog())
                {
                    if (rutaDelArchivoParaAbrir.ShowDialog() == DialogResult.OK)
                    {
                        return Leer(rutaDelArchivoParaAbrir.FileName);
                    }

                    return null;
                }
            }
            catch (Exception ex)
            { throw new Exception("Se encontró un problema en el metodo LeerPreguntandoRutaDelArchivo de la clase Serializador", ex); }
        }
    }

}

