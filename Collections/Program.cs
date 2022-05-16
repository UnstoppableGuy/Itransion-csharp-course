using Microsoft.AspNetCore.Identity;
using CollectionPR.Data;
using CollectionPR.Hub;
using CollectionPR.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using CollectionPR.Services;
using CollectionPR.Services.Classes;
using CollectionPR.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;
using CollectionPR.Data.Interfaces;
using CollectionPR.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CollectionDbContext>()
            .AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddSingleton<ISaveFileAsync, SaveCloudService>()
            .AddSingleton<IDeleteCloud, DeleteCloudService>();

builder.Services.AddScoped<IUserService, UserService>()
            .AddScoped<ICollectionService, CollectionService>()
            .AddScoped<IItemService, ItemService>()
            .AddScoped<ILikeService, LikeService>()
            .AddScoped<ICommentService, CommentService>()
            .AddSingleton<IUserIdProvider, CustomUserIdProvider>(); ;

builder.Services.AddScoped<IUserRepository, UserRepository>()
            .AddScoped<ICollectionRepository, CollectionRepository>()
            .AddScoped<ILikeRepository, LikeRepository>()
            .AddScoped<IItemRepository, ItemRepository>()
            .AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddScoped<IUserValidation, UserValidationService>()
            .AddScoped<ICollectionValidation, CollectionValidationService>()
            .AddScoped<IItemValidation, ItemValidationService>()
            .AddScoped<ILikeValidation, LikeValidationService>();


builder.Services.AddIdentity<User, IdentityRole>(options =>
    {
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireLowercase = false;
        options.Password.RequiredLength = 8;
        options.User.RequireUniqueEmail = true;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CollectionDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddSignalR();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => 
    {
        options.LoginPath = new PathString("/Account/Login");
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseCors();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<CommentsHub>("/chat");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}",
    "{controller=Account}/{action=Login}/{id?}");
app.MapRazorPages();

app.Run();