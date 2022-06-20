using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.FormasConcretas
{
    public class Trapecio : TipoFormaAbstracto
    {

        readonly decimal _ladoIzquierdo;
        readonly decimal _ladoDerecho;
        readonly decimal _baseMayor;
        readonly decimal _baseMenor;

        public Trapecio() : base() { }
        public Trapecio(decimal ladoIzquierdo, decimal ladoDerecho,  decimal base1, decimal base2, decimal altura) : base (altura)
        {
            //Le insertamos el valor de la altura en la variable _lado del base
            _ladoDerecho= ladoDerecho;
            _ladoIzquierdo = ladoIzquierdo;
            if (base1 > base2)
            {
                _baseMayor= base1;
                _baseMenor= base2;
            }
            else
            {
                _baseMayor = base2;
                _baseMenor = base1;
            }
        }
        public override decimal CalcularArea()
        {
            return (1M / 2M * (_baseMenor + _baseMayor) * _lado);
        }
        public override decimal CalcularPerimetro()
        {
            return _ladoDerecho + _ladoIzquierdo + _baseMenor + _baseMayor;
        }


    }
}
