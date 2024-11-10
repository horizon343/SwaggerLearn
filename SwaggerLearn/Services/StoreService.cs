using SwaggerLearn.Models;

namespace SwaggerLearn.Services;

public class StoreService
{
    public readonly List<MedicationModel> Store = new List<MedicationModel>();
    private int Index = 0;

    public MedicationModel Add(MedicationUpdateModel medicationUpdate)
    {
        MedicationModel medication = new MedicationModel()
        {
            Id = Index,
            Name = medicationUpdate.Name,
            Description = medicationUpdate.Description,
            DosageForm = medicationUpdate.DosageForm,
            Dosage = medicationUpdate.Dosage
        };

        Store.Add(medication);
        Index += 1;

        return medication;
    }

    public void Remove(MedicationModel medication)
    {
        Store.Remove(medication);
    }

    public void Update(MedicationUpdateModel medicationUpdate, int id)
    {
        MedicationModel medication = Store.FirstOrDefault(med => med.Id.Equals(id))!;
        Store.Remove(medication);
        
        MedicationModel newMedication = new MedicationModel()
        {
            Id = id,
            Name = medicationUpdate.Name,
            Description = medicationUpdate.Description,
            DosageForm = medicationUpdate.DosageForm,
            Dosage = medicationUpdate.Dosage
        };
        Store.Add(newMedication);
    }
}