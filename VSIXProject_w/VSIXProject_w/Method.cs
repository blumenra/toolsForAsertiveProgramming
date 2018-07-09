using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    public class Method : GeneralFunction
    {

        public Method() : base()
        { }

        public Method(GeneralFunction func) : base(func)
        { }

        public override string GenerateDecleration()
        {
            string ans = "";
            string tabs = "\t";


            List<Variable> args = new List<Variable>();
            foreach(Variable var in this.args)
            {
                if (hasRetValue(var))
                {
                    Variable arg = new Variable(var.Name + "0", var.Type);
                    args.Add(arg);

                }
                else
                    args.Add(new Variable(var.Name, var.Type));
            }
            
            //List<string> preConds = this.AppendPreConds(tabs);
            List<string> preCondsList = new List<string>();
            //string newPreConds = preConds;
            foreach (string pre in this.preConditions)
            {
                string tmpPreCond = pre;
                foreach (Variable arg in args)
                {
                    string name = arg.Name;
                    if (name[name.Length-1].Equals('0'))
                    {
                        string rawName = name.Substring(0, name.Length-1);
                        //string pattern = @"(^" + Regex.Escape(rawName) + @"\W) | (\W" + Regex.Escape(rawName) + @"\W)";
                        string pattern = @"^" + Regex.Escape(rawName) + @"\W";
                        foreach (Match m in Regex.Matches(tmpPreCond, pattern))
                        {

                            string tmp = tmpPreCond;
                            tmpPreCond = tmp.Substring(0, m.Index);
                            tmpPreCond += name;
                            tmpPreCond += tmp.Substring(m.Index+rawName.Length, tmp.Length - m.Index - rawName.Length);
                        }
                    }
                }
                foreach (Variable arg in args)
                {
                    string name = arg.Name;
                    if (name[name.Length - 1].Equals('0'))
                    {
                        string rawName = name.Substring(0, name.Length - 1);
                        string pattern = @"\W" + Regex.Escape(rawName) + @"\W";
                        //string pattern = @"^" + Regex.Escape(rawName) + @"\W";
                        foreach (Match m in Regex.Matches(tmpPreCond, pattern))
                        {

                            string tmp = tmpPreCond;
                            tmpPreCond = tmp.Substring(0, m.Index + 1);
                            tmpPreCond += name;
                            tmpPreCond += tmp.Substring(m.Index + 1 + rawName.Length, tmp.Length - m.Index - 1 - rawName.Length);
                        }
                    }
                }
                preCondsList.Add(tmpPreCond);
            }

            string preConds = this.AppendPreConds(preCondsList, tabs);

            ans += "method ";
            ans += this.name;
            ans += "(" + this.AppendArgs(args) + ")";
            ans += " returns";
            ans += "(" + this.AppendRetVals() + ")\n";

            ans += preConds;
            ans += this.AppendPostConds(tabs);

            //ans += "{\n";
            //ans += tabs + body;
            //ans += "\n";
            //ans += tabs + "// Implement here...\n";
            //ans += "}\n";

            return ans;
        }

        public string createAssignmentArgsToRet()
        {
            string ans = "";

            List<Variable> args = new List<Variable>();
            foreach (Variable arg in RetValues)
            {
                Variable var = new Variable(arg.Name + "0", arg.Type);
                if (hasArg(var))
                {
                    args.Add(var);
                }
            }
            string left = "";
            string right = "";
            foreach (Variable var in args)
            {
                left += var.Name.Substring(0, var.Name.Length-1) + ", ";
                right += var.Name + ", ";
            }

            if (left.Length > 2)
            {
                left = left.Substring(0, left.Length - 2);
                right = right.Substring(0, right.Length - 2);
                ans = left + " := " + right + ";\n";
            }

            return ans;
        }

        public string AppendRetVals()
        {
            return this.AppendArgs(this.retValues);
        }
    }
}
