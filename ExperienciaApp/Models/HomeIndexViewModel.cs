namespace ExperienciaApp.Models {
    public class HomeIndexViewModel {
        public IEnumerable<Proyecto>? Proyectos { get; set; }
        public IEnumerable<Habilidad>? Habilidades { get; set; }
        public bool? Estatus { get; set; }
    }
}
