using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Announcement
    {
        public Announcement() { }
        public Announcement(string make, string model, string version, int year, int mileage, string note)
        {
            Make = make;
            Model = model;
            Version = version;
            Year = year;
            Mileage = mileage;
            Note = note;
        }

        public int Id { get; private set; }
        public string Make { get; private set; }
        public string Model { get; private set; }
        public string Version { get; private set; }
        public int Year { get; private set; }
        public int Mileage { get; private set; }
        public string Note { get; private set; }

        public Announcement Update(string make, string model, string version, int year, int mileage, string note)
        {

            this.Make = make;
            this.Model = model;
            this.Version = version;
            this.Year = year;
            this.Mileage = mileage;
            this.Note = note;

            return this;
        }
    }
}
