using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MDIapp_c
{
	/// <summary>
	/// Summary description for Employee.
	/// </summary>
	public class Employee : System.Windows.Forms.Form
	{
    private System.Windows.Forms.Button button5;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckedListBox checkedListBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Employee()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
      this.button5 = new System.Windows.Forms.Button();
      this.button4 = new System.Windows.Forms.Button();
      this.button3 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
      this.SuspendLayout();
      // 
      // button5
      // 
      this.button5.Location = new System.Drawing.Point(400, 291);
      this.button5.Name = "button5";
      this.button5.Size = new System.Drawing.Size(64, 32);
      this.button5.TabIndex = 19;
      this.button5.Text = "Cancel";
      // 
      // button4
      // 
      this.button4.Location = new System.Drawing.Point(312, 291);
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size(64, 32);
      this.button4.TabIndex = 18;
      this.button4.Text = "OK";
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(312, 243);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(152, 32);
      this.button3.TabIndex = 17;
      this.button3.Text = "Randomly Demote";
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(312, 195);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(152, 32);
      this.button2.TabIndex = 16;
      this.button2.Text = "Fire Employee";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(312, 147);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(152, 32);
      this.button1.TabIndex = 15;
      this.button1.Text = "Add Employee";
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(16, 19);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(264, 16);
      this.label1.TabIndex = 14;
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
      this.checkedListBox1.Location = new System.Drawing.Point(16, 35);
      this.checkedListBox1.Name = "checkedListBox1";
      this.checkedListBox1.Size = new System.Drawing.Size(272, 289);
      this.checkedListBox1.TabIndex = 13;
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
