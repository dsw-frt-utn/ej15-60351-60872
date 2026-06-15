using Dsw2026Ej15.Data;

namespace Dsw2026Ej15
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IPercistence, PersistenceInMemory>();

            var app = builder.Build();
        }
    }
}
