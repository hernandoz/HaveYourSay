using System;
using System.Collections.ObjectModel;
using System.IO;
using HaveYourSay.Model;
using MvvmHelpers;
using Xamarin.Forms;

namespace HaveYourSay.ViewModel
{
    public class FormViewModel : BaseViewModel
    {

        public FormViewModel()
        {
            Media = new ObservableCollection<Media>();
            Item = new Model.Entry();
        }

        private Model.Entry item;

        public Model.Entry Item
        {
            get { return item; }
            set
            {
                item = value;
            }
        }


        private string project = string.Empty;

        public string Project
        {
            get
            {
                return project;
            }
            set
            {
                if (SetProperty(ref project, value))
                {
                    string[] words = project.Split('¬');
                    project = words[1];

                    Location = words[2] + " : " + words[3];

                    Item.Project = Project;
                    Item.Location = location;
                }
            }
        }
        private string location;

        public string Location 
        { 
            get { return location; }
            set 
            {
                SetProperty(ref location, value);
                
            }
        }

        private ObservableCollection<Media> _media;

        public ObservableCollection<Media> Media
        {
            get => _media;
            set
            {
                _media = value;
                OnPropertyChanged();
            }
        }

        public void AddMedia(byte[] mediaAsBytes, string path)
        {
            var media = new Media
            {
                ContentAsBytes = mediaAsBytes,
                ImagePath = path

            };

            Media.Add(media);

            OnPropertyChanged(nameof(Media));
        }

        public async void SaveEntryAsync()
        {
            await App.restManager.SaveEntryAsync(Item);
            await Application.Current.MainPage.DisplayAlert("Alert", "Thanks for sending Imformaiton", null , "ok");
            await Application.Current.MainPage.Navigation.PopAsync();

        }

        public async void UploadPhoto()
        {
            //string title = DateTime.Now.ToString();
            foreach (var photo in Media)
            {
                try
                {
                    Guid g;
                    g = Guid.NewGuid();

                    var x = await BlobStorageService.SaveBlockBlob("mediastorage", photo.ContentAsBytes, g.ToString());
                    Console.WriteLine($"Uploaded Photo ::: " + g.ToString() +";;;;;" + x.Uri);

                    item.ImageUrl = x.Uri.ToString();

                    //SaveEntryAsync();

                } 
                catch (Exception e)
                {
                    Console.WriteLine($":::::::" + e);
                }
            }
        }

    }
}
