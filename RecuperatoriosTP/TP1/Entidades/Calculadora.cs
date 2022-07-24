using System;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Resuelve operaciones arítmeticas. 
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns name="double resultado">Se resolvió correctamente la operación, se retorna el resultado.</returns>
        /// <returns name="double double.MaxValue">Existe error se devuelve  "1.7976931348623157E+308" para notificarlo</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultadoDeLaOperacion = 0;


            if(ValidarOperador(operador) == '-')
            {
                switch (operador)
                {
                    case '+':
                        resultadoDeLaOperacion = num1 + num2;
                        break;

                    case '-':
                        resultadoDeLaOperacion = num1 - num2;
                        break;

                    case '*':
                        resultadoDeLaOperacion = num1 * num2;
                        break;

                    case '/':
                        resultadoDeLaOperacion = num1 / num2;
                        break;

                    default:
                        resultadoDeLaOperacion = double.MaxValue;
                        break;
                }
            }
           
            return resultadoDeLaOperacion;
        }



        /// <summary>
        /// Se ingresa un operador arítmetico y se lo valida.
        /// </summary>
        /// <param name="operador"> El operador a validar </param>
        /// <returns name="-"> Si fue validado correctamente</returns>
        /// <returns name="+"> Si no fue validado correctamente</returns>
        private static char ValidarOperador(char operador)
        {         
            if (operador == '+' || operador == '-' || operador == '/' 
                || operador == '*')
            {
                return '-';
            }

            return '+';
        }



    }
}
