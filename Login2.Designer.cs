namespace SPA
{
  partial class Login2
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
      this.button2 = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Modern No. 20", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
      this.label1.Location = new System.Drawing.Point(56, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(164, 21);
      this.label1.TabIndex = 7;
      this.label1.Text = "ВВЕДИТЕ ПАРОЛЬ";
      // 
      // button2
      // 
      this.button2.AutoSize = true;
      this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
      this.button2.Image = global::SPA.Properties.Resources._1378149904_cancel;
      this.button2.Location = new System.Drawing.Point(160, 57);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(126, 72);
      this.button2.TabIndex = 6;
      this.button2.UseVisualStyleBackColor = true;
      // 
      // button1
      // 
      this.button1.AutoSize = true;
      this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
      this.button1.Image = global::SPA.Properties.Resources._1378149834_ok;
      this.button1.Location = new System.Drawing.Point(5, 57);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(149, 72);
      this.button1.TabIndex = 5;
      this.button1.UseVisualStyleBackColor = true;
      // 
      // textBox1
      // 
      this.textBox1.BackColor = System.Drawing.Color.Azure;
      this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.textBox1.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBox1.Location = new System.Drawing.Point(5, 37);
      this.textBox1.Name = "textBox1";
      this.textBox1.PasswordChar = ' ';
      this.textBox1.Size = new System.Drawing.Size(281, 14);
      this.textBox1.TabIndex = 4;
      this.textBox1.Text = "Password";
      // 
      // Login2
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(293, 134);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.textBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "Login2";
      this.Text = "Login2";
      this.TransparencyKey = System.Drawing.Color.Maroon;
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TextBox textBox1;
  }
}