WebApplication app = WebApplication.Create();

app.Urls.Add("https://localhost:3000");
app.Urls.Add("http://*:3000");

List<Overwat> overwat = new();
overwat.Add(new() { Name = "Winton", Attractiveness = "Beyond infinite", Strength = 99999 });
overwat.Add(new() { Name = "Hampter", Attractiveness = "Beyond infinite", Strength = 43110 });
overwat.Add(new() { Name = "Kiko", Attractiveness = "Beyond infinite", Strength = 80085 });

app.MapGet("/overwat/", () =>
{
    return overwat;
});


app.MapGet("/overwat/{num}", (int num) =>
{
    if (num >= 0 && num < overwat.Count)
    {
        return Results.Ok(overwat[num]);
    }
    return Results.NotFound();
});


app.MapGet("/", Answer);

app.MapPost("/overwat/", (Overwat overwats) =>
{
    Console.WriteLine("Added overwat " + overwats.Name);
    overwat.Add(overwats);
});

app.Run();

static string Answer()
{
    return "I like chicken";
}