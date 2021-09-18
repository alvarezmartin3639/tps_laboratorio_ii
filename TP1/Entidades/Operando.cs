using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Operando
    {
        //ATRIBUTOS
        private double numero;


        /// <summary>
        /// Convierte de binario a decimal un string.
        /// </summary>
        /// <param name="numeroBinario"></param>
        /// <returns name="string ResultadoConversion"> Si tiene exito</returns>
        /// <returns name="const 'Valor inválido'"> Si tiene fallo</returns>
        public static string BinarioDecimal(string binario)
        {
            int acumuladorResultado;
            string cadenaInvertida=string.Empty;

            acumuladorResultado = 0;

            if (Operando.EsBinario(binario) == true || int.Parse(binario) >=0)
            {
                for (int i = binario.Length - 1; i >= 0; i--)
                {
                    cadenaInvertida += binario[i];
                }

                for (int i = 0; i < cadenaInvertida.Length; i++)
                {
                    if (cadenaInvertida[i] == '1')
                    {
                        acumuladorResultado += (int)Math.Pow(2, i);
                    }
                }

                return Convert.ToString(acumuladorResultado);
            }       

            return "Valor inválido";
        }



        /// <summary>
        /// Convierte de binario a decimal un double.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns name="string resultadoConversion"> Si tiene exito</returns>
        /// <returns name="const 'Valor inválido' "> Si tiene fallo</returns>
        public static string DecimalBinario(double numero)
        {
            string stringRetorno=string.Empty;
            int restoDeLaDivision;
            int decimalConvertido;

            decimalConvertido = (int)numero;

            if(numero > 0)
            {
                do
                {
                    restoDeLaDivision = decimalConvertido % 2;
                    decimalConvertido /= 2;
                    stringRetorno = restoDeLaDivision.ToString() + stringRetorno;
                } while (decimalConvertido >0);
            

                if (Operando.EsBinario(stringRetorno) == true)
                {
                    return stringRetorno;
                }

            }
         
            return "Valor inválido";
        }



        /// <summary>
        /// Convierte de decimal a binario un string
        /// </summary>
        /// <param name="numero"></param>
        /// <returns name="string resultadoConversion"> Si tiene exito</returns>
        /// <returns name="const 'Valor inválido' "> Si tiene fallo</returns>
        public static string DecimalBinario(string numero)
        {
            return Operando.DecimalBinario(Double.Parse(numero));          
        }



        /// <summary>
        /// Valida un string para ver si es binario
        /// </summary>
        /// <param name="binario"></param>
        /// <returns name="bool true"> Si tiene exito</returns>
        /// <returns name="bool false "> Si tiene fallo</returns>
        public static bool EsBinario(string binario)
        {
            for(int i=0; i<binario.Length;i++)
            {
                if (binario[i] !='1' && binario[i] != '0')
                {
                    return false;
                }
            }
         

            return true;
        }



        /// <summary>
        /// Constructor por defecto, instancia numero a 0.
        /// </summary>
        public Operando()
        {
            this.numero = 0;
        }



        /// <summary>
        /// Constructor de instancia, instancia el atributo numero al double pasado por parametro
        /// </summary>
        /// <param name="numero"></param>
        public Operando(double numero)
        {
            this.Numero = Convert.ToString(numero);   
        }



        /// <summary>
        /// Constructor de instancia, instancia el atributo numero al string pasado por parametro
        /// </summary>
        /// <param name="strNumero"></param>
        public Operando(string strNumero):this(double.Parse(strNumero))
        {
            
        }



        /// <summary>
        /// Propiedad setter del atributo numero
        /// </summary>
        string Numero
        {
            set
            {
                if (Operando.ValidarOperando(value) != double.MinValue)
                {
                  this.numero = Convert.ToDouble(value);
                }
                else
                {
                    this.numero = double.MinValue;
                }
               
            }

        }



        /// <summary>
        /// Sobrecarga el operador '-' para restar dos objetos Operando 
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns name="n1.numero - n2.numero"> La resta de los dos Operando</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }



        /// <summary>
        /// Sobrecarga el operador '*' para multiplicar dos objetos Operando 
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns name="n1.numero * n2.numero"> La multiplicacion de los dos Operando</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;

        }



        /// <summary>
        /// Sobrecarga el operador '/' para dividir dos objetos Operando 
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns name="n1.numero / n2.numero"> La division de los dos objetos Operando</returns>
        /// <returns name="double.MinValue"> Si alguno de los dos operando es 0</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if(n1.numero != 0 && n2.numero != 0)
            {
             return n1.numero / n2.numero;
            }

            return double.MinValue;
        }



        /// <summary>
        /// Sobrecarga el operador '+' para sumar dos objetos Operando 
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns name="n1.numero + n2.numero"> La suma de los dos objetos Operando</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;

        }



        /// <summary>
        /// Valida y convierte(si se valida correctamente) una cadena a double.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns name="double.Parse(strNumero)"> El numero convertido</returns>
        /// <returns name="0"> Si no se pudo validar</returns>
        public static double ValidarOperando(string strNumero)
        {
             if (strNumero.All(char.IsDigit))
            {
                return double.Parse(strNumero);
             }

            return 0;
        }



    }
}
