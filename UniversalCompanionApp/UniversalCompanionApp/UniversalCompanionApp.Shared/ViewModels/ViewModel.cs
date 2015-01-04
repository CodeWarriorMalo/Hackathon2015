using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UniversalCompanionApp.ViewModels
{
    class ViewModel : INotifyPropertyChanged
    {
        MobileServiceClient _Client;

        public ViewModel(MobileServiceClient client)
        {
            _Client = client;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private MobileServiceCollection<Config, Config> _Configs;
        public MobileServiceCollection<Config, Config> Configs
        {
            get { return _Configs; }
            set { _Configs = value; NotifyPropertyChanged("Configs"); }
        }

        private MobileServiceCollection<ContactInfo, ContactInfo> _ContactInfos;
        public MobileServiceCollection<ContactInfo, ContactInfo> ContactInfos
        {
            get { return _ContactInfos; }
            set { _ContactInfos = value; NotifyPropertyChanged("ContactInfos"); }
        }

        public MobileServiceCollection<RawData, RawData> _RawDatas;
        public MobileServiceCollection<RawData, RawData> RawDatas
        {
            get { return _RawDatas; }
            set { _RawDatas = value; NotifyPropertyChanged("RawDatas"); }
        }
        private bool _IsPending;
        public bool IsPending
        {
            get { return _IsPending; }
            set { _IsPending = value; NotifyPropertyChanged("IsPending"); }
        }
        private string _ErrorMessage = null;
        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set
            {
                _ErrorMessage = value;
                NotifyPropertyChanged("ErrorMessage");
            }
        }

        public async Task GetAllConfigsAsync()
        {
            IsPending = true;
            ErrorMessage = null;

            try
            {
                IMobileServiceTable<Config> table = _Client.GetTable<Config>();
                Configs = await table.OrderBy(x => x.DeviceId).ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                ErrorMessage = ex.Message;
            }
            catch (HttpRequestException ex2)
            {
                ErrorMessage = ex2.Message;
            }
            finally
            {
                IsPending = false;
            }
        }
        public async Task AddCofigAsync(Config config)
        {
            IsPending = true;
            ErrorMessage = null;

            try
            {
                IMobileServiceTable<Config> table = _Client.GetTable<Config>();
                await table.InsertAsync(config);
                Configs.Add(config);
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                ErrorMessage = ex.Message;
            }
            catch (HttpRequestException ex2)
            {
                ErrorMessage = ex2.Message;
            }
            finally
            {
                IsPending = false;
            }
        }
    }
}
