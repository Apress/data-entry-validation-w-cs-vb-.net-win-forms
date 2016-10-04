using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Golf_c
{
	/// <summary>
	/// Summary description for NewCourseDlg.
	/// </summary>
	public class NewCourseDlg : System.Windows.Forms.Form
	{
    private string mName = string.Empty;

    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Button cmdSave;
    private System.Windows.Forms.Button cmdCancel;

    private System.ComponentModel.Container components = null;

		public NewCourseDlg()
		{
			InitializeComponent();

      txtName.MaxLength = 50;

      //Setting the dialogresult of the button makes the form 
      //take the same dialog result.  The form is then hidden.
      this.TopMost            = true;
      this.Text               = "New Course";
      cmdSave.DialogResult    = DialogResult.OK;
      cmdSave.Click           += new EventHandler(OK);
      cmdCancel.DialogResult  = DialogResult.Cancel;
      cmdCancel.Click         += new EventHandler(Cancel);
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
      this.lblName = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.cmdSave = new System.Windows.Forms.Button();
      this.cmdCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lblName
      // 
      this.lblName.Location = new System.Drawing.Point(16, 8);
      this.lblName.Name = "lblName";
      this.lblName.Size = new System.Drawing.Size(248, 16);
      this.lblName.TabIndex = 0;
      this.lblName.Text = "Enter Name for new golf course";
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(16, 24);
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(248, 20);
      this.txtName.TabIndex = 1;
      this.txtName.Text = "";
      // 
      // cmdSave
      // 
      this.cmdSave.Location = new System.Drawing.Point(16, 64);
      this.cmdSave.Name = "cmdSave";
      this.cmdSave.Size = new System.Drawing.Size(104, 32);
      this.cmdSave.TabIndex = 2;
      this.cmdSave.Text = "OK";
      // 
      // cmdCancel
      // 
      this.cmdCancel.Location = new System.Drawing.Point(160, 64);
      this.cmdCancel.Name = "cmdCancel";
      this.cmdCancel.Size = new System.Drawing.Size(104, 32);
      this.cmdCancel.TabIndex = 3;
      this.cmdCancel.Text = "Cancel";
      // 
      // NewCourseDlg
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(282, 111);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.cmdCancel,
                                                                  this.cmdSave,
                                                                  this.txtName,
                                                                  this.lblName});
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "NewCourseDlg";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "NewCourseDlg";
      this.Load += new System.EventHandler(this.NewCourseDlg_Load);
      this.ResumeLayout(false);

    }
		#endregion

    private void NewCourseDlg_Load(object sender, System.EventArgs e)
    {
    }

    public string NewName {get{return mName;}}

    #region Events

    private void OK(object sender, EventArgs e)
    {
      mName = txtName.Text;

      //Since dialogresult was assigned to this button the form will
      //hide itself rather than close.
    }

    private void Cancel(object sender, EventArgs e)
    {
      mName = string.Empty;

      //Since dialogresult was assigned to this button the form will
      //hide itself rather than close.
    }

    #endregion

	}
}
