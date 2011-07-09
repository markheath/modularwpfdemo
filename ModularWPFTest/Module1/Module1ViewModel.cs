using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using ModularWPFTest.MvvmUtils;

namespace ModularWPFTest
{
    class Module1ViewModel : ViewModelBase
    {
        private string userName;
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                if (userName != value)
                {
                    userName = value;
                    RaisePropertyChanged("UserName");
                }
            }
        }
    }
}
