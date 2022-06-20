using CodingChallenge.Data.Classes.FormasConcretas;

namespace CodingChallenge.Data.Classes.Idiomas
{
    internal class IdiomaIngles : IdiomaAbstracto
    {
        public override string getTextoArea()
        {
            return "Area ";
        }
        public override string getTextoFormas()
        {
            return "shapes";
        }

        public override string getTextoPerimetro()
        {
            return "Perimeter ";
        }
        public override string ImprimirHeader()
        {
            return "<h1>Shapes report</h1>";
        }

        public override string ImprimirListaVacia()
        {
            return "<h1>Empty list of shapes!</h1>";
        }
        public override string ObtenerLinea(int cantidad, decimal area, decimal perimetro, dynamic tipoFigura)
        {
            return $"{cantidad} {TraducirForma(tipoFigura, cantidad)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";
        }

        public override string TraducirForma(Circulo tipoFigura, int cantidad)
        {
            return cantidad == 1 ? "Circle" : "Circles";
        }

        public override string TraducirForma(Cuadrado tipoFigura, int cantidad)
        {
            return cantidad == 1 ? "Square" : "Squares";
        }

        public override string TraducirForma(Trapecio tipoFigura, int cantidad)
        {
            return cantidad == 1 ? "Trapeze" : "Trapezes";
        }

        public override string TraducirForma(TrianguloEquilatero tipoFigura, int cantidad)
        {
            return cantidad == 1 ? "Triangle" : "Triangles";
        }

        public override string TraducirForma(Rectangulo tipoFigura, int cantidad)
        {
            return cantidad == 1 ? "Rectangle" : "Rectangles";
        }
    }
}
