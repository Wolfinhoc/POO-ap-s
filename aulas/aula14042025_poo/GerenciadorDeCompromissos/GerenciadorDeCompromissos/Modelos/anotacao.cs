using System;

namespace ConsoleApp.Modelos
{
    public class Anotacao
    {
        public string Texto { get; set; }
        public DateTime DataCriacao { get; private set; }

        public Anotacao(string texto)
        {
            Texto = string.IsNullOrWhiteSpace(texto) ? throw new ArgumentException("Texto é obrigatório.") : texto;
            DataCriacao = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{DataCriacao:dd/MM/yyyy HH:mm} - {Texto}";
        }
    }
}
