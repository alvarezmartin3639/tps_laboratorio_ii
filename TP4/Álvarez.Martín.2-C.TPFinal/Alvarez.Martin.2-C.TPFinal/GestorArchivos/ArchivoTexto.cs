using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace GestorArchivos
{
    public class ArchivoTexto : IArchivos<string>
    {


        /// <summary>
        /// Escribe un texto en una ruta
        /// </summary>
        /// <param name="dato">El texto a escribir en el archivo</param>
        /// <param name="path">La ruta donde se guarda el archivo</param>
        public void Escribir(string dato, string path)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    streamWriter.WriteLine(dato);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna un string con el texto leido de una ruta
        /// </summary>
        /// <param name="path">La ruta donde se guarda el archivo</param>
        /// <returns></returns>
        public string Leer(string path)
        {
            string returnAux = string.Empty;
            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    while (!streamReader.EndOfStream)
                    {
                        returnAux += $"{streamReader.ReadLine()}\n";
                    }
                }
                return returnAux;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// El usuario elige el path donde se guarda el archivo
        /// </summary>
        /// <param name="dato">El texto a escribir en el archivo</param>
        public static void EscribirPreguntandoRuta(string dato)
        {
            try
            {
                using (SaveFileDialog rutaDelArchivoParaAbrir = new SaveFileDialog())
                {
                    if (rutaDelArchivoParaAbrir.ShowDialog() == DialogResult.OK)
                    {
                        ArchivoTexto archivoTexto = new ArchivoTexto();
                        archivoTexto.Escribir(dato, rutaDelArchivoParaAbrir.FileName);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Escribe un DataGridView a texto sin formato y sin los titulos de la columna
        /// </summary>
        /// <param name="tablaDeDatos">El dataGridView a escribir</param>
        public static void EscribirPreguntandoRuta(DataGridView tablaDeDatos)
        {
            try
            {

                using (SaveFileDialog rutaDelArchivoParaAbrir = new SaveFileDialog())
                {
                    if (rutaDelArchivoParaAbrir.ShowDialog() == DialogResult.OK)
                    {
                        List<string> lstFilas = new List<string>();
                        string strLinea;

                        foreach (DataGridViewRow row in tablaDeDatos.Rows)
                        {
                            strLinea = "\n\n";

                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (cell.Value == null)
                                    strLinea += " ";
                                else
                                    strLinea += $"{tablaDeDatos.Columns[cell.ColumnIndex].Name.ToUpper()}: {cell.Value.ToString()}\n";
                            }

                            lstFilas.Add($"{strLinea}\n\n");
                        }
                        //BORRO EL FICHERO PARA VOLVER A EMPEZAR
                        if (File.Exists(rutaDelArchivoParaAbrir.FileName)) File.Delete(rutaDelArchivoParaAbrir.FileName);

                        File.WriteAllLines(rutaDelArchivoParaAbrir.FileName, lstFilas);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
