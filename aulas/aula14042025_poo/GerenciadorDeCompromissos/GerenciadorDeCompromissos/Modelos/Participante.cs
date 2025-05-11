using System.Collections.Generic;

namespace ConsoleApp.Modelos
{
    public class Participante
    {
        public string Nome { get; set; }

        private List<Compromisso> _compromissos = new();
        public IReadOnlyCollection<Compromisso> Compromissos => _compromissos.AsReadOnly();

        public Participante(string nome)
        {
            Nome = nome;
        }

        public void AdicionarCompromisso(Compromisso compromisso)
        {
            if (!_compromissos.Contains(compromisso))
                _compromissos.Add(compromisso);
        }
    }
}
