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
        //Estrutura de calculo salarial sobre os custos e beneficios {pode ocorre mudanças na estrutura do calculo}
        public double Calculo_Salario()
        {
            //sera adicionado a possibilidade de informa valor em conta e a opção de salvar os valores para calcular os dados aos proximos meses.
            double salario = this.Salario - (this.Desconto_Salario * this.Salario / 100); //Calculo do desconto salarial
            return salario + this.Beneficio - this.Cartao_de_Credito - this.Gastos_Geral; //calculo do desconto salarial sobre o restante dos dados
        }
        //Estrutura de input dos dados
        public class Program
        {
            static void Main(string[] args)
            {
                //Herança da classe de pessoas que informa dados como nome e data de nascimento
                Pessoas pessoas = new Pessoas();
                //{Estrutura em modificação}
                double totalGasto = 0;

                for (int month = 1; month <= 12; month++)//Estrutura para calculo dos custos em decorrencia dos meses
                {
                    try 
                    {
                        Gastos gastos = new Gastos() { Mes = month }; //abertura da condição

                        Console.WriteLine($"Informe os dados para o mês {month}");// informa qual é o mes referente ao calculo

                        Console.WriteLine("Informe seu nome.");
                        gastos.Nome = Console.ReadLine();

                        Console.WriteLine("Informe o ano de nascimento.");
                        gastos.Ano_Nascimento = Console.ReadLine();

                        Console.WriteLine("Informe o salario ou os ganhos de forma mensal.");
                        gastos.Salario = double.Parse(Console.ReadLine());

                        Console.WriteLine("Informe o desconto salario EX: 12.");
                        gastos.Desconto_Salario = double.Parse(Console.ReadLine());

                        Console.WriteLine("Informe os beneficios em R$ como: Alimentação, Vale Combustivel.");
                        gastos.Beneficio = double.Parse(Console.ReadLine());

                        Console.WriteLine("Informe um limite em R$ que pretende gastar.");
                        gastos.Gastos_Geral = double.Parse(Console.ReadLine());

                        Console.WriteLine("Informe o gasto com cartao de credito");
                        gastos.Cartao_de_Credito = double.Parse(Console.ReadLine());

                        double resultado = gastos.Calculo_Salario();//retornando a condoção de calculo resumida

                        Console.WriteLine($"Resultado do mes {month}: R$: {resultado}");//informa o valor final do mes
                        Console.WriteLine($"Total gasto no ano: R$: {resultado * 12}");//informa o valor final em 12 meses
                        Console.WriteLine("Deseja ir para o proximo mês? (S/N)");//retorna ao usuario se gostaria de continuar para o proximo mes
                        string resposta = Console.ReadLine();//gravar a resposta passada pelo usuario

                        if (resposta.ToUpper() != "S")//verifica a reposta pelo usuario e confirma o processo
                        {
                            break;
                        }
                    }
                    catch (FormatException ex)//tratamento de possiveis erros de digitação ou erro inesperado
                    {
                        Console.WriteLine("Formato inválido de entrada. Certifique-se de inserir um número válido.");
                        Console.WriteLine("Erro: " + ex.Message);
                    }
                }
            }
        }
    }
}