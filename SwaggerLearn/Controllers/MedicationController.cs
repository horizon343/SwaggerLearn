using Microsoft.AspNetCore.Mvc;
using SwaggerLearn.Models;
using SwaggerLearn.Services;

namespace SwaggerLearn.Controllers;

[ApiController]
[Route("api/v1")]
public class MedicationController : ControllerBase
{
    private StoreService _storeService { get; }

    public MedicationController(StoreService storeService)
    {
        _storeService = storeService;
    }

    /// <summary>
    /// Adds a new medication to the database
    /// </summary>
    /// <param name="medicationModel">Data about medication</param>
    /// <returns>Returns the medication added to the database</returns>
    /// <response code="400">Request body error</response>
    /// <response code="201">Successful completion of the request</response>
    [ProducesResponseType(typeof(MedicationModel), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("medications")]
    public IActionResult Create([FromBody] MedicationUpdateModel? medicationModel)
    {
        if (medicationModel is null) return BadRequest();

        MedicationModel medication = _storeService.Add(medicationModel);

        return Created($"medications/{medication.Id}", medication);
    }

    /// <summary>
    /// Get a list of all medications
    /// </summary>
    /// <returns>Returns a list of all medications in the database</returns>
    /// <response code="200">Successful completion of the request</response>
    [ProducesResponseType(typeof(List<MedicationModel>), StatusCodes.Status200OK)]
    [HttpGet("medications")]
    public IActionResult GetAll()
    {
        return Ok(_storeService.Store);
    }

    /// <summary>
    /// Returns the medication found by id
    /// </summary>
    /// <param name="id">Unique medication identifier</param>
    /// <returns>Returns the medication</returns>
    /// <response code="404">Medication not found by id</response>
    /// <response code="200">Successful completion of the request</response>
    [ProducesResponseType(typeof(MedicationModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("medications/{id}")]
    public IActionResult GetById(int id)
    {
        MedicationModel? medication = _storeService.Store.FirstOrDefault(med => med.Id.Equals(id));

        if (medication is null) return NotFound();

        return Ok(medication);
    }

    /// <summary>
    /// Updates medication information in the database
    /// </summary>
    /// <param name="id">Unique medication identifier</param>
    /// <param name="medicationModel">Data about medication</param>
    /// <response code="404">Medication not found by id</response>
    /// <response code="400">Request body error</response>
    /// <response code="200">Successful completion of the request</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("medications/{id}")]
    public IActionResult Update(int id, [FromBody] MedicationUpdateModel? medicationModel)
    {
        if (medicationModel is null) return BadRequest();

        MedicationModel? medication = _storeService.Store.FirstOrDefault(med => med.Id.Equals(id));
        if (medication is null) return NotFound();

        _storeService.Update(medicationModel, id);
        return Ok();
    }

    /// <summary>
    /// Removes a medication from the database
    /// </summary>
    /// <param name="id">Unique medication identifier</param>
    /// <response code="404">Medication not found by id</response>
    /// <response code="204">Successful completion of the request</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("medications/{id}")]
    public IActionResult Remove(int id)
    {
        MedicationModel? medication = _storeService.Store.FirstOrDefault(med => med.Id.Equals(id));
        if (medication is null) return NotFound();

        _storeService.Remove(medication);

        return NoContent();
    }
}