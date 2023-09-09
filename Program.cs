// See https://aka.ms/new-console-template for more information
using curso_linq;

LinqQueries linqQueries = new();

//ImprimirValores(linqQueries.TodaLaColeccion());
// ImprimirValores(linqQueries.LibrosDespuesDel2000());
ImprimirValores(linqQueries.LibrosMas200PaginasContainsAction());

void ImprimirValores(IEnumerable<Book>? listaLibros)
{
    if(listaLibros != null)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 11}\n", "Titulo", "N.Paginas", "Fecha publicación");
        foreach(var item in listaLibros)
        {
            Console.WriteLine("{0, -60} {1, 15} {2, 11}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
        }
    }
}