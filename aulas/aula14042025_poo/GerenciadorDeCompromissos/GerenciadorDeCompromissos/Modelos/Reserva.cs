namespace ConsoleApp.Modelos;
  public class Reserva
    {
        private ConfiguracaoReserva _configReserva;
        private DateTime _data;
        private TimeSpan _hora;
        private string _descricaoSala;
        private int _capacidade;

        public List<string> Erros { 
            get; private set; 
        }

        public Reserva(ConfiguracaoReserva configuracaoReserva){

            _configReserva = configuracaoReserva;
            Erros = new List<string>();
        }

        public void RegistrarData(DateTime data){

            _data = data;
        }

        public void RegistrarHora(TimeSpan hora){
           
            _hora = hora;
        }

        public void RegistrarDescricao(string descricao){
           
            _descricaoSala = descricao;
        }

        public void RegistrarCapacidade(int capacidade){
           
            _capacidade = capacidade;
        }

        public void ValidarReserva(){
            
            Erros.Clear();

            if (!_configReserva.ValidarData(_data))
                Erros.Add("Data fora do intervalo permitido");

            if (!_configReserva.ValidarHora(_hora))
                Erros.Add("Hora fora do intervalo permitido");

            if (_capacidade <= 0 || _capacidade >= 40)
                Erros.Add("Capacidade deve ser maior que 0 e menor que 40");
        }

        public override string ToString(){
          
            return $"Data: {_data:dd'/'MM'/'yyyy} Hora: {_hora:hh\\:mm} Sala: {_descricaoSala} Capacidade: {_capacidade}";
        }
    }