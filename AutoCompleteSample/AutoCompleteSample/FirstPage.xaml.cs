using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;

namespace AutoCompleteSample
{
    public partial class FirstPage : ContentPage
    {
        private string _country;
        public string Country
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_country))
                {
                    return "";
                }
                else
                {
                    return _country;
                }
            }
            set
            {
                _country = value;
            }
        }


        private ObservableCollection<Country> _countries;
        public ObservableCollection<Country> Countries
        {
            get
            {
                if (_countries == null)
                {
                    return GetCountries();
                }
                return _countries;
            }
            set { _countries = value; }
        }

        private Command<string> _searchCommand;

        public FirstPage()
        {
            InitializeComponent();
            this.BindingContext = this; 
        }

        private ObservableCollection<Country> GetCountries()
        {
            try
            {
                var assembly = typeof(FirstPage).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("TewRailtext15.CountriesList.xml");
                ObservableCollection<Country> countries;
                using (var reader = new System.IO.StreamReader(stream))
                {
                    XmlRootAttribute xRoot = new XmlRootAttribute();
                    xRoot.ElementName = "Countries";
                    xRoot.IsNullable = true;

                    var serializer = new XmlSerializer(typeof(ObservableCollection<Country>), xRoot);
                    countries = (ObservableCollection<Country>)serializer.Deserialize(reader);

                    return countries;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Command<string> SearchCommand
        {
            get
            {
                return _searchCommand ?? (_searchCommand = new Command<string>(
                    obj => { },
                    obj => !string.IsNullOrEmpty(obj.ToString())));
            }
        }
    }
}
