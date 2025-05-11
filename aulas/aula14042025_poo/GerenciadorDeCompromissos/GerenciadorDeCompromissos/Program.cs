using ConsoleApp.Modelos;
 
 
 Console.WriteLine("Configuração das reservas de salas\n");
            Console.Write("Data mínima (dd/MM/yyyy): ");
            var dataMin = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Data máxima (dd/MM/yyyy): ");
            var dataMax = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Hora mínima (HH:mm): ");
            var horaMin = TimeSpan.Parse(Console.ReadLine());
            Console.Write("Hora máxima (HH:mm): ");
            var horaMax = TimeSpan.Parse(Console.ReadLine());

            ConfiguracaoReserva config = new(dataMin, dataMax, horaMin, horaMax);

            Console.WriteLine("Cadastro da reserva\n");
            Console.Write("Data da reserva (dd/MM/yyyy): ");
            var data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Hora da reserva (hh:mm): ");
            var hora = TimeSpan.Parse(Console.ReadLine());
            Console.Write("Descrição da sala(código da sala): ");
            var descricao = Console.ReadLine();
            Console.Write("Capacidade: ");
            var capacidade = int.Parse(Console.ReadLine());

            Reserva reserva = new(config);
            reserva.RegistrarData(data);
            reserva.RegistrarHora(hora);
            reserva.RegistrarDescricao(descricao);
            reserva.RegistrarCapacidade(capacidade);
            reserva.ValidarReserva();

            if (reserva.Erros.Count == 0)
            {
                Console.WriteLine("Reserva feita corretamente: ");
                Console.WriteLine(reserva);
            }
            else
            {
                Console.WriteLine("Erro na reserva: ");
                foreach (var erro in reserva.Erros)
                {
                    Console.WriteLine($"- {erro}");
                }
            }

            Console.WriteLine("Pressione qualquer tecla para sair");
            Console.ReadKey();
      