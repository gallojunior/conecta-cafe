using ConectaCafe.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// string conexao = builder.Configuration.GetConnectionString("CafeDb");
// builder.Services.AddDbContext<AppDbContext>(
//     opt => opt.UseSqlServer(conexao)
// );

string conexao = builder.Configuration.GetConnectionString("CafeMemory");
builder.Services.AddDbContext<AppDbContext>(
    opt => opt.UseInMemoryDatabase(conexao)
);


var app = builder.Build();

using (var scope = app.Services.CreateScope()) {
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

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
