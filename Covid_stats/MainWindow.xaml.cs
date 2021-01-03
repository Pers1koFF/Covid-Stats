using Newtonsoft.Json;
using System.Net.Http;
using System.Windows;

namespace Covid_stats
{
    public partial class MainWindow : Window{
        public MainWindow(){InitializeComponent();label_cases.Opacity = 0;label_deaths.Opacity = 0;label_recovered.Opacity = 0;}

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            if (textbox.Text is null || textbox.Text == "" || textbox.Text == " ")
                MessageBox.Show("Вы не указали страну!", "Тупой шоли", MessageBoxButton.OK, MessageBoxImage.Error);
            else{label_cases.Opacity = 0;label_deaths.Opacity = 0;label_recovered.Opacity = 0;
                HttpClient client = new HttpClient();
                string json = "";
                try
                {
                    json = await client.GetStringAsync($"https://corona.lmao.ninja/v2/countries/{textbox.Text}");
                }catch(System.Net.Http.HttpRequestException ex) { MessageBox.Show("Неверная страна.", "Error");
                    return;
                }
                JsonResponse convertedJsonData = JsonConvert.DeserializeObject<JsonResponse>(json);cases.Content = convertedJsonData.cases + " чел";recovered.Content = convertedJsonData.recovered + " чел";ded_insaid.Content = convertedJsonData.deaths + " чел";

                if ((bool)check_afterUse.IsChecked)textbox.Text = "";
                label_cases.Opacity = 100;label_deaths.Opacity = 100;label_recovered.Opacity = 100;}}}}