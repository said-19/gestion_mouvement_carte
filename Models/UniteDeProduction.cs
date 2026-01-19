using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GestionMouvementCarte.Models
{
    public class UniteDeProduction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Nom { get; set; }
        public string NomResponsable { get; set; }

        // Relation Many-to-Many avec CarteElectronique
        public virtual ICollection<CarteElectronique> CartesElectroniques { get; set; }
    }
}