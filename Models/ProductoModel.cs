
namespace ConexionEF.Models
{
    public class ProductoModel
    {
        public ProductoModel()
        {
        }

        public Guid Id {get;set;}
     
        public string Nombre {get;set;}
        
        public string Descripcion {get;set;}
    }
}