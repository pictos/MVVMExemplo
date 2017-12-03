using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMExemplo.ViewModel
{
    public class SobreViewModel : BaseViewModel
    {
        private string _texto;

        public string Texto
        {
            get { return _texto; }
            set { _texto = value; OnPropertyChanged(); }
        }


        public SobreViewModel(string p)
        {
            Texto = p;
        }
    }
}
