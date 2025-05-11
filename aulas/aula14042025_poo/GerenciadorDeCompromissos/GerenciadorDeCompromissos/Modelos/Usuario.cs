namespace ConsoleApp.Modelos
{
    public class Usuario
    {
        public string NomeCompleto { get; set; }

        private List<Compromisso> _compromissos = new();
        public IReadOnlyCollection<Compromisso> Compromissos => _compromissos.AsReadOnly();

        public Usuario(string nomeCompleto)
        {
            NomeCompleto = nomeCompleto ?? throw new ArgumentException("Nome completo é obrigatório.");
        }

        public void AdicionarCompromisso(Compromisso compromisso)
        {
            if (compromisso == null) throw new ArgumentNullException(nameof(compromisso));
            if (!_compromissos.Contains(compromisso))
                _compromissos.Add(compromisso);
        }
    }
}
