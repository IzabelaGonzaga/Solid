using Solid.Calculadora.Interface;

namespace Solid.Calculadora.Entidades
{
    public class DescontoPremium : IDesconto
    {
        public double Calcular(double valorCompra)
        {
            return valorCompra * 0.10;
        }
    }
}
