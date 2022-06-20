using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public abstract class TipoFormaAbstracto
    {
        protected readonly decimal _lado;
        public TipoFormaAbstracto() { }

        public TipoFormaAbstracto(decimal lado)
        {
            _lado = lado;
        }
            
        public virtual decimal CalcularArea()
        {
            throw new ArgumentOutOfRangeException(@"Forma desconocida");
        }
        public virtual decimal CalcularPerimetro()
        {
            throw new ArgumentOutOfRangeException(@"Forma desconocida");
        }
        
        public void llenarEstructuraConValores(Dictionary<string, Dictionary<string, decimal>> estructuraQueMantieneLosValores)
        {
            estructuraQueMantieneLosValores[this.GetType().Name]["numero"] ++;
            estructuraQueMantieneLosValores[this.GetType().Name]["area"]+= this.CalcularArea();
            estructuraQueMantieneLosValores[this.GetType().Name]["perimetro"] += this.CalcularPerimetro();
        }
    }
}
