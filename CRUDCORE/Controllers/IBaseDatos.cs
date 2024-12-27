
using CRUDCORE.Models;

namespace CRUDCORE.Controllers
{
    public interface IBaseDatos
    {
        List<ContactoModel> Listar();
        ContactoModel Obtener(int IdContacto);
        bool Guardar(ContactoModel oContacto);
        bool Editar(ContactoModel oContacto);
        bool Eliminar(int IdContacto);
    }
}
