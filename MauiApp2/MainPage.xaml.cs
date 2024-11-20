namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        private AnimalViewModel animalViewModel;
    
        public MainPage()
        {
            InitializeComponent();
            animalViewModel = new AnimalViewModel();
            BindingContext = animalViewModel;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            infoLabel.Text = await animalViewModel.GetAnimals();
        }
    }

}
