using si730ebuu20220659.Inventory.Domain.Model.Commands;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using si730ebuu20220659.Inventory.Domain.Model.ValueObjects;

namespace si730ebuu20220659.Inventory.Domain.Model.Aggregates;

public partial class Thing {
    
    [Required]
    public int Id { get; set; }
    
    [Required]
    public SerialNumber SerialNumberValObj { get; set; }

    public string SerialNumber => SerialNumberValObj.Value.ToString();
    
    //(string,Obligatorio, no vacío)
    [Required]
    [NotNull]
    public string Model { get; set; }
    
    [Required] 
    public EOperationMode OperationModeEnum { get; set; }
    public string OperationMode => OperationModeEnum.ToString();
    
    // Requiere que los valores válidos para
    // maximumTemperatureThreshold solo sean decimales entre -40.00
    // y 85.00.
    
    [Required]
    [Range(-40.00, 85.00)]
    public decimal MaximumTemperatureThreshold { get; set; }
    
    //Requiere que los valores válidos para minimumHumidityThreshold
    //solo sean decimales entre 0.00 y 100.00
    [Required]
    [Range(0.00, 100.00)]
    public decimal MinimumHumidityThreshold { get; set; }
    
    public Thing(){}

    public Thing(CreateThingCommand command)
    {
        SerialNumberValObj = new SerialNumber(command.SerialNumber);
        Model = command.Model;
        MaximumTemperatureThreshold = command.MaximumTemperatureThreshold;
        MinimumHumidityThreshold = command.MinimumHumidityThreshold;
    }
    
    
}