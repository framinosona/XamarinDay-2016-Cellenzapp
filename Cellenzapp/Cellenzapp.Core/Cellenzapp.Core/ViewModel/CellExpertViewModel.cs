//
// CellExpertViewModel.cs
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
using System.Diagnostics;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Cellenzapp.Core.Model;
using Plugin.Messaging;
using Plugin.ExternalMaps;
using GalaSoft.MvvmLight.Ioc;

namespace Cellenzapp.Core.ViewModel
{
    public class CellExpertViewModel : CustomViewModelBase
    {
        public const string ExpertPropertyName = "Expert";

        private CellExpert _expert;

        /// <summary>
        ///     Sets and gets the Expert property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public CellExpert Expert {
            get { return _expert; }

            set {
                if(_expert == value) {
                    return;
                }

                _expert = value;
                RaisePropertyChanged(ExpertPropertyName);
            }
        }

        public CellExpertViewModel()
        {
        }


        #region Email
        RelayCommand<string> emailCommand;
        public RelayCommand<string> EmailCommand {
            get { return emailCommand ?? (emailCommand = new RelayCommand<string>(async (emailAddress) => await ExecuteEmailCommandAsync(emailAddress))); }
        }

        async Task ExecuteEmailCommandAsync(string emailAddress)
        {
            if(IsBusy)
                return;

            IsBusy = true;

            try {
                Debug.WriteLine($"Open mail : {emailAddress}");
                var emailTask = MessagingPlugin.EmailMessenger;
                if(emailTask.CanSendEmail) {
                    // Send simple e-mail to single receiver without attachments, CC, or BCC.
                    emailTask.SendEmail(emailAddress, "Xamarin Day", "Hey ! Xamarin Day c'est génial ! Merci pour ta présentation !");
                }
                // Send Email
            } catch(Exception ex) {
                Debugger.Break();
            } finally {
                IsBusy = false;
            }
        }
        #endregion


        #region OpenMap
        RelayCommand<string> openMapCommand;
        public RelayCommand<string> OpenMapCommand {
            get { return openMapCommand ?? (openMapCommand = new RelayCommand<string>(async (openMapAddress) => await ExecuteOpenMapCommandAsync(openMapAddress))); }
        }

        async Task ExecuteOpenMapCommandAsync(string openMapAddress)
        {
            if(IsBusy)
                return;

            IsBusy = true;

            try {
                Debug.WriteLine($"Open map : {openMapAddress}");
                var success = await CrossExternalMaps.Current.NavigateTo("Cellenza", "156 Boulevard Haussmann", "Paris", "Paris", "75008", "France", "France");


                // Send OpenMap
            } catch(Exception ex) {
                Debugger.Break();
            } finally {
                IsBusy = false;
            }
        }
        #endregion


        #region Call
        RelayCommand<string> callCommand;
        public RelayCommand<string> CallCommand {
            get { return callCommand ?? (callCommand = new RelayCommand<string>(async (phoneNumber) => await ExecuteCallCommandAsync(phoneNumber))); }
        }

        async Task ExecuteCallCommandAsync(string phoneNumber)
        {
            if(IsBusy)
                return;

            IsBusy = true;

            try {
                Debug.WriteLine($"Call : {phoneNumber}");
                var phoneCallTask = MessagingPlugin.PhoneDialer;
                if(phoneCallTask.CanMakePhoneCall)
                    phoneCallTask.MakePhoneCall(phoneNumber);
                // Send Call
            } catch(Exception ex) {
                Debugger.Break();
            } finally {
                IsBusy = false;
            }
        }
        #endregion


        #region SendSMS
        RelayCommand<string> sendSMSCommand;
        public RelayCommand<string> SendSMSCommand {
            get { return sendSMSCommand ?? (sendSMSCommand = new RelayCommand<string>(async (phoneNumber) => await ExecuteSendSMSCommandAsync(phoneNumber))); }
        }

        async Task ExecuteSendSMSCommandAsync(string phoneNumber)
        {
            if(IsBusy)
                return;

            IsBusy = true;

            try {
                Debug.WriteLine($"Text : {phoneNumber}");
                var smsMessenger = MessagingPlugin.SmsMessenger;
                if(smsMessenger.CanSendSms)
                    smsMessenger.SendSms(phoneNumber, "XamaLove @ #XamarinDay");
                // Send SendSMS
            } catch(Exception ex) {
                Debugger.Break();
            } finally {
                IsBusy = false;
            }
        }
        #endregion


        #region Twitter
        RelayCommand<string> twitterCommand;
        public RelayCommand<string> TwitterCommand {
            get { return twitterCommand ?? (twitterCommand = new RelayCommand<string>(async (twitterHandle) => await ExecuteTwitterCommandAsync(twitterHandle))); }
        }

        async Task ExecuteTwitterCommandAsync(string twitterHandle)
        {
            if(IsBusy)
                return;

            IsBusy = true;

            try {

                var TwitterService = (ITwitterService)SimpleIoc.Default.GetService(typeof(ITwitterService));
                TwitterService.OpenTwitterUri(twitterHandle);
                // Send Twitter
            } catch(Exception ex) {
                Debugger.Break();
            } finally {
                IsBusy = false;
            }
        }
        #endregion
    }
}
