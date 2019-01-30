using System;
using System.Collections.Generic;
using HaveYourSay.ViewModel;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace HaveYourSay.Views
{
    public partial class ScanView : ContentPage
    {
        FormViewModel viewModel = new FormViewModel();
        public ScanView()
        {
            InitializeComponent();
            BindingContext = new FormViewModel();
        }

        async void Handle_ClickedAsync(object sender, System.EventArgs e)
        {
            var scanPage = new ZXingScannerPage();
            // Navigate to our scanner page
            await Navigation.PushAsync(scanPage);

            scanPage.OnScanResult += (result) =>
            {
                // Stop scanning
                scanPage.IsScanning = false;

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    //await DisplayAlert("Scanned Barcode", result.Text, "OK");
                    Console.WriteLine(result.Text);
                    await Navigation.PushAsync(new FormEntry(result.Text));

                });
            };
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new FormEntry("001780¬1 Finsbury Avenue¬Level 2¬North East"));
        }
    }
}
