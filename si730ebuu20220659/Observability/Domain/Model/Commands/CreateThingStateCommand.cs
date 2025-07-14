namespace si730ebuu20220659.Observability.Domain.Model.Commands;

//Establece que la información de cada Thing State,
//incluye id (int, Primary Key, Autogenerado),
//thingSerialNumber (identificador del negocio, Obligatorio),
public record CreateThingStateCommand(string SerialNumber,int CurrentOperationMode,decimal CurrentTemperature,decimal CurrentHumidity, DateTime CollectedAt)
{
    
}