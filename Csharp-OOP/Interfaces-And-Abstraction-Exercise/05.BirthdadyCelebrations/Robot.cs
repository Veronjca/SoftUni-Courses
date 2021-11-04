using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection.Metadata;

namespace PersonInfo
{
    public class Robot : IIdentifiable
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Model { get; private set; }
        public string Id { get; set; }
    }
}
