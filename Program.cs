using Microsoft.EntityFrameworkCore;
using MultiDbWebApi.Data;
using MultiDbWebApi.Models;
using MultiDbWebApi.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// TestDB için DbContext tanımlaması
builder.Services.AddDbContext<TestDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestDBConnection")));

// FERPEX için DbContext tanımlaması
builder.Services.AddDbContext<FerpexDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FERPEXConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITBLUSERSRepository, TBLUSERSRepository>();
builder.Services.AddScoped<ITBLCARISBRepository, TBLCARISBRepository>();
builder.Services.AddScoped<ITBLCARIHRRepository, TBLCARIHRRepository>();
builder.Services.AddScoped<ITBLSTOKSBRepository, TBLSTOKSBRepository>();
builder.Services.AddScoped<ITBLSTOKSBRepository2,TBLSTOKSBRepository2>();
builder.Services.AddScoped<ITBLSTOKHRRepository, TBLSTOKHRRepository>();
builder.Services.AddScoped<ITBLKASASBRepository, TBLKASASBRepository>();
builder.Services.AddScoped<ITBLKASAHRRepository, TBLKASAHRRepository>();
builder.Services.AddScoped<ITBLBANKASBRepository, TBLBANKASBRepository>();
builder.Services.AddScoped<ITBLBANKAHRRepository, TBLBANKAHRRepository>();
builder.Services.AddScoped<ITBLCEKSENETRepository, TBLCEKSENETRepository>();
builder.Services.AddScoped<ITBLCEKSENETwithSERIALRepository, TBLCEKSENETwithSERIALRepository>();
builder.Services.AddScoped<ITBLRECETESBRepository, TBLRECETESBRepository>();
builder.Services.AddScoped<ITBLRECETEHRRepository, TBLRECETEHRRepository>();
builder.Services.AddScoped<ITBLISEMRISBRepository, TBLISEMRISBRepository>();
builder.Services.AddScoped<ITBLISEMRIHRRepository, TBLISEMRIHRRepository>();
builder.Services.AddScoped<ITBLURETIMRepository, TBLURETIMRepository>();
builder.Services.AddScoped<ITBLURETIMRepository2, TBLURETIMRepository2>();
//builder.Services.AddScoped<TBLSTOKREHBERRepository>();
builder.Services.AddScoped<ITBLDEPOSBRepository, TBLDEPOSBRepository>();
builder.Services.AddScoped<ITBLKALITEKONTROLRepository, TBLKALITEKONTROLRepository>();

builder.Services.AddScoped<ITBLURETIMKABULRepository, TBLURETIMKABULRepository>();

//rehber hızlandırılmı

builder.Services.AddScoped<ITBLSTOKREHBERRepository, TBLSTOKREHBERRepository>();
builder.Services.AddScoped<ITBLCARIREHBERRepository, TBLCARIREHBERRepository>();
builder.Services.AddScoped<ITBLDEPOSAYIMREHBERRepository, TBLDEPOSAYIMREHBERRepository>();

// JWT Authentication configuration
var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // JWT auth middleware
app.UseAuthorization();

app.MapControllers();

app.Run();

public interface ITBLSTOKREHBERRepository
{
    Task<IEnumerable<TBLSTOKREHBER>> ExecuteStoredProcedureAsync(string DatabaseName, string gelen);
}
public interface ITBLCARIREHBERRepository
{
    Task<IEnumerable<TBLCARIREHBER>> ExecuteStoredProcedureAsync(string DatabaseName, string gelen);
}

public interface ITBLSTOKSBRepository2
{
    Task<IEnumerable<TBLSTOKSB2>> ExecuteStoredProcedureAsync(string DatabaseName, string StokKod);
}
public interface ITBLURETIMKABULRepository
{
    Task<bool> ExecuteFPROCOPRSAVEAsync(TBLURETIMKABULRequestDto requestDto);
}
public interface ITBLDEPOSAYIMREHBERRepository
{
    Task<IEnumerable<TBLDEPOSAYIMREHBER>> ExecuteStoredProcedureAsync(string DatabaseName, string gelen);
}
public interface ITBLKALITEKONTROLRepository
{
    Task<bool> AddPanelKaliteAsync(TBLKALITEKONTROL PanelKaliteKontrol);
}

public interface ITBLBANKAHRRepository
{
    Task<IEnumerable<TBLBANKAHR>> ExecuteStoredProcedureAsync(string DatabaseName, string DetayTur, string BankaKod);
}

public interface ITBLCARIHRRepository
{
    Task<IEnumerable<TBLCARIHR>> ExecuteStoredProcedureAsync(string DatabaseName, string CariKod);
}

public interface ITBLSTOKSBRepository
{
    Task<IEnumerable<TBLSTOKSB>> ExecuteStoredProcedureAsync(string DatabaseName);
}

public interface ITBLSTOKHRRepository
{
    Task<IEnumerable<TBLSTOKHR>> ExecuteStoredProcedureAsync(string DatabaseName, string StokKod);
}

public interface ITBLKASASBRepository
{
    Task<IEnumerable<TBLKASASB>> ExecuteStoredProcedureAsync(string DatabaseName);
}

public interface ITBLKASAHRRepository
{
    Task<IEnumerable<TBLKASAHR>> ExecuteStoredProcedureAsync(string DatabaseName, string KasaKod);
}

public interface ITBLBANKASBRepository
{
    Task<IEnumerable<TBLBANKASB>> ExecuteStoredProcedureAsync(string DatabaseName);
}

public interface ITBLCEKSENETRepository
{
    Task<IEnumerable<TBLCEKSENET>> ExecuteStoredProcedureAsync(string DatabaseName);
}

public interface ITBLCEKSENETwithSERIALRepository
{
    Task<IEnumerable<TBLCEKSENETwithSERIAL>> ExecuteStoredProcedureAsync(string DatabaseName);
}

public interface ITBLRECETESBRepository
{
    Task<IEnumerable<TBLRECETESB>> ExecuteStoredProcedureAsync(string DatabaseName);
}

public interface ITBLRECETEHRRepository
{
    Task<IEnumerable<TBLRECETEHR>> ExecuteStoredProcedureAsync(string DatabaseName, string ReceteKod);
}

public interface ITBLISEMRISBRepository
{
    Task<IEnumerable<TBLISEMRISB>> ExecuteStoredProcedureAsync(string DatabaseName);
}

public interface ITBLISEMRIHRRepository
{
    Task<IEnumerable<TBLISEMRIHR>> ExecuteStoredProcedureAsync(string DatabaseName, string IsEmriKod);
}

public interface ITBLURETIMRepository
{
    Task<IEnumerable<TBLURETIM>> ExecuteStoredProcedureAsync(string DatabaseName);
}

public interface ITBLURETIMRepository2
{
    Task<IEnumerable<TBLURETIM2>> ExecuteStoredProcedureAsync(string DatabaseName, string UretimKod);
}

public interface ITBLDEPOSBRepository
{
    Task<IEnumerable<TBLDEPOSB>> ExecuteStoredProcedureAsync(string DatabaseName);
}

public interface ITBLUSERSRepository
{
    Task<IEnumerable<TBLUSERS>> ExecuteStoredProcedureAsync(string kulAdi, string kulSifre, string extraParam);
}

public interface ITBLCARISBRepository
{
    Task<IEnumerable<TBLCARISB>> ExecuteStoredProcedureAsync(string DatabaseName);
}
