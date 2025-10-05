using System;
using System.Net;
using System.Threading.Tasks;
using CalculadoraMovil_PELP_Lib;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace CalculadoraMovil_PELP
{
    public partial class MainPage : ContentPage
    {
        double numero1;
        char signo = '_';

        public MainPage()
        {
            InitializeComponent();
            desactivadorBotones();
        }

        private void desactivadorBotones()
        {
            activadorPorcentaje();

            division.IsEnabled = false;
            multiplicacion.IsEnabled = false;
            sumar.IsEnabled = false;
            resta.IsEnabled = false;
        }

        private void activadorBotones()
        {
            if (lblOperacion.Text.Length > 0)
            {
                if (!lblOperacion.Text.Contains(signo))
                {
                    activadorPorcentaje();

                    division.IsEnabled = true;
                    multiplicacion.IsEnabled = true;
                    sumar.IsEnabled = true;
                    resta.IsEnabled = true;
                }
                else
                    desactivadorBotones();
            }
            
        }

        private void activadorPorcentaje()
        {
            if (lblOperacion.Text.Contains(signo) && !lblOperacion.Text.EndsWith(signo))
                porciento.IsEnabled = true;
            else
                porciento.IsEnabled = false;
        }

        private double asignarNum2(char signo)
        {
            int indice = lblOperacion.Text.IndexOf(signo);

            string num2 = "";

            for (int i = indice+1; i < lblOperacion.Text.Length; i++)
                num2 += lblOperacion.Text[i];

            return Convert.ToDouble(num2);
        }

        private void calcularResultado(double num1, char signo)
        {
            switch (signo)
            {
                case '+':
                    lblResultado.Text = (num1 += asignarNum2(signo)).ToString();
                    break;
                case '-':
                    lblResultado.Text = (num1 -= asignarNum2(signo)).ToString();
                    break;
                case '×':
                    lblResultado.Text = (num1 *= asignarNum2(signo)).ToString();
                    break;
                case '÷':
                    lblResultado.Text = (num1 /= asignarNum2(signo)).ToString();
                    break;
            }
        }

        private void validacionCero()
        {
            if (lblOperacion.Text.Length == 0 || lblOperacion.Text.EndsWith(signo))
                lblOperacion.Text += "0";
            else if (!lblOperacion.Text.Contains(signo) && lblOperacion.Text.Contains('.'))
                lblOperacion.Text += "0";
            else if (lblOperacion.Text.EndsWith(signo) && asignarNum2(signo) != 0)
                lblOperacion.Text += "0";
        }

        private void cero_Clicked(object sender, EventArgs e)
        {
            validacionCero();
            activadorBotones();

            if (lblOperacion.Text.Contains(signo) && asignarNum2(signo) != 0)
                calcularResultado(numero1, signo);
        }

        private void uno_Clicked(object sender, EventArgs e)
        {
            lblOperacion.Text += '1';
            activadorBotones();

            if (lblOperacion.Text.Contains(signo))
                calcularResultado(numero1, signo);
        }

        private void dos_Clicked(object sender, EventArgs e)
        {
            lblOperacion.Text += '2';
            activadorBotones();

            if (lblOperacion.Text.Contains(signo))
                calcularResultado(numero1, signo);
        }

        private void tres_Clicked(object sender, EventArgs e)
        {
            lblOperacion.Text += '3';
            activadorBotones();

            if (lblOperacion.Text.Contains(signo))
                calcularResultado(numero1, signo);
        }

        private void cuatro_Clicked(object sender, EventArgs e)
        {
            lblOperacion.Text += '4';
            activadorBotones();

            if (lblOperacion.Text.Contains(signo))
                calcularResultado(numero1, signo);
        }

        private void cinco_Clicked(object sender, EventArgs e)
        {
            lblOperacion.Text += '5';
            activadorBotones();

            if (lblOperacion.Text.Contains(signo))
                calcularResultado(numero1, signo);
        }

        private void seis_Clicked(object sender, EventArgs e)
        {
            lblOperacion.Text += '6';
            activadorBotones();

            if (lblOperacion.Text.Contains(signo))
                calcularResultado(numero1, signo);
        }

        private void siete_Clicked(object sender, EventArgs e)
        {
            lblOperacion.Text += '7';
            activadorBotones();

            if (lblOperacion.Text.Contains(signo))
                calcularResultado(numero1, signo);
        }

        private void ocho_Clicked(object sender, EventArgs e)
        {
            lblOperacion.Text += '8';
            activadorBotones();

            if (lblOperacion.Text.Contains(signo))
                calcularResultado(numero1, signo);
        }

        private void nueve_Clicked(object sender, EventArgs e)
        {
            lblOperacion.Text += '9';
            activadorBotones();

            if (lblOperacion.Text.Contains(signo))
                calcularResultado(numero1, signo);
        }

        private void decimal_Clicked(object sender, EventArgs e)
        {
            if (lblOperacion.Text.Length == 0 || lblOperacion.Text.EndsWith(signo))
                lblOperacion.Text += "0.";
            else if (!lblOperacion.Text.Contains(signo))
            {
                if (!lblOperacion.Text.Contains('.'))
                    lblOperacion.Text += ".";
            }
            else if (lblOperacion.Text.Contains(signo))
            {
                string prueba = "";
                for (int i = lblOperacion.Text.IndexOf(signo); i < lblOperacion.Text.Length; i++)
                    prueba += lblOperacion.Text[i];
                
                if(!prueba.Contains('.'))
                    lblOperacion.Text += ".";
            }
        }

        private void sumar_Clicked(object sender, EventArgs e)
        {
            numero1 = Convert.ToDouble(lblOperacion.Text);
            signo = '+';
            lblOperacion.Text += signo;

            desactivadorBotones();
        }

        private void resta_Clicked(object sender, EventArgs e)
        {
            numero1 = Convert.ToDouble(lblOperacion.Text);
            signo = '-';
            lblOperacion.Text += signo;

            desactivadorBotones();
        }

        private void multiplicacion_Clicked(object sender, EventArgs e)
        {
            numero1 = Convert.ToDouble(lblOperacion.Text);
            // ×
            signo = '×';
            lblOperacion.Text += signo;

            desactivadorBotones();
        }

        private void division_Clicked(object sender, EventArgs e)
        {
            numero1 = Convert.ToDouble(lblOperacion.Text);
            // ÷
            signo = '÷';
            lblOperacion.Text += signo;

            desactivadorBotones();
        }

        private void atras_Clicked(object sender, EventArgs e)
        {
            string mantener = "";

            for (int i = 0; i < (lblOperacion.Text.Length - 1); i++)
            {
                mantener += lblOperacion.Text[i];
            }
                

            lblOperacion.Text = mantener;

            if (mantener.Contains(signo))
            {
                desactivadorBotones();
                if (!lblOperacion.Text.EndsWith(signo))
                    calcularResultado(numero1, signo);
            }
            else
            {
                signo = '_';
                if (lblOperacion.Text.Length > 0)
                    activadorBotones();
                else
                    desactivadorBotones();
            }
                

            if (lblOperacion.Text.EndsWith(signo))
            {
                lblResultado.Text = "";
                desactivadorBotones();
            }
        }

        private void porciento_Clicked(object sender, EventArgs e)
        {
            int indice = lblOperacion.Text.IndexOf(signo);

            string num1 = "";
            for (int i = 0; i < indice; i++)
                num1 += lblOperacion.Text[i];

            numero1 = Convert.ToDouble(num1);

            string num2 = "";
            for (int i = indice + 1; i < lblOperacion.Text.Length; i++)
                num2 += lblOperacion.Text[i];

            double por100toSumRes = numero1 * (Convert.ToDouble(num2) / 100);
            double por100toMulDiv = (Convert.ToDouble(num2) / 100);

            switch (signo)
            {
                case '+':
                    lblOperacion.Text = (numero1 += por100toSumRes).ToString();
                    break;
                case '-':
                    lblOperacion.Text = (numero1 -= por100toSumRes).ToString();
                    break;
                case '×':
                    lblOperacion.Text = (numero1 *= por100toMulDiv).ToString();
                    break;
                case '÷':
                    lblOperacion.Text = (numero1 /= por100toMulDiv).ToString();
                    break;
            }

            signo = '_'; lblResultado.Text = ""; activadorBotones();
        }

        private void cambiarSigno_Clicked(object sender, EventArgs e)
        {
            if (lblOperacion.Text.Contains(signo))
            {
                lblOperacion.Text = (Convert.ToDouble(lblResultado.Text) * -1).ToString();
                signo = '_';
                lblResultado.Text = "";
                activadorBotones();
            }
            else
                lblOperacion.Text = (Convert.ToDouble(lblOperacion.Text) * -1).ToString();
        }

        private void borrar_Clicked(object sender, EventArgs e)
        {
            signo = '_';
            lblOperacion.Text = "";
            lblResultado.Text = "";
            desactivadorBotones();
        }

        private void total_Clicked(object sender, EventArgs e)
        {
            if (lblResultado.Text != "")
            {
                lblOperacion.Text = lblResultado.Text;
                signo = '_';
                lblResultado.Text = "";
                activadorBotones();
            }
        }
    }
}
