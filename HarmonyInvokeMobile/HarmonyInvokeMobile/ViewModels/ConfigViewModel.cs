using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HarmonyInvokeMobile.ViewModels
{
    public class ConfigViewModel : BaseViewModel
    {

        public const string HelpURL = "https://github.com/stoves3";
        public const string InitialTestConnectionText = "TEST CONNECTION";

        string apiUri = 
                Application.Current.Properties.ContainsKey(Constants.BaseApiUrlKeyName)
                ? Application.Current.Properties[Constants.BaseApiUrlKeyName] as string 
                : string.Empty;
        public string ApiUri
        {
            get { return apiUri; }
            set { SetProperty(ref apiUri, value); }
        }

        string buttonText = string.Empty;
        public string ButtonText
        {
            get { return buttonText; }
            set { SetProperty(ref buttonText, value); }
        }

        public ConfigViewModel()
        {
            Title = "Web API Config";
            ButtonText = InitialTestConnectionText;

            TestConnectionCommand = new Command(async () => {
                ButtonText = "TESTING CONNECTION...";
                string result = await CheckConnectionAsync(ApiUri);
                ButtonText = result;
            });

            PropertyChanged += (sender, e) => OnPropChanged(e.PropertyName);
        }
        
        public ICommand TestConnectionCommand { get; }

        private void OnPropChanged(string propertyName)
        {
            if (propertyName == "ApiUri")
            {
                if (!Application.Current.Properties.ContainsKey(Constants.BaseApiUrlKeyName))
                {
                    Application.Current.Properties.Add(Constants.BaseApiUrlKeyName, null);
                }

                Application.Current.Properties[Constants.BaseApiUrlKeyName] = ApiUri;
                ButtonText = InitialTestConnectionText;
            }
        }

        private async Task<string> CheckConnectionAsync(string url)
        {
            var result = "CONNECTION TEST SUCCESSFUL!";
            try
            {
                var response = await new HttpClient().GetAsync(url);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                result = $"Failed: {ex.Message}";
            }

            return result;
        }
    }
}