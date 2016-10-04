using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MouseTrap_c
{
  /// <summary>
  /// Example showing how to use the mouse events
  /// press delete key to subtract flags from the panel and re-arrange
  /// </summary>
  public class frmMouse : System.Windows.Forms.Form
  {
    #region Class Local Variables

    //Structs get created on the stack
    private struct Symbols
    {
      private Image   mflag;
      private string  mDispName;
      public Symbols(string DispName, Image flag)
      {
        mflag = flag;
        mDispName = DispName;
      }
      public Image Flag
      {
        get{return mflag;}
      }
      public string Name
      {
        get{return mDispName;}
      }
    };

    //This is added for marquis selection of flags in the Panel
    Rectangle Marquis = Rectangle.Empty;

    #endregion

    private System.Windows.Forms.ListBox lstPics;
    private System.Windows.Forms.Button cmdAdd;
    private System.Windows.Forms.Panel P1;
    private System.Windows.Forms.StatusBar sb;

    private System.ComponentModel.Container components = null;

    public frmMouse()
    {
      InitializeComponent();

      //Need to use arraylist here.
      ArrayList Pics = new ArrayList();
      Pics.Add(new Symbols("Italy",       Image.FromFile("Italy.ico")));
      Pics.Add(new Symbols("Japan",       Image.FromFile("japan.ico")));
      Pics.Add(new Symbols("Canada",      Image.FromFile("canada.ico")));
      Pics.Add(new Symbols("Germany",     Image.FromFile("germany.ico")));
      Pics.Add(new Symbols("Mexico",      Image.FromFile("mexico.ico")));
      Pics.Add(new Symbols("Norway",      Image.FromFile("norway.ico")));
      Pics.Add(new Symbols("New Zealand", Image.FromFile("nz.ico")));
      Pics.Add(new Symbols("England",     Image.FromFile("england.ico")));
      Pics.Add(new Symbols("USA",         Image.FromFile("usa.ico")));

      lstPics.SelectionMode = SelectionMode.MultiExtended;
      lstPics.DataSource = Pics;
      lstPics.DisplayMember = "Name";
      lstPics.ValueMember = "Flag";

      //Set up the status bar
      sb.Panels.Add("Flag = ");
      sb.Panels[0].AutoSize = StatusBarPanelAutoSize.Spring;
      sb.ShowPanels = true;


      //Transfer the data over.
      cmdAdd.Click += new EventHandler(this.MoveFlags);

      //Make sure the user can see all flags
      P1.AutoScroll = true;
      //These delegates are added to facilitate marquis selection
      P1.MouseMove += new MouseEventHandler(this.PanelMouseMove);
      P1.MouseDown += new MouseEventHandler(this.PanelMouseDown);
      P1.MouseUp   += new MouseEventHandler(this.PanelMouseUp);
      P1.Paint     += new PaintEventHandler(this.PanelPaint);

      //Intercept all keyboard strokes before they get to the controls
      this.KeyPreview = true;
      this.KeyDown    += new KeyEventHandler(this.DeleteFlags);

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
      this.P1 = new System.Windows.Forms.Panel();
      this.lstPics = new System.Windows.Forms.ListBox();
      this.cmdAdd = new System.Windows.Forms.Button();
      this.sb = new System.Windows.Forms.StatusBar();
      this.SuspendLayout();
      // 
      // P1
      // 
      this.P1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.P1.Location = new System.Drawing.Point(160, 24);
      this.P1.Name = "P1";
      this.P1.Size = new System.Drawing.Size(312, 328);
      this.P1.TabIndex = 0;
      // 
      // lstPics
      // 
      this.lstPics.Location = new System.Drawing.Point(8, 32);
      this.lstPics.Name = "lstPics";
      this.lstPics.Size = new System.Drawing.Size(136, 264);
      this.lstPics.TabIndex = 1;
      // 
      // cmdAdd
      // 
      this.cmdAdd.Location = new System.Drawing.Point(8, 320);
      this.cmdAdd.Name = "cmdAdd";
      this.cmdAdd.Size = new System.Drawing.Size(136, 32);
      this.cmdAdd.TabIndex = 2;
      this.cmdAdd.Text = "Add to Panel";
      // 
      // sb
      // 
      this.sb.Location = new System.Drawing.Point(0, 368);
      this.sb.Name = "sb";
      this.sb.Size = new System.Drawing.Size(482, 24);
      this.sb.TabIndex = 3;
      // 
      // frmMouse
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(482, 392);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.sb,
                                                                  this.cmdAdd,
                                                                  this.lstPics,
                                                                  this.P1});
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmMouse";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Mouse Event Handlers";
      this.Load += new System.EventHandler(this.frmMouse_Load);
      this.ResumeLayout(false);

    }
		#endregion


    [STAThread]
    static void Main() 
    {
      Application.Run(new frmMouse());
    }

    private void frmMouse_Load(object sender, System.EventArgs e)
    {
    }

    #region Helper functions

    private void ArrangeImages()
    {
      int x         = 0;
      int y         = 0;
      int PICSPACE  = 10;
      int PICSIZE   = 64;

      //Number of pictures in a row.
      //Do not show a picture if it means we get a horizontal
      //scroll bar
      int NumPicsInWidth  = (int)((P1.Size.Width - PICSPACE) / 
        (PICSIZE + PICSPACE)) - 1;
      for (int k = 0; k<= P1.Controls.Count - 1; k++)
      {
        //determine if we are in a new row
        if (k % (NumPicsInWidth) == 0 )
          x = PICSPACE;
        else
          x = P1.Controls[k - 1].Location.X + PICSIZE + PICSPACE;

        if (k < NumPicsInWidth )
          y = PICSPACE;
        else if (k % (NumPicsInWidth) == 0 )
          y = P1.Controls[k - 1].Location.Y + PICSIZE + PICSPACE;

        P1.Controls[k].Location = new Point(x, y);
      }

    }

    #endregion

    #region events

    private void MoveFlags(object sender, EventArgs e)
    {
      foreach(Symbols flg in lstPics.SelectedItems)
      {
        PictureBox p  = new PictureBox();
        p.Size        = new Size(40, 40);
        p.SizeMode    = PictureBoxSizeMode.StretchImage;
        p.MouseDown   += new MouseEventHandler(this.PicMouseDown);
        p.MouseEnter  += new EventHandler(this.PicMouseEnter);
        p.MouseLeave  += new EventHandler(this.PicMouseLeave);
        p.Cursor      = Cursors.Hand;
        p.Image       = flg.Flag;
        p.Tag         = flg.Name;
        P1.Controls.Add(p);
      }

      ArrangeImages();

    }

    private void DeleteFlags(object sender, KeyEventArgs e)
    {
      if(e.KeyCode == Keys.Delete)
      {

        //Try this shortcut. It will not work.  Do you know why?
//        foreach(PictureBox p in P1.Controls)
//        {
//          if(p.BorderStyle == BorderStyle.FixedSingle)
//            P1.Controls.Remove(p);
//        }

        PictureBox p;
        bool deleted = true;
        while (deleted)
        {
          deleted = false;
          for(int k=0; k<P1.Controls.Count; k++)
          {
            if(P1.Controls[k] is PictureBox)
            {
              p = (PictureBox)P1.Controls[k];
              if(p.BorderStyle == BorderStyle.FixedSingle)
              {
                P1.Controls.RemoveAt(k);
                deleted = true;
                //Controls.count has changed. Reinitialize the "for" loop
                break;
              }
            }
          }
        }

        ArrangeImages();
      }
    }

    private void PicMouseDown(object sender, MouseEventArgs e)
    {
      PictureBox P;
      if (sender is PictureBox)
        P = (PictureBox)sender;
      else
        return;

      if(e.Button == MouseButtons.Left)
      {
        if(P.BorderStyle == BorderStyle.FixedSingle)
          P.BorderStyle = BorderStyle.None;
        else
          P.BorderStyle = BorderStyle.FixedSingle;
      }
    }

    private void PicMouseEnter(object sender, EventArgs e)
    {
      PictureBox P;
      if (sender is PictureBox)
        P = (PictureBox)sender;
      else
        return;

      sb.Panels[0].Text = P.Tag.ToString();

    }

    private void PicMouseLeave(object sender, EventArgs e)
    {
      sb.Panels[0].Text = "";
    }

    #endregion

    #region Marquis selection events

    private void PanelPaint(object sender, PaintEventArgs e)
    {
      Rectangle r = RectangleC.Convert(Marquis);

      if(Marquis != Rectangle.Empty)
      {
        e.Graphics.DrawRectangle(Pens.Red, r);
        foreach(PictureBox P in P1.Controls)
        {
          if(r.Contains(P.Bounds))
            P.BorderStyle = BorderStyle.FixedSingle;
          else
            P.BorderStyle = BorderStyle.None;
        }
      }
    }

    private void PanelMouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;

      Marquis = new Rectangle(new Point(e.X, e.Y), Size.Empty);
    }

    private void PanelMouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;

      Marquis.Size = new Size(e.X-Marquis.X, e.Y-Marquis.Y);
      P1.Invalidate();
    }

    private void PanelMouseUp(object sender, MouseEventArgs e)
    {
      Marquis = Rectangle.Empty;
      P1.Invalidate();
    }

    #endregion
  }
}
