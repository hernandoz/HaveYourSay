using System;
using MvvmHelpers;
using Xamarin.Forms;

namespace HaveYourSay.Model
{
    public class Media : ObservableObject
    {
        public int Id { get; set; }
        public int DiaryId { get; set; }

        public byte[] ContentAsBytes { get; set; }
        public string ImagePath { get; set; }
    }
}
