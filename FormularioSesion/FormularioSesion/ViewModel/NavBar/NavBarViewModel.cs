using FormularioSesion.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FormularioSesion.ViewModel.NavBar
{
    public class NavBarViewModel
    {
        public ICommand CollectionViewCommand { get; set;  } 

        public NavBarViewModel() {
            CollectionViewCommand = new Command<object[]>(CollectionViewEvent);
        }
            
        public void CollectionViewEvent(object[] args)
        {
            //debemos especificar los datos que le pasamos por la matriz.
            object sender = args[0];
            SelectionChangedEventArgs e = (SelectionChangedEventArgs)args[1];

            if (Application.Current.MainPage is FlyoutPage flyoutPage)
            {
                var item = e.CurrentSelection.FirstOrDefault() as FlyoutPageItem;
                if (item != null)
                {
                    //NavigationPage.SetHasNavigationBar(this, false);
                    flyoutPage.Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                    flyoutPage.IsPresented = false;
                    ((CollectionView)sender).SelectedItem = false;
                }
            }
        }
    }
}
