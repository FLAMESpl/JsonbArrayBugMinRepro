using System;
using System.Threading.Tasks;

namespace JsonbArrayBugMinRepro
{
    class Program
    {
        static async Task Main()
        {
            using var dbContext = new AppDbContext();

            try
            {
                var model = new Model
                {
                    JsonbArray = new[]
                    {
                        "{}",
                        @"{ ""Prop"": ""Val"" }"
                    }
                };
                dbContext.Set<Model>().Add(model);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("Finished");
                Console.ReadLine();
            }
        }
    }
}
