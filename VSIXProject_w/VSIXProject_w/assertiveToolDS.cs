using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSIXProject_w
{
    public class assertiveToolDS
    {
        private Method pMethod;
        private Method newMethod;
        private List<Variable> localVars;
        private Lemma strengthLemma;
        private Lemma weakLemma;
        private List<string> strengthedPostConds;
        private List<string> weakednedPreConds;

        public assertiveToolDS()
        {
            this.pMethod = new Method();
            this.newMethod = new Method();
            this.localVars = new List<Variable>();
            this.strengthLemma = new Lemma();
            this.weakLemma = new Lemma();
            this.strengthedPostConds = new List<string>();
            this.weakednedPreConds = new List<string>();
        }

        public string generateStrengthLemma()
        {
            if (!this.HasStrengthenedPostConds())
                return "";

            Lemma tmp = new Lemma(this.strengthLemma);

            foreach (string preCond in this.strengthedPostConds)
                tmp.AddPreCond(preCond);

            foreach (string postCond in this.pMethod.PostConditions)
                tmp.AddPostCond(postCond);

            return tmp.GenerateDecleration();
        }

        public string generateWeakLemma()
        {
            if (!this.HasWeakenedPreConds())
                return "";

            Lemma tmp = new Lemma(this.weakLemma);

            foreach (string preCond in this.pMethod.PreConditions)
                tmp.AddPreCond(preCond);

            foreach (string postCond in this.weakednedPreConds)
                tmp.AddPostCond(postCond);

            return tmp.GenerateDecleration();
        }

        // For debugging
        public string generatePMethod()
        {
            return pMethod.GenerateDecleration();
        }

        public string generateMethod()
        {
            Method tmp = new Method(this.newMethod);
            List<string> preConds;
            List<string> postConds;

            /*
             * Copy pre-conditions either from pMethod or weakned pre-conditions
             */
            if (this.HasWeakenedPreConds())
                preConds = this.weakednedPreConds;
            else
                preConds = this.pMethod.PreConditions;

            foreach (string preCond in preConds)
                    tmp.AddPreCond(preCond);

            /*
             * Copy post-conditions either from pMethod or strengthed post-conditions
             */
            if (this.HasStrengthenedPostConds())
                postConds = this.strengthedPostConds;
            else
                postConds = this.pMethod.PostConditions;

            foreach (string preCond in postConds)
                tmp.AddPostCond(preCond);

            /*
             * assign method parameters to variables without 0 at the end
             */
            tmp.Body = tmp.createAssignmentArgsToRet();


            return tmp.GenerateDecleration();
        }

        public void AddPreCond(string preCond)
        {
            if (this.pMethod.hasPreCond(preCond))
                return;

            this.weakLemma.AddPreCond(preCond);
            this.pMethod.AddPreCond(preCond);
        }

        public void AddPostCond(string postCond)
        {
            if (this.pMethod.hasPostCond(postCond))
                return;

            this.strengthLemma.AddPostCond(postCond);
            this.pMethod.AddPostCond(postCond);
        }

        public void AddRetValue(Variable retValue)
        {
            if (this.pMethod.hasRetValue(retValue))
                return;

            if (!this.pMethod.hasRetValue(retValue))
                this.pMethod.AddRetValue(retValue);

            if (!this.newMethod.hasRetValue(retValue))
                this.newMethod.AddRetValue(retValue);

            Variable var = new Variable(retValue.Name + "0", retValue.Type);
            
            if (!this.strengthLemma.hasArg(var) && !this.strengthLemma.hasArg(retValue))
                this.strengthLemma.AddArgument(retValue);

            if (!this.weakLemma.hasArg(var) && !this.weakLemma.hasArg(retValue))
                this.weakLemma.AddArgument(retValue);
        }

        public void AddArgument(Variable argument)
        {
            if (this.pMethod.hasArg(argument))
                return;

            if (!this.pMethod.hasArg(argument))
                this.pMethod.AddArgument(argument);

            Variable var = argument;
            if (argument.Name[argument.Name.Length - 1].Equals("0"))
            {
                var = new Variable(argument.Name.Substring(0, argument.Name.Length-2), argument.Type);
            }
            if (!this.newMethod.hasArg(var))
                this.newMethod.AddArgument(var);

            if(!this.strengthLemma.hasArg(var))
                this.strengthLemma.AddArgument(var);

            if (!this.weakLemma.hasArg(var))
                this.weakLemma.AddArgument(var);
        }

        public void AddLoclVar(Variable var)
        {
            if (containsVar(this.localVars, var))
                return;

            if (!this.localVars.Contains(var))
                this.localVars.Add(var);

            if (!this.newMethod.hasRetValue(var))
                this.newMethod.AddRetValue(var);

            if (!this.strengthLemma.hasArg(var))
                this.strengthLemma.AddArgument(var);

            if (!this.weakLemma.hasArg(var))
                this.weakLemma.AddArgument(var);
        }

        private bool containsVar(List<Variable> vars, Variable var)
        {
            foreach(var v in vars)
            {
                if (v.Name == var.Name)
                    return true;
            }

            return false;
        }

        public void strengthenPostCond(string postCond)
        {
            this.strengthedPostConds.Add(postCond);
        }

        public void weakenPreCond(string preCond)
        {
            this.weakednedPreConds.Add(preCond);
        }

        public GeneralFunction NewMethod
        {
            get
            {
                return newMethod;
            }
        }

        public List<Variable> LocalVars
        {
            get
            {
                return localVars;
            }

            set
            {
                localVars = value;
            }
        }

        public GeneralFunction StrengthLemma
        {
            get
            {
                return strengthLemma;
            }
        }

        public GeneralFunction WeakLemma
        {
            get
            {
                return weakLemma;
            }
        }

        public string Name
        {
            get
            {
                return this.pMethod.Name;
            }

            set
            {
                this.pMethod.Name = value;
            }
        }

        public bool HasWeakenedPreConds()
        {
            return this.weakednedPreConds.Count > 0;
        }

        public bool HasStrengthenedPostConds()
        {
            return this.strengthedPostConds.Count > 0;
        }

        public string generateBody()
        {
            String body = "";


            Method tmpMethod = new Method(this.newMethod);

            string assign = tmpMethod.createAssignmentArgsToRet();
            body += assign;

            foreach (var v in this.localVars)
            {
                body += createNewDeclaration(v);
            }

            if(assign.Length > 0)
            {
                List<string> tmp_preConds = new List<string>();
                foreach(string preCond in this.pMethod.PreConditions)
                {
                    string s = preCond;
                    foreach (Variable arg in this.pMethod.Args)
                    {
                        if (arg.Name[arg.Name.Length - 1].Equals('0'))
                        {
                            Variable tmp = new Variable(arg.Name.Substring(0, arg.Name.Length-1), arg.Type);
                            s = s.Replace(arg.Name, tmp.Name);
                        }
                    }
                    tmp_preConds.Add(s);
                }
                this.pMethod.PreConditions = tmp_preConds;
                this.WeakLemma.PreConditions = new List<string>(tmp_preConds);
            }
            body += this.pMethod.GenerateAssertionsFromPreConds();

            if (this.HasWeakenedPreConds())
            {
                body += this.weakLemma.GenerateFunctionCall();
                body += ";\n";

                foreach(var cond in this.weakednedPreConds)
                    tmpMethod.AddPreCond(cond);

                body += tmpMethod.GenerateAssertionsFromPreConds();
            }
            else
            {
                foreach (var cond in this.pMethod.PreConditions)
                    tmpMethod.AddPreCond(cond);
            }

            string value = tmpMethod.GenerateFunctionCall();
            string vars = tmpMethod.GenerateCommaSeperatedArgsStr();
            body += GenerateAssignment(vars, value);

            if (this.HasStrengthenedPostConds())
            {
                foreach (var cond in this.strengthedPostConds) {
                    tmpMethod.AddPostCond(cond);
                    this.strengthLemma.AddPreCond(cond);
                }

                body += tmpMethod.GenerateAssertionsFromPostConds();

                body += this.strengthLemma.GenerateFunctionCall();
                body += ";\n";

            }
            else
            {
                foreach (var cond in this.pMethod.PostConditions)
                    tmpMethod.AddPostCond(cond);
            }

            body += this.pMethod.GenerateAssertionsFromPostConds();

            return body;
        }

        private string GenerateAssignment(string vars, string values)
        {
            return vars + " := " + values + ";\n";
        }

        private string createNewDeclaration(Variable var)
        {
            string ans = "var " + var.Name + " : " + var.Type + ";\n";
            return ans;
        }

    }
    
}


//method MinAndMax'(q: seq<int>) returns (min: int, max: int)
//	requires 0 < |q|
//	ensures MinElement(min, q)

//    ensures MaxElement(max, q)
//{
//    // Design: iterate up, keeping 
//    // 0 < i <= |q| && MinElement(min, q[..i]) && MaxElement(max, q[..i]) invariant.

//    // Step 1: introduce local variable + strengthen postcond.
//    var i: nat;
//    assert 0 < | q |;
//    min, max, i:= MM1(q);
//    assert Inv(q, i, min, max) && i == | q |;
//    L1(q, i, min, max);
//    assert MinElement(min, q);
//    assert MaxElement(max, q);
//}