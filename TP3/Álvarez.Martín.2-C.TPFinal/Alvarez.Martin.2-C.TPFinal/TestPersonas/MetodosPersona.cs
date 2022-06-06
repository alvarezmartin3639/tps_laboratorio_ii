using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestPersonas
{
    [TestClass]
    public class MetodosPersona
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
    }
}
