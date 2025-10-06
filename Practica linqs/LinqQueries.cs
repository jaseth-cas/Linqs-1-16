using System.Reflection;

public class LinqQueries
{
    private List<Book> libroscollection = new List<Book>();
    public LinqQueries()
    {
        using (StreamReader reader = new StreamReader("books.json"))
        {
            //lee todo el archiv json
            string json = reader.ReadToEnd();
            //serealiza el texto completo
            this.libroscollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }

    //metodo que devolvera toda la info de los libros 
    public IEnumerable<Book> TodaLaColeccion()
    {
        return libroscollection;
    }

    public IEnumerable<Book> LibrosDespuesde2000()
    {
        //extension method
        //return libroscollection.Where(p => p.PublishedDate.Year > 2000);

        //query expresion
        return from l in libroscollection where l.PublishedDate.Year > 2000 select l;
    }

    public IEnumerable<Book> Librosconmas250pagconpalabrasInAction()
    {
        //extesion method
        //return libroscollection.Where(p => p.PageCount > 250 && p.Title.Contains("in Action"));

        //query expression
        return from l in libroscollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;
    }

    //all y any devuelve booleanos
    public bool Todoloslibrostienenstatus()
    {
        return libroscollection.All(p => p.Status != string.Empty);
    }

    public bool Sialgunlibrofuepublicadoen2005()
    {
        return libroscollection.Any(p => p.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> LibrosdePython()
    {
        return libroscollection.Where(p => p.Categories.Contains("Python"));
    }

    public IEnumerable<Book> Librosdejavanombreascendente()
    {
        return libroscollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);
    }

    public IEnumerable<Book> Librosdemasde450pagordenadorpprnumpagdesc()
    {
        return libroscollection.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);
    }

    public IEnumerable<Book> tresprimeroslibrosodernadosporfecha()
    {
        return libroscollection
        .Where(p => p.Categories.Contains("Java"))
        .OrderByDescending(p => p.PublishedDate)
        .Take(3);
    }

    public IEnumerable<Book> tercerycuartolibrodemas400pags()
    {
        return libroscollection
        .Where(p => p.PageCount > 400)
        .Take(4)
        .Skip(2);
    }

    public IEnumerable<Book> tresprimeroslibrosdelacoleccion()
    {
        libroscollection.Take(3)
        .Select(p => new Book() { Title = p.Title, PageCount = p.PageCount });
    }
}