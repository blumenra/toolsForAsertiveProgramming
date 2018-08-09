using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace VSIXProject_w
{
    public partial class question_form : Form
    {
        TextBox prevtxtBox1;
        TextBox prevtxtBox2;
        int index ;
        DafnyCodeParser p;
        TextSelection toInsert;

        public question_form()
        {
            InitializeComponent();
            prevtxtBox1 = this.NameBox1;
            prevtxtBox2 = this.TypeBox1;
            index = 1;
            p = new DafnyCodeParser();
           

        }

        public DialogResult ShowDialog()
        {
            TextDocument activeDoc = null;
            DTE dte = null;

            try
            {
                dte = Package.GetGlobalService(typeof(DTE)) as DTE;
                activeDoc = dte.ActiveDocument.Object() as TextDocument;
            }
            catch
            {
                MessageBox.Show("Please open a Dafny file befor using the aplication.", "File not open", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //this.Close();
                return DialogResult.Abort;

            }

            //get position 
            var cursPoint = activeDoc.Selection.ActivePoint;

            // to insert
            toInsert = (EnvDTE.TextSelection)(activeDoc.Selection);

            //get all text
            var text = activeDoc.CreateEditPoint(activeDoc.StartPoint).GetText(activeDoc.EndPoint);

            // get input to spesific class
            // get input
            string name = get_method_name(text, cursPoint);
            if (name == String.Empty)
            {
                MessageBox.Show("Method not found.", "Method not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // this.Close();
                return DialogResult.Abort;
            }
            label1.Text = "To introduce local variable for the method \"" + name + "\", please fill the fields below:";
            try
            {
                //parsing
                p.parse_file(dte.ActiveDocument.FullName, name);
               
                //adding pre conditions
                List<String> precond = p.get_req();
                this.pre_lable.Text = string.Join("\n", precond);
                this.pre_cond.Location = new Point(this.pre_cond.Location.X, this.pre_cond.Location.Y + 10 * precond.Count);
                this.lableLemaPre.Location = new Point(this.lableLemaPre.Location.X, this.lableLemaPre.Location.Y + 10 * precond.Count);
                this.preCondName.Location = new Point(this.preCondName.Location.X, this.preCondName.Location.Y + 10 * precond.Count);

                //adding post conditions
                List<String> postcond = p.get_ens();
                this.post_lable.Text = string.Join("\n", postcond);
                this.post_cond.Location = new Point(this.post_cond.Location.X, this.post_cond.Location.Y + 10 * postcond.Count + 10 * precond.Count);
                this.postLemaName.Location = new Point(this.postLemaName.Location.X, this.postLemaName.Location.Y + 10 * postcond.Count + 10 * precond.Count);
                this.lableLemaPost.Location = new Point(this.lableLemaPost.Location.X, this.lableLemaPost.Location.Y + 10 * postcond.Count + 10 * precond.Count);
                this.checkBox2.Location = new Point(this.checkBox2.Location.X, this.checkBox2.Location.Y  + 10 * precond.Count);
                this.label5.Location = new Point(this.label5.Location.X, this.label5.Location.Y + 10 * precond.Count);
                this.post_lable.Location = new Point(this.label5.Location.X, this.label5.Location.Y + 10 * precond.Count);


                this.Height += 10 * postcond.Count + 10 *precond.Count;
            }
            catch
            {
                MessageBox.Show("Error parsing Dafny.", "Error parsing Dafny.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // this.Close();
                return DialogResult.Abort;
            }
            return base.ShowDialog();
        }

        private void button_more_Click(object sender, EventArgs e)
        {
            index++;
            TextBox txtBox1, txtBox2;
            txtBox1 = new TextBox();
            txtBox2 = new TextBox();

            this.button_more.Location = new Point(this.button_more.Location.X, this.button_more.Location.Y + 25);

            txtBox1.Size = prevtxtBox1.Size;
            txtBox1.Location = new Point(this.prevtxtBox1.Location.X, this.prevtxtBox1.Location.Y + 25);
            txtBox1.Visible = true;
            txtBox1.Name = "NameBox" + index;
            Controls.Add(txtBox1);
            prevtxtBox1 = txtBox1;

            txtBox2.Size = prevtxtBox2.Size;
            txtBox2.Location = new Point(this.prevtxtBox2.Location.X, this.prevtxtBox2.Location.Y + 25);
            txtBox2.Visible = true;
            txtBox2.Name = "TypeBox" + index;
            Controls.Add(txtBox2);
            prevtxtBox2 = txtBox2;

            this.Height += 25;
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).Text = String.Empty;
                }
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            try
            {
                assertiveToolDS dafnyCreate = new assertiveToolDS();
            
                dafnyCreate.Name = p.currentMethod.FullName;

                if (this.methodName.Text == string.Empty)
                {
                    MessageBox.Show("Please enter Method Name.", "Empty input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                dafnyCreate.NewMethod.Name = this.methodName.Text;
                //Add var names and types
                bool isFound = false;
           for (int i =1; i<=this.index;i++)
            {
                string t = String.Empty;
                string n = String.Empty;

                foreach (Control x in this.Controls)
                {
                    if (x is TextBox && x.Name.StartsWith("NameBox" + i))
                    {
                        n = x.Text;
                    }
                    if (x is TextBox && x.Name.StartsWith("TypeBox" + i))
                    {
                        t = x.Text;
                    }
                    if (n != String.Empty && t != String.Empty)
                        break;
                }
                    if (n == String.Empty)
                        continue;
                    else
                    {
                        isFound = true;
                        Variable newVar = new Variable(n, t);
                        dafnyCreate.AddLoclVar(newVar);
                    }
            }
           if(!isFound)
                {
                    MessageBox.Show("Please enter at least one variable and type.", "Empty input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                if (this.pre_cond.Enabled)
                {
                    if (pre_cond.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter preCondition.", "Empty input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (preCondName.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter Lema name.", "Empty input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    dafnyCreate.weakenPreCond(pre_cond.Text);
                    dafnyCreate.WeakLemma.Name = this.preCondName.Text;
                }

                if (this.post_cond.Enabled)
                {
                    if (post_cond.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter preCondition.", "Empty input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (postLemaName.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter Lema name.", "Empty input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    dafnyCreate.strengthenPostCond(post_cond.Text);
                    dafnyCreate.StrengthLemma.Name = this.postLemaName.Text;
                }
                
                // Add parser
                try
                {
               //     DafnyCodeParser p = new DafnyCodeParser();
                //    p.parse_file(dte.ActiveDocument.FullName, dafnyCreate.Name);

                    //vars:
                    List<String> varNames = p.get_var_names();
                    List<String> varTypes = p.get_var_types();
                    for (int i = 0; i < varNames.Count; i++)
                    {
                        Variable arg1 = new Variable(varNames[i], varTypes[i]);
                        dafnyCreate.AddArgument(arg1);
                    }

                    //ret:
                    List<String> retNames = p.get_ret_names();
                    List<String> retTypes = p.get_ret_types();
                    for (int i = 0; i < retNames.Count; i++)
                    {
                        Variable arg1 = new Variable(retNames[i], retTypes[i]);
                        dafnyCreate.AddRetValue(arg1);
                    }

                    //precond
                    List<String> precond = p.get_req();
                    for (int i = 0; i < precond.Count; i++)
                    {
                        dafnyCreate.AddPreCond(precond[i]);
                    }

                    //post
                    List<String> postcond = p.get_ens();
                    for (int i = 0; i < postcond.Count; i++)
                    {
                        dafnyCreate.AddPostCond(postcond[i]);
                    }
                }
                catch
                {
                    MessageBox.Show("Error in parsing the file.", "Parser Exeption", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }

                // insert text
                string pre_and_post = String.Empty;
                if (pre_cond.Enabled)
                    pre_and_post += "\n\n" + dafnyCreate.generateWeakLemma();
                if (post_cond.Enabled)
                    pre_and_post += "\n\n" + dafnyCreate.generateStrengthLemma();

                toInsert.Insert("\n{\n" + dafnyCreate.generateBody() + "}\n\n" + dafnyCreate.generateMethod() + pre_and_post + "\n");
        


            this.Close();

            }
            catch
            {
                MessageBox.Show("Unexpected Exeption occurred during the execution.", "Unexpected Exeption", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;

            }
        }
        
        private string get_method_name(string text, VirtualPoint cursPoint)
        {
            // Match the regular expression pattern against a text string.
            string pat = @"method\s+(.+?)\s*\(";
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            string methodName = string.Empty;

            Match m = r.Match(text);         

            while (m.Success)
            {
                if (m.Index > cursPoint.AbsoluteCharOffset)
                    break;

                Group g = m.Groups[1];
                //  CaptureCollection cc = g.Captures;
                CaptureCollection cc = g.Captures;
                methodName = cc[0].ToString();

                m = m.NextMatch();
            }
            return methodName;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.pre_cond.Enabled = true;
                this.lableLemaPre.Enabled = true;
                this.preCondName.Enabled = true;
                this.pre_lable.Enabled = true;

            }
            else
            {
                this.pre_cond.Enabled = false;
                this.lableLemaPre.Enabled = false;
                this.preCondName.Enabled = false;
                this.pre_lable.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked)
            {
                this.post_cond.Enabled = true;
                this.lableLemaPost.Enabled = true;
                this.postLemaName.Enabled = true;
                this.post_lable.Enabled = true;
            }

            else
            {
                this.post_cond.Enabled = false;
                this.lableLemaPost.Enabled = false;
                this.postLemaName.Enabled = false;
                this.post_lable.Enabled = false;
            }
        }

    
       
    }

}
