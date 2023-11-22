using Xamarin.Google.Crypto.Tink.Proto;
using static Android.Graphics.ColorSpace;

namespace XamarinMHike;

public partial class HikeContentPage : ContentPage
{
    HikeModel models;

    public HikeContentPage()
    {
        InitializeComponent();
    }

    public HikeContentPage(HikeModel model)
    {
        InitializeComponent();
        models = model;
        txtHike.Text = model.name;
        txtLocation.Text = model.location;
        dtpDateofBirth.Date = model.date;
        model.isParking = model.isParking;
        txtLength.Text = model.length.ToString();
        cbxLevel.SelectedItem = model.level;
        txtDescription.Text = model.description;
        txtVehicle.Text = model.vehicle;
        txtMember.Text = model.member.ToString();
    }

    private async void btnSubmit_Clicker(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtHike.Text))
        {
            await DisplayAlert("Invalid", "BLank or white space", "ok");
        }
        else if (models != null)
                {
                    EditHike();
                }
        else
        {
            AddNewHike();
        }

        async void AddNewHike()
        {

            await App.MyDb.AddHike(new HikeModel
            {
                name = txtHike.Text,
                location = txtLocation.Text,
                date = dtpDateofBirth.Date,
                isParking = 1,
                length = float.Parse(txtLength.Text),
                level = (string)cbxLevel.SelectedItem,
                description = txtDescription.Text,
                vehicle = txtVehicle.Text,
                member = int.Parse(txtMember.Text),

            });
            await Navigation.PopAsync();
        }

        async void EditHike()
        {
            models.name = txtHike.Text;
            models.location = txtLocation.Text;
            models.date = dtpDateofBirth.Date;
            models.isParking = 1;
            models.length = float.Parse(txtLength.Text);
            models.level = (string)cbxLevel.SelectedItem;
            models.description = txtDescription.Text;
            models.vehicle = txtVehicle.Text;
            models.member = int.Parse(txtMember.Text);

            await App.MyDb.UpdateHike(models);
            await Navigation.PopAsync();

        }
    }
}