using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

try
{
    var builder = new HostBuilder();
    using IHost host = await StartSiloAsync(builder);
    Console.WriteLine("\n\n Press Enter to terminate...\n\n");
    Console.ReadLine();

    await host.StopAsync();

    return 0;
}
catch (Exception ex)
{
    Console.WriteLine(ex);
    return 1;
}

static async Task<IHost> StartSiloAsync(IHostBuilder builder)
{
    var invariant = "Npgsql";
    var postgres = "Host=localhost:5432;Username=postgres;Password=postgrespw;Database=postgres";
    builder.UseOrleans(silo =>
    {
        silo.UseLocalhostClustering()
            .ConfigureLogging(log => log.AddConsole());
    
        silo.AddAdoNetGrainStorage("BidState", opt =>
        {
            opt.Invariant = invariant;
            opt.ConnectionString = postgres;
        });
    });

    var host = builder.Build();
    await host.StartAsync();

    return host;
}