using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraMovil_PELP
{
    class Calculo
    {
        private double num1;
        private char signo;
        private double num2;
        private double resultado;

        public Calculo()
        {

        }

        public Calculo(double num1, char signo, double num2, double resultado)
        {
            this.num1 = num1;
            this.signo = signo;
            this.num2 = num2;
            this.resultado = resultado;
        }

        public double Num1 { get => num1; set => num1 = value; }
        public char Signo { get => signo; set => signo = value; }
        public double Num2 { get => num2; set => num2 = value; }
        public double Resultado { get => resultado; set => resultado = value; }

        public int cantidadOperaciones(string label)
        {
            int cant = 0;
            
           for (int i = 0; i < label.Length ; i++)
           {
               if (label[i] == '+' || label[i] == '-' || label[i] == '×' || label[i] == '÷')
                    cant += 1;
           }

            return cant;
        }

        public double previsualizarResutado(Calculo cuenta, double operador1, int i, string label, int operaciones)
        {
            string capturador = "";

            for (int j = i; (!char.IsDigit(label[i]) || label[i] != '.'); i++)
            {
                capturador += label[j];
            }

            i += capturador.Length-1;
            double operador2 = Convert.ToDouble(capturador);

            double preResultado = calcularResultado(operador1, operador2, label[i - (capturador.Length+1)]);

            if (cantidadOperaciones(label) <= operaciones)
                previsualizarResutado(cuenta, operador1, i, label, operaciones);

            return preResultado;
        }

        public double calcularResultado(double operador1, double operador2, char signo)
        {
            double resultado = 0;
            switch (signo)
            {
                case '+':
                    resultado = operador1 += operador2;
                    break;
                case '-':
                    resultado = operador1 -= operador2;
                    break;
                case '×':
                    resultado = operador1 *= operador2;
                    break;
                case '÷':
                    resultado = operador1 /= operador2;
                    break;
            }

            return resultado;
        }
    }
}
