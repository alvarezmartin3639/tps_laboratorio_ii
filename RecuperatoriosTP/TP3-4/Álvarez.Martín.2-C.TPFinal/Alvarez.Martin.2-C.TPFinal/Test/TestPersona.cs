using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Test
{
    [TestClass]
    public class TestPersona
    {
        /// <summary>
        /// Prueba el metodo Paciente.BuscarPacienteEnListaMedianteId, agregando un paciente a la lista y preguntando si está dentro de ella.
        /// </summary>
        [TestMethod]
        public void BuscarUnPacienteMedianteSuId()
        {
            //ARRANGE 
            Paciente nuevoPaciente = new(35353, 23, "Martín Álvarez", sexoEnum.Hombre, 1, new List<Atencion>(), false, "Ninguno");
            Paciente otroPaciente = new();
            List<Paciente> listaDePacientes = new();
            listaDePacientes.Add(nuevoPaciente);

            //ACT
            otroPaciente = Paciente.BuscarPacienteEnListaMedianteId(1, new List<Paciente>(listaDePacientes));

            //ASSERT
            Assert.AreEqual(nuevoPaciente.IdDePaciente, otroPaciente.IdDePaciente);
        }


        /// <summary>
        /// Prueba la serialización de un Paciente a Xml, si los identificadores únicos de una Persona son iguales antes y despues de  ser serializada se aprueba el test
        /// </summary>
        [TestMethod]
        public void SerializarUnaPersonaXml_SeEsperaCoincidienciaEnLosAtributosIdYDni()
        {
            //ARRANGE 
            Paciente nuevoPaciente = new(35353, 23, "Martín Álvarez", sexoEnum.Hombre, 1, new List<Atencion>(), false, "Ninguno");
            Paciente pacienteDeserealizado = new();

            //ACT

            using (XmlTextWriter xmlTextWriter = new XmlTextWriter($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}//PersonaTest.xml", Encoding.UTF8))
            {
                xmlTextWriter.Formatting = Formatting.Indented;
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Paciente));
                xmlSerializer.Serialize(xmlTextWriter, nuevoPaciente);
            }

            using (XmlTextReader xmlTextReader = new XmlTextReader($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}//PersonaTest.xml"))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Paciente));
                pacienteDeserealizado = (Paciente)xmlSerializer.Deserialize(xmlTextReader);
            }

            //ASSERT
            Assert.AreEqual(nuevoPaciente == pacienteDeserealizado, true);
        }

    }
}
