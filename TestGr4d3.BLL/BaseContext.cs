using TestGr4d3.DAL.Contexto;

namespace TestGr4d3.BLL
{
    public class BaseContext
    {
        protected DataContext _context;

        public BaseContext(DataContext context) => _context = context;
    }
}
