using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.FormasConcretas
{
    public class Rectangulo: TipoFormaAbstracto
    {
        readonly decimal _ladoB;
        public Rectangulo(): base() { }

        public Rectangulo(decimal ladoA, decimal ladoB) : base(ladoA)
        {
            _ladoB=ladoB;
        }
        public override decimal CalcularArea()
        {
            return (_lado * _ladoB);
        }
        public override decimal CalcularPerimetro()
        {
            return (2*_lado) + (2* _ladoB);
        }
    }
}
