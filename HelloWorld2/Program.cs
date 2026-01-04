var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseDefaultFiles();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.MapGet("/HelloWorld", async context =>
{
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync($"Hello, World!!!</br>");
    await context.Response.WriteAsync($"System info:{Environment.OSVersion}</br>");
    await context.Response.WriteAsync($"Platform info:{Environment.Version}</br>");
    await context.Response.WriteAsync($"Today is:{DateTime.Now}</br>");
    await context.Response.WriteAsync($"<p><a href=\"index.html\">Simple Html Page</a></br>");
    await context.Response.WriteAsync($"<a href=\"Hello\">Razor Page</a></p>");
});
app.Run();
