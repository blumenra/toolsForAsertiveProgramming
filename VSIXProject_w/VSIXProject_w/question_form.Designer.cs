namespace VSIXProject_w
{
    partial class question_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.NameBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TypeBox1 = new System.Windows.Forms.TextBox();
            this.button_more = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.pre_cond = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.post_cond = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.methodName = new System.Windows.Forms.TextBox();
            this.preCondName = new System.Windows.Forms.TextBox();
            this.postLemaName = new System.Windows.Forms.TextBox();
            this.lableLemaPre = new System.Windows.Forms.Label();
            this.lableLemaPost = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "To introduce local variable, please fill the fields below:";
            // 
            // NameBox1
            // 
            this.NameBox1.Location = new System.Drawing.Point(14, 179);
            this.NameBox1.Name = "NameBox1";
            this.NameBox1.Size = new System.Drawing.Size(60, 20);
            this.NameBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Type";
            // 
            // TypeBox1
            // 
            this.TypeBox1.Location = new System.Drawing.Point(92, 179);
            this.TypeBox1.Name = "TypeBox1";
            this.TypeBox1.Size = new System.Drawing.Size(67, 20);
            this.TypeBox1.TabIndex = 3;
            // 
            // button_more
            // 
            this.button_more.Location = new System.Drawing.Point(14, 216);
            this.button_more.Name = "button_more";
            this.button_more.Size = new System.Drawing.Size(49, 29);
            this.button_more.TabIndex = 9;
            this.button_more.Text = "More";
            this.button_more.UseVisualStyleBackColor = true;
            this.button_more.Click += new System.EventHandler(this.button_more_Click);
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(555, 31);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(72, 29);
            this.button_ok.TabIndex = 6;
            this.button_ok.Text = "Ok";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(555, 66);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(72, 29);
            this.button_cancel.TabIndex = 7;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(555, 101);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(72, 29);
            this.button_clear.TabIndex = 8;
            this.button_clear.Text = "Clean";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // pre_cond1
            // 
            this.pre_cond.Enabled = false;
            this.pre_cond.Location = new System.Drawing.Point(260, 63);
            this.pre_cond.Name = "pre_cond1";
            this.pre_cond.Size = new System.Drawing.Size(224, 20);
            this.pre_cond.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Pre Condition (optional):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(216, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Post Condition (optional):";
            // 
            // post_cond1
            // 
            this.post_cond.Enabled = false;
            this.post_cond.Location = new System.Drawing.Point(260, 179);
            this.post_cond.Name = "post_cond1";
            this.post_cond.Size = new System.Drawing.Size(224, 20);
            this.post_cond.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Variables:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(216, 66);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(219, 182);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 16;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Method Name:";
            // 
            // methodName
            // 
            this.methodName.Location = new System.Drawing.Point(13, 60);
            this.methodName.Name = "methodName";
            this.methodName.Size = new System.Drawing.Size(146, 20);
            this.methodName.TabIndex = 18;
            // 
            // preCondName
            // 
            this.preCondName.Enabled = false;
            this.preCondName.Location = new System.Drawing.Point(260, 101);
            this.preCondName.Name = "preCondName";
            this.preCondName.Size = new System.Drawing.Size(155, 20);
            this.preCondName.TabIndex = 19;
            // 
            // postLemaName
            // 
            this.postLemaName.Enabled = false;
            this.postLemaName.Location = new System.Drawing.Point(260, 221);
            this.postLemaName.Name = "postLemaName";
            this.postLemaName.Size = new System.Drawing.Size(155, 20);
            this.postLemaName.TabIndex = 20;
            // 
            // lableLemaPre
            // 
            this.lableLemaPre.AutoSize = true;
            this.lableLemaPre.Enabled = false;
            this.lableLemaPre.Location = new System.Drawing.Point(216, 86);
            this.lableLemaPre.Name = "lableLemaPre";
            this.lableLemaPre.Size = new System.Drawing.Size(67, 13);
            this.lableLemaPre.TabIndex = 21;
            this.lableLemaPre.Text = "Lema Name:";
            // 
            // lableLemaPost
            // 
            this.lableLemaPost.AutoSize = true;
            this.lableLemaPost.Enabled = false;
            this.lableLemaPost.Location = new System.Drawing.Point(216, 204);
            this.lableLemaPost.Name = "lableLemaPost";
            this.lableLemaPost.Size = new System.Drawing.Size(67, 13);
            this.lableLemaPost.TabIndex = 22;
            this.lableLemaPost.Text = "Lema Name:";
            // 
            // question_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 259);
            this.Controls.Add(this.lableLemaPost);
            this.Controls.Add(this.lableLemaPre);
            this.Controls.Add(this.postLemaName);
            this.Controls.Add(this.preCondName);
            this.Controls.Add(this.methodName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.post_cond);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pre_cond);
            this.Controls.Add(this.button_more);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.NameBox1);
            this.Controls.Add(this.TypeBox1);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "question_form";
            this.Text = "Introduce local variables";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TypeBox1;
        private System.Windows.Forms.Button button_more;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.TextBox pre_cond;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox post_cond;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox methodName;
        private System.Windows.Forms.TextBox preCondName;
        private System.Windows.Forms.TextBox postLemaName;
        private System.Windows.Forms.Label lableLemaPre;
        private System.Windows.Forms.Label lableLemaPost;
    }
}