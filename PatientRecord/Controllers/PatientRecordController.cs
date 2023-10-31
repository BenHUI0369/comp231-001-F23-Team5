using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using PatientRecord.Contract.PatientRecord;
using PatientRecord.Models;
using PatientRecord.Services.PatientRecords;
using PatientRecord.ServicesErrors;
namespace PatientRecord.Controllers;

public class PatientRecordController : ApiController
{
    private readonly IPatientRecordSevice _patientRecordService;

    public PatientRecordController(IPatientRecordSevice patientRecordService)
    {
       _patientRecordService = patientRecordService; 
    }

    [HttpPost()]
    public IActionResult CreatePatientRecord(CreatePatientRecordRequest request)
    {
        var patientRecode = new Record(
            Guid.NewGuid(),
            request.firstName,
            request.lastName,
            request.dateOfBirth,
            request.gender,
            request.contactInformation,
            request.medicalHistory
        );

        // TODO save the record to database
        ErrorOr<Created> createRecordResult = _patientRecordService.CreatePatientRecord(patientRecode);

        return createRecordResult.Match(
            created => CreatedAsGetRecord(patientRecode),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetPatientRecord(Guid id)
    {
        ErrorOr<Record> getRecordResult = _patientRecordService.GetRecord(id);

        return getRecordResult.Match(
            record => Ok(MapRecordResponse(record)),
            errors => Problem(errors)
        );



        // if (getRecordResult.IsError && getRecordResult.FirstError == Errors.Record.NotFound)
        // {
        //     return NotFound();
        // }

        // var patientRecode = getRecordResult.Value;

        // PatientRecordRsponse response = MapRecordResponse(patientRecode);

        // return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertPatientRecord(Guid id, UpsertPatientRecordRequest request)
    {
        var patientRecode = new Record(
            id,
            request.firstName,
            request.lastName,
            request.dateOfBirth,
            request.gender,
            request.contactInformation,
            request.medicalHistory
        );

        ErrorOr<UpsertedRecord> upsertRecordResult = _patientRecordService.UpsertPatientRecord(patientRecode);

        // TODO: return 201 if new patient record was created


        return upsertRecordResult.Match(
            upserted => upserted.IsNewlyCreated? CreatedAsGetRecord(patientRecode) : NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeletePatientRecord(Guid id)
    {
        ErrorOr<Deleted> deleteRecordResult = _patientRecordService.DeletePatientRecord(id);
        
        return deleteRecordResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }

    private static PatientRecordRsponse MapRecordResponse(Record patientRecode)
    {
        return new PatientRecordRsponse(
        patientRecode.Id,
        patientRecode.FirstName,
        patientRecode.LastName,
        patientRecode.DateOfBirth,
        patientRecode.Gender,
        patientRecode.ContactInformation,
        patientRecode.MedicalHistory
        );
    }

        private IActionResult CreatedAsGetRecord(Record patientRecode)
    {

        // var response = new PatientRecordRsponse(
        //     patientRecode.Id,
        //     patientRecode.FirstName,
        //     patientRecode.LastName,
        //     patientRecode.DateOfBirth,
        //     patientRecode.Gender,
        //     patientRecode.ContactInformation,
        //     patientRecode.MedicalHistory
        //     );
        return CreatedAtAction(
            actionName: nameof(GetPatientRecord),
            routeValues: new { id = patientRecode.Id },
            value: MapRecordResponse(patientRecode));
    }

}