namespace Cars.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class City
    {
        private ICollection<Dealer> dealers;

        private ICollection<Manufacturer> manufacturers;

        public City()
        {
            this.dealers = new HashSet<Dealer>();
            this.manufacturers = new HashSet<Manufacturer>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        [Index("Name", IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Manufacturer> Manufacturers
        {
            get
            {
                return this.manufacturers;
            }
            set
            {
                this.manufacturers = value;
            }
        }

        public virtual ICollection<Dealer> Dealers
        {
            get
            {
                return this.dealers;
            }

            set
            {
                this.dealers = value;
            }
        }
    }
}
