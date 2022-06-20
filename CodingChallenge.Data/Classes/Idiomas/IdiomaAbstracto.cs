using System;
using CodingChallenge.Data.Classes.FormasConcretas;

namespace CodingChallenge.Data.Classes.Idiomas { }

public abstract class IdiomaAbstracto
{
    public abstract string ImprimirListaVacia();
    public abstract string ImprimirHeader();
    public abstract string ObtenerLinea(int cantidad, decimal area, decimal perimetro, dynamic tipoFigura);
    public abstract string TraducirForma(Circulo tipoFigura, int cantidad);
    public abstract string TraducirForma(Cuadrado tipoFigura, int cantidad);
    public abstract string TraducirForma(Trapecio tipoFigura, int cantidad);
    public abstract string TraducirForma(TrianguloEquilatero tipoFigura, int cantidad);
    public abstract string getTextoFormas();

    public abstract string getTextoPerimetro();
    public abstract string getTextoArea();
}