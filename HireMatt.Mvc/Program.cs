var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapGet("/sitemap.xml", (HttpContext ctx) =>
{
    var baseUrl = $"{ctx.Request.Scheme}://{ctx.Request.Host}{ctx.Request.PathBase}";
    var xml =
        "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
        "<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">\n" +
        $"  <url><loc>{baseUrl}/</loc></url>\n" +
        $"  <url><loc>{baseUrl}/Home/About</loc></url>\n" +
        $"  <url><loc>{baseUrl}/Home/Privacy</loc></url>\n" +
        "</urlset>";
    return Results.Content(xml, "application/xml");
});

app.Run();
