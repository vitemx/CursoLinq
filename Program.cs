// See https://aka.ms/new-console-template for more information
using curso_linq;

LinqQueries linqQueries = new();

//ImprimirValores(linqQueries.TodaLaColeccion());
// ImprimirValores(linqQueries.LibrosDespuesDel2000());
//ImprimirValores(linqQueries.LibrosMas200PaginasContainsAction());
//Console.WriteLine($"Todos los libros tienen status? {linqQueries.TodosLosLibrosTienenStatus()}");
//Console.WriteLine($"Existen libros publicados en 2005? {linqQueries.AlgunLibroPublicadoEn2005()}");
//ImprimirValores(linqQueries.PertenecenCategoriaPyton());
// System.Console.WriteLine("Ordenar Ascendente");
// ImprimirValores(linqQueries.OrdenarLibrosJavaXNombreAscendente());
// System.Console.WriteLine("Ordenar Descendente");
// ImprimirValores(linqQueries.OrdenarLibrosXPaginaDescendente());
// ImprimirValores(linqQueries.Selecciona3LibrosRecienteJava());
// ImprimirValores(linqQueries.TercerCuartoLibroMayor400Paginas());
//ImprimirValores(linqQueries.ObtenerTituloPaginas());
//System.Console.WriteLine($"Cantidad de libros que tienen entre 200 y 500 paginas son: {linqQueries.ContarLibros200Y500Paginas()}");
// System.Console.WriteLine($"La fecha de publicación menor es: {linqQueries.MenorFechaPublicacionLibro()}");
//System.Console.WriteLine($"El mayor libro tiene: {linqQueries.RetornaPaginasLibroMasAmplio()} páginas");
// var book = linqQueries.LibrosMenorCantidadPaginas();
// System.Console.WriteLine($"Libro con menor numero de paginas es: {book.Title} con {book.PageCount}");
// var book = linqQueries.LibroFechaMasReciente();
// Console.WriteLine($"El libro mas reciente publicado es {book?.Title} publicado el: {book?.PublishedDate.ToShortDateString()}");
//System.Console.WriteLine($"La suma total de las paginas de los libros es: {linqQueries.SumaPaginasLibros()}");
//System.Console.WriteLine($"Los libros publicados despues del 2015 son: {linqQueries.TitulosLibrosPublicadosDespues2015()}");
//System.Console.WriteLine($"El promedio de caracteres de los titulos de libros es: {linqQueries.PromedioCarateresTitulosLibros()}");
//System.Console.WriteLine($"El promedio de paginas de los libros es de {linqQueries.PromedioNumeroPaginasLibros()}");
// ImprimirValoresGrupo(linqQueries.AgrupaLibrosXAnioPublicadosDespues2000());

ImprimirValoresDiccionario(linqQueries.DiccionarioDeLibrosXLetra(), 'Z' );

void ImprimirValoresDiccionario(ILookup<char, Book> listaLibros, char letra)
{
    System.Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N.Paginas", "Fecha publicación");
    foreach (var item in listaLibros[letra])
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

void ImprimirValoresGrupo(IEnumerable<IGrouping<int, Book>> listaLibros)
{
    foreach (var grupo in listaLibros)
    {
        System.Console.WriteLine("");
        System.Console.WriteLine($"Grupo: { grupo.Key }");
        System.Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N.Paginas", "Fecha publicación");
        foreach (var item in grupo)
        {
            Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
        }
    }
}


void ImprimirValores(IEnumerable<Book>? listaLibros)
{
    if(listaLibros != null)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 11} {3, 12}\n", "Titulo", "N.Paginas", "Fecha publicación", "Categoria");
        foreach(var item in listaLibros)
        {
            Console.WriteLine("{0, -60} {1, 15} {2, 11} {3, 12}", item.Title, item.PageCount, "na", "NA");
        }
    }
}