namespace PetClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Procedure
    {
        public int Id { get; set; }

        public int AnimalId { get; set; }

        [Required]
        public Animal Animal { get; set; }

        public int VetId { get; set; }

        [Required]
        public Vet Vet { get; set; }

        public ICollection<ProcedureAnimalAid> ProcedureAnimalAids { get; set; }

        [NotMapped]
        public decimal Cost { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
    }
}
