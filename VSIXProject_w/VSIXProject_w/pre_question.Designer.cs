namespace VSIXProject_w
{
    partial class pre_question
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
            this.button_clear = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lableLemaPre = new System.Windows.Forms.Label();
            this.preCondName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pre_cond1 = new System.Windows.Forms.TextBox();
            this.methodName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button_more = new System.Windows.Forms.Button();
            this.pre_lable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(312, 113);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(72, 29);
            this.button_clear.TabIndex = 11;
            this.button_clear.Text = "Clean";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(312, 78);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(72, 29);
            this.button_cancel.TabIndex = 10;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(312, 43);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(72, 29);
            this.button_ok.TabIndex = 9;
            this.button_ok.Text = "Ok";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Please insert the precondition and lemma name:";
            // 
            // lableLemaPre
            // 
            this.lableLemaPre.AutoSize = true;
            this.lableLemaPre.Location = new System.Drawing.Point(8, 80);
            this.lableLemaPre.Name = "lableLemaPre";
            this.lableLemaPre.Size = new System.Drawing.Size(67, 13);
            this.lableLemaPre.TabIndex = 26;
            this.lableLemaPre.Text = "Lema Name:";
            // 
            // preCondName
            // 
            this.preCondName.Location = new System.Drawing.Point(52, 95);
            this.preCondName.Name = "preCondName";
            this.preCondName.Size = new System.Drawing.Size(224, 20);
            this.preCondName.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Pre Conditions:";
            // 
            // pre_cond1
            // 
            this.pre_cond1.Location = new System.Drawing.Point(52, 151);
            this.pre_cond1.Name = "pre_cond1";
            this.pre_cond1.Size = new System.Drawing.Size(224, 20);
            this.pre_cond1.TabIndex = 22;
            // 
            // methodName
            // 
            this.methodName.Location = new System.Drawing.Point(52, 59);
            this.methodName.Name = "methodName";
            this.methodName.Size = new System.Drawing.Size(225, 20);
            this.methodName.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Method Name:";
            // 
            // button_more
            // 
            this.button_more.Location = new System.Drawing.Point(52, 177);
            this.button_more.Name = "button_more";
            this.button_more.Size = new System.Drawing.Size(49, 29);
            this.button_more.TabIndex = 29;
            this.button_more.Text = "More";
            this.button_more.UseVisualStyleBackColor = true;
            this.button_more.Click += new System.EventHandler(this.button_more_Click);
            // 
            // pre_lable
            // 
            this.pre_lable.AutoSize = true;
            this.pre_lable.Location = new System.Drawing.Point(54, 135);
            this.pre_lable.Name = "pre_lable";
            this.pre_lable.Size = new System.Drawing.Size(0, 13);
            this.pre_lable.TabIndex = 30;
            // 
            // pre_question
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 215);
            this.Controls.Add(this.pre_lable);
            this.Controls.Add(this.button_more);
            this.Controls.Add(this.methodName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lableLemaPre);
            this.Controls.Add(this.preCondName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pre_cond1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Name = "pre_question";
            this.Text = "Weaken Precondition";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lableLemaPre;
        private System.Windows.Forms.TextBox preCondName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox pre_cond1;
        private System.Windows.Forms.TextBox methodName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_more;
        private System.Windows.Forms.Label pre_lable;
    }
}