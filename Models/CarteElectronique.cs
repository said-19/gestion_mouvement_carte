using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GestionMouvementCarte.Models
{

    public class CarteElectronique
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string Reference { get; set; }
        public string Statut { get; set; }
        public string TypeMouvement { get; set; }
        public DateTime DateAjout { get; set; }
        public DateTime DerniereUtilisation { get; set; }

        // Relation Many-to-Many avec UniteDeProduction
        public virtual ICollection<UniteDeProduction> UnitesDeProduction { get; set; }
    }
}
