using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.FormasConcretas
{
    public class Cuadrado: TipoFormaAbstracto
    {
        public Cuadrado() { }
        public Cuadrado(decimal lado):base (lado) {
            
        }
        public override decimal CalcularArea()
        {
            return _lado * _lado;
        }
        public override decimal CalcularPerimetro()
        {
            return _lado * 4;
        }
    }
}
