using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace Tracing_c
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{

    #region class local variables
    TraceSwitch Tsw;
    #endregion

    private System.Windows.Forms.Button cmdEnable;
    private System.Windows.Forms.Button cmdDisable;
    private System.Windows.Forms.TextBox txtInput;
    private System.Windows.Forms.Button cmdQuit;

    public class NewListener : TraceListener
    {
      console con = new console();
      public NewListener()
      {
        con = null;
      }
      public override void Write(string s)
      {
        if(con == null || !con.IsAlive)
          con = new console();

        con.Out(s);
      }
      public override void WriteLine(string s)
      {
        if(con == null || !con.IsAlive)
          con = new console();

        con.OutL(s);
      }
      public override void Close()
      {
        if(con != null)
        {
          con.Close();
          con = null;
        }
      }
      public void clear()
      {
        if(con != null)
          con.Clear();
      }
    }

		private System.ComponentModel.Container components = null;

		public Form1()
		{
			InitializeComponent();

      Tsw = new TraceSwitch("VerboseTrace", "Trace data read/write");

      Stream myFile = File.Create("TestFile.txt");
      Trace.Listeners.Add(new TextWriterTraceListener(myFile));
      Trace.Listeners.Add(new NewListener());
      Trace.AutoFlush = true;

      txtInput.KeyPress += new KeyPressEventHandler(this.KeyPress);
      cmdEnable.Click   += new EventHandler(this.EnableTrace);
      cmdDisable.Click  += new EventHandler(this.DisableTrace);
      cmdQuit.Click     += new EventHandler(this.Quit);
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
      this.cmdEnable = new System.Windows.Forms.Button();
      this.cmdDisable = new System.Windows.Forms.Button();
      this.txtInput = new System.Windows.Forms.TextBox();
      this.cmdQuit = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // cmdEnable
      // 
      this.cmdEnable.Location = new System.Drawing.Point(24, 208);
      this.cmdEnable.Name = "cmdEnable";
      this.cmdEnable.Size = new System.Drawing.Size(120, 24);
      this.cmdEnable.TabIndex = 0;
      this.cmdEnable.Text = "Enable Trace";
      // 
      // cmdDisable
      // 
      this.cmdDisable.Location = new System.Drawing.Point(24, 240);
      this.cmdDisable.Name = "cmdDisable";
      this.cmdDisable.Size = new System.Drawing.Size(120, 24);
      this.cmdDisable.TabIndex = 1;
      this.cmdDisable.Text = "Disable Trace";
      // 
      // txtInput
      // 
      this.txtInput.Location = new System.Drawing.Point(24, 32);
      this.txtInput.Multiline = true;
      this.txtInput.Name = "txtInput";
      this.txtInput.Size = new System.Drawing.Size(312, 160);
      this.txtInput.TabIndex = 2;
      this.txtInput.Text = "";
      // 
      // cmdQuit
      // 
      this.cmdQuit.Location = new System.Drawing.Point(264, 232);
      this.cmdQuit.Name = "cmdQuit";
      this.cmdQuit.Size = new System.Drawing.Size(72, 32);
      this.cmdQuit.TabIndex = 3;
      this.cmdQuit.Text = "Quit";
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(360, 278);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.cmdQuit,
                                                                  this.txtInput,
                                                                  this.cmdDisable,
                                                                  this.cmdEnable});
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
      //You should not see this anywhere in any trace logs
      Trace.WriteLineIf(Tsw.TraceVerbose, "Program Started");
    }

    #region events

    private void EnableTrace(object sender, EventArgs e)
    {
      Tsw.Level = TraceLevel.Verbose;
      Trace.WriteLineIf(Tsw.TraceVerbose, DateTime.Now.ToString() + 
                                          "  Tracing enabled");
    }

    private void DisableTrace(object sender, EventArgs e)
    {
      Trace.WriteLineIf(Tsw.TraceVerbose, DateTime.Now.ToString() + 
        "  Tracing Disabled");
      Tsw.Level = TraceLevel.Off;
    }

    private void Quit(object sender, EventArgs e)
    {
      Trace.WriteLineIf(Tsw.TraceVerbose, DateTime.Now.ToString() + 
        "  Program Closed");
      Trace.Close();
      this.Close();
    }

    private void KeyPress(object sender, KeyPressEventArgs e)
    {
      Trace.WriteIf(Tsw.TraceVerbose, e.KeyChar.ToString());

    }
    #endregion

  }
}
