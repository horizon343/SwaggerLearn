using System.ComponentModel.DataAnnotations;

namespace SwaggerLearn.Models;

public class MedicationModel
{
    /// <summary>
    /// Unique medication identifier
    /// </summary>
    [Required]
    public int Id { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Dosage form (tablets, syrup, spray)
    /// </summary>
    [Required]
    [MinLength(4)]
    [MaxLength(35)]
    public string DosageForm { get; set; }

    /// <summary>
    /// Dosage (mg/ml)
    /// </summary>
    [Required]
    public float Dosage { get; set; }
}