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
                Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true});

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
}
