using CodingChallenge.Data.Classes.FormasConcretas;

namespace CodingChallenge.Data.Classes.Idiomas
{
    internal class IdiomaEspañol : IdiomaAbstracto
    {
        public override string getTextoFormas()
        {
            return "formas";
        }

        public override string getTextoArea()
        {
            return "Area ";
        }

        public override string getTextoPerimetro()
        {
            return "Perimetro ";
        }

        public override string ImprimirHeader()
        {
            return "<h1>Reporte de Formas</h1>";
        }

        public override string ImprimirListaVacia()
        {
            return "<h1>Lista vacía de formas!</h1>";
        }

        public override string ObtenerLinea(int cantidad, decimal area, decimal perimetro, dynamic ClaseDeFigura)
        {
            return $"{cantidad} {TraducirForma(ClaseDeFigura, cantidad )} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";
        }

        public override string TraducirForma(Cuadrado cuadrado, int cantidad)
        {
            return cantidad == 1 ? "Cuadrado" : "Cuadrados";
        }

        public override string TraducirForma(Circulo tipoFigura, int cantidad)
        {
            return cantidad == 1 ? "Círculo" : "Círculos";
        }

        public override string TraducirForma(Trapecio tipoFigura, int cantidad)
        {
            return cantidad == 1 ? "Trapecio" : "Trapecios";
        }

        public override string TraducirForma(TrianguloEquilatero tipoFigura, int cantidad)
        {
            return cantidad == 1 ? "Triángulo" : "Triángulos";
        }

        public override string TraducirForma(Rectangulo tipoFigura, int cantidad)
        {
            return cantidad == 1 ? "Rectángulo" : "Rectángulos";
        }
    }
}
