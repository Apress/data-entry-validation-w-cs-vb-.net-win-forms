using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Data;

namespace WriteXML_c
{
  public class Form1 : System.Windows.Forms.Form
  {
    #region vars
    
    string fname = "Output.xml";
    enum MODE
    {
      None,
      OnLine,
      OffLine,
      Dumb
    }

    //Added for read
    enum CONFIG_STATE
    {
      C_UNKNOWN,
      C_DATE,
      C_IP,
      C_MODE,
      C_PASS,
      C_OFFSET,
      C_RELAY
    }

    #endregion

    private System.Windows.Forms.Button cmdWrite;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lblFirst;
    private System.Windows.Forms.Label lblDate;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox cmbMode;
    private System.Windows.Forms.TextBox txtIP;
    private System.Windows.Forms.TextBox txtOffset;
    private System.Windows.Forms.TextBox txtPass;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtRelay;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button cmdRead;

    private System.ComponentModel.Container components = null;

    public Form1()
    {
      InitializeComponent();

      lblDate.Text = DateTime.Now.ToLongDateString();
      cmbMode.Items.Add(MODE.Dumb);
      cmbMode.Items.Add(MODE.OffLine);
      cmbMode.Items.Add(MODE.OnLine);
      cmbMode.Items.Add(MODE.None);
      cmbMode.SelectedIndex = 0;

      txtIP.Text = "123.456.789.13";
      txtPass.Text = "Abc56def";
      txtOffset.Text = "-34";
      txtRelay.Text = "21.8";

      cmdWrite.Click += new EventHandler(this.WriteXMLFile);

      //=========== New read code =============
      cmdRead.Enabled = false;
      cmdRead.Click += new EventHandler(this.ReadXMLFile);
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
      this.cmdWrite = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.lblFirst = new System.Windows.Forms.Label();
      this.txtIP = new System.Windows.Forms.TextBox();
      this.lblDate = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.txtOffset = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.cmbMode = new System.Windows.Forms.ComboBox();
      this.txtPass = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.txtRelay = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.cmdRead = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // cmdWrite
      // 
      this.cmdWrite.Location = new System.Drawing.Point(200, 192);
      this.cmdWrite.Name = "cmdWrite";
      this.cmdWrite.Size = new System.Drawing.Size(112, 32);
      this.cmdWrite.TabIndex = 0;
      this.cmdWrite.Text = "Write XML";
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(24, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(184, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "Configuration  Date";
      // 
      // lblFirst
      // 
      this.lblFirst.Location = new System.Drawing.Point(24, 72);
      this.lblFirst.Name = "lblFirst";
      this.lblFirst.Size = new System.Drawing.Size(128, 16);
      this.lblFirst.TabIndex = 3;
      this.lblFirst.Text = "IP Address";
      // 
      // txtIP
      // 
      this.txtIP.Location = new System.Drawing.Point(24, 88);
      this.txtIP.Name = "txtIP";
      this.txtIP.Size = new System.Drawing.Size(128, 20);
      this.txtIP.TabIndex = 4;
      this.txtIP.Text = "";
      // 
      // lblDate
      // 
      this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblDate.Location = new System.Drawing.Point(24, 32);
      this.lblDate.Name = "lblDate";
      this.lblDate.Size = new System.Drawing.Size(184, 16);
      this.lblDate.TabIndex = 7;
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(184, 72);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(128, 16);
      this.label3.TabIndex = 8;
      this.label3.Text = "Mode";
      // 
      // txtOffset
      // 
      this.txtOffset.Location = new System.Drawing.Point(184, 144);
      this.txtOffset.Name = "txtOffset";
      this.txtOffset.Size = new System.Drawing.Size(128, 20);
      this.txtOffset.TabIndex = 11;
      this.txtOffset.Text = "";
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(184, 128);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(128, 16);
      this.label4.TabIndex = 10;
      this.label4.Text = "Time zone offset";
      // 
      // cmbMode
      // 
      this.cmbMode.Location = new System.Drawing.Point(184, 88);
      this.cmbMode.Name = "cmbMode";
      this.cmbMode.Size = new System.Drawing.Size(128, 21);
      this.cmbMode.TabIndex = 12;
      // 
      // txtPass
      // 
      this.txtPass.Location = new System.Drawing.Point(24, 144);
      this.txtPass.Name = "txtPass";
      this.txtPass.Size = new System.Drawing.Size(128, 20);
      this.txtPass.TabIndex = 14;
      this.txtPass.Text = "";
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(24, 128);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(128, 16);
      this.label5.TabIndex = 13;
      this.label5.Text = "Password";
      // 
      // txtRelay
      // 
      this.txtRelay.Location = new System.Drawing.Point(24, 200);
      this.txtRelay.Name = "txtRelay";
      this.txtRelay.Size = new System.Drawing.Size(128, 20);
      this.txtRelay.TabIndex = 16;
      this.txtRelay.Text = "";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(24, 184);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(128, 16);
      this.label2.TabIndex = 15;
      this.label2.Text = "Relay Delay";
      // 
      // cmdRead
      // 
      this.cmdRead.Location = new System.Drawing.Point(200, 240);
      this.cmdRead.Name = "cmdRead";
      this.cmdRead.Size = new System.Drawing.Size(112, 32);
      this.cmdRead.TabIndex = 17;
      this.cmdRead.Text = "Read XML";
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(336, 286);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.cmdRead,
                                                                  this.txtRelay,
                                                                  this.label2,
                                                                  this.txtPass,
                                                                  this.label5,
                                                                  this.cmbMode,
                                                                  this.txtOffset,
                                                                  this.label4,
                                                                  this.label3,
                                                                  this.lblDate,
                                                                  this.txtIP,
                                                                  this.lblFirst,
                                                                  this.label1,
                                                                  this.cmdWrite});
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

    private void WriteXMLFile(object sender, EventArgs e)
    {
      double    RelayDelay;
      DateTime  date;
      string    IP;
      MODE      mode;
      int       TZ_Offset;
      string    Pword;

      //I am going to be really bad here and assume that all user filled in 
      //fields are going to convert properly
      date        = Convert.ToDateTime(lblDate.Text);
      IP          = txtIP.Text;
      mode        = (MODE)cmbMode.SelectedItem;
      TZ_Offset   = int.Parse(txtOffset.Text);
      Pword       = Classify.Encrypt(txtPass.Text);
      RelayDelay  = Convert.ToDouble(txtRelay.Text);

      //This is your basic well formed XMl file.
      XmlTextWriter w = new XmlTextWriter(fname, Encoding.UTF8);
      w.Formatting = Formatting.Indented;
      w.WriteStartDocument();
      w.WriteStartElement("Device_Configuration");

      w.WriteElementString("ConfigDate", XmlConvert.ToString(date));
      w.WriteElementString("IP", txtIP.Text);
      w.WriteElementString("Mode", cmbMode.SelectedItem.ToString());
      w.WriteElementString("PassWord", Pword);
      w.WriteElementString("TimeZoneOffset", XmlConvert.ToString(TZ_Offset));
      w.WriteElementString("RelayDelay", XmlConvert.ToString(RelayDelay));

      w.WriteEndElement();
      w.WriteEndDocument();
      w.Flush();
      w.Close();

      //enable read code
      cmbMode.SelectedIndex = 3;
      cmdRead.Enabled   = true;
      cmdWrite.Enabled  = false;
      txtIP.Text        = "";
      txtPass.Text      = "";
      txtOffset.Text    = "";
      txtRelay.Text     = "";
      lblDate.Text      = "";
    }

    private void ReadXMLFile(object sender, EventArgs e)
    {
      double        RelayDelay  = 0.0;;
      DateTime      date        = DateTime.Today.AddYears(-28);
      string        IP          = "INVALID IP";
      MODE          mode        = MODE.None;
      int           TZ_Offset   = 0;
      string        Pword       = string.Empty;
      bool          Config      = false;
      CONFIG_STATE  cs          = CONFIG_STATE.C_UNKNOWN;

      //I use a state machine based upon the CONFIG_STATE value.
      //This is but one way to do this.
      XmlTextReader r = new XmlTextReader(fname);
      //Ignore all whitespace
      r.WhitespaceHandling = WhitespaceHandling.None;
      while (r.Read())
      {
        switch (r.NodeType)
        {
          case XmlNodeType.Element:
            if(r.Name == "Device_Configuration")
              Config = true;
            else
            {
              if(Config)
              {
                switch(r.Name)
                {
                  case "ConfigDate":
                    cs = CONFIG_STATE.C_DATE;
                    break;
                  case "IP":
                    cs = CONFIG_STATE.C_IP;
                    break;
                  case "Mode":
                    cs = CONFIG_STATE.C_MODE;
                    break;
                  case "PassWord":
                    cs = CONFIG_STATE.C_PASS;
                    break;
                  case "TimeZoneOffset":
                    cs = CONFIG_STATE.C_OFFSET;
                    break;
                  case "RelayDelay":
                    cs = CONFIG_STATE.C_RELAY;
                    break;
                }
              }
            }
            break;
          case XmlNodeType.Text:
            if(Config)
            {
              switch(cs)
              {
                case CONFIG_STATE.C_DATE:
                  date = XmlConvert.ToDateTime(r.Value);
                  break;
                case CONFIG_STATE.C_IP:
                  if(Regex.IsMatch(r.Value, 
                                   "^\\d{1,3}.\\d{1,3}.\\d{1,3}.\\d{1,3}$"))
                    IP = r.Value;
                  break;
                case CONFIG_STATE.C_MODE:
                  switch(r.Value)
                  {
                    case "Dumb":
                      mode = MODE.Dumb;
                      break;
                    case "OnLine":
                      mode = MODE.OnLine;
                      break;
                    case "OffLine":
                      mode = MODE.OffLine;
                      break;
                    case "None":
                    default:
                      mode = MODE.None;
                      break;
                  }
                  break;
                case CONFIG_STATE.C_PASS:
                  Pword = Classify.Decrypt(r.Value);
                  break;
                case CONFIG_STATE.C_OFFSET:
                  //Do some validation
                  if(Regex.IsMatch(r.Value, "^[0-9+-]+$"))
                    TZ_Offset = XmlConvert.ToInt32(r.Value);
                  break;
                case CONFIG_STATE.C_RELAY:
                  //Do some validation
                  if(Regex.IsMatch(r.Value, "^[0-9+-.]+$"))
                    RelayDelay = XmlConvert.ToDouble(r.Value);
                  break;
              }
            }
            break;
        }    
      }
      r.Close();
      txtIP.Text        = IP;
      txtPass.Text      = Pword;
      txtOffset.Text    = TZ_Offset.ToString();
      txtRelay.Text     = RelayDelay.ToString();
      lblDate.Text      = date.ToLongDateString();
      for(int k=0; k<cmbMode.Items.Count; k++)
      {
        if((MODE)cmbMode.Items[k] == mode)
        {
          cmbMode.SelectedIndex = k;
          break;
        }
      }
      cmdWrite.Enabled = true;
      cmdRead.Enabled  = false;
    }
  }
}
