using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SocialBook.Data;
using SocialBook.Repositories;
using SocialBook.Repositories.Interfaces;
using SocialBook.Service;
using SocialBook.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SocialBookContext"); builder.Services.AddDbContext<SocialBook.Data.SocialBookContext>(options => 
    options.UseSqlite(connectionString));



builder.Services.AddRazorPages();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount =false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<SocialBookContext>(); builder.Services.AddDbContext<SocialBookContext>(options =>
     options.UseSqlite(builder.Configuration.GetConnectionString("SocialBookContext")));

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 6;

    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.AllowedForNewUsers = true;

    // User Settings
    options.User.RequireUniqueEmail = true;
});


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Add(new ServiceDescriptor(typeof(ILog), new ConsoleLogger()));

builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileService, ProfileService>();

builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostService, PostService>();


builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddScoped<IReactionRepository, ReactionRepository>();
builder.Services.AddScoped<IReactionService, ReactionService>();
builder.Services.AddScoped<PostImageProcessorService, PostImageProcessorService>();

builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();



// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddCoreAdmin();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseCoreAdminCustomUrl("admin");
app.MapRazorPages();

app.Run();
