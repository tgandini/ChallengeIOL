/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CodingChallenge.Data.Classes.FormasConcretas;
using CodingChallenge.Data.Classes.Idiomas;

namespace CodingChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        #region Formas

        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int Trapecio = 4;

        #endregion

        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;
        public const int Portugues = 3;
        public const int Frances = 4;
        #endregion


        public int Tipo { get; set; }

        public FormaGeometrica(int tipo, decimal ancho)
        {
            ConstructFormaFromIntAndLado(tipo, ancho);
        }

        public static string Imprimir(List<TipoFormaAbstracto> formas, int idioma)
        {
            var sb = new StringBuilder();
            var idiomaInstanciado = GetIdiomaFromInt(idioma);

            if (!formas.Any())
            {
                sb.Append(idiomaInstanciado.ImprimirListaVacia());
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                sb.Append(idiomaInstanciado.ImprimirHeader());


                //Creamos un diccionario por cada tipo de Forma Concreta que existe. Luego adentro de cada Forma habrá otro diccionario más con 3 claves 'numero', 'area' y 'perimetro'. Se le pasará el diccionario a cada uno de los objetos, que llenarán en la página correspondiente a su clase, los 3 elementos (numero, area y perímetro)

                string nspace = "CodingChallenge.Data.Classes.FormasConcretas";

                var query = from t in Assembly.GetExecutingAssembly().GetTypes()
                            where t.IsClass && t.Namespace == nspace
                            select t;
                var FormasPertenecientesAlNameSpace = query.ToList();

                Dictionary<string, Dictionary<string, decimal>> estructuraQueGuardaLosValores = new Dictionary<string, Dictionary<string, decimal>>();
                foreach (var cadaClaseDeForma in FormasPertenecientesAlNameSpace)
                {
                    Dictionary<string, decimal> valorPorForma = new Dictionary<string, decimal>();
                    valorPorForma.Add("numero", 0);
                    valorPorForma.Add("area", 0);
                    valorPorForma.Add("perimetro", 0);
                    estructuraQueGuardaLosValores.Add(cadaClaseDeForma.Name, valorPorForma);
                }

                foreach (var cadaForma in formas)
                {
                    cadaForma.llenarEstructuraConValores(estructuraQueGuardaLosValores);
                }

                foreach (var cadaClaseDeForma in FormasPertenecientesAlNameSpace)
                {
                    //Guardo la línea de las figuras si al menos tiene una... esto es para poder pasar los test, porque si no generaba 1 línea por cada figura por más q la cantidad sea 0, y rechazaba los test
                    if (estructuraQueGuardaLosValores[cadaClaseDeForma.Name]["numero"] > 0) {
                        sb.Append(idiomaInstanciado.ObtenerLinea((int)estructuraQueGuardaLosValores[cadaClaseDeForma.Name]["numero"],
                        estructuraQueGuardaLosValores[cadaClaseDeForma.Name]["area"],
                        estructuraQueGuardaLosValores[cadaClaseDeForma.Name]["perimetro"],
                        Activator.CreateInstance(cadaClaseDeForma)));
                    }
                }

                // FOOTER
                sb.Append("TOTAL:<br/>");

                int cantidadFormas = 0;
                decimal sumaPerimetros = 0;
                decimal sumaAreas = 0;

                foreach (var cantidadForma in estructuraQueGuardaLosValores.Values)
                {
                    cantidadFormas += (int) cantidadForma["numero"];
                    sumaPerimetros += cantidadForma["perimetro"];
                    sumaAreas += cantidadForma["area"];
                }


                sb.Append(cantidadFormas + " " + idiomaInstanciado.getTextoFormas() + " ");
                sb.Append(idiomaInstanciado.getTextoPerimetro() + (sumaPerimetros).ToString("#.##") + " ");
                sb.Append(idiomaInstanciado.getTextoArea() + (sumaAreas).ToString("#.##"));
            }

            return sb.ToString();
        }
        public static IdiomaAbstracto GetIdiomaFromInt(int numIdioma)
        {
            switch (numIdioma)
            {
                case 1:
                    return new IdiomaEspañol();
                case 2:
                    return new IdiomaIngles();
                case 3:
                    return new IdiomaPortugues();
                case 4:
                    return new IdiomaFrances();
                default:
                    throw new NotImplementedException();
            }
        }
        public static TipoFormaAbstracto ConstructFormaFromIntAndLado(int numForma, decimal lado1, decimal lado2 = 0, decimal lado3 = 0, decimal lado4=0, decimal altura=0)
        {
            switch (numForma)
            {
                case 1:
                    return new Cuadrado(lado1);
                case 2:
                    return new TrianguloEquilatero(lado1);
                case 3:
                    return new Circulo(lado1);
                case 4:
                    return new Trapecio(ladoIzquierdo: lado1, ladoDerecho: lado2, lado3, lado4, altura);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
