using CodingChallenge.Data.Classes.FormasConcretas;

namespace CodingChallenge.Data.Classes.Idiomas
{
    internal class IdiomaFrances:IdiomaAbstracto
    {
        public override string getTextoArea()
        {
            return "Zone ";
        }
        public override string getTextoFormas()
        {
            return "formes";
        }
        public override string getTextoPerimetro()
        {
            return "Périmètre ";
         }
        public override string ImprimirHeader()
        {
            return "<h1>Rapport sur les formes</h1>";
        }

        public override string ImprimirListaVacia()
        {
            return "<h1>Liste de formes vide !</ h1>";
        }
        public override string ObtenerLinea(int cantidad, decimal area, decimal perimetro, dynamic tipoFigura)
        {
            return $"{cantidad} {TraducirForma(tipoFigura, cantidad)} | Zone {area:#.##} | Périmètre {perimetro:#.##} <br/>";
        }

        public override string TraducirForma(Circulo tipoFigura, int cantidad)
        {
            return cantidad == 1 ? "Cercle" : "Cercles";
        }

        public override string TraducirForma(Cuadrado tipoFigura, int cantidad)
        {
            return cantidad == 1 ? "Carré" : "Carrés";
        }

        public override string TraducirForma(Trapecio tipoFigura, int cantidad)
        {
            return cantidad == 1 ? "Trapèze" : "Trapèzes";
        }

        public override string TraducirForma(TrianguloEquilatero tipoFigura, int cantidad)
        {
            return cantidad == 1 ? "Triangle" : "Triangles";
        }
    }
}
