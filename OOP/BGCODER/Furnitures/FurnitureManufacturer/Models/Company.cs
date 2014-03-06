using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private readonly ICollection<IFurniture> furnitures;
        private const string RegistrationNumberValidationRegex = @"\d{10}";

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("name", "The name of the company cannot be null!");
                }

                if (value.Length < 5)
                {
                    throw new FormatException("The name of the company should be at least 5 symbols long!");
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
                if (Regex.IsMatch(value, RegistrationNumberValidationRegex))
                {
                    this.registrationNumber = value;
                }
                else
                {
                    throw new FormatException("The registration number should contain only digits and they must be exactly 10.");
                }
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get { return new List<IFurniture>(furnitures); }
        }

        public void Add(IFurniture furniture)
        {
            if (furniture != null)
            {
                this.furnitures.Add(furniture);
            }
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            return this.furnitures.FirstOrDefault(furniture => String.Equals(furniture.Model, model, StringComparison.InvariantCultureIgnoreCase));
        }

        public string Catalog()
        {
            var output = new StringBuilder();
            output.AppendLine(this.ToString());

            foreach (var furniturePiece in this.Furnitures.OrderBy(furniture => furniture.Price).ThenBy(furniture => furniture.Model))
            {
                output.AppendLine(furniturePiece.ToString());
            }
            return output.ToString().TrimEnd();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} {3}",
                this.Name,
                this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString(CultureInfo.InvariantCulture) : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture"
                );
        }
    }
}
