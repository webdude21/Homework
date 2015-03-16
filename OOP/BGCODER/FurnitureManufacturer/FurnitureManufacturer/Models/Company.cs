using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    using System.Text.RegularExpressions;

    using FurnitureManufacturer.Interfaces;

    class Company : ICompany
    {
        private string name;

        private string registrationNumber;

        private ICollection<IFurniture> furnitures;

        public Company(string companyName, string registrationNumber)
        {
            this.Name = companyName;
            this.RegistrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
        }

        private const int MinimumAllowedSymbols = 5;

        private const string RegistrationNumberValidationRegex = @"\d{10}";

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinimumAllowedSymbols)
                {
                    throw new ArgumentException(string.Format("Name cannot be empty, null or with less than {0} symbols.", MinimumAllowedSymbols));
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }
            private set
            {
                if (!Regex.IsMatch(value, RegistrationNumberValidationRegex))
                {
                    throw new FormatException("The registration number should contain only digits and they must be exactly 10.");

                }

                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return new List<IFurniture>(this.furnitures);
            }
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            return this.furnitures.FirstOrDefault(x => x.Model.ToLowerInvariant().Equals(model.ToLowerInvariant()));
        }

        public string Catalog()
        {
            var companyInfo = string.Format(
                "{0} - {1} - {2} {3}",
                this.Name,
                this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture");

            if (this.furnitures.Count != 0)
            {
                return companyInfo + Environment.NewLine + string.Join(Environment.NewLine, this.furnitures.OrderBy(x => x.Price).ThenBy(x => x.Model));
            }

            return companyInfo;
        }
    }
}
