using System.Runtime.InteropServices;

namespace curso_linq;

public class LinqQueries
{
    private List<Book> librosCollection;
    public LinqQueries()
    {
        using (StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.librosCollection = System.Text.Json.JsonSerializer.
                Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        }
    }
    public IEnumerable<Book> TodaLaCollecion()
    {
        return librosCollection;
    }

    public IEnumerable<Book> LibrosDespuesde2000()
    {
        //Manera con Extension method
        //return librosCollection.Where(p => p.PublishedDate.Year > 2000);

        //Manera con query expresion
        return from l in librosCollection
               where l.PublishedDate.Year > 2000
               select l;
    }

    public IEnumerable<Book> LibrosConMasDe250PagInAction()
    {
        //Manera con Extension method 
        //return librosCollection.Where(p=> p.PageCount > 250 
        //&& p.Title.Contains("in Action"));

        //Manera con query expresion
        return from l in librosCollection
               where l.PageCount > 250 &&
               l.Title.Contains("in Action")
               select l;
    }

    public bool LibrosConStatus()
    {
        //Manera con Extension method 
        return librosCollection.All(p => p.Status != string.Empty);

    }

    public IEnumerable<Book> LibrosConStatusQuery()
    {
        //Manera con query expresion
        return from l in librosCollection
               where !string.IsNullOrEmpty(l.Status)
               select l;
    }

    public bool AlgunLibroPublicadoEn2005()
    {
        //Manera con Extension method 
        return librosCollection.Any(p => p.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> AlgunLibroPublicadoEn2005Query()
    {


        //Manera con query expresion
        return from l in librosCollection
               where l.PublishedDate.Year == 2005
               select l;
    }

    public IEnumerable<Book> CategoriaPython()
    {
        //Manera con Extension method 
        return librosCollection.Where(p => p.Categories.Contains("Python"));

        //Manera con query expresion
        //return from l in librosCollection
        //       where l.Categories.Contains("Python")
        //       select l;    
    }

    public IEnumerable<Book> CategoriaOrderByJava()
    {
        //Manera con Extension method 
        return librosCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);

        //Manera con query expresion
        //return (from l in librosCollection
        //        where l.Categories.Contains("Java")
        //        select l).OrderBy(p => p.Title);
    }

    public IEnumerable<Book> CategoriaOrderByDescendingJavaQuery()
    {
        //Manera con Extension method 
        return librosCollection.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);

        //Manera con query expresion
        //return (from l in librosCollection
        //        where l.PageCount > 450
        //        select l).OrderByDescending(p => p.PageCount);
    }

    public IEnumerable<Book> OperadorTakeBuscarCategoriaJavaQuery()
    {
        //Manera con Extension method 
        //return librosCollection.
        //    Where(p => p.Categories.Contains("Java")).
        //    OrderByDescending(p => p.PublishedDate).
        //    Take(3);

        //return librosCollection.
        //    Where(p => p.Categories.Contains("Java")).
        //    OrderBy(p => p.PublishedDate).
        //    TakeLast(3);

        //Manera con query expresion
        return (from l in librosCollection
                where l.Categories.Contains("Java")
                select l).OrderByDescending(p => p.PublishedDate).Take(3);
    }

    public IEnumerable<Book> OperadorSkipSeleccionaTerceryCuartoLibro()
    {
        //Manera con Extension method 
        return librosCollection.
            Where(p => p.PageCount > 400).
            Take(4).
            Skip(2);
    }

    public IEnumerable<Book> OperadorSelectTresprimerosLibros()
    {
        return librosCollection.
         Take(3).
         Select(p => new Book { Title = p.Title, PageCount = p.PageCount, PublishedDate = p.PublishedDate });

    }

    public int OperadorCountNumeroLibros200y500()
    {
        return librosCollection.Count(p => p.PageCount >= 200 && p.PageCount <= 500);

    }

    public long OperadorCountNumeroLibros200y500pag()
    {
        return librosCollection.LongCount(p => p.PageCount >= 200 && p.PageCount <= 500);

    }

    public DateTime OperadorMinMenorFechaDePublicacion()
    {
        return librosCollection.Min(p => p.PublishedDate);

    }

    public int OperadorMaxNumerodePagLibroMayor()
    {
        return librosCollection.Max(p => p.PageCount);
    }

    public Book OperadorMinByLibroMenorCantidadPag()
    {
        return librosCollection.Where(p => p.PageCount > 0).MinBy(p => p.PageCount);

    }

    public Book OperadorMaxByLibroFechaPublicacionMasReciente()
    {
        return librosCollection.MaxBy(p => p.PublishedDate);
    }

    public int OperadorSumParaSumarCantidadPaginasEntre0y500()
    {
        return librosCollection.Where(p => p.PageCount >= 0 && p.PageCount <= 500).Sum(p => p.PageCount);
    }

    public string OperadorAgregateTitulosDeLibrosDespuesDel2015()
    {
        return librosCollection
            .Where(p => p.PublishedDate.Year > 2015)
            .Aggregate("", (TitulosLibros, next) =>
            {
                 if (TitulosLibros != string.Empty)
                     TitulosLibros += " - " + next.Title;
                 else
                     TitulosLibros += next.Title;
                 return TitulosLibros;

            });
    }

    public double OperadorAvegarePromedioCaracteres() 
    {
        return librosCollection.Average(p => p.Title.Length);
    }

    public IEnumerable<IGrouping<int, Book>> OperadorGroupByLibrosPublicadosDespuesDel2000() 
    {
        return librosCollection.Where(p => p.PublishedDate.Year >= 2000)
                               .GroupBy(p => p.PublishedDate.Year);
    }

}
