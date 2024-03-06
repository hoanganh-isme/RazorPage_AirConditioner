using AirConditionerDAO.PhotoUpload.Interface;
using AirConditionerManagement.Helpers;
using AirConditionerRepository;
using AirConditionerService;
using AirConditionerService.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IStaffMemberService, StaffMemberService>();
builder.Services.AddScoped<IAirConditionerService, AirConditionersService>();
builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));
// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseSession();

app.Run();
