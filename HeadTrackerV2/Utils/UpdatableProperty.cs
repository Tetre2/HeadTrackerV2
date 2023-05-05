using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HeadTrackerV2.Utils
{
    public class UpdatableProperty<T> : INotifyPropertyChanged
    {
        private T val;
        public T Value
        {
            get { return val; }
            set
            {
                val = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Value"));

            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }

    }

}
