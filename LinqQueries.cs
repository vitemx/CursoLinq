namespace curso_linq
{
    public class LinqQueries
    {
        private List<Book>? librosCollection = new();
        public LinqQueries()
        {
            using(StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>
                                        (json, new System.Text.Json.JsonSerializerOptions()
                                        {PropertyNameCaseInsensitive = true});
            }
        }
        public IEnumerable<Book>? TodaLaColeccion()
        {
            return librosCollection;
        }

        #region Where Operator
        public IEnumerable<Book>? LibrosDespuesDel2000()
        {
            //extension method
            //return librosCollection.Where(p => p.PublishedDate.Year > 2000);

            //query expresion
            return from l in librosCollection where l.PublishedDate.Year > 2000 select l;
        }

        public IEnumerable<Book>? LibrosMas200PaginasContainsAction()
        {
            //extension method
            //return librosCollection.Where(p => p.PageCount > 250 && p.Title.Contains("in Action", StringComparison.InvariantCultureIgnoreCase));

            //query expresion
            return from l in librosCollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;
        } 
        #endregion

        #region All Operator
        public bool TodosLosLibrosTienenStatus()
        {
            return librosCollection != null ? librosCollection.All(l => l.Status != string.Empty) : false;
        }
        #endregion

         #region Any Operator
        public bool AlgunLibroPublicadoEn2005()
        {
            return librosCollection?.Any(l => l.PublishedDate.Year == 2005) ?? false;
        }
        #endregion

        #region ContainsOperator
        public IEnumerable<Book> ?PertenecenCategoriaPyton()
        {
            return librosCollection?.Where(l => l.Categories.Contains("Python"));
        }    

        #endregion

        #region OrderBy & OrderByDescending
        public IEnumerable<Book>? OrdenarLibrosJavaXNombreAscendente()
        {
            return librosCollection?.Where(l => l.Categories.Contains("Java")).OrderBy(l => l.Title);
        }

        public IEnumerable<Book>? OrdenarLibrosXPaginaDescendente()
        {
            return librosCollection?.Where(l => l.PageCount > 450).OrderByDescending(l => l.PageCount);
        }
            
        #endregion

        #region Take, Skip Operator
        public IEnumerable<Book>? Selecciona3LibrosRecienteJava()
        {
            return librosCollection?.Where(l => l.Categories.Contains("Java")).OrderByDescending(l => l.PublishedDate)
                                        .Take(3);
        }

        public IEnumerable<Book>? TercerCuartoLibroMayor400Paginas()
        {
            return librosCollection?.Where(l => l.PageCount > 400)
                                    .Take(4)
                                    .Skip(2);
        }

        #endregion

        #region Select operator
        public IEnumerable<Book>? ObtenerTituloPaginas()
        {
            return librosCollection?.Take(3)
            .Select(p => new Book() { Title =  p.Title, PageCount = p.PageCount });
        }
        #endregion

        #region Count & longCount operator
        public long ContarLibros200Y500Paginas()
        {
            return librosCollection?.Count(p => p.PageCount >= 200 && p.PageCount <= 500) ?? 0;
        }
        #endregion

        #region Operador min & max
        
        public DateTime MenorFechaPublicacionLibro()
        {
            return librosCollection?.Min(l => l.PublishedDate) ?? DateTime.Now;
        }

        public int RetornaPaginasLibroMasAmplio()
        {
            return librosCollection?.Max(l => l.PageCount) ?? 0;
        }

        #endregion

        #region MinBy MaxBy Operator

        public Book? LibrosMenorCantidadPaginas()
        {
            return librosCollection?.Where(l => l.PageCount > 0).MinBy(l => l.PageCount);
        }

        public Book? LibroFechaMasReciente()
        {
            return librosCollection?.MaxBy(l => l.PublishedDate);
        }
            
        #endregion

        #region Sume - Agregate Operator

        public int SumaPaginasLibros()
        {
            return librosCollection?.Where(l => l.PageCount >= 0 && l.PageCount <= 500).Sum(l => l.PageCount) ?? 0;
        }

        public string TitulosLibrosPublicadosDespues2015()
        {
            return librosCollection?.Where(l => l.PublishedDate.Year > 2015)
                                    .Aggregate("", (TitulosLibros, next) => 
                                    {
                                        if(TitulosLibros != string.Empty)
                                        {
                                            TitulosLibros += " - " + next.Title;
                                        }
                                        else{
                                            TitulosLibros += next.Title;
                                        }
                                        return TitulosLibros;
                                    }) ?? string.Empty;
        }

            
        #endregion

        #region AverageOperator

        public double PromedioCarateresTitulosLibros()
        {
            return librosCollection.Average(l => l.Title.Length);
        }

         public double PromedioNumeroPaginasLibros()
        {
            return librosCollection.Where(l => l.PageCount > 0).Average(l => l.PageCount);
        }
            
        #endregion

        #region GroupBy Operator

        public IEnumerable<IGrouping<int, Book>> AgrupaLibrosXAnioPublicadosDespues2000()
        {
            return librosCollection?.Where(l => l.PublishedDate.Year > 2000).GroupBy(l => l.PublishedDate.Year);
        }    
        
        #endregion

        #region Lookup Operator

        public ILookup<Char, Book> DiccionarioDeLibrosXLetra()
        {
            return librosCollection.ToLookup(l => l.Title[0], l => l);
        }
        
        #endregion

        #region Join Operator

        public IEnumerable<Book> Libros500YPublicacionMayor2005()
        {
            var libros500Paginas = librosCollection.Where(l => l.PageCount > 500);
            var librosDespues2005 = librosCollection.Where(l => l.PublishedDate.Year > 2005);
            return libros500Paginas.Join(librosDespues2005, p => p.Title, a => a.Title, (p, a) => p);
        }
           

        #endregion
    }
}