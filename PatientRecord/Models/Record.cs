using PatientRecord.Contract.PatientRecord;

namespace PatientRecord.Models;

public class Record
{
    public Guid Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string DateOfBirth { get; }
    public string Gender { get; }
    public Contact ContactInformation { get; }
    public MedicalHistory[] MedicalHistory { get; }

    public Record(
        Guid id,
        string fName,
        string lName,
        string birthday,
        string gender,
        Contact contactInformation,
        MedicalHistory[] medicalHistory
    )
    {
        // emforce invariants
        Id = id;
        FirstName = fName;
        LastName = lName;
        DateOfBirth = birthday;
        Gender = gender;
        ContactInformation = contactInformation;
        MedicalHistory = medicalHistory;
    }
}