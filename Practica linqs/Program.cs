LinqQueries queries = new LinqQueries();
// aqui muestra toda la coleccion
//PrintValues(queries.TodaLaColeccion());//llama el metodo de la clase linqueries la lee y la presenta en el formato de el metodo printvalues

//libros despues del 2000
//PrintValues(queries.LibrosDespuesde2000());

//estos son los libros que tienen mas de 250 pag y que tienen en el titulo tiene in action
//PrintValues(queries.Librosconmas250pagconpalabrasInAction());

//todos los libros tienen status
//Console.WriteLine($" Todos los libros tienen Status? - {queries.Todoloslibrostienenstatus()}");

//si algun libro fue publicado en 2005
//Console.WriteLine($" algun libro fue publicado en 2005? - {queries.Sialgunlibrofuepublicadoen2005()}");

//si hay libros de python
//PrintValues(queries.LibrosdePython());

//si hay libros de java que lo ordene en orden ascendente
//PrintValues(queries.Librosdejavanombreascendente());

// libros que tienen mas de 450 paginas ordenadas por cantidad de paginas
//PrintValues(queries.Librosdemasde450pagordenadorpprnumpagdesc());

//tres libros de java mas publicados recientemente
//PrintValues(queries.tresprimeroslibrosodernadosporfecha());

//tercer y cuarto libro de mas de 400 pags
//PrintValues(queries.tercerycuartolibrodemas400pags());

//tres primeros libros filtrados con select
PrintValues(queries.tresprimeroslibrosdelacoleccion());

//crea un void para la funcion de los libros de programacion
void PrintValues(IEnumerable<Book> listadelibros)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N.Paginas", "Fecha publicacion");
    foreach (var item in listadelibros)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }


}