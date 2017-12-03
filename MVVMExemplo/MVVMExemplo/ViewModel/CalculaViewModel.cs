using MVVMExemplo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVMExemplo.ViewModel
{
    public class CalculaViewModel : BaseViewModel
    {
        private string _quantidade;

        public string Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; OnPropertyChanged(); }
        }

        private string _valor;

        public string Valor
        {
            get { return _valor; }
            set { _valor = value; OnPropertyChanged(); }
        }

        public Command CalcularCommand { get; }
        public Command LimparCommand { get; }
        public Command SobreCommand { get; }

        public ObservableCollection<Valores> Historico { get; set; }

        CultureInfo culture;

        public CalculaViewModel()
        {
            Historico = new ObservableCollection<Valores>();
            CalcularCommand = new Command(ExecuteCalcularCommand);
            LimparCommand = new Command(ExecuteLimparCommand);
            SobreCommand = new Command(async () => await ExecuteSobreCommand());
            culture = new CultureInfo("pt-BR");
        }

        async Task ExecuteSobreCommand()
        {
            await PushAsync<SobreViewModel>("Eu sou a página sobre!");
        }

        private void ExecuteLimparCommand()
        {
            Historico.Clear();
            Valor = "";
            Quantidade = "";
        }

        private void ExecuteCalcularCommand()
        {
            double Resultado = double.Parse(Valor, culture) * 1000 / double.Parse(Quantidade, culture);
            Historico.Add(new Valores
            {
                ValorP = Valor,
                ValorC = Resultado.ToString("N2", culture)
            });
        }
    }
}
