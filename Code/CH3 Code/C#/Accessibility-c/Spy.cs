using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Accessibility_c
{
	/// <summary>
	/// Summary description for Spy.
	/// </summary>
	public class Spy : System.Windows.Forms.Form
	{
    private System.Windows.Forms.Label lblDesc;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label lblText;

		private System.ComponentModel.Container components = null;

		public Spy()
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
      this.lblDesc = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.lblText = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // lblDesc
      // 
      this.lblDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblDesc.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblDesc.Location = new System.Drawing.Point(24, 64);
      this.lblDesc.Name = "lblDesc";
      this.lblDesc.Size = new System.Drawing.Size(424, 48);
      this.lblDesc.TabIndex = 0;
      this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label1.Location = new System.Drawing.Point(24, 40);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(424, 24);
      this.label1.TabIndex = 1;
      this.label1.Text = "Accessible Description";
      // 
      // label2
      // 
      this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label2.Location = new System.Drawing.Point(32, 184);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(416, 24);
      this.label2.TabIndex = 2;
      this.label2.Text = "Text";
      // 
      // lblText
      // 
      this.lblText.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblText.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblText.Location = new System.Drawing.Point(32, 208);
      this.lblText.Name = "lblText";
      this.lblText.Size = new System.Drawing.Size(424, 48);
      this.lblText.TabIndex = 3;
      this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // Spy
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(482, 302);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.lblText,
                                                                  this.label2,
                                                                  this.label1,
                                                                  this.lblDesc});
      this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Spy";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Spy";
      this.Load += new System.EventHandler(this.Spy_Load);
      this.ResumeLayout(false);

    }
		#endregion

    private void Spy_Load(object sender, System.EventArgs e)
    {
      //This precludes menus becaus a menu is a component
      foreach(Control c in this.Owner.Controls)
      {
        c.MouseEnter += new EventHandler(this.AccessibleEnter);
        c.MouseLeave += new EventHandler(this.AccessibleLeave);
      }

    }

    private void AccessibleEnter(object sender, EventArgs e)
    {
      Control c;

      //This precludes menus.  You can include menus if you like
      //by testing for a component.
      if(sender is Control)
        c = (Control)sender;
      else
        return;

      //Dont bother with incidental controls
      if(c.AccessibleRole == AccessibleRole.Default)
        return;

      //Yes folks you can use VB commands inside C#
      Microsoft.VisualBasic.Interaction.Beep();

      lblDesc.Text = c.AccessibleDescription;
      lblText.Text = c.Text;
    }

    private void AccessibleLeave(object sender, EventArgs e)
    {

      lblDesc.Text = "";
      lblText.Text = "";
    }

	}
}
