using Solid.Calculadora.Interface;

namespace Solid.Calculadora.Entidades
{
    public class CalculadoraPreco
    {
        private readonly IDesconto desconto;

        public CalculadoraPreco(IDesconto desconto)
        {
            this.desconto = desconto;
        }

        public double CalcularPreco(double valorCompra)
        {
            return valorCompra - desconto.Calcular(valorCompra);
        }
    }
}
