using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

var builder = WebApplication.CreateBuilder(args);

// Adicionar configura��o da conex�o do banco de dados
builder.Services.AddDbContext<TaskContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionar autentica��o e autoriza��o
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddAuthorization(options =>
{
    // Por padr�o, todas as solicita��es de entrada ser�o autorizadas de acordo com a pol�tica padr�o.
    options.FallbackPolicy = options.DefaultPolicy;
});

// Adicionar Razor Pages e Identity UI
builder.Services.AddRazorPages()
    .AddMicrosoftIdentityUI();

var app = builder.Build();

// Configurar o pipeline de solicita��o HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // O valor padr�o do HSTS � 30 dias. Voc� pode querer alterar isso para cen�rios de produ��o.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Adicionar autentica��o
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
