namespace RepasoApp.Models
{
    public class ContactoViewModel : Contacto
    {
        public IEnumerable<Contacto>? Contactos { get; set; }
        public int AbrirModel {get; set;} = 0;
    }
}