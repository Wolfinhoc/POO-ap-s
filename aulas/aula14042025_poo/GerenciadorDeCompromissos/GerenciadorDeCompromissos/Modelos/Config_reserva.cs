namespace ConsoleApp.Modelos;

 public class ConfiguracaoReserva{
        public DateTime DataMinima {
            get;
            private set;
        }
        public DateTime DataMaxima {
            get;
            private set;
        }
        public TimeSpan HoraMinima {
            get;
            private set;
        }

        public TimeSpan HoraMaxima{
            get;
            private set;
        }

        public ConfiguracaoReserva(DateTime dataMinima, DateTime dataMaxima, TimeSpan horaMinima, TimeSpan horaMaxima){
            
            if (dataMinima > dataMaxima){
                
                throw new ArgumentException("Data mínima deve ser menor que a data máxima");
            }
               
            if (horaMinima > horaMaxima){

                throw new ArgumentException("Hora mínima deve ser menor que a hora máxima");
            }
             
            DataMinima = dataMinima;
            DataMaxima = dataMaxima;
            HoraMinima = horaMinima;
            HoraMaxima = horaMaxima;
        }

        public bool ValidarData(DateTime data){

            return data >= DataMinima && data <= DataMaxima;
        }

        public bool ValidarHora(TimeSpan hora){

            return hora >= HoraMinima && hora <= HoraMaxima;
        }
    }