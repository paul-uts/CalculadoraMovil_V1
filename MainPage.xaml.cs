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
            if (lblResultado.Text.Length == 0 || lblOperacion.Text.Length == 0)
                cambiarSigno.IsEnabled = false;
        }

        private void activadorBotones()
        {
            if (lblOperacion.Text.Length > 0)
            {
                if (!lblOperacion.Text.Contains(signo) || (lblResultado.Text.Length>0 && lblOperacion.Text.Contains(signo)))
                {
                    if (!lblOperacion.Text.EndsWith('%'))
                        activadorPorcentaje();

                    if (lblResultado.Text.Length != 0 || !lblOperacion.Text.Contains(signo))
                        cambiarSigno.IsEnabled = true;

                    division.IsEnabled = true;
                    multiplicacion.IsEnabled = true;
                    sumar.IsEnabled = true;
                    resta.IsEnabled = true;
                }
                else
                    desactivadorBotones();
            }
            
        }

        private void desactivadorNumeros()
        {
            cero.IsEnabled = false;
            uno.IsEnabled = false;
            dos.IsEnabled = false;
            tres.IsEnabled = false;
            cuatro.IsEnabled = false;
            cinco.IsEnabled = false;
            seis.IsEnabled = false;
            siete.IsEnabled = false;
            ocho.IsEnabled = false;
            nueve.IsEnabled = false;
            punto.IsEnabled = false;
        }

        private void activadorNumeros()
        {
            if (!lblOperacion.Text.EndsWith('%'))
            {
                cero.IsEnabled = true;
                uno.IsEnabled = true;
                dos.IsEnabled = true;
                tres.IsEnabled = true;
                cuatro.IsEnabled = true;
                cinco.IsEnabled = true;
                seis.IsEnabled = true;
                siete.IsEnabled = true;
                ocho.IsEnabled = true;
                nueve.IsEnabled = true;
                punto.IsEnabled= true;
            }

        }

        private void activadorPorcentaje()
        {
            if (lblOperacion.Text.Contains(signo) && !lblOperacion.Text.EndsWith(signo))
                porciento.IsEnabled = true;
            else if (lblOperacion.Text.EndsWith('%') || lblOperacion.Text.Length == 0)
            {
                porciento.IsEnabled = false;
                activadorBotones();
            }
                
        }

        private double asignarNum2(char signo)
        {
            int indice;

            string num2 = "";

            if (lblOperacion.Text.StartsWith('-'))
            {
                string alreves = "";
                for (int i = lblOperacion.Text.Length - 1; !(lblOperacion.Text[i] == signo); i--)
                    alreves += lblOperacion.Text[i];

                for (int i = alreves.Length-1; i >= 0 ; i--)
                    num2 += alreves[i];
            }
            else
            {
                indice = lblOperacion.Text.IndexOf(signo);

                for (int i = indice + 1; i < lblOperacion.Text.Length; i++)
                    num2 += lblOperacion.Text[i];
            }

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

            if (lblOperacion.Text.Contains(signo) && lblResultado.Text.Length > 0)
                activadorBotones();
        }

        private void validacionCero()
        {
            if (lblOperacion.Text.Length == 0)
                lblOperacion.Text += "0";
            else if (lblOperacion.Text.Contains('.'))
            {
                if (!lblOperacion.Text.Contains(signo))
                {
                    if (lblOperacion.Text.Contains('.'))
                        lblOperacion.Text += "0";
                    else if (lblOperacion.Text.EndsWith('0') || char.IsDigit(lblOperacion.Text[lblOperacion.Text.Length - 1]))
                        lblOperacion.Text += "0";
                }
                else if (lblOperacion.Text.Contains(signo))
                {
                    if (lblOperacion.Text.EndsWith(signo))
                        lblOperacion.Text += "0";
                    else if (lblOperacion.Text.EndsWith('.'))
                        lblOperacion.Text += "0";
                    else if (lblOperacion.Text.EndsWith('0') || char.IsDigit(lblOperacion.Text[lblOperacion.Text.Length - 1]))
                        lblOperacion.Text += "0";
                }
            }
        }

        private void signos(char signo)
        {
            if (lblResultado.Text.Length > 0)
            {
                lblOperacion.Text = lblResultado.Text;
                lblResultado.Text = "";
            }

            if (lblOperacion.Text.Contains(signo) && lblResultado.Text.Length > 0)
            {
                string excepcion = "";

                for (int i = 0; i < lblOperacion.Text.IndexOf(signo); i++)
                    excepcion += lblOperacion.Text[i];

                numero1 = Convert.ToDouble(excepcion);
            }
            else 
                numero1 = Convert.ToDouble(lblOperacion.Text);


            lblOperacion.Text += signo;

            desactivadorBotones();
            activadorNumeros();
        }

        private void cero_Clicked(object sender, EventArgs e)
        {
            validacionCero();
            activadorBotones();

            if (lblOperacion.Text.Contains(signo) && asignarNum2(signo) != 0 && !lblOperacion.Text.EndsWith(signo))
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
            signo = '+';

            if (lblOperacion.Text.EndsWith('%'))
            {
                lblOperacion.Text = lblResultado.Text;
                lblResultado.Text = "";
            }

            signos(signo);
        }

        private void resta_Clicked(object sender, EventArgs e)
        {
            signo = '-';

            if (lblOperacion.Text.EndsWith('%'))
            {
                lblOperacion.Text = lblResultado.Text;
                lblResultado.Text = "";
            }

            signos(signo);
        }

        private void multiplicacion_Clicked(object sender, EventArgs e)
        {
            // ×
            signo = '×';

            if (lblOperacion.Text.EndsWith('%'))
            {
                lblOperacion.Text = lblResultado.Text;
                lblResultado.Text = "";
            }

            signos(signo);
        }

        private void division_Clicked(object sender, EventArgs e)
        {
            // ÷
            signo = '÷';
            if (lblOperacion.Text.EndsWith('%'))
            {
                lblOperacion.Text = lblResultado.Text;
                lblResultado.Text = "";
            }

            signos(signo);
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
            lblOperacion.Text += '%';

            int indice = lblOperacion.Text.IndexOf(signo);

            string num1 = "";
            for (int i = 0; i < indice; i++)
                num1 += lblOperacion.Text[i];

            numero1 = Convert.ToDouble(num1);

            string num2 = "";
            for (int i = indice + 1; i < lblOperacion.Text.Length-1; i++)
                num2 += lblOperacion.Text[i];

            double por100toSumRes = numero1 * (Convert.ToDouble(num2) / 100);
            double por100toMulDiv = (Convert.ToDouble(num2) / 100);

            switch (signo)
            {
                case '+':
                    lblResultado.Text = (numero1 += por100toSumRes).ToString();
                    break;
                case '-':
                    lblResultado.Text = (numero1 -= por100toSumRes).ToString();
                    break;
                case '×':
                    lblResultado.Text = (numero1 *= por100toMulDiv).ToString();
                    break;
                case '÷':
                    lblResultado.Text = (numero1 /= por100toMulDiv).ToString();
                    break;
            }

            signo = '_'; activadorBotones(); porciento.IsEnabled = false; desactivadorNumeros();
        }

        private void cambiarSigno_Clicked(object sender, EventArgs e)
        {
            if (lblOperacion.Text.Contains(signo) || lblResultado.Text.Length > 0)
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
            activadorNumeros();
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