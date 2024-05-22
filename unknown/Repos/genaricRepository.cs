using unknown.Models;

namespace unknown.Repos
{
    public class genaricRepository<T> where T : class 
    {
        ManytomanyContext context;

        public genaricRepository(ManytomanyContext context)
        {
            this.context = context;
        }

        List<T> getall()
        {
        return context.Set<T>().ToList();    
        }
    }
}
