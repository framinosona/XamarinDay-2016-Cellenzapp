//
// MasterDetailMenu.xaml.cs
//
// Author:
//       Francois Raminosona <framinosona@hotmail.fr>
//
// Copyright (c) 2016 François Raminosona
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;
using System.Linq;

using Xamarin.Forms;
using Cellenzapp.Forms.ViewModel;

namespace Cellenzapp.Forms.Views
{
    public partial class MasterDetailMenu : ContentPage
    {
        private readonly MasterDetailViewModel ViewModel;
        public MasterDetailMenu()
        {
            InitializeComponent();
            ViewModel = SimpleIoc.Default.GetInstance<MasterDetailViewModel>();
            ViewModel.CurrentPageChanged += VmOnCurrentPageChanged;
            ListViewMenu.ItemSelected += ListViewMenuOnItemSelected;
            this.Icon = ImageSource.FromResource("Cellenzapp.Forms.Resources.Images.hamburger.png") as FileImageSource;
        }


        private void VmOnCurrentPageChanged(object sender, NavigationOccuredEventArgs navigationOccuredEventArgs)
        {
            if(ListViewMenu.SelectedItem != navigationOccuredEventArgs.MenuItem) {
                ListViewMenu.SelectedItem =
                    ViewModel.MenuItems.First(kvp => kvp.Key == navigationOccuredEventArgs.PageType);
            }
        }

        private void ListViewMenuOnItemSelected(object sender, SelectedItemChangedEventArgs selectedItemChangedEventArgs)
        {
            if(ListViewMenu.SelectedItem == null)
                return;


            ViewModel.SetCurrentPage(
                ((KeyValuePair<MenuPagesEnum, HomeMenuItem>)selectedItemChangedEventArgs.SelectedItem).Key);
            /*
            try
            {
                ViewModel.SetCurrentPage(
                    ((KeyValuePair<MenuPagesEnum, HomeMenuItem>)selectedItemChangedEventArgs.SelectedItem).Key);
            }
            catch (Exception)
            {
                try
                {
                    ViewModel.SetCurrentPage(
                        ((HomeMenuItem)selectedItemChangedEventArgs.SelectedItem).MenuPagesEnum);
                }
                catch (Exception)
                {
                    
                }
            }*/
        }
    }
}
