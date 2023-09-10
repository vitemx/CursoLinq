using System.Net.Http.Headers;

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
            return librosCollection.Any(l => l.PublishedDate.Year == 2005);
        }
        #endregion

        #region ContainsOperator
        public IEnumerable<Book> PertenecenCategoriaPyton()
        {
            return librosCollection.Where(l => l.Categories.Contains("Python"));
        }    

        #endregion

        #region OrderBy & OrderByDescending
        public IEnumerable<Book> OrdenarLibrosJavaXNombreAscendente()
        {
            return librosCollection.Where(l => l.Categories.Contains("Java")).OrderBy(l => l.Title);
        }

        public IEnumerable<Book> OrdenarLibrosXPaginaDescendente()
        {
            return librosCollection.Where(l => l.PageCount > 450).OrderByDescending(l => l.PageCount);
        }
            
        #endregion

        #region Take, Skip Operator
        public IEnumerable<Book> Selecciona3LibrosRecienteJava()
        {
            return librosCollection.Where(l => l.Categories.Contains("Java")).OrderByDescending(l => l.PublishedDate)
                                        .Take(3);
        }

        public IEnumerable<Book> TercerCuartoLibroMayor400Paginas()
        {
            return librosCollection.Where(l => l.PageCount > 400)
                                    .Take(4)
                                    .Skip(2);
        }

        #endregion

        #region Select operator
        public IEnumerable<Book> ObtenerTituloPaginas()
        {
            return librosCollection.Take(3)
            .Select(p => new Book() { Title =  p.Title, PageCount = p.PageCount });
        }
        #endregion
    }
}