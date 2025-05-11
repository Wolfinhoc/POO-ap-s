using ConsoleApp.Modelos;

Console.WriteLine("Configuração das reservas de compromissos\n");

// Cadastro do usuário responsável
Console.Write("Nome do usuário responsável: ");
var nomeUsuario = Console.ReadLine();
var usuario = new Usuario(nomeUsuario);

// Cadastro do local
Console.Write("Nome do local (ex: Sala 101, Online): ");
var nomeLocal = Console.ReadLine();
Console.Write("Capacidade máxima do local: ");
var capacidadeLocal = int.Parse(Console.ReadLine());
var local = new Local(nomeLocal, capacidadeLocal);

// Cadastro do compromisso
Console.WriteLine("\nCadastro do compromisso");
Console.Write("Data (dd/MM/yyyy): ");
var dataTexto = Console.ReadLine();
Console.Write("Hora (hh:mm): ");
var horaTexto = Console.ReadLine();
Console.Write("Descrição do compromisso: ");
var descricao = Console.ReadLine();

var compromisso = new Compromisso
{
    Data = dataTexto,
    Hora = horaTexto,
    Descricao = descricao,
    Local = nomeLocal
};

// Adiciona anotação
Console.Write("Deseja adicionar uma anotação? (s/n): ");
var resposta = Console.ReadLine();
if (resposta?.ToLower() == "s")
{
    Console.Write("Texto da anotação: ");
    var textoAnotacao = Console.ReadLine();
    var anotacao = new Anotacao(textoAnotacao);
    Console.WriteLine("Anotação registrada: " + anotacao);
}

// Cadastro de participantes
Console.Write("Quantos participantes deseja adicionar? ");
int qtdParticipantes = int.Parse(Console.ReadLine());

for (int i = 0; i < qtdParticipantes; i++)
{
    Console.Write($"Nome do participante #{i + 1}: ");
    string nomeParticipante = Console.ReadLine();
    var participante = new Participante(nomeParticipante);
    try
    {
        if (local.ValidarCapacidade(i + 1))
        {
            participante.AdicionarCompromisso(compromisso);
            Console.WriteLine($"Participante {nomeParticipante} adicionado com sucesso.");
        }
        else
        {
            Console.WriteLine("Capacidade do local excedida. Participante não adicionado.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao adicionar participante: {ex.Message}");
    }
}

// Relacionamentos manuais (visto que sua classe Compromisso original não possui propriedades de objeto)
usuario.AdicionarCompromisso(compromisso);
local.AdicionarCompromisso(compromisso);

// Exibe o compromisso final
Console.WriteLine("\nResumo do compromisso:");
Console.WriteLine($"Descrição: {descricao}");
Console.WriteLine($"Data: {dataTexto}");
Console.WriteLine($"Hora: {horaTexto}");
Console.WriteLine($"Local: {nomeLocal} (Capacidade: {capacidadeLocal})");
Console.WriteLine($"Responsável: {usuario.NomeCompleto}");
Console.WriteLine($"Participantes cadastrados: {qtdParticipantes}");

Console.WriteLine("\nPressione qualquer tecla para sair...");
Console.ReadKey();
