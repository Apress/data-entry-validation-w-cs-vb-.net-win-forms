using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SDIsample_c
{
	/// <summary>
	/// Summary description for Employee.
	/// </summary>
	public class Employee : System.Windows.Forms.Form
	{
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckedListBox checkedListBox1;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button button5;

    private System.ComponentModel.Container components = null;

    #region Class Local Variables


    #endregion

		public Employee()
		{
			InitializeComponent();

		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.button3 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
      this.button4 = new System.Windows.Forms.Button();
      this.button5 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(312, 240);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(152, 32);
      this.button3.TabIndex = 10;
      this.button3.Text = "Randomly Demote";
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(312, 192);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(152, 32);
      this.button2.TabIndex = 9;
      this.button2.Text = "Fire Employee";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(312, 144);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(152, 32);
      this.button1.TabIndex = 8;
      this.button1.Text = "Add Employee";
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(16, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(264, 16);
      this.label1.TabIndex = 7;
      this.label1.Text = "Employees";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // checkedListBox1
      // 
      this.checkedListBox1.Items.AddRange(new object[] {
                                                         "Jack",
                                                         "Jim",
                                                         "Jane",
                                                         "Leon"});
      this.checkedListBox1.Location = new System.Drawing.Point(16, 32);
      this.checkedListBox1.Name = "checkedListBox1";
      this.checkedListBox1.Size = new System.Drawing.Size(272, 289);
      this.checkedListBox1.TabIndex = 6;
      // 
      // button4
      // 
      this.button4.Location = new System.Drawing.Point(312, 288);
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size(64, 32);
      this.button4.TabIndex = 11;
      this.button4.Text = "OK";
      // 
      // button5
      // 
      this.button5.Location = new System.Drawing.Point(400, 288);
      this.button5.Name = "button5";
      this.button5.Size = new System.Drawing.Size(64, 32);
      this.button5.TabIndex = 12;
      this.button5.Text = "Cancel";
      // 
      // Employee
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(480, 342);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.button5,
                                                                  this.button4,
                                                                  this.button3,
                                                                  this.button2,
                                                                  this.button1,
                                                                  this.label1,
                                                                  this.checkedListBox1});
      this.Name = "Employee";
      this.Text = "Employee";
      this.Load += new System.EventHandler(this.Employee_Load);
      this.ResumeLayout(false);

    }
		#endregion

    private void Employee_Load(object sender, System.EventArgs e)
    {
    }

	}
}
