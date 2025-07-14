namespace si730ebuu20220659.Inventory.Domain.Model.ValueObjects;
//Establece que la información que se desea preservar de cada Thing
//operationMode (EOperationMode, obligatorio)
//EOperationMode es un enumeration que representa el modo de operación soportado por
//el dispositivo,
//teniendo como posibles valores:
//ScheduleDriven (0),
//TemperatureDriven (1)
//y HumidityDriven (2).

public enum  EOperationMode
{
    ScheduleDriven=0,
    TemperatureDriven=1,
    HumidityDriven=2
}