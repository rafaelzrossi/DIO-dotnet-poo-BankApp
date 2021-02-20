using System;

namespace Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }



        public Conta(TipoConta TipoConta, double Saldo, double Credito, string Nome){
            this.TipoConta = TipoConta;
            this.Saldo = Saldo;
            this.Credito = Credito;
            this.Nome = Nome;
        }

        public bool Sacar(double valorSaque){
            var limite = this.Saldo + this.Credito;

            if(limite - valorSaque < 0){
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }
            
            this.Saldo -= valorSaque;
            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
            return true;
        }

        public void Depositar(double valorDeposito){
            this.Saldo += valorDeposito;

            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
        }

        public void Transferir(double valorTransferencia, Conta contaDestino){
            if(this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }

		public override string ToString()
		{
			return $"Tipo da Conta: {this.TipoConta}\n" +
                   $"Nome: {this.Nome}\n" + 
                   $"Saldo: {this.Saldo}\n" +
                   $"Crédito: {this.Credito}\n";
		}
	
    }
}