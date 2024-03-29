﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ImcApp.Model; 

namespace ImcApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LimpiarIU();
        }
        private void LimpiarIU()
        {
            PesoEntry.Text = String.Empty;
            EstaturaEntry.Text = String.Empty;
            ImcLabel.Text = String.Empty;
            SituacionNutricionalLabel.Text = String.Empty;
        }

        private void CalcularButton_Clicked(object sender, EventArgs e)
        {
            decimal peso;
            decimal estatura;
            bool pesoEsConvertible = decimal.TryParse(PesoEntry.Text, out peso);
            bool estaturaEsConvertible = decimal.TryParse(EstaturaEntry.Text, out estatura);
            if (pesoEsConvertible && estaturaEsConvertible)
            {
                CalculadoraImc cimc = new CalculadoraImc(peso, estatura); 
                ImcLabel.Text = String.Format("{0:F4}", cimc.Imc);
                SituacionNutricionalLabel.Text = GetEstadoNutricional(cimc.SituacionNutricional);
            }
            else
            {
                DisplayAlert
                    ("Alerta",
                    "El peso y la estatura deben ser valores numéricos",
                    "Aceptar");
            }

        }
        private string GetEstadoNutricional(CalculadoraImc.EstadoNutricional estado)
        {
            switch (estado)
            {
                case CalculadoraImc.EstadoNutricional.PesoBajo:
                    return "Peso Bajo";
                case CalculadoraImc.EstadoNutricional.PesoNormal:
                    return "Peso Normal";
                case CalculadoraImc.EstadoNutricional.SobrePeso:
                    return "Sobrepeso";
                case CalculadoraImc.EstadoNutricional.Obesidad:
                    return "Obesidad";
                case CalculadoraImc.EstadoNutricional.ObesidadExtrema:
                    return "Obesidad Estrema";
                default:
                    return String.Empty;
            }
        }

        private void LimpiarButton_Clicked(object sender, EventArgs e)
        {
            LimpiarIU();
        }
        

    }
}
