using GestionMouvementCarte.DBcontextSQL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Ajoutez les services nécessaires
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Configurez le contexte de base de données
builder.Services.AddDbContext<DataDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Tis")));

// Configurez Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
.AddEntityFrameworkStores<DataDBContext>()
.AddDefaultTokenProviders();

// Ajoutez le service d'envoi d'email (si nécessaire)
builder.Services.AddTransient<IEmailSender, NoOpEmailSender>();

// Ajoutez l'autorisation
builder.Services.AddAuthorization();

var app = builder.Build();

// Configurez le pipeline de requêtes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
