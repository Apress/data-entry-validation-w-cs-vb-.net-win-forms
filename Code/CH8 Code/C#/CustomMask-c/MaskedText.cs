using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Text;
using System.Text.RegularExpressions;

namespace CustomMask_c
{

  public class ValidationErrorEventArgs : EventArgs 
  {

    private string mMask;
    private string mText;

    public ValidationErrorEventArgs(string mask, string OffendingText)
    {
      mMask = mask;
      mText = OffendingText;
    }

    public string Mask{get{return mMask;}}
    public string Text{get{return mText;}}
  }
  public delegate void ValidationErrorEventHandler(object sender, 
                                                   ValidationErrorEventArgs e);

	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	public class MaskedTextBox_C : System.Windows.Forms.TextBox
	{
    #region local variables

    public event ValidationErrorEventHandler ValidationError;

    public enum FormatType
    {
      None,
      Date,
      Numbers,
      Alpha
    };
    string        mUserMask;
    FormatType    mFmt           = FormatType.None;
    char          mNumberPlace   = '#';
    char          mCue           = '_';
    string        mRegNum        = "[0-9]";
    char          mAlphaPlace    = '?';
    string        mRegAlpha      = "[A-Za-z]";
    string        mAnything      = ".*";
    string        mRegExpression = string.Empty;
    StringBuilder mText          = new StringBuilder();
    int           mValidationErrors;

    #endregion


		private System.ComponentModel.Container components = null;

		public MaskedTextBox_C()
		{
			InitializeComponent();

      mValidationErrors     = 0;
      this.Enter            += new EventHandler(MaskBoxEnter);
      this.Leave            += new EventHandler(MaskBoxLeave);
      this.KeyDown          += new KeyEventHandler(MaskBoxKeyDown);
      this.KeyPress         += new KeyPressEventHandler(MaskBoxKeyPress);
      this.Validated        += new EventHandler(MaskBoxValidated);
      this.ValidationError  += new ValidationErrorEventHandler(DefaultHandler);
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.Name = "MaskedTextBox";
    }
		#endregion

    #region New properties

    /// <summary>
    /// Sets one of three formats
    /// Date must be ##/##/####
    /// Numbers must be 0-9 exactly 8 digits.
    /// Alpha must be A-Z or a-z, exactly 8 digits
    /// </summary>
    public FormatType Format
    {
      get{return mFmt;}
      set
      {
        mFmt = value;
        mText = new StringBuilder();

        if(mFmt == FormatType.None)
        {
          mUserMask = "";
          mRegExpression = mAnything;
        }
        else if(mFmt == FormatType.Date)
        {
          mUserMask = "##/##/####";
          mText.Append("__/__/____");
          mRegExpression = "\\d{2}/\\d{2}/\\d{4}";
        }
        else if(mFmt == FormatType.Alpha)
        {
          mUserMask = "????????";
          mRegExpression = mRegAlpha + "{8}";
          mText.Append("________");
        }
        else if(mFmt == FormatType.Numbers)
        {
          mUserMask = "########";
          mRegExpression = mRegNum + "{8}";
          mText.Append("________");
        }
        Mask = mUserMask;
      }
    }

    /// <summary>
    /// If the Format property is set then 
    /// this property is invalid
    /// Mask properties recognized are:
    ///   # for number
    ///   ? for alpha (upper or lowercase)
    /// all other characters are literals   
    /// </summary>
    public string Mask
    {
      get{return mUserMask;}
      set
      {
        if(mFmt == FormatType.None)
        {
          mRegExpression = string.Empty;
          mText = new StringBuilder();
          mUserMask = value;
          char[] chars = mUserMask.ToCharArray();
          foreach(char c in chars)
          {
            if(c == mNumberPlace)
            {
              mRegExpression += mRegNum;
              mText.Append(mCue);
            }
            else if(c == mAlphaPlace)
            {
              mRegExpression += mRegAlpha;
              mText.Append(mCue);
            }
            else
            {
              mRegExpression += c.ToString();
              mText.Append(c);
            }
          }
        }
        this.Text = mText.ToString();
      }
    }

    #endregion

    #region hooked events

    private void MaskBoxValidated(object sender, EventArgs e)
    {
      if(!Regex.IsMatch(mText.ToString(), mRegExpression))
        RaiseError();
    }

    private void MaskBoxEnter(object sender, EventArgs e)
    {
      this.Text = mText.ToString();
      this.SelectionLength=0;
    }

    private void MaskBoxLeave(object sender, EventArgs e)
    {
      if(mUserMask == string.Empty)
      {
        mText = new StringBuilder(this.Text);
      }
    }

    private void MaskBoxKeyDown(object sender, KeyEventArgs e)
    {
      //No mask so let in any character
      if(mUserMask == string.Empty)
        return;

      int pos = this.SelectionStart;
      if(e.KeyData == Keys.Delete)
      {
        this.Text = DeleteLetter(ref pos);
        this.SelectionStart = pos;
      }
      e.Handled = true;
    }

    private void MaskBoxKeyPress(object sender, KeyPressEventArgs e)
    {
      //No mask so let in any character
      if(mUserMask == string.Empty)
        return;

      int pos = this.SelectionStart;
      this.Text = EnterLetter(ref pos, e.KeyChar);
      e.Handled = true;
      this.SelectionStart = pos;
    }

    //Special event to handle case of no-one connecting to my delegate
    //avoids a null reference
    private void DefaultHandler(object sender, ValidationErrorEventArgs e)
    {
      mValidationErrors++;
    }

    #endregion

    #region OnXXX event stuff

    public void RaiseError()
    {
      ValidationErrorEventArgs e = new ValidationErrorEventArgs(mUserMask, 
        mText.ToString());
      OnValidationError(e);
    }

    protected virtual void OnValidationError(ValidationErrorEventArgs e)
    {
      ValidationError(this, e);
    }

    #endregion

    #region Helper stuff

    public string EnterLetter(ref int position, char c)
    {
      //User pressed delete key
      if((int)c == 8)
      {
        position--;
        return DeleteLetter(ref position);
      }

      //User trying to go beyond bounds
      if(position >= mText.Length)
        return mText.ToString();

      //If we have hit a literal then advance one
      //Do this in a loop in case there are more literals.
      if(mText[position] != mCue)
        position++;

      //check to see if the character is ok
      if(mUserMask[position] == mNumberPlace)
      {
        if(Regex.IsMatch(c.ToString(), mRegNum))
        {
          mText[position] = c;
          position ++;
        }
      }
      else if(mUserMask[position] == mAlphaPlace)
      {
        if(Regex.IsMatch(c.ToString(), mRegAlpha))
        {
          mText[position] = c;
          position ++;
        }
      }

      return mText.ToString();
    }

    public string DeleteLetter(ref int pos)
    {
      //If the character to be deleted is a cue the bail out
      if(mText[pos] != mCue)
      {
        //If the character to be dleted is valid then change it back to a cue
        if(mUserMask[pos] == mNumberPlace || mUserMask[pos] == mAlphaPlace)
          mText[pos] = mCue;
      }
      return mText.ToString();
    }

    #endregion

	}
}
