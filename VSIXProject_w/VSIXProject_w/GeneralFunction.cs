using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSIXProject_w
{
    public abstract class GeneralFunction
    {
        protected string name;
        protected List<Variable> args;
        protected List<Variable> retValues;
        protected List<string> preConditions;
        protected List<string> postConditions;
        protected string body;

        public GeneralFunction()
        {
            initialize();
        }

        public GeneralFunction(GeneralFunction pMethod)
        {
            initialize();

            this.name = pMethod.Name;

            foreach (Variable arg in pMethod.Args)
                AddArgument(new Variable(arg));

            foreach (Variable ret in pMethod.RetValues)
                AddRetValue(new Variable(ret));

            foreach (string preCond in pMethod.PreConditions)
                AddPreCond(preCond);

            foreach (string postCond in pMethod.PostConditions)
                AddPostCond(postCond);

            pMethod.Body = this.body;
        }

        private void initialize()
        {
            this.name = "";
            this.args = new List<Variable>();
            this.retValues = new List<Variable>();
            this.preConditions = new List<string>();
            this.postConditions = new List<string>();
            this.body = "";
        }

        public void AddPreCond(string preCond)
        {
            List<string> vars = this.preConditions;
            if (!vars.Contains(preCond))
                vars.Add(preCond);
        }

        public void AddPostCond(string postCond)
        {
            List<string> vars = this.postConditions;
            if (!vars.Contains(postCond))
                vars.Add(postCond);
        }

        public void AddRetValue(Variable retValue)
        {
            List<Variable> vars = this.retValues;
            if (!vars.Contains(retValue))
            {
                vars.Add(retValue);
            }
        }

        public void AddArgument(Variable argument)
        {
            List<Variable> vars = this.args;
            if (!vars.Contains(argument))
                vars.Add(argument);
        }

        public string GenerateBody()
        {
            string ret = "";
            ret += "{\n";

            if (this. body.Length == 0)
                ret += "\n";

            ret += this.body;
            ret += "}\n";

            return ret;
        }

        public string GenerateFunctionCall()
        {
            string ans = "";

            ans += this.name;
            ans += "(";

            List<Variable> tmp = new List<Variable>();
            foreach (var arg in this.args)
            {
                if (arg.Name[arg.Name.Length - 1].Equals('0'))
                {
                    Variable var = new Variable(arg.Name.Substring(0, arg.Name.Length-1), arg.Type);
                    //if(this.hasRetValue(var))
                    tmp.Add(var);
                    ans += var.Name + ", ";
                    //else
                        //ans += arg.Name + ", ";

                }
                else
                {
                    tmp.Add(arg);
                    ans += arg.Name + ", ";
                }
            }
            this.args = tmp;

            // Chop last comma if necessary
            if (ans.Length > 1)
                ans = ans.Substring(0, ans.Length - 2);

            ans += ")";

            return ans;
        }

        public abstract string GenerateDecleration();

        protected string AppendArgs(List<Variable> arguments)
        {
            string ans = "";
            foreach (Variable arg in arguments)
            {
                ans += arg.Name + ": " + arg.Type + ", ";
            }

            // Chop last comma if necessary
            if (ans.Length > 0)
                ans = ans.Substring(0, ans.Length - 2);

            return ans;
        }

        protected string AppendPreConds(List<string> preConds, string indentation)
        {
            return this.AppendConds(indentation, "requires", preConds);
        }

        protected string AppendPostConds(string indentation)
        {
            return this.AppendConds(indentation, "ensures", this.postConditions);
        }

        protected string AppendConds(string indentation, string prefix, List<string> conds)
        {
            string ans = "";
            foreach (var cond in conds)
            {
                ans += indentation + prefix + " " + cond + "\n";
            }

            //// Chop last comma if necessary
            //if (ans.Length > 0)
            //    ans = ans.Substring(0, ans.Length - 1);

            return ans;
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

        public List<Variable> Args
        {
            get
            {
                return this.args;
            }
            set
            {
                args = value;
            }
        }

        public List<string> PreConditions
        {
            get
            {
                return this.preConditions;
            }
            set
            {
                preConditions = value;
            }
        }

        internal string GenerateCommaSeperatedArgsStr()
        {
            string vars = "";
            foreach (var arg in this.retValues)
            {
                vars += arg.Name + ", ";
            }
            // Chop last comma if necessary
            if (vars.Length > 0)
                vars = vars.Substring(0, vars.Length - 2);

            return vars;
        }

        public virtual List<Variable> RetValues
        {
            get
            {
                return this.retValues;
            }
            set
            {
                retValues = value;
            }
        }

        public List<string> PostConditions
        {
            get
            {
                return this.postConditions;
            }
            set
            {
                postConditions = value;
            }
        }

        public string Body
        {
            set
            {
                body = value;
            }
        }

        public string GenerateAssertionsFromPreConds()
        {
            return GenerateAssertionsFromConds(this.preConditions);
        }

        public string GenerateAssertionsFromPostConds()
        {
            return GenerateAssertionsFromConds(this.postConditions);
        }

        public bool hasPreCond(string preCond)
        {
            return this.preConditions.Contains(preCond);
        }

        public bool hasPostCond(string postCond)
        {
            return this.postConditions.Contains(postCond);
        }

        public bool hasRetValue(Variable retValue)
        {
            return containsVar(this.retValues, retValue);
        }

        public bool hasArg(Variable args)
        {
            return containsVar(this.args, args);
        }

        private bool containsVar(List<Variable> vars, Variable var)
        {
            foreach (var v in vars)
            {
                if (v.Name == var.Name && v.Type == var.Type)
                    return true;
            }

            return false;
        }

        private string GenerateAssertionsFromConds(List<string> conds)
        {
            string ans = "";

            foreach (var preCond in conds)
            {
                ans += "assert " + preCond + ";\n";
            }

            return ans;
        }

        public bool hasPostConds()
        {
            return this.postConditions.Count > 0;
        }

        public bool hasPreConds()
        {
            return this.preConditions.Count > 0;
        }

    }
}
