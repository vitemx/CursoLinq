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
ImprimirValores(linqQueries.ObtenerTituloPaginas());

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