//
// MasterDetailViewModel.cs
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
using Cellenzapp.Core.ViewModel;
using Xamarin.Forms;
using System.Collections.Generic;
using Cellenzapp.Core.Helpers.MVVM;
using Cellenzapp.Forms.Views;

namespace Cellenzapp.Forms.ViewModel
{
    public class HomeMenuItem
    {
        public bool IsEnabled { get; set; } = true;
        public string Title { get; set; }
        public ImageSource ImgSource { get; set; }
        public MenuPagesEnum MenuPagesEnum { get; set; }

        /// <summary>
        /// Used if MasterDetailPage doesn't have the required NavigationPage. Has to create one.
        /// </summary>
        public Func<NavigationPage> CreateNavigationPage { get; set; }

    }
    public enum MenuPagesEnum
    {
        CellExperts,
        Settings,
        About,
    }
    public class NavigationOccuredEventArgs : EventArgs
    {
        public MenuPagesEnum PageType { get; set; }
        public NavigationPage Page { get; set; }
        public HomeMenuItem MenuItem { get; set; }
    }
    public class MasterDetailViewModel : CustomViewModelBase
    {
        public MasterDetailViewModel()
        {

            Pages = new Dictionary<MenuPagesEnum, NavigationPage>();
            MenuItems = new ObservableDictionary<MenuPagesEnum, HomeMenuItem>
            {
                {
                    MenuPagesEnum.CellExperts, new HomeMenuItem
                    {
                        Title = "Cell'Experts",
                        MenuPagesEnum = MenuPagesEnum.CellExperts,
                        ImgSource = ImageSource.FromResource("Cellenzapp.Forms.Resources.Images.social.png"),
                        CreateNavigationPage = () => new NavigationPage(new CellExpertsPage())
                    }
                },
                {
                    MenuPagesEnum.Settings, new HomeMenuItem
                    {
                        Title = "Settings",
                        MenuPagesEnum = MenuPagesEnum.Settings,
                        ImgSource = ImageSource.FromResource("Cellenzapp.Forms.Resources.Images.settings.png"),
                        CreateNavigationPage = () => new NavigationPage(new SettingsPage())
                    }
                },
                {
                    MenuPagesEnum.About, new HomeMenuItem
                    {
                        Title = "About",
                        MenuPagesEnum = MenuPagesEnum.About,
                        ImgSource = ImageSource.FromResource("Cellenzapp.Forms.Resources.Images.info.png"),
                        CreateNavigationPage = () => new NavigationPage(new AboutPage())
                    }
                }
            };

            this.CurrentPageType = MenuPagesEnum.CellExperts;
        }

        public MenuPagesEnum CurrentPageType { get; private set; }

        private Dictionary<MenuPagesEnum, NavigationPage> Pages { get; }
        public ObservableDictionary<MenuPagesEnum, HomeMenuItem> MenuItems { get; }

        public event EventHandler<NavigationOccuredEventArgs> CurrentPageChanged;

        protected virtual void OnCurrentPageChanged(NavigationOccuredEventArgs e)
        {
            var handler = CurrentPageChanged;
            handler?.Invoke(this, e);
        }

        public void SetCurrentPage(MenuPagesEnum id)
        {
            if(id == CurrentPageType) return;

            if(!Pages.ContainsKey(id)) {
                Pages.Add(id, MenuItems[id].CreateNavigationPage.Invoke());
            }

            var newPage = Pages[id];
            if(newPage == null)
                return;
            CurrentPageType = id;
            OnCurrentPageChanged(new NavigationOccuredEventArgs {
                Page = newPage,
                PageType = id,
                MenuItem = MenuItems[id]
            });
        }
    }
}
