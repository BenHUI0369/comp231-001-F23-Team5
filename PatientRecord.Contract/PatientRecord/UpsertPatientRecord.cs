namespace PatientRecord.Contract.PatientRecord;
public record UpsertPatientRecordRequest(
    string firstName,
    string lastName,
    string dateOfBirth,
    string gender,
    Contact contactInformation,
    MedicalHistory[] medicalHistory
);