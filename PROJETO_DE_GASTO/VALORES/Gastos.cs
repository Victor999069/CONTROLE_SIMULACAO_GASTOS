using PROJETO_DE_GASTO.PESSOAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_DE_GASTO.GASTOS
{
    public class Gastos : Pessoas
    {
        public double Cartao_de_Credito { get; set; }
        public double Gastos_Geral { get; set; }
        public double Salario { get; set; }
        public double Beneficio { get; set; }
        public double Desconto_Salario { get; set; }

        public int Mes { get; set; }

        public double Calculo_Salario()
        {

            double salario = this.Salario - (this.Desconto_Salario * this.Salario / 100);
            return salario + this.Beneficio - this.Cartao_de_Credito - this.Gastos_Geral;
        }

        public class Program
        {
            static void Main(string[] args)
            {
                Pessoas pessoas = new Pessoas();
                double totalGasto = 0;

                for (int month = 1; month <= 12; month++)
                {
                    try 
                    {
                        Gastos gastos = new Gastos() { Mes = month };

                        Console.WriteLine($"Informe os dados para o mês {month}");

                        Console.WriteLine("Informe seu nome");
                        gastos.Nome = Console.ReadLine();

                        Console.WriteLine("Informe o ano de nascimento");
                        gastos.Data_Nascimento = Console.ReadLine();

                        Console.WriteLine("Informe o salario");
                        gastos.Salario = double.Parse(Console.ReadLine());

                        Console.WriteLine("Informe o desconto salario");
                        gastos.Desconto_Salario = double.Parse(Console.ReadLine());

                        Console.WriteLine("Informe os beneficios, exemplo: Alimentação, Vale Combustivel");
                        gastos.Beneficio = double.Parse(Console.ReadLine());

                        Console.WriteLine("Informe gastos geral");
                        gastos.Gastos_Geral = double.Parse(Console.ReadLine());

                        Console.WriteLine("Informe o gasto com cartao de credito");
                        gastos.Cartao_de_Credito = double.Parse(Console.ReadLine());

                        double resultado = gastos.Calculo_Salario();

                        Console.WriteLine($"Resultado do mes {month}: R$: {resultado}");
                        Console.WriteLine($"Total gasto no ano: R$: {resultado * 12}");
                        Console.WriteLine("Deseja ir para o proximo mês? (S/N)");
                        string resposta = Console.ReadLine();

                        if (resposta.ToUpper() != "S")
                        {
                            break;
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Formato inválido de entrada. Certifique-se de inserir um número válido.");
                        Console.WriteLine("Erro: " + ex.Message);
                    }
                }
            }
        }
    }
}