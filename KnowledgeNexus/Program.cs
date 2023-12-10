using KnowledgeNexus.Components;
using KnowledgeNexus.Components.Account;
using KnowledgeNexus.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("ApplicationDbContext"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("AbleToCreate", policy => policy.RequireRole("Teacher", "Admin"));

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
    roleManager?.CreateAsync(new IdentityRole("Student")).Wait();
    roleManager?.CreateAsync(new IdentityRole("Teacher")).Wait();
    roleManager?.CreateAsync(new IdentityRole("Admin")).Wait();

    var userStore = scope.ServiceProvider.GetService<IUserStore<ApplicationUser>>();
    var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();

    ApplicationUser user;

    // add admin
    user = new ApplicationUser
    {
        UserName = "admin@admin.com",
        Email = "admin@admin.com",
        EmailConfirmed = true
    };
    user.PasswordHash = userManager.PasswordHasher.HashPassword(user, "admin123!");
    userStore.CreateAsync(user, CancellationToken.None).Wait();

    userManager.AddToRoleAsync(user, "Admin").Wait();

    // add teacher
    user = new ApplicationUser
    {
        UserName = "teacher@teacher.com",
        Email = "teacher@teacher.com",
        EmailConfirmed = true
    };
    user.PasswordHash = userManager.PasswordHasher.HashPassword(user, "teacher123!");
    userStore.CreateAsync(user, CancellationToken.None).Wait();

    userManager.AddToRoleAsync(user, "Teacher").Wait();

    // add student
    user = new ApplicationUser
    {
        UserName = "student@student.com",
        Email = "student@student.com",
        EmailConfirmed = true
    };
    user.PasswordHash = userManager.PasswordHasher.HashPassword(user, "student123!");
    userStore.CreateAsync(user, CancellationToken.None).Wait();

    userManager.AddToRoleAsync(user, "Student").Wait();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
