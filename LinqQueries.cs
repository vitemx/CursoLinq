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
            //return librosCollection.Where(p => p.PageCount > 250 && p.Title.Contains("Action", StringComparison.InvariantCultureIgnoreCase));

            //query expresion
            return from l in librosCollection where l.PageCount > 250 && l.Title.Contains("Action") select l;
        } 
    
    }
}