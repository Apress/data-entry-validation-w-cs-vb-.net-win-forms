using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace PlayCatch_c
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			InitializeComponent();

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
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(292, 266);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);

    }
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

    private void Form1_Load(object sender, System.EventArgs e)
    {
      StreamReader file;
      try
      {
        int x, y, z;
        file = new StreamReader("MyFile.txt");
        string s = file.ReadLine();
        if(s == string.Empty || s == null)
          throw new ApplicationException("First line was empty");

        x = int.Parse(s);
        s = file.ReadLine();
        if(s == string.Empty || s == null)
          throw new ApplicationException("Second line was empty");

        y = int.Parse(s);
        if(y != 0)
        {
          z = x/y;
          MessageBox.Show("The value of X/Y is " + z.ToString());
        }
        else
          MessageBox.Show("Unable to divide numbers");

        if(file != null)
          file.Close();
      }
      catch(ApplicationException ex)
      {
        MessageBox.Show(ex.Message);
        //Put a trace message here
      }
      catch(IOException ex)
      {
        MessageBox.Show("File I/O Exception: " + ex.Message);
        //Put a trace message here
      }
      catch(Exception ex)
      {
        MessageBox.Show(ex.Message);
        //Put a trace message here
      }

      this.Close();

    }

    private void FooBar()
    {
      StreamReader file = null;
      SolidBrush B      = new SolidBrush(Color.Azure);
      Pen P             = new Pen(B, 3);
      Font F            = new Font("Arial", 12);
      Graphics G        = null;
      
      try
      {
        G = Graphics.FromHwnd(this.Handle);
        file = new StreamReader("MyFile.txt");
        string s = file.ReadLine();
        G.DrawString(s, F, B, 10, 20);
        // Do some funky stuff with the pen here
        // Also do some extensive code
        //...
        //...
        if(s == "The End")
          return;

        s = file.ReadLine();
        // Do some more stuff with the pen here
        // Also do some more extensive code
        //...
        //...
        G.DrawString(s, F, B, 30, 20);

      }
      catch(Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
      finally
      {
        if(G != null)
          G.Dispose();
        if(F != null)
          F.Dispose();
        if(P != null)
          P.Dispose();
        if(B != null)
          B.Dispose();
        if(file != null)
          file.Close();
      }
    }

    private void foo()
    {
      StreamReader file = null;
      try
      {
        file = new StreamReader("MyFile.txt");
        file.Close();
      }
      catch(Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
      finally
      {
        if(file != null)
          file.Close();
      }
    }
	}
}
