using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : IIdentifiable
    {
        private string model;

        private string id;

        private string birthdate;

        public Robot(string model, string id, string birthdate)
        {
            this.Model = model;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }

    }
}
