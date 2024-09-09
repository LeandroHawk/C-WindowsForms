using System;

class Program
{
    // Definindo constantes
    const int NUM_FILEIRAS = 15;
    const int POLTRONAS_POR_FILEIRA = 40;
    static readonly int[] PRECO_FILEIRAS = {50, 50, 50, 50, 50, 30, 30, 30, 30, 30, 15, 15, 15, 15, 15};

    // Matriz para representar o teatro
    static char[,] teatro = new char[NUM_FILEIRAS, POLTRONAS_POR_FILEIRA];

    // Variáveis globais para controle de ocupação e faturamento
    static int lugaresOcupados = 0;
    static float faturamentoTotal = 0.0f;

    // Função para inicializar o teatro com lugares vazios
    static void InicializarTeatro()
    {
        for (int i = 0; i < NUM_FILEIRAS; i++)
        {
            for (int j = 0; j < POLTRONAS_POR_FILEIRA; j++)
            {
                teatro[i, j] = '.';
            }
        }
    }

    // Função para reservar uma poltrona
    static void ReservarPoltrona()
    {
        Console.Write("Digite a fileira (1-" + NUM_FILEIRAS + "): ");
        if (!int.TryParse(Console.ReadLine(), out int fileira) || fileira < 1 || fileira > NUM_FILEIRAS)
        {
            Console.WriteLine("Entrada inválida. Tente novamente.");
            return;
        }

        Console.Write("Digite a poltrona (1-" + POLTRONAS_POR_FILEIRA + "): ");
        if (!int.TryParse(Console.ReadLine(), out int poltrona) || poltrona < 1 || poltrona > POLTRONAS_POR_FILEIRA)
        {
            Console.WriteLine("Entrada inválida. Tente novamente.");
            return;
        }

        // Verifica se a poltrona está ocupada
        if (teatro[fileira - 1, poltrona - 1] == '#')
        {
            Console.WriteLine("Esta poltrona já está ocupada.");
        }
        else
        {
            // Reserva a poltrona e atualiza o faturamento
            teatro[fileira - 1, poltrona - 1] = '#';
            lugaresOcupados++;
            faturamentoTotal += PRECO_FILEIRAS[fileira - 1];
            Console.WriteLine("Sua poltrona foi reservada.");
        }
    }

    // Função para exibir o mapa de ocupação
    static void MostrarMapaOcupacao()
    {
        Console.WriteLine("Mapa de ocupação do teatro:");
        for (int i = 0; i < NUM_FILEIRAS; i++)
        {
            for (int j = 0; j < POLTRONAS_POR_FILEIRA; j++)
            {
                Console.Write(teatro[i, j]);
            }
            Console.WriteLine();
        }
    }

    // Função para exibir o faturamento
    static void MostrarFaturamento()
    {
        Console.WriteLine("Quantidade de lugares ocupados: " + lugaresOcupados);
        Console.WriteLine("Valor da bilheteira: R$ " + faturamentoTotal.ToString("F2"));
    }

    static void Main()
    {
        InicializarTeatro();
        int opcao;
        do
        {
            Console.WriteLine("\nSelecione uma opção:");
            Console.WriteLine("0. Finalizar");
            Console.WriteLine("1. Reservar poltrona");
            Console.WriteLine("2. Mapa de ocupação");
            Console.WriteLine("3. Faturamento");
            Console.Write("Opção: ");
            
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
                continue;
            }

            // Switch case
            switch (opcao)
            {
                case 0:
                    Console.WriteLine("Finalizando o programa.");
                    break;
                case 1:
                    ReservarPoltrona();
                    break;
                case 2:
                    MostrarMapaOcupacao();
                    break;
                case 3:
                    MostrarFaturamento();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        } while (opcao != 0);
    }
}
