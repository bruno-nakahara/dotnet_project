﻿using System.ComponentModel.DataAnnotations;

namespace hikitocAPI.Models.Domain {
    public class Planet {
        [Key]
        public Guid PlanetId { get; set; }

        [StringLength(30)]
        public string Name { get; set; } = null!;

        [StringLength(1000)]
        public string Description { get; set; }
        public double DiameterKm {  get; set; }

        [StringLength(1000)]
        public string? Image {  get; set; }
        public Guid SolarSystemId { get; set; }
        public Guid WaterId { get; set; }
        public SolarSystem SolarSystem { get; set; }
        public Water Water { get; set; }

    }
}
