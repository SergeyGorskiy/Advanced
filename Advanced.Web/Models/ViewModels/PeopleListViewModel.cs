using System.Collections.Generic;

namespace Advanced.Web.Models.ViewModels
{
    public class PeopleListViewModel
    {
        public IEnumerable<Person> People { get; set; }

        public IEnumerable<string> Cities { get; set; }

        public string SelectedCity { get; set; }

        public string GetClass(string city)
        {
            return SelectedCity == city ? "bg-info text-white" : "";
        }
    }
}