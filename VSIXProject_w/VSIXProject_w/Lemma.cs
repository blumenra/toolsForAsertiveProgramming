using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSIXProject_w
{
    public class Lemma : GeneralFunction
    {

        public Lemma() : base()
        { }

        public Lemma(GeneralFunction func) : base(func)
        { }

        public override string GenerateDecleration()
        {
            string ans = "";

            ans += "lemma ";
            ans += this.name;
            ans += "(" + this.AppendArgs(this.args) + ")\n";
            string tabs = "\t";

            ans += this.AppendPreConds(this.preConditions, tabs);
            ans += this.AppendPostConds(tabs);

            return ans;
        }

        /*
         * Prevent from setting return values of a lemma (because it doesnt have ones)
         */
        public override List<Variable> RetValues
        {
            set
            {
                ;
            }
        }
    }
}


