namespace si730ebuu20220659.Observability.Domain.Model.Aggregates;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;


//Especifica que tanto Thing como Thing State son Aggregate Roots
//en sus respectivos bounded contexts, 
//por lo que se requiere contar con atributos de auditoría para registrar createdAt
//(fecha y hora de creación
//de registro) y updatedAt (fecha y hora de última actualización de registro),
//de uso interno y poblados de
//forma automática por el sistema al momento de las operaciones de creación o actualización.


public partial class ThingState:IEntityWithCreatedUpdatedDate
{
    public DateTimeOffset? CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
}