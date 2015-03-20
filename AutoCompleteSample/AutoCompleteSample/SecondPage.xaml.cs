using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AutoCompleteSample
{
    public partial class SecondPage : ContentPage
    {
        ObservableCollection<string> Items = new ObservableCollection<string>(); 
        public SecondPage()
        {
            InitializeComponent();

            for (int i = 0; i < 50; i++)
            {
                Items.Add(i.ToString());
            }

            //Set item source for the list to populate it 
            itemsList.ItemsSource = Items; 
        }
    }
}
