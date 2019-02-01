using System;
using MvvmHelpers;

namespace HaveYourSay.Model
{
    public class Entry : ObservableObject
    {
        public string Project { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        //public Media[] Media { get; set; }

    }
}
