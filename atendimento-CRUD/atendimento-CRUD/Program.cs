using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace atendimento_CRUD
{
    internal class Program
    {
        static string conexao = "server=127.0.0.1;uid=root;pwd=root;database=atendimentoCRUD";
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
                        CadastrarPaciente();
                        break;

                    case "2":
                        Console.WriteLine("\nLista de Pacientes\n");
                        ListarPaciente();
                        break;

                    case "3":
                        Console.WriteLine("\nAtender Pacientes\n");
                        AtenderPaciente();
                        break;

                    case "4":
                        Console.WriteLine("\nAlterar Dados\n");
                        AtualizarPaciente();
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

        static void CadastrarPaciente()
        {
            Console.WriteLine("Digite o nome do paciente:");
            string Nome = Console.ReadLine();
            Console.WriteLine("Digite o nível de prioridade do paciente");
            int Prioridade = int.Parse(Console.ReadLine());

            using (var con = new MySqlConnection(conexao))
            {
                con.Open();
                var cmd = new MySqlCommand("insert into paciente (Nome, Prioridade) values (@Nome, @Prioridade)", con);
                cmd.Parameters.AddWithValue("@Nome", Nome);
                cmd.Parameters.AddWithValue("@Prioridade", Prioridade);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Paciente cadastrado.");
            }
        }
        static void ListarPaciente()
        {
            using (var con = new MySqlConnection(conexao))
            {
                con.Open();
                string sqlSelect = "select * from paciente order by Prioridade asc";
                var cmd = new MySqlCommand(sqlSelect, con);
                var rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0]+" - " + rdr[1]+ " Prioridade: " + rdr[2]);
                }
            }
        }
        static void AtenderPaciente()
        {
            ListarPaciente();
            Console.WriteLine("Digite o ID do paciente a ser atendido");
            int cd = int.Parse(Console.ReadLine());
            using (var con = new MySqlConnection(conexao))
            {
                con.Open();
                string sqlDelete = "Delete from Paciente where CdPaciente = @cd";
                var cmd = new MySqlCommand(sqlDelete, con);
                cmd.Parameters.AddWithValue("@cd", cd);
                Console.WriteLine("Paciente atendido");
            }
        }
        static void AtualizarPaciente()
        {
            ListarPaciente();
            Console.WriteLine("Digite o ID do paciente a ser alterado");
            int cd = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o novo nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o novo nível de prioridade");
            int prioridade = int.Parse(Console.ReadLine());
            using (var con = new MySqlConnection(conexao))
            {
                con.Open();
                string sqlUpdate = "Update paciente set Nome = @nome, Prioridade = @prioridade where CdPaciente = @cd";
                var cmd = new MySqlCommand(sqlUpdate, con);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@prioridade", prioridade);
                cmd.Parameters.AddWithValue("cd", cd);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Paciente alterado");

            }
        }
    }
}
