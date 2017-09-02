using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x416

namespace Calculadora_de_Transferencia
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public double tamanho;
        public double velocidade;
        public double resultado;
        public MainPage()
        {
            //this.InitializeComponent();
        }

        // GERENCIA TAMANHO DA TRANSFERENCIA
        private void comboBoxTamanho_Load(object sender, SelectionChangedEventArgs e)
        {

        }
        private void textBoxTamanho_Load(object sender, TextChangedEventArgs e)
        {
           //Try - Catch
        }
        public void TextBoxTamanho_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tbTama = (TextBox)sender;
            tbTama.Text = string.Empty;
            tbTama.GotFocus -= TextBoxTamanho_GotFocus;
            return;
        }

        // GERENCIA VELOCIDADE DA TRANSFERENCIA
        private void comboBoxVelocidade_Load(object sender, SelectionChangedEventArgs e)
        {

        }
        private void textBoxVelocidade_Load(object sender, TextChangedEventArgs e)
        {
            //Try - Catch
        }
        public void TextBoxVelocidade_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tbVelo = (TextBox)sender;
            tbVelo.Text = string.Empty;
            tbVelo.GotFocus -= TextBoxVelocidade_GotFocus;
            return;
        }

        //EXIBE RESULTADO
        private void textBoxResultado_Load(object sender, TextChangedEventArgs e)
        {

        }
        private void Calcular_click(object sender, RoutedEventArgs e)
        {
            int validaVelo = 0, validaTama = 0;
            try
            {
                velocidade = Convert.ToDouble(textBoxVelocidade.Text);
                validaVelo = 1;
                if(velocidade < 0)
                {
                    velocidade = -1;
                    textBoxVelocidade.Text = "Somente numero positivo";
                    validaVelo = 0;
                }
            }
            catch
            {
                validaVelo = 0;
                textBoxVelocidade.Text = "Somente Numeros";
                
            }

            try
            {
                validaTama = 1;
                tamanho = Convert.ToDouble(textBoxTamanho.Text);
                if (tamanho < 0)
                {
                    validaTama = 0;
                    tamanho = -1;
                    textBoxTamanho.Text = "Somente numero positivo";
                }
            }
            catch
            {
                validaTama = 0;
                textBoxTamanho.Text = "Somente Numeros";
            }
            if (validaTama == 1 && validaVelo == 1)
            {
                procuraCbx();
            }
            return;
        }

        //CALCULA RESULTADO
        public void procuraCbx()
        {
            // Converte para KB
            switch (comboBoxVelocidade.SelectedIndex)
            {
                case 0: //KB
                        // opcaoVelocidade = 0;
                    break;

                case 1: //Mb
                        // opcaoVelocidade = 1;
                    velocidade = (velocidade / 8) * 1000;
                    break;

                case 2: //MB
                        // opcaoVelocidade = 2;
                    velocidade = velocidade * 1000;
                    break;

                case 3: //Gb
                        // opcaoVelocidade = 3;
                    velocidade = ((velocidade / 8) * 1000) * 1000;
                    break;
            }

            switch (comboBoxTamanho.SelectedIndex)
            {
                // Converte para KB

                case 0: //KB
                        // opcaoTamanho = 0;
                    break;

                case 1: //MB
                        // opcaoTamanho = 1;
                    tamanho = tamanho * 1000;
                    break;

                case 2: //GB
                        // opcaoTamanho = 2;
                    tamanho = (tamanho * 1000) * 1000;
                    break;

                case 3: //TB
                        // opcaoTamanho = 3;
                    tamanho = ((tamanho * 1000) * 1000) * 1000;
                    break;
            }
            int seg = 0, min = 0, hr = 0, dia = 0;
            int actmin = 0, acthr = 0, actdia = 0;
            while (tamanho > 0)
            {
                tamanho = tamanho - velocidade;
                seg++;
                if (seg == 60)
                {
                    seg = 0;
                    min++;
                    actmin = 1;
                    if (min == 60)
                    {
                        min = 0;
                        hr++;
                        acthr = 1;
                        if (hr == 24)
                        {
                            hr = 0;
                            dia++;
                            actdia = 1;
                            if (dia > 30)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            if (actdia == 1)
            {
                if (dia >= 30)
                {
                    textBoxResultado.Text = ("Tempo de transferencia:\n" + "Mais de 1 mês");
                }
                else
                {
                    textBoxResultado.Text = ("Tempo de transferencia:\n" + dia + " dia(s), " + hr + " hora(s) e " + min + " minuto(s)");
                }
               
            }
            else if (acthr == 1)
            {
                textBoxResultado.Text = ("Tempo de transferencia:\n" + hr + " hora(s), " +min +" minuto(s) e " +seg +" segundo(s)");
            }
            else if (actmin == 1)
            {
                textBoxResultado.Text = ("Tempo de transferencia:\n" + min + " minuto(s) e " + seg + " segundo(s)");
            }
            else{
                textBoxResultado.Text = ("Tempo de transferencia:\n"  + seg + " segundo(s)");
            }
            return;
        }

        // BOTAO HAMBURGUER
        
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void VeloTempo_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(VeloTempo));
        }
        /*
        private void TracertButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Tracert));
        }

        private void ScrollPrincipal_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {

        }
        */

        private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
