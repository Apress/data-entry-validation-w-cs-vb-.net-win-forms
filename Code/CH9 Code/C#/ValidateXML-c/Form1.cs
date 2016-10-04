using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.IO;
using System.Xml.Schema;

namespace ValidateXML_c
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
    #region vars
    
    string XMLfname   = "ConfigDevice.xml";
    string XSDfname   = "ConfigDevice.xsd";
    string NameSpace  = "http://tempuri.org/ConfigDevice.xsd";
    enum MODE
    {
      None,
      OnLine,
      OffLine,
      Dumb
    }

    #endregion

    private System.Windows.Forms.Button cmdRead;
    private System.Windows.Forms.TextBox txtRelay;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtPass;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox cmbMode;
    private System.Windows.Forms.TextBox txtOffset;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label lblDate;
    private System.Windows.Forms.TextBox txtIP;
    private System.Windows.Forms.Label lblFirst;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button cmdWrite;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.RichTextBox rcResults;

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
      this.cmdRead = new System.Windows.Forms.Button();
      this.txtRelay = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtPass = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.cmbMode = new System.Windows.Forms.ComboBox();
      this.txtOffset = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.lblDate = new System.Windows.Forms.Label();
      this.txtIP = new System.Windows.Forms.TextBox();
      this.lblFirst = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.cmdWrite = new System.Windows.Forms.Button();
      this.label6 = new System.Windows.Forms.Label();
      this.rcResults = new System.Windows.Forms.RichTextBox();
      this.SuspendLayout();
      // 
      // cmdRead
      // 
      this.cmdRead.Location = new System.Drawing.Point(192, 240);
      this.cmdRead.Name = "cmdRead";
      this.cmdRead.Size = new System.Drawing.Size(112, 32);
      this.cmdRead.TabIndex = 31;
      this.cmdRead.Text = "Read XML";
      this.cmdRead.Click += new System.EventHandler(this.cmdRead_Click);
      // 
      // txtRelay
      // 
      this.txtRelay.Location = new System.Drawing.Point(16, 200);
      this.txtRelay.Name = "txtRelay";
      this.txtRelay.Size = new System.Drawing.Size(128, 20);
      this.txtRelay.TabIndex = 30;
      this.txtRelay.Text = "";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(16, 184);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(128, 16);
      this.label2.TabIndex = 29;
      this.label2.Text = "Relay Delay";
      // 
      // txtPass
      // 
      this.txtPass.Location = new System.Drawing.Point(16, 144);
      this.txtPass.Name = "txtPass";
      this.txtPass.Size = new System.Drawing.Size(128, 20);
      this.txtPass.TabIndex = 28;
      this.txtPass.Text = "";
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(16, 128);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(128, 16);
      this.label5.TabIndex = 27;
      this.label5.Text = "Password";
      // 
      // cmbMode
      // 
      this.cmbMode.Location = new System.Drawing.Point(176, 88);
      this.cmbMode.Name = "cmbMode";
      this.cmbMode.Size = new System.Drawing.Size(128, 21);
      this.cmbMode.TabIndex = 26;
      // 
      // txtOffset
      // 
      this.txtOffset.Location = new System.Drawing.Point(176, 144);
      this.txtOffset.Name = "txtOffset";
      this.txtOffset.Size = new System.Drawing.Size(128, 20);
      this.txtOffset.TabIndex = 25;
      this.txtOffset.Text = "";
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(176, 128);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(128, 16);
      this.label4.TabIndex = 24;
      this.label4.Text = "Time zone offset";
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(176, 72);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(128, 16);
      this.label3.TabIndex = 23;
      this.label3.Text = "Mode";
      // 
      // lblDate
      // 
      this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblDate.Location = new System.Drawing.Point(16, 32);
      this.lblDate.Name = "lblDate";
      this.lblDate.Size = new System.Drawing.Size(184, 16);
      this.lblDate.TabIndex = 22;
      // 
      // txtIP
      // 
      this.txtIP.Location = new System.Drawing.Point(16, 88);
      this.txtIP.Name = "txtIP";
      this.txtIP.Size = new System.Drawing.Size(128, 20);
      this.txtIP.TabIndex = 21;
      this.txtIP.Text = "";
      // 
      // lblFirst
      // 
      this.lblFirst.Location = new System.Drawing.Point(16, 72);
      this.lblFirst.Name = "lblFirst";
      this.lblFirst.Size = new System.Drawing.Size(128, 16);
      this.lblFirst.TabIndex = 20;
      this.lblFirst.Text = "IP Address";
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(16, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(184, 16);
      this.label1.TabIndex = 19;
      this.label1.Text = "Configuration  Date";
      // 
      // cmdWrite
      // 
      this.cmdWrite.Location = new System.Drawing.Point(192, 192);
      this.cmdWrite.Name = "cmdWrite";
      this.cmdWrite.Size = new System.Drawing.Size(112, 32);
      this.cmdWrite.TabIndex = 18;
      this.cmdWrite.Text = "Write XML";
      this.cmdWrite.Click += new System.EventHandler(this.cmdWrite_Click);
      // 
      // label6
      // 
      this.label6.Location = new System.Drawing.Point(336, 16);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(352, 16);
      this.label6.TabIndex = 33;
      this.label6.Text = "Read Results";
      this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // rcResults
      // 
      this.rcResults.Location = new System.Drawing.Point(328, 32);
      this.rcResults.Name = "rcResults";
      this.rcResults.Size = new System.Drawing.Size(360, 224);
      this.rcResults.TabIndex = 34;
      this.rcResults.Text = "";
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(704, 294);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.rcResults,
                                                                  this.label6,
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

    private void WriteXMLFile()
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
      Pword       = txtPass.Text;
      RelayDelay  = Convert.ToDouble(txtRelay.Text);

      //This is your basic well formed XMl file.
      XmlTextWriter w = new XmlTextWriter(XMLfname, null);
      w.Formatting = Formatting.Indented;
      w.WriteStartDocument();

      w.WriteStartElement("Device_Configuration", NameSpace);

      //Uncomment the short date line and comment the one above to cause
      //an XML validation error in the read routine
      w.WriteStartElement("ConfigDate");
 //     w.WriteString(XmlConvert.ToString(date));
      w.WriteString(date.ToShortDateString());
      w.WriteEndElement();

      w.WriteStartElement("IP");
      w.WriteString(txtIP.Text);
      w.WriteEndElement();

      w.WriteStartElement("Mode");
      w.WriteString(cmbMode.SelectedItem.ToString());
      w.WriteEndElement();

      w.WriteStartElement("PassWord");
      w.WriteString(Pword);
      w.WriteEndElement();

      w.WriteStartElement("TimeZoneOffset");
      w.WriteString(XmlConvert.ToString(TZ_Offset));
      w.WriteEndElement();

      w.WriteStartElement("RelayDelay");
      w.WriteString(XmlConvert.ToString(RelayDelay));
      w.WriteEndElement();

      w.WriteEndElement();
      w.WriteEndDocument();
      w.Flush();
      w.Close();

      //enable read code
      cmbMode.SelectedIndex = 3;
      cmdRead.Enabled   = true;
      cmdWrite.Enabled  = false;
    }

    #region Read XML file

    private void ReadXML()
    {
      double    RelayDelay;
      DateTime  date;
      string    IP;
      MODE      mode;
      decimal   TZ_Offset;
      string    Pword;

      try
      {
        //open up a stream and fed it to the XmlTextReader
        StreamReader sRdr           = new StreamReader(XMLfname);
        XmlTextReader tRdr          = new XmlTextReader(sRdr);

        //Instantiate a new schemas collection
        //Add this one schema to the collection
        //A collection means that you can validate this XML file against any
        //number of schemas.  You would do this if you were reading the file 
        //piecemeal
        XmlSchemaCollection Schemas = new XmlSchemaCollection();
        Schemas.Add(null, XSDfname);

        //Instantiate a new validating reader.  This validates for data type
        //and presence.
        //Add the schemas collection to the validating reader and funnel the 
        //XmlTextReader through it.
        //wire up an ad-hoc validation delegate to catch any validation errors
        XmlValidatingReader vRdr    = new XmlValidatingReader(tRdr);
        vRdr.ValidationType         = ValidationType.Schema;
        vRdr.ValidationEventHandler += new ValidationEventHandler(ValXML);
        vRdr.Schemas.Add(Schemas);

        //Read the XML file through the validator
        object node;
        while (vRdr.Read())
        {
          node = null;
          if (vRdr.LocalName.Equals("ConfigDate"))
          {
            node = vRdr.ReadTypedValue();
            if(node != null)
              date = (DateTime)node;
          }
          if (vRdr.LocalName.Equals("RelayDelay"))
          {
            node = vRdr.ReadTypedValue();
            if(node != null)
              RelayDelay = (double)node;
          }
          if (vRdr.LocalName.Equals("TimeZoneOffset"))
          {
            node = vRdr.ReadTypedValue();
            if(node != null)
              TZ_Offset = (decimal)node;
          }
          if (vRdr.LocalName.Equals("PassWord"))
          {
            node = vRdr.ReadTypedValue();
            if(node != null)
              Pword = (string)node;
          }
          if (vRdr.LocalName.Equals("Mode"))
          {
            node = vRdr.ReadTypedValue();
//            mode = (string)node;
          }
          if (vRdr.LocalName.Equals("IP"))
          {
            node = vRdr.ReadTypedValue();
            if(node != null)
              IP = (string)node;
          }
          if(node != null)
          {
            rcResults.AppendText(vRdr.LocalName + "\n");
            rcResults.AppendText(node.GetType().ToString() + "\n");
            rcResults.AppendText(node.ToString() + "\n\n");
          }

        }
        vRdr.Close();
        tRdr.Close();
        sRdr.Close();
      }
      catch (Exception e)
      {
        //The handler will catch mal-formed xml docs.  
        //It is not intended to catch bad data.  That is the delegates job
        MessageBox.Show("Exception analyzing Config file: " + e.Message);
      }
    }

    private void ValXML(Object sender, ValidationEventArgs e)
    {
      //This delegate will ONLY catch bad data.  It will not catch 
      //a mal-formed XML document!!
      rcResults.AppendText(e.Message + "\n\n");
    }

    #endregion

    #region events

    private void cmdWrite_Click(object sender, System.EventArgs e)
    {
      WriteXMLFile();
    }

    private void cmdRead_Click(object sender, System.EventArgs e)
    {
      ReadXML();
    }

    #endregion

	}
}
