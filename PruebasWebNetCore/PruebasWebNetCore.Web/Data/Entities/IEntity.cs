namespace PruebasWebNetCore.Web.Data.Entities
{
    //TODO: se puede agregar el atributo de estado para desactivarlo en la base de datos
    public interface IEntity
    {
        int Id { get; set; }
    }
}
