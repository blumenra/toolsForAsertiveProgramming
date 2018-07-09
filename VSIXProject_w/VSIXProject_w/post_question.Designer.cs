namespace VSIXProject_w
{
    partial class post_question
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
            this.methodName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lableLemaPost = new System.Windows.Forms.Label();
            this.postLemaName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.post_cond1 = new System.Windows.Forms.TextBox();
            this.button_more = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(307, 106);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(72, 29);
            this.button_clear.TabIndex = 14;
            this.button_clear.Text = "Clean";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(307, 71);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(72, 29);
            this.button_cancel.TabIndex = 13;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(307, 36);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(72, 29);
            this.button_ok.TabIndex = 12;
            this.button_ok.Text = "Ok";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // methodName
            // 
            this.methodName.Location = new System.Drawing.Point(58, 52);
            this.methodName.Name = "methodName";
            this.methodName.Size = new System.Drawing.Size(225, 20);
            this.methodName.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Method Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Please insert the postcondition and lemma name:";
            // 
            // lableLemaPost
            // 
            this.lableLemaPost.AutoSize = true;
            this.lableLemaPost.Location = new System.Drawing.Point(12, 77);
            this.lableLemaPost.Name = "lableLemaPost";
            this.lableLemaPost.Size = new System.Drawing.Size(67, 13);
            this.lableLemaPost.TabIndex = 36;
            this.lableLemaPost.Text = "Lema Name:";
            // 
            // postLemaName
            // 
            this.postLemaName.Location = new System.Drawing.Point(56, 94);
            this.postLemaName.Name = "postLemaName";
            this.postLemaName.Size = new System.Drawing.Size(225, 20);
            this.postLemaName.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Post Condition:";
            // 
            // post_cond1
            // 
            this.post_cond1.Location = new System.Drawing.Point(56, 141);
            this.post_cond1.Name = "post_cond1";
            this.post_cond1.Size = new System.Drawing.Size(225, 20);
            this.post_cond1.TabIndex = 32;
            // 
            // button_more
            // 
            this.button_more.Location = new System.Drawing.Point(56, 167);
            this.button_more.Name = "button_more";
            this.button_more.Size = new System.Drawing.Size(49, 29);
            this.button_more.TabIndex = 37;
            this.button_more.Text = "More";
            this.button_more.UseVisualStyleBackColor = true;
            this.button_more.Click += new System.EventHandler(this.button_more_Click);
            // 
            // post_question
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 202);
            this.Controls.Add(this.button_more);
            this.Controls.Add(this.lableLemaPost);
            this.Controls.Add(this.postLemaName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.post_cond1);
            this.Controls.Add(this.methodName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Name = "post_question";
            this.Text = "Strengthen Postcondition";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.TextBox methodName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lableLemaPost;
        private System.Windows.Forms.TextBox postLemaName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox post_cond1;
        private System.Windows.Forms.Button button_more;
    }
}