namespace PatientRecord.Contract.PatientRecord;
public record PatientRecordRsponse(
    Guid id,
    string firstName,
    string lastName,
    string dateOfBirth,
    string gender,
    Contact contactInformation,
    MedicalHistory[] medicalHistory
);