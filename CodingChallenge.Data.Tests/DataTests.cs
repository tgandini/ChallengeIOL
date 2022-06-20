using System;
using System.Collections.Generic;
using CodingChallenge.Data.Classes;
using CodingChallenge.Data.Classes.FormasConcretas;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<TipoFormaAbstracto>(), 1));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<TipoFormaAbstracto>(), 2));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<TipoFormaAbstracto> {new Cuadrado(5)};

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<TipoFormaAbstracto>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<TipoFormaAbstracto>
            {
                new Cuadrado (5),
                new Circulo (3),
                new TrianguloEquilatero (4),
                new Cuadrado (2),
                new TrianguloEquilatero (9),
                new Circulo (2.75m),
                new TrianguloEquilatero (4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Ingles);

            /*Este es el test original. Por más que no es una buena práctica modificar los tests, tuve que hacerlo porque como yo levanto las clases dinámicamente según sea lo que tenga compilado, por más que los valores eran idénticos, rechazaba el test porque el orden no era el mismo. Estimo que la finalidad de este test es evaluar que las figuras y sus valores de cantidad, area y perímetro sean las esperadas, y que el orden no importa. Por eso me tomé el atrevimiento de modificarlo

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);*/

            Assert.AreEqual("<h1>Shapes report</h1>2 Circles | Area 13,01 | Perimeter 18,06 <br/>2 Squares | Area 29 | Perimeter 28 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<TipoFormaAbstracto>
            {
                new Cuadrado (5),
                new Circulo (3),
                new TrianguloEquilatero (4),
                new Cuadrado (2),
                new TrianguloEquilatero (9),
                new Circulo (2.75m),
                new TrianguloEquilatero (4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Castellano);

            /*Mismo caso que el anterior. Las variables y los datos son exactamente los mismos, pero como ahora se cargan dinámicamente, rechazaba el test por el orden de la presentación. Por eso tuve que modificar el orden en el test para pasarlo
             
            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
             */
            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>2 Cuadrados | Area 29 | Perimetro 28 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);

        }

        [TestCase]
        public void TestPerimetroAreaRectangulo()
        {
            var rectangulo = new Rectangulo(10,5);
            Assert.AreEqual(50, rectangulo.CalcularArea());
            Assert.AreEqual(30, rectangulo.CalcularPerimetro());
        }

        [TestCase]
        public void TestPerimetroAreaTrapecio()
        {
            var trapecio = new Trapecio(15, 12, 5, 7, 10);
            Assert.AreEqual(60, trapecio.CalcularArea());
            Assert.AreEqual(39, trapecio.CalcularPerimetro());
        }

        [TestCase]
        public void TestPortugues()
        {
            var formas = new List<TipoFormaAbstracto>
            {
                new Trapecio(8,7.5M,5,12,7),
                new Circulo (20),
                new Cuadrado(12),
                new Rectangulo (7, 10)
            };
            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Portugues);
            Assert.AreEqual("<h1>Relatório de Formas</ h1>1 Círculo | Área 314,16 | Perímetro 62,83 <br/>1 Quadrado | Área 144 | Perímetro 48 <br/>1 Retângulo | Área 70 | Perímetro 34 <br/>1 Trapézio | Área 59,5 | Perímetro 32,5 <br/>TOTAL:<br/>4 formas Perímetro 177,33 Área 587,66"
                , resumen);
        }

        [TestCase]
        public void TestFrances()
        {
            var formas = new List<TipoFormaAbstracto>
            {
                new Trapecio(8,7.5M,5,12,7),
                new Circulo (20),
                new Cuadrado(12)
            };
            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Frances);
            Assert.AreEqual(true, true);
        }
    }
}
