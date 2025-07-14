namespace si730ebuu20220659.Inventory.Domain.Model.ValueObjects;

//serialNumber es un identificador único que IRRIOT genera para sus
//dispositivos, el cual sirve para identificarlos en los inventarios.
//Internamente es un owned type con un valor UUID que debe generarse al
//momento de registrarse

public record SerialNumber (Guid Value)
{
    public SerialNumber(string value) : this(Guid.Parse(value))
    {
    }
}