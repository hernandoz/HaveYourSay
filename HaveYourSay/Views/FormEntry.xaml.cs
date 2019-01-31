using System;
using System.Collections.Generic;
using HaveYourSay.ViewModel;
using Plugin.Media;
using Xamarin.Forms;
using System.IO;
using Plugin.Media.Abstractions;

namespace HaveYourSay.Views
{
    public partial class FormEntry : ContentPage
    {
        public FormViewModel viewModel => BindingContext as FormViewModel;

        public FormEntry(string data)
        {
            InitializeComponent();
            BindingContext = new FormViewModel();
            codedata.Text = data;

            var monkeyList = new List<string>();
            monkeyList.Add("Safety Observation / Near Miss");
            monkeyList.Add("Clean Up Needed");
            monkeyList.Add("Environmental Incident");
            monkeyList.Add("Good Practice");
            monkeyList.Add("Suggestion");

            picker.ItemsSource = monkeyList;
        }

        void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Console.WriteLine("Picker selected ");
        }

        async void AddPhoto_ClickedAsync(object sender, System.EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }


            var mediaOptions = new StoreCameraMediaOptions
            {
                Directory = "SRM_App",
                Name = $"{DateTime.UtcNow}.jpg",
                PhotoSize = PhotoSize.Medium
            };
                
            using (var file = await CrossMedia.Current.TakePhotoAsync(mediaOptions))
            {
                if (file == null)
                    return;

                var imageAsBytes = File.ReadAllBytes(file.Path);
                var path = file.Path;

                addedImage.Source = path;
                viewModel.AddMedia(imageAsBytes, path);

            }
        }

        void Submit_Clicked(object sender, System.EventArgs e)
        {
            viewModel.SaveEntryAsync();
        }

        void UploadPhoto_Clicked(object sender, System.EventArgs e)
        {
            viewModel.UploadPhoto();
        }
    }
}
