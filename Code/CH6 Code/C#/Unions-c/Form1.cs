using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.IO;

namespace Unions_c
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{

    #region class local variables

    //Must use only value types.  Cannot mix in reference types
    [ StructLayout( LayoutKind.Explicit )]
      public struct UnionBenefits 
    {
      [ FieldOffset(0)]
      public int      VacationDays;
      [ FieldOffset(4)]
      public int      SickDays;
      [ FieldOffset(0)]
      public double   DaysOff;

    }

    public struct SalaryBenefits
    {
      private int    mVacationDays;
      private int    mSickDays;
      public int VacationDays
      { 
        get{return mVacationDays;} 
        set{mVacationDays = value;}
      }
      public int SickDays
      { 
        get{return mSickDays;} 
        set{mSickDays = value;}
      }
      public int DaysOff {get{return mSickDays + mVacationDays;}}
    }

    FileStream    FS;
    BinaryReader  BR;
    BinaryWriter  BW;

    private byte[] Buffer = new byte[1000];

    #endregion


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
      this.ClientSize = new System.Drawing.Size(264, 238);
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
      WriteNormalBinary();
      ReadNormalBinary();

      WriteViaUnion();
      ReadViaUnion();

      WriteMemNormalBinary();
      ReadMemNormalBinary();

      WriteMemViaUnion();
      ReadMemViaUnion();

    }


    #region read/write to memory stream normal way

    private void WriteMemNormalBinary()
    {
      MemoryStream MS = new MemoryStream(Buffer);
      BW = new BinaryWriter(MS);

      SalaryBenefits x = new SalaryBenefits();
      x.VacationDays = 36;
      x.SickDays = 17;
      BW.Write(x.VacationDays);
      BW.Write(x.SickDays);
      BW.Flush();
      BW.Close();

    }

    private void ReadMemNormalBinary()
    {
      MemoryStream MS = new MemoryStream(Buffer);
      BR = new BinaryReader(MS);

      SalaryBenefits y = new SalaryBenefits();
      y.VacationDays = BR.ReadInt32();
      y.SickDays = BR.ReadInt32();
    }


    #endregion

    #region Read/Write File via normal way

    private void WriteNormalBinary()
    {
      FS = new FileStream("SalaryFile", FileMode.OpenOrCreate);
      BW = new BinaryWriter(FS);

      SalaryBenefits x = new SalaryBenefits();
      x.VacationDays = 82;
      x.SickDays = 31;
      BW.Write(x.VacationDays);
      BW.Write(x.SickDays);
      BW.Flush();
      BW.Close();

    }

    private void ReadNormalBinary()
    {
      FS = new FileStream("SalaryFile", FileMode.Open);
      BR = new BinaryReader(FS);

      SalaryBenefits y = new SalaryBenefits();
      y.VacationDays = BR.ReadInt32();
      y.SickDays = BR.ReadInt32();
    }

    #endregion

    #region Read/Write File via fake union

    private void WriteViaUnion()
    {
      UnionBenefits x = new UnionBenefits();
      x.SickDays = 5;
      x.VacationDays = 15;

      FS = new FileStream("UnionFile", FileMode.OpenOrCreate);
      BW = new BinaryWriter(FS);
      BW.Write(x.DaysOff);
      BW.Flush();
      BW.Close();

    }

    private void ReadViaUnion()
    {
      FS = new FileStream("UnionFile", FileMode.Open);

      UnionBenefits y = new UnionBenefits();
      BR = new BinaryReader(FS);
      y.DaysOff = BR.ReadDouble();

    }

    #endregion

    #region read/write to memory stream via fake union

    private void WriteMemViaUnion()
    {
      UnionBenefits x = new UnionBenefits();
      x.SickDays = 33;
      x.VacationDays = 66;

      MemoryStream MS = new MemoryStream(Buffer);
      BW = new BinaryWriter(MS);
      BW.Write(x.DaysOff);
      BW.Flush();
      BW.Close();

    }

    private void ReadMemViaUnion()
    {
      MemoryStream MS = new MemoryStream(Buffer);

      UnionBenefits y = new UnionBenefits();
      BR = new BinaryReader(MS);
      y.DaysOff = BR.ReadDouble();

    }

    #endregion

	}
}
