namespace RepasoApp.Models
{
    public class TipoEmpleoViewModel : TipoEmpleo
    {
        public IEnumerable<TipoEmpleo>? TipoEmpleos { get; set; }
    }
}