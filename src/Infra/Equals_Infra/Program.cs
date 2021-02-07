using Microsoft.EntityFrameworkCore;

namespace Equals_Infra
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
