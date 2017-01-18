using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Tillsammens.WindowsPhone.App.Messages;
using Tillsammens.WindowsPhone.Domain.Model;
using Tillsammens.WindowsPhone.Domain.Services.Interfaces;

namespace Tillsammens.WindowsPhone.App.ViewModel
{
    public class TillsammensViewModelBase : ViewModelBase
    {
        protected readonly IDialogService DialogService;
        protected readonly ITillsammensService TillsammensService;

        private bool _isWorking;

        public TillsammensViewModelBase(IDialogService dialogService, ITillsammensService tillsammensService)
        {
            DialogService = dialogService;
            TillsammensService = tillsammensService;
        }

        public bool IsWorking
        {
            get { return _isWorking; }
            set { Set(ref _isWorking, value); }
        }

        protected void ShowWebResultCommunicate(WebServiceStatus status)
        {
            string message = null;
            switch (status)
            {
                case WebServiceStatus.ConnectionError:
                    message = "Service is not available.";
                    break;

                case WebServiceStatus.ServiceError:
                    message = "Internal server error.";
                    break;


                case WebServiceStatus.Unauthorized:
                    message = "Wrong login or password.";
                    break;
            }
            DialogService.ShowMessageBox(message, string.Empty);
        }

        protected void StartWorking()
        {
            IsWorking = true;
            MessengerInstance.Send(new ShowTopProgressBarMessage(true));
        }

        protected void StopWorking()
        {
            IsWorking = false;
            MessengerInstance.Send(new ShowTopProgressBarMessage(false));
        }
    }
}
