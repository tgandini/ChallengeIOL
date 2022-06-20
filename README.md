# Coding Challenge de Invertir Online Argentina
En este repositorio está la solución propuesta al caso del refactoring del método 
```csharp
public static string Imprimir(List<FormaGeometrica> formas, int idioma)
```
Donde se torna muy doloroso el implementar nuevas figuras y idiomas al mismo.
Para la resolución se optó por tomar diferentes patrones de diseño, entre los cuales se ven 2 casos marcados de herencia (Uno por los idiomas a implementar y otro por las figuras a desarrollar).
Ahora el objeto de FormaGeometrica tiene 2 métodos, para que según el integer que ingrese en idioma y en figura, sepa qué clase concreta instanciar de esas 2.

Usando polimorfismo:

- Cada clase de figura responde a los mensajes CalcularArea() y CalcularPerimetro(), resolviendo lo correcto según sea el caso.

- También usando polimorfismo, cada clase de Idioma (Por ahora contamos con 4. Español, Inglés, Francés y Portugués) responde a ciertos mensajes de su forma correcta, dependiendo el idioma que estemos instanciado. En el caso de traducir la forma correcta (Es decir, "Cuadrado", "Círculo", etc), recibiendo un objeto del tipo correspondiente, ya sabrá qué texto responder.

- Para mostrar los reportes, se generan de forma dinámica, obteniendo y leyendo todas las clases de figuras que están codeadas en el namespace CodingChallenge.Data.Classes.FormasConcretas. De esta forma es innecesario tipearlas mano a mano una vez que se agreguen nuevas.

De todas las formas de codear el challenge, esta me pareció la más fácil de agregar nueva funcionalidad, ya que para generar una nueva figura, solamente es necesario crear una nueva heredada desde TipoFormaAbstracto, declarar sus constructores parametrizado y vacío, y setear los métodos CalcularArea y CalcularPerimetro, y la clase FormaGeometrica ya sabrá como crear su reporte basado en lo que está codeado en los diferentes idiomas.
De mismo modo, para generar un reporte en otro idioma, solamente es necesario generar una nueva clase de Idioma que herede de IdiomaAbstracto, y aquella clase con sus métodos abstractos, obligará a declarar todos los métodos necesarios para generar los reportes en el idioma correspondiente.





## Resumen General

Bajo esta solución, es mucho más fácil agregar funcionalidad, ya sea Agregar Idiomas nuevos o Formas nuevas, ya que para agregar una nueva forma nos abstraemos de la manera de mostrar el reporte, dado que eso es responsabilidad del idioma elegido.

De igual manera, al agregar un nuevo idioma, solamente nos tendremos que ocupar de desarrollar la forma del nuevo reporte, independientemente de las clases de figuras que poseemos y sus formas de declarar sus áreas y perímetros, dado que eso lo hace la clase de figura concreta con la que estemos trabajando.

Para finalizar, en caso que agreguemos nuevas figuras, tampoco es necesario tocar nada de los reportes generales, ya que como está codeado, directamente alimenta al reporte general de TODAS las clases de figuras que estén declaradas en el namespace "CodingChallenge.Data.Classes.FormasConcretas", haciendo el filtro correspondiente de sacar las clases de figuras que NO tengan objetos instanciados.

## Autor de la solución

- [@tgandini](https://www.github.com/tgandini)


## Mail de Contacto
- gandinitomas@gmail.com
