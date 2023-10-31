using PatientRecord.Services.PatientRecords;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IPatientRecordSevice, PatientRecordService>();
}

var app = builder.Build();

{
    // add an exception handler, 
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

