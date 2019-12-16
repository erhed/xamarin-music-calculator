using System;
using System.Collections.Generic;
using MusicCalculator.Models;
using MusicCalculator.Data;

using Xamarin.Forms;

namespace MusicCalculator
{
    public partial class SongPage : ContentPage
    {
        public List<Song> Songs;

        public SongPage()
        {
            InitializeComponent();

            Title = "Songs";
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#233951");
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            Songs = await App.Database.GetSongsAsync();
            RenderSongs();
        }

        private void RenderSongs()
        {
            for (int i = 0; i < Songs.Count; i++)
            {
                Label titleLabel = new Label();
                titleLabel.Text = Songs[i].Title;
                titleLabel.TextColor = Color.FromHex("#FFFFFF");
                Grid.SetColumn(titleLabel, 0);
                Grid.SetRow(titleLabel, i);
                Song_Grid.Children.Add(titleLabel);

                Label tempoLabel = new Label();
                tempoLabel.Text = Songs[i].Tempo.ToString("0");
                tempoLabel.TextColor = Color.FromHex("#FFFFFF");
                tempoLabel.HorizontalTextAlignment = TextAlignment.End;
                Grid.SetColumn(tempoLabel, 1);
                Grid.SetRow(tempoLabel, i);
                Song_Grid.Children.Add(tempoLabel);
            }

            Label spaceLabel = new Label();
            spaceLabel.Text = "";
            Grid.SetRow(spaceLabel, Songs.Count);
            Song_Grid.Children.Add(spaceLabel);
        }

        private void ClearSongs()
        {
            Song_Grid.Children.Clear();
        }

        private async void UpdateSongs()
        {
            ClearSongs();
            Songs = await App.Database.GetSongsAsync();
            RenderSongs();
        }

        async void OnAddButtonClicked(object sender, EventArgs e)
        {
            string tempoString = Tempo_Entry.Text;
            int tempoInt = Convert.ToInt32(tempoString);
            var song = new Song
            {
                Title = Title_Entry.Text,
                Tempo = tempoInt
            };
            await App.Database.SaveSongAsync(song);

            Title_Entry.Text = "";
            Tempo_Entry.Text = "";

            UpdateSongs();
        }
    }
}
