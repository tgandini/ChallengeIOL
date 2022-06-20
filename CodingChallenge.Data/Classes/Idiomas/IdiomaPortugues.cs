using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingChallenge.Data.Classes.FormasConcretas;

namespace CodingChallenge.Data.Classes.Idiomas
{
    internal class IdiomaPortugues : IdiomaAbstracto
    {
        public override string getTextoArea()
        {
            return "Área ";
        }

        public override string getTextoFormas()
        {
            return "formas";
        }

        public override string getTextoPerimetro()
        {
            return "Perímetro ";
        }
        public override string ImprimirHeader()
        {
            return "<h1>Relatório de Formas</ h1>";
        }

        public override string ImprimirListaVacia()
        {
            return "<h1>Lista vazia de formas!</h1>";
        }

        public override string ObtenerLinea(int cantidad, decimal area, decimal perimetro, dynamic tipoFigura)
        {
            return $"{cantidad} {TraducirForma(tipoFigura, cantidad)} | Área {area:#.##} | Perímetro {perimetro:#.##} <br/>";
        }

        public override string TraducirForma(Circulo tipoFigura, int cantidad)
        {
            return cantidad == 1 ? "Círculo" : "Círculos";
        }

        public override string TraducirForma(Cuadrado tipoFigura, int cantidad)
        {
            return cantidad == 1 ? "Quadrado" : "Quadrados";
        }

        public override string TraducirForma(Trapecio tipoFigura, int cantidad)
        {
            return cantidad == 1 ? "Trapézio" : "Trapézios";
        }

        public override string TraducirForma(TrianguloEquilatero tipoFigura, int cantidad)
        {
            return cantidad == 1 ? "Triângulo" : "Triângulos";
        }
    }
}
