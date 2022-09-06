//var builder = WebApplication.CreateBuilder(args);

var oldpath = Directory.GetCurrentDirectory().Split("\\");
var newpath = string.Join("\\", oldpath.Take(oldpath.Length - 1).ToArray());
WebApplicationBuilder builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    ContentRootPath = newpath,
    WebRootPath = ""
});

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

app.Run();
