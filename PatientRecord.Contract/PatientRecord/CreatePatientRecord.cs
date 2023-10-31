namespace PatientRecord.Contract.PatientRecord;
public record CreatePatientRecordRequest(
    string firstName,
    string lastName,
    string dateOfBirth,
    string gender,
    Contact contactInformation,
    MedicalHistory[] medicalHistory
);