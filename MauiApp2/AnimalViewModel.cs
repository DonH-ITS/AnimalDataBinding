

using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiApp2
{
    public class AnimalViewModel : INotifyPropertyChanged
    {
        private string title;
        private List<Animal> animalList;
        private HttpClient httpClient;

        private ObservableCollection<Animal> _animals;
        public ObservableCollection<Animal> Animals { get => _animals; }


        public string Title
        {
            get => title;
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool isBusy;
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsNotBusy));
                }
            }
        }
        public bool IsNotBusy => !IsBusy;

        public event PropertyChangedEventHandler? PropertyChanged;

        public AnimalViewModel()
        {
            httpClient = new HttpClient();
            animalList = new List<Animal>();
        }


        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task<string> GetAnimals()
        {
            var response = await httpClient.GetAsync("https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/MonkeysApp/monkeydata.json");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "";
        }


    }
}
