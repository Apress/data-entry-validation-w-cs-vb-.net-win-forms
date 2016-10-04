using System;
using System.Text;
using System.Text.RegularExpressions;

namespace MaskClient_c
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
  public delegate void ValidationErrorEventHandler(object sender, ValidationErrorEventArgs e);

  public class maskedregx
	{

    public event ValidationErrorEventHandler ValidationError;

    #region global and local variables

    public enum FormatType
    {
      None,
      Date,
      Numbers,
      Alpha
    };
    string     mUserMask;
    FormatType mFmt           = FormatType.None;
    char       mNumberPlace   = '#';
    char       mCue           = '_';
    string     mRegNum        = "[0-9]";
    char       mAlphaPlace    = '?';
    string     mRegAlpha      = "[A-Za-z]";
    string     mAnything      = ".*";
    string     mRegExpression = string.Empty;
    StringBuilder     mText = new StringBuilder();


    #endregion

    #region New properties

    /// <summary>
    /// Sets one of three formats
    /// Date must be ##/##/####
    /// Numbers must be 0-9
    /// Alpha must be A-Z or a-z
    /// </summary>
    public FormatType Format
    {
      get{return mFmt;}
      set
      {
        mFmt = value;
        if(mFmt != FormatType.None)
          Mask = "";
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
        else
        {
          mUserMask = "";
          mRegExpression = mAnything;
        }
  //      this.Text = mUserMask;
      }
    }

    public string Text
    {
      get{return mText.ToString();}
    }

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
      char q = mUserMask[position];
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


    public void Leave()
    {
      if(!Regex.IsMatch(mText.ToString(), mRegExpression))
        RaiseError();
    }

    #endregion

    #region errors

    public void RaiseError()
    {
      ValidationErrorEventArgs e = new ValidationErrorEventArgs(mUserMask, mText.ToString());
      OnValidationError(e);
    }

    protected virtual void OnValidationError(ValidationErrorEventArgs e)
    {
      ValidationError(this, e);
    }

    #endregion

		public maskedregx()
		{
		}
	}
}
