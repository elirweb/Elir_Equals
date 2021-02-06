using Microsoft.EntityFrameworkCore;

namespace ByRequest.Infra
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Equals_Infra.Context.EfCore())
            {
                db.Database.Migrate();   
     
            }

            
        }
    }
}
