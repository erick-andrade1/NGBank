using System;

namespace NGBank
{
    public class Conta
    {
        private TipoConta tipoConta { get; set; }
		private double saldo { get; set; }
		private double credito { get; set; }
		private string nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome){
            this.tipoConta = tipoConta;
            this.saldo = saldo;
            this.credito = credito;
            this.nome = nome;
        }

        public bool Sacar(double valorSaque){
            bool r;
            if(this.saldo - valorSaque < (this.credito * -1)){
                r = false;
            } 
            else {
                this.saldo -= valorSaque;
                Console.WriteLine($"Saldo atual da conta de {this.nome} é {this.saldo}");
                r = true;
            }
            return r;
        }

        public void Depositar(double valorDeposito){
            this.saldo += valorDeposito;

            Console.WriteLine($"Saldo atual da conta de {this.nome} é {this.saldo}");
        }

        public void Transferir(double valorTransferencia, Conta contaDestino){
            
            if(this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
            else{
                Console.WriteLine("Saldo insuficiente para transferência");
            }

        }

        public override string ToString()
		{
            string retorno = "";
            retorno += "TipoConta " + this.tipoConta + " | ";
            retorno += "Nome " + this.nome + " | ";
            retorno += "Saldo " + this.saldo + " | ";
            retorno += "Crédito " + this.credito;
			return retorno;
		}
    }
}