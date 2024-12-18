using ForjaDosAneisFrontend.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner.
builder.Services.AddRazorPages();

// Registrar o HttpClient para injeção de dependência
builder.Services.AddHttpClient();

// Registrar o AnelService para injeção de dependência
builder.Services.AddScoped<IAnelService, AnelService>();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configuração do pipeline de requisições.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Aplicar a política de CORS
app.UseCors("PermitirTudo");

app.MapRazorPages();

app.Run();
