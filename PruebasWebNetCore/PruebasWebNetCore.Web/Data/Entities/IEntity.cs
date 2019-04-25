
//esta interfaz debe estar implementada en todas las entitys asi se obliga a todas a implementar el Id
//se ponen los atributos que son persistentes en todas las entidades
namespace PruebasWebNetCore.Web.Data.Entities
{
    public interface IEntity
    {
        int Id { get; set; }
        
        //TODO: implementar los estados en las entidades
        //bool Estado { get; set; }

    }
}
