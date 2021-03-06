﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExchangeRates
{
    public class Response : INotifyPropertyChanged
    {
        private string _error { get; set; }
        private bool _status { get; set; }

        [JsonProperty("error")]
        public string Error
        {
            get
            {
                return _error;
            }

            set
            {
                if (_error == value) return;

                _error = value;
                OnPropertyChanged(nameof(Error));
            }
        }

        [JsonProperty("status")]
        public bool Status
        {
            get
            {
                return _status;
            }

            set
            {
                if (_status == value) return;

                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
