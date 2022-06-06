using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestDePersonas
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BuscarUnPacienteMedianteSuId()
        {
            //ARRANGE 
            Paciente nuevoPaciente = new(35353,23,"Mart�n �lvarez",sexoEnum.Hombre,1,new List<Atencion>(), false,"Ninguno");
            Paciente otroPaciente = new();
            List<Paciente> listaDePacientes = new();
            listaDePacientes.Add(nuevoPaciente);

            //ACT
            otroPaciente = Paciente.BuscarPacienteEnListaMedianteId(1,new List<Paciente>(listaDePacientes));

            //ASSERT
            Assert.AreEqual(nuevoPaciente.IdDePaciente,otroPaciente.IdDePaciente);
        }
    }
}
