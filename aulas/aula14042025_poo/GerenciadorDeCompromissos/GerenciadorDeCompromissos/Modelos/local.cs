using System;
using System.Collections.Generic;

namespace ConsoleApp.Modelos
{
    public class Local
    {
        public string Nome { get; set; }
        public int CapacidadeMaxima { get; set; }

        private List<Compromisso> _compromissos = new();
        public IReadOnlyCollection<Compromisso> Compromissos => _compromissos.AsReadOnly();

        public Local(string nome, int capacidadeMaxima)
        {
            Nome = nome ?? throw new ArgumentException("Nome do local é obrigatório.");
            CapacidadeMaxima = capacidadeMaxima > 0 ? capacidadeMaxima : throw new ArgumentException("Capacidade deve ser maior que zero.");
        }

        public bool ValidarCapacidade(int quantidade)
        {
            return quantidade <= CapacidadeMaxima;
        }

        public void AdicionarCompromisso(Compromisso compromisso)
        {
            if (!_compromissos.Contains(compromisso))
                _compromissos.Add(compromisso);
        }
    }
}
