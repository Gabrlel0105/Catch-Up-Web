namespace si730ebuu20220659.Observability.Domain.Model.Aggregates;
using si730ebuu20220659.Observability.Domain.Model.Commands;
using si730ebuu20220659.Inventory.Domain.Model.ValueObjects;
using System.ComponentModel.DataAnnotations;

public partial class ThingState
{

    // cada Thing State, incluye id (int, Primary Key, Autogenerado)
    [Required]
    public int Id { get; set; }

    // thingSerialNumber (identificador del negocio, Obligatorio)
    [Required] 
    public SerialNumber ThingSerialNumber { get; set; }
    public string SerialNumber => ThingSerialNumber.Value.ToString();

    //Requiere que los valores válidos para currentOperationMode solo
    //sean enteros entre 0 y 2
    [Required]
    [Range(0,2)]
    public int CurrentOperationMode { get; set; }
    
    [Required]
    public decimal CurrentTemperature { get; set; }
    
    [Required]
    public decimal CurrentHumidity { get; set; }
    
    [Required]
    public DateTime CollectedAt { get; set; }
    
    public  ThingState(){}

    public ThingState(CreateThingStateCommand command)
    {
        ThingSerialNumber = new SerialNumber(command.SerialNumber);
        CurrentOperationMode = command.CurrentOperationMode;
        CurrentTemperature = command.CurrentTemperature;
        CurrentHumidity = command.CurrentHumidity;
        CollectedAt = command.CollectedAt;
    }
    
}