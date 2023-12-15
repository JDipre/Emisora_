using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.Maui.Controls;
using Plugin.Maui.Audio;

namespace Emisora.View
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private int count = 0;
        private readonly IEmisoraServices _emisoraServices;

        private bool isPlaying = false;

        public MainPage(IEmisoraServices services)
        {
            InitializeComponent();
            _emisoraServices = services;
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            loading.IsVisible = true;
            loading.IsRunning = true;

            var data = await _emisoraServices.Obtener();
            var dataFinal = data.Where(m => m.EmisoraID < 100081);
            listViewEmisoras.ItemsSource = dataFinal;

            loading.IsVisible = false;
        }

        private async void OnPlayEmisoraClicked(object sender, EventArgs e)
        {
            int selectedEmisoraIndex = listViewEmisoras.SelectedIndex;

            if (selectedEmisoraIndex >= 0 && selectedEmisoraIndex < listViewEmisoras.ItemsSource.Count)
            {
                var emisora = (Emisora)listViewEmisoras.ItemsSource[emisoraindex];

                if (!string.IsNullOrEmpty(emisora.Url))
                {
                    if (!isPlaying)
                    {
                        if (_audioPlayer == null)
                        {
                            _audioPlayer = new AudioPlayer();
                        }

                        _audioPlayer.Play(emisora.Url);
                        isPlaying = true;

                        // Actualizar la interfaz de usuario para mostrar el estado de reproducción
                        ((Button)sender).Text = "Pausar";
                    }
                    else
                    {
                        _audioPlayer.Pause();
                        isPlaying = false;

                        // Actualizar la interfaz de usuario para mostrar el estado de pausa
                        ((Button)sender).Text = "Escuchar";
                    }
                }
            }
        }
    }
}
