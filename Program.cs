
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
//Console.WriteLine($"Algun libro fue publicado en 2005? - {queries.AlgunLibroPublicadoEn2005()}");

//Algun libro fue publicado en 2005 query
//ImprimirValores(queries.AlgunLibroPublicadoEn2005Query());

//Categoria Python
//ImprimirValores(queries.CategoriaPython());

//Categoria OrderBy Java
//ImprimirValores(queries.CategoriaOrderByJava());

//Categoria OrderByDescending JavaQuery
//ImprimirValores(queries.CategoriaOrderByDescendingJavaQuery());

//OperadorTakeBuscarCategoriaJavaQuery
//ImprimirValores(queries.OperadorTakeBuscarCategoriaJavaQuery());

//Operador Skip Selecciona Tercer y Cuarto Libro
//ImprimirValores(queries.OperadorSkipSeleccionaTerceryCuartoLibro());

//Operador Select Tres primeros Libros
//ImprimirValores(queries.OperadorSelectTresprimerosLibros());

//Operador Count Numero Libros entre 200 y 500
//Console.WriteLine($"los  Libros entre 200 y 500 paginas son  = {queries.OperadorCountNumeroLibros200y500()}");

//Operador LongCount Numero Libros entre 200 y 500
//Console.WriteLine($"los  Libros entre 200 y 500 paginas son  = {queries.OperadorCountNumeroLibros200y500pag()}");

//Operador Min Menor Fecha De Publicacion
//Console.WriteLine($"la fecha de publicaciones menor es = {queries.OperadorMinMenorFechaDePublicacion()}");

//Operador Max Numero de Pag Libro Mayor
//Console.WriteLine($"Numero de paginas del libro mayor es = {queries.OperadorMaxNumerodePagLibroMayor()}");

//Operador MinBy Libro con menor numero de paginas
//var libroMenorPag = queries.OperadorMinByLibroMenorCantidadPag();
//Console.WriteLine($"Titulo = {libroMenorPag.Title}, paginas = {libroMenorPag.PageCount}");

//Operador MaxBy Libro con Fecha de Publicacion Mas Reciente
//var libroMayorFecha = queries.OperadorMaxByLibroFechaPublicacionMasReciente();
//Console.WriteLine($"Titulo = {libroMayorFecha.Title}, paginas = {libroMayorFecha.PublishedDate.ToShortDateString()}");

//Operador Sum Para Sumar Cantidad de Paginas Entre 0 y 500
//Console.WriteLine($"Sumar Cantidad de Paginas Entre 0 y 500 es = {queries.OperadorSumParaSumarCantidadPaginasEntre0y500()}");

//Operador Agregate Titulos De Libros Despues Del 2015
//Console.WriteLine($"Titulos De Libros Despues Del 2015 son = {queries.OperadorAgregateTitulosDeLibrosDespuesDel2015()}");

//Operador Avegare Promedio Caracteres
//Console.WriteLine($"El promedio de caracteres de los titulos son = {queries.OperadorAvegarePromedioCaracteres()}");

//Operador GroupBy Libros Publicados Despues Del 2000
//ImprimirGrupo(queries.OperadorGroupByLibrosPublicadosDespuesDel2000());

//Operador Lookup Diccionario De Libros Por primera Letra del titulo
var diccionarioLookup = queries.OperadorLookupDiccionarioDeLibrosPorLetra();
ImorimirDiccionario(diccionarioLookup, 'A');


//Imprime todos los datos del Json
void ImprimirValores (IEnumerable<Book> listaDeLibros)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo","N. Paginas", "Fecha publicacion");

	foreach (var item in listaDeLibros)
	{
        Console.WriteLine("{0, -60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.ToShortDateString());
    }
}

void ImprimirGrupo(IEnumerable<IGrouping<int, Book>> ListadeLibros)
{
    foreach (var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {grupo.Key}");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach (var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
        }
    }
}

void ImorimirDiccionario(ILookup<char, Book> ListadeLibros, char letra)
{
    char mayuscula = Char.ToUpper(letra);
    if (ListadeLibros[mayuscula].Count() == 0)
    {
        Console.WriteLine($"No hay libros que inicien con la letra '{mayuscula}'");
    }
    else
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Título", "Nro. Páginas", "Fecha de Publicación");
        foreach (var book in ListadeLibros[mayuscula])
        {
            Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
        }
    }
}


