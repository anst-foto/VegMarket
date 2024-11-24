var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/products", () =>
    {
        var products = new Product[]
        {
            new("яблоки", 10, new Uri("https://image.pngaaa.com/159/5142159-middle.png")),
            new("помидоры", 5, new Uri("https://avatars.mds.yandex.net/i?id=f03cc96c72692aba40f19e5fdf21dc83_l-5312300-images-thumbs&n=13")),
            new("бананы", 30, new Uri("https://avatars.mds.yandex.net/i?id=5030a8a7a56dd7a2c83474917b3c6b71_l-5314093-images-thumbs&n=13")),
            new("груши", 7, new Uri("https://avatars.mds.yandex.net/i?id=88a856f5fdb33487447633f8d01240a7_l-4297797-images-thumbs&n=13"))
        };
        return products;
    })
    .WithName("GetProducts");

app.Run();

internal record Product(string Name, int Count, Uri Image);