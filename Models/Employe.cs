using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace GestionMouvementCarte.Models

{
    public class Employe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Matricule { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }

      

        // Relation Many-to-Many avec CarteElectronique
        public virtual ICollection<CarteElectronique> CartesElectroniques { get; set; }
    }
}
