using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSIXProject_w
{
    public class Variable
    {
        string name;
        string type;

        public Variable(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }

        public Variable(Variable var)
        {
            this.Name = var.Name;
            this.Type = var.Type;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }
    }
}
