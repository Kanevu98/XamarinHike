namespace XamarinMHike
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                hikeColletion.ItemsSource = await App.MyDb.ReadHike();
            }
            catch (Exception ex)
            {

            }
        }
        private async void SwipeItem_Invoke_Edit(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as HikeModel;
            await Navigation.PushAsync(new HikeContentPage(emp));
        }

        private async void SearchBar_TextChange(object sender, TextChangedEventArgs e)
        {
            hikeColletion.ItemsSource = await App.MyDb.Search(e.NewTextValue);
        }

        private async void ToolbarItem_Clicked_AddHike(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HikeContentPage());
        }

        private async void SwipeItem_Invoke_Delete(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as HikeModel;
            var result = await DisplayAlert("Delete", $"Delete {emp.name} from database", "yes", "no");
            if (result)
            {
                await App.MyDb.DeleteHike(emp);
                hikeColletion.ItemsSource = await App.MyDb.ReadHike();
            }
        }
    }
}