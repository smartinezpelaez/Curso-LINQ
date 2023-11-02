
using curso_linq;

LinqQueries queries = new LinqQueries();


//Toda la coleccion
//ImprimirValores(queries.TodaLaCollecion());

//Libros despues del 2000
//ImprimirValores(queries.LibrosDespuesde2000());

//Libros con mas de 250 paginas y el titulo contenga la palabra "in Action"
//ImprimirValores(queries.LibrosConMasDe250PagInAction());

//Libros que contengas alguna palabra en Status con metodo de extension
//Console.WriteLine( $"Todos los libros tienen Status? - {queries.LibrosConStatus()}" );

//Libros que contengas alguna palabra en Status con metodo de consulta Query expresion
//ImprimirValores(queries.LibrosConStatusQuery());

//Algun libro fue publicado en 2005
Console.WriteLine($"Algun libro fue publicado en 2005? - {queries.AlgunLibroPublicadoEn2005()}");

//Algun libro fue publicado en 2005 query
ImprimirValores(queries.AlgunLibroPublicadoEn2005Query());


//Imprime todos los datos del Json
void ImprimirValores (IEnumerable<Book> listaDeLibros)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo","N. Paginas", "Fecha publicacion");

	foreach (var item in listaDeLibros)
	{
        Console.WriteLine("{0, -60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.ToShortDateString());
    }
}

