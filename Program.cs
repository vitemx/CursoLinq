﻿// See https://aka.ms/new-console-template for more information
using curso_linq;

LinqQueries linqQueries = new();

//ImprimirValores(linqQueries.TodaLaColeccion());
// ImprimirValores(linqQueries.LibrosDespuesDel2000());
//ImprimirValores(linqQueries.LibrosMas200PaginasContainsAction());
//Console.WriteLine($"Todos los libros tienen status? {linqQueries.TodosLosLibrosTienenStatus()}");
//Console.WriteLine($"Existen libros publicados en 2005? {linqQueries.AlgunLibroPublicadoEn2005()}");
//ImprimirValores(linqQueries.PertenecenCategoriaPyton());
System.Console.WriteLine("Ordenar Ascendente");
ImprimirValores(linqQueries.OrdenarLibrosJavaXNombreAscendente());
System.Console.WriteLine("Ordenar Descendente");
ImprimirValores(linqQueries.OrdenarLibrosXPaginaDescendente());

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