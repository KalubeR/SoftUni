using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Ferrari : ICar
    {
        private const string modelName = "488-Spider";

        private string driver;

        private string model;

        public Ferrari(string driver)
        {
            this.Driver = driver;
            this.Model = modelName;
        }

        public string Driver
        {
            get { return driver; }
            set { driver = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public string Brake()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Zadu6avam sA!";
        }
    }
}
