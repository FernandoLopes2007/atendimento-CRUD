using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace atendimento_CRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string escolha;

            while (true)
            {
                Console.WriteLine("\nBem-vindo ao cadastro de paciente\n");
                Console.WriteLine("1 - Cadastro\n2 - Lista\n3 - Atender\n4 - Alterar\nQ - Sair\n");
                escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        Console.WriteLine("\nÁrea de Cadastro\n");
                        break;

                    case "2":
                        Console.WriteLine("\nLista de Pacientes\n");
                        break;

                    case "3":
                        Console.WriteLine("\nAtender Pacientes\n");
                        break;

                    case "4":
                        Console.WriteLine("\nAlterar Dados\n");

                        break;

                    case "q":
                        if (escolha == "q" || escolha == "Q")
                        {
                            Console.WriteLine("\nPrograma encerrado");
                        }
                        return;

                    default:
                        Console.WriteLine("\nOpção Incorreta");
                        break;
                }
            }
        }
    }
}
