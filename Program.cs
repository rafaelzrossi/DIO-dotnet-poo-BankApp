using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario != "X"){
                switch(opcaoUsuario){
                    case "1":
                        ListarContas();
                        break;
                    case "2":
						InserirConta();
						break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        break;
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos Serviços.");
        }

		private static void InserirConta()
		{
			Console.WriteLine("Inserir Nova Conta");

            Console.Write("Digite 1 para Conta Fisica ou 2 para conta Juridica: ");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o Saldo Inicial: ");
            double saldoInicial = double.Parse(Console.ReadLine());

            Console.Write("Digite o Crédito: ");
            double creditoInicial = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(TipoConta: (TipoConta)tipoConta,
                                        Nome: nome,
                                        Saldo: saldoInicial,
                                        Credito: creditoInicial);

            listContas.Add(novaConta);
		}

        private static void ListarContas(){
            Console.WriteLine("Listar Contas");

            if(listContas.Count == 0){
                Console.WriteLine("Nenhuma Conta Cadastrada.");
                return;
            }

            for(int i = 0; i < listContas.Count; i++){
                Conta conta = listContas[i];
                Console.Write($"#{i} - ");
                Console.WriteLine(conta);
            }
        }

        private static void Sacar(){
            Console.Write("Digite o Número da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque: valorSaque);
        }

        private static void Depositar(){
            Console.Write("Digite o Número da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito: valorDeposito);
        }

        private static void Transferir(){
            Console.Write("Informe o númro da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Informe o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Informe o valor a ser transferido: ");
            double valorTransferido = double.Parse(Console.ReadLine());

            listContas[index: indiceContaOrigem].Transferir(valorTransferencia: valorTransferido,
                                                            contaDestino: listContas[indiceContaDestino]);
        }

		private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Lista Contas");
            Console.WriteLine("2 - Inserir Nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar a Tela");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
