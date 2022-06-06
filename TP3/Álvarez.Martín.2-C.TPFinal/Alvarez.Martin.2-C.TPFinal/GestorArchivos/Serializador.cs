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
        /// Escribe y serializa un archivo Xml o Json
        /// </summary>
        /// <param name="dato">Lo que se va a guardar en el archivo</param>
        /// <param name="path">La ruta donde se va a guardar el archivo</param>
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
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lee y deserializa un archivo Xml o Json
        /// </summary>
        /// <param name="path">La ruta donde se va a guardar el archivo</param>
        /// <returns>un objeto serialziado, este puede ser json o xml</returns>
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
                    throw new Exception($"{Path.GetExtension(path)} Es una extension Invalida");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Lee un Json
        /// </summary>
        /// <param name="path">La ruta donde se va a guardar el archivo</param>
        /// <returns>un objeto serialziado, este puede ser json o xml</returns>
        private static T LeerJson(string path)
        {
            try
            {
                ArchivoTexto archivoTexto = new ArchivoTexto();

                string texto = archivoTexto.Leer(path);
                return JsonSerializer.Deserialize<T>(texto);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Lee un Xml
        /// </summary>
        /// <param name="path">La ruta donde se va a guardar el archivo</param>
        /// <returns>un objeto serialziado, este puede ser json o xml</returns>
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
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Escribe en un Xml
        /// </summary>
        /// <param name="dato">Lo que se va a guardar en el archivo</param>
        /// <param name="path">La ruta donde se va a guardar el archivo</param>
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
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Escribe en un Json
        /// </summary>
        /// <param name="dato">Lo que se va a guardar en el archivo</param>
        /// <param name="path">La ruta donde se va a guardar el archivo</param>
        private static void EscribirJson(T dato, string path)
        {
            try
            {
                ArchivoTexto archivoTexto = new ArchivoTexto();

                archivoTexto.Escribir(JsonSerializer.Serialize(dato, typeof(T)), path);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
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
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Escribe un DataGridView en un archivo.
        /// </summary>
        /// <param name="tabla">El DataGridView que se va a guardar en el archivo</param>
        public void EscribirDataGridViewPreguntandoRuta(DataGridView tabla)
        {
            string output = JsonSerializer.Serialize(tabla);
            System.IO.File.WriteAllText("json.json", output);
        }

        /// <summary>
        /// Da la opcion al usuario a elegir donde quiere guardar el archivo y lo guarda
        /// </summary>
        /// <returns>un objeto serialziado, este puede ser json o xml</returns>
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
            catch (Exception)
            {
                throw;
            }
        }
    }

}

