using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

var builder = WebApplication.CreateBuilder(args);

// Adicionar configuração da conexão do banco de dados
builder.Services.AddDbContext<TaskContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionar autenticação e autorização
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddAuthorization(options =>
{
    // Por padrão, todas as solicitações de entrada serão autorizadas de acordo com a política padrão.
    options.FallbackPolicy = options.DefaultPolicy;
});

// Adicionar Razor Pages e Identity UI
builder.Services.AddRazorPages()
    .AddMicrosoftIdentityUI();

var app = builder.Build();

// Configurar o pipeline de solicitação HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // O valor padrão do HSTS é 30 dias. Você pode querer alterar isso para cenários de produção.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Adicionar autenticação
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
