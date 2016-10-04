using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ListViewSwap_c
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{

    #region class local variables

    LvItems lvw1;
    LvItems lvw2;
    LvItems SwapList;

    #endregion

    private System.Windows.Forms.ListView lv;
    private System.Windows.Forms.Button cmdSwap;
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			InitializeComponent();

      //Show details with two columns
      lv.View = View.Details;
      lv.Columns.Add("First Item", -2, HorizontalAlignment.Center);
      lv.Columns.Add("Sub Item",   -2, HorizontalAlignment.Center);

      //Add individual items to the first stored list
      lvw1 = new LvItems();
      lvw1.Add("1     I belong to LC1");
      lvw1.Add("2     I belong to LC1");
      lvw1.Add("3     I belong to LC1");

      //Add an item to the first list that has a sub item
      ListViewItem k = new ListViewItem();
      k.Text = "4     Parent Item";
      k.SubItems.Add("Sub Item 1");
      lvw1.Add(k);

      //Add items to the second stored list
      lvw2 = new LvItems();
      lvw2.Add("1   I belong to LC2");
      lvw2.Add("2   I belong to LC2");
      lvw2.Add("3   I belong to LC2");

      lv.Items.AddRange(lvw1.Items);
    }

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
      this.lv = new System.Windows.Forms.ListView();
      this.cmdSwap = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lv
      // 
      this.lv.Location = new System.Drawing.Point(48, 48);
      this.lv.Name = "lv";
      this.lv.Size = new System.Drawing.Size(232, 192);
      this.lv.TabIndex = 0;
      // 
      // cmdSwap
      // 
      this.cmdSwap.Location = new System.Drawing.Point(128, 256);
      this.cmdSwap.Name = "cmdSwap";
      this.cmdSwap.Size = new System.Drawing.Size(80, 32);
      this.cmdSwap.TabIndex = 1;
      this.cmdSwap.Text = "Swap";
      this.cmdSwap.Click += new System.EventHandler(this.cmdSwap_Click);
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(344, 309);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.cmdSwap,
                                                                  this.lv});
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);

    }
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

    private void Form1_Load(object sender, System.EventArgs e)
    {
    }

    private void cmdSwap_Click(object sender, System.EventArgs e)
    {
      SwapList = SwapList == lvw2 ? lvw1 : lvw2;
      lv.Items.Clear();
      lv.Items.AddRange(SwapList.Items);
    }

	}
}
