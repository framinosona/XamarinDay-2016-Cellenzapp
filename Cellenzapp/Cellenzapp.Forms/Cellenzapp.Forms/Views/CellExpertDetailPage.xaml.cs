//
// CellExpertDetailPage.xaml.cs
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

using Xamarin.Forms;
using Cellenzapp.Core.Model;
using System.Diagnostics;
using Xamarin.Forms.Maps;

namespace Cellenzapp.Forms.Views
{
    public partial class CellExpertDetailPage : ContentPage
    {

        CellExpert Expert;

        public CellExpertDetailPage(CellExpert expert)
        {
            InitializeComponent();
            Expert = expert;
            this.BindingContext = expert;
            this.Title = expert.Name.Full;
            Debug.WriteLine($"Navigated to : {expert.Name.Full}");


        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var position = new Position(Expert.Location.Lat, Expert.Location.Lon);
            var pin = new Pin {
                Type = PinType.Place,
                Position = position,
                Label = "",
                Address = $"{Expert.Location.Street} - {Expert.Location.City} {Expert.Location.Postcode}"
            };
            Location.Pins.Add(pin);
            Location.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(1)));
        }
    }
}
