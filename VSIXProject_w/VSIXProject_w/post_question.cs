﻿using System;
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
    public partial class post_question : Form
    {
        TextBox prevtxtBox1;
        int index;
        DafnyCodeParser p;
        TextSelection toInsert;

        public post_question()
        {
            InitializeComponent();
            prevtxtBox1 = this.post_cond1;
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
            label1.Text = "Please insert the postcondition and lemma name for the method \"" + name + "\" :";
            try
            {
                p.parse_file(dte.ActiveDocument.FullName, name);


                List<String> postcond = p.get_ens();
                this.post_lable.Text = string.Join("\n", postcond);
                this.post_cond1.Location = new Point(this.post_cond1.Location.X, this.post_cond1.Location.Y + 10 * postcond.Count);
                this.button_more.Location = new Point(this.button_more.Location.X, this.button_more.Location.Y + 10 * postcond.Count);
                this.Height += 10 * postcond.Count;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Exception caught during parsing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // this.Close();
                return DialogResult.Abort;
            }
            return base.ShowDialog();
        }


        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button_ok_Click(object sender, EventArgs e)
        {
            try
            { 
                assertiveToolDS dafnyCreate = new assertiveToolDS();
                dafnyCreate.Name = p.currentMethod.FullName;

            //validation:
            if (this.methodName.Text == string.Empty)
                {
                    MessageBox.Show("Please enter Method Name.", "Empty input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (postLemaName.Text == string.Empty)
                {
                    MessageBox.Show("Please enter Lema name.", "Empty input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                bool isFound = false;
                foreach (Control x in this.Controls)
                {
                    if (x is TextBox && x.Name.StartsWith("post_cond") && x.Text != String.Empty)
                    {
                        isFound = true;
                        dafnyCreate.strengthenPostCond(x.Text);
                    }
                }

                if (!isFound)
                {
                    MessageBox.Show("Please enter at least one postCondition.", "Empty input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // add the new pre_condition and method
                
                dafnyCreate.StrengthLemma.Name = this.postLemaName.Text;
                dafnyCreate.NewMethod.Name = this.methodName.Text;

                try
                {
                    

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
                    //postcond
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
                toInsert.Insert("{\n" + dafnyCreate.generateBody() + "}\n\n" + dafnyCreate.generateMethod() + "\n\n" + dafnyCreate.generateStrengthLemma() + "\n\n");


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

        private void button_more_Click(object sender, EventArgs e)
        {
            add_posl_lable();
        }

        private void add_posl_lable()
        {
            index++;
            TextBox txtBox1;
            txtBox1 = new TextBox();

            this.button_more.Location = new Point(this.button_more.Location.X, this.button_more.Location.Y + 25);

            txtBox1.Size = prevtxtBox1.Size;
            txtBox1.Location = new Point(this.prevtxtBox1.Location.X, this.prevtxtBox1.Location.Y + 25);
            txtBox1.Visible = true;
            txtBox1.Name = "post_cond" + index;
            Controls.Add(txtBox1);
            prevtxtBox1 = txtBox1;
            this.Height += 25;
        }
    }
}
