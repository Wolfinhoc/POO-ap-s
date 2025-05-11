namespace ConsoleApp.Modelos;

public class Compromisso
{
    private DateTime _data;
    private TimeSpan _hora; 
    public String Data
    {
        get { return _data.ToString(); }
        set
        {
            _validarDataInformada(value);
            _validarDataValidaParaCompromisso();
        }
    }
    public string Hora
        {
            get { return _hora.ToString(@"hh\:mm"); }
            set
            {
                _validarHoraInformada(value);
                _validarHoraValidaParaCompromisso();
            }
        }
    public string Descricao { get; set; }
    public string Local { get; set; }

    private void _validarDataInformada(string data) {
        if (!DateTime.TryParseExact(data,
                       "dd/MM/yyyy",
                       System.Globalization.CultureInfo.GetCultureInfo("pt-BR"),
                       System.Globalization.DateTimeStyles.None,
                       out _data))
        {
            throw new Exception($"Data {data} Inválida!");
        }
    }
    private void _validarHoraInformada(string hora)
        {
            if (!TimeSpan.TryParseExact(
                    hora,
                    @"hh\:mm",
                    System.Globalization.CultureInfo.InvariantCulture,
                    out _hora))
            {
                throw new Exception($"Hora '{hora}' inválida!");
            }
        }

     private void _validarHoraValidaParaCompromisso()
        {
            var horaMin = new TimeSpan(13, 0, 0);
            var horaMax = new TimeSpan(17, 30, 0);

            if (_hora < horaMin || _hora > horaMax)
            {
                throw new Exception(
                    $"Hora {_hora:hh\\:mm} inválida. " +
                    $"O compromisso deve ser entre {horaMin:hh\\:mm} e {horaMax:hh\\:mm}.");
            }
        }

    private void _validarDataValidaParaCompromisso() {
        if (_data<=DateTime.Now) {
            throw new Exception($"Data {_data.ToString("dd/MM/yyyy")} é inferior a permitida.");
        }
        // if (_data == null) {
        //     throw new Exception("Data ainda não informada");
        // }
    }
    // private TimeSpan _hora;
    // public TimeSpan Hora
    // {
    //     get { return _hora; }
    //     set { _hora = value; }
    // }

    // private DateTime _data;

    // public DateTime Data {
    //     get {
    //         return _data;
    //     }
    //     set {
    //         _data = value;
    //     }
    // }

    // public string DataBR() {
    //     return _data.ToString("dd/MM/yyyy");
    // }

    // public void RegistrarData(DateTime data) {
    //     _data = data;
    // }

    // public DateTime ObterData() {
    //     return _data;
    // }
}