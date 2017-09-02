using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x416

namespace Calculadora_de_Transferencia
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class VeloTempo : Page
    {

        public VeloTempo()
        {
            this.InitializeComponent();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }
        private void dominioPing_Load(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
        private void TracertButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Tracert));
        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {

        }

        private void Horas_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void comboBoxVelocidade_Load(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textBoxVelocidade_Load(object sender, TextChangedEventArgs e)
        {

        }

        public void TextBoxVelocidade_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tbVelo = (TextBox)sender;
            tbVelo.Text = string.Empty;
            tbVelo.GotFocus -= TextBoxVelocidade_GotFocus;
            return;
        }

        private void textBoxResultado_Load(object sender, TextChangedEventArgs e)
        {

        }
    }
}