using System;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Vlad_C
{

  [ProvideProperty("Required",            typeof(Control))]
  [ProvideProperty("RangeValueRequired",  typeof(Control))]
  [ProvideProperty("MinValue",            typeof(Control))]
  [ProvideProperty("MaxValue",            typeof(Control))]
  public class NumberValidate : Component, IExtenderProvider
  {
    #region locals

    // holds Key - value pair for efficient retrieval
    //Holds all properties of all controls that use this extender.
    private System.Collections.Hashtable CustomProps  = 
                        new System.Collections.Hashtable();

    ErrorProvider er = new ErrorProvider();
    ToolTip       tp = new ToolTip();
    
    //Holds all the custom properties of a control
    private class Props
    {
      public bool Required      = false;
      public bool RangeRequired = false;
      public Decimal  MinVal    = 0;
      public Decimal  MaxVal    = 999;
    }

    #endregion


    public NumberValidate()
    {
    }

    bool IExtenderProvider.CanExtend(object target) 
    {
      if (target is TextBox) 
      {
        TextBox t = (TextBox)target;
        tp.Active = true;
        return true;
      }
      else
        return false;
    }

    private void SetToolTip(Control ctl)
    {
      string tip = string.Empty;
      Props p = (Props)CustomProps[ctl];
      if(p.Required)
        tip = "Validation of numbers required";
      if(p.RangeRequired)
      {
        tip += " / Number range required";
        tip += " / Min value = " + p.MinVal.ToString();
        tip += " / Max value = " + p.MaxVal.ToString();
      }
      tp.SetToolTip(ctl, tip);
    }

    #region RangeValue required

    //Get method for range required
    public bool GetRangeValueRequired(Control ctl)
    {
      //This makes best use of a hashtable for quick retrieval
      if(CustomProps.Contains(ctl))
      {
        Props p = (Props)CustomProps[ctl];
        SetToolTip(ctl);
        return p.RangeRequired;
      }
      else
        return false;
    }

    //Set method for Range required
    public void SetRangeValueRequired(Control ctl, bool val)
    {
      if(CustomProps.Contains(ctl))
      {
        //See if this property is already correctly set
        Props p = (Props)CustomProps[ctl];
        if(val == p.RangeRequired)
          return;

        //Set this property and add it back to the list
        p.RangeRequired = val;
        CustomProps[ctl] = p;
        if(val)
        {
          ctl.KeyPress   += new KeyPressEventHandler(KeyPress);
          ctl.Validating += new CancelEventHandler(ValidateProp);
        }
        else
        {
          ctl.KeyPress   -= new KeyPressEventHandler(KeyPress);
          ctl.Validating -= new CancelEventHandler(ValidateProp);
        }
        SetToolTip(ctl);
      }
      else
      {
        //Set this property and add it to the list
        Props p = new Props();
        p.RangeRequired = val;
        CustomProps.Add(ctl, p);
        if(val)
          ctl.KeyPress += new KeyPressEventHandler(KeyPress);

        SetToolTip(ctl);
      }
    }

    #endregion

    #region Min and Max Values

    public Decimal GetMinValue(Control ctl)
    {
      if(CustomProps.Contains(ctl))
      {
        Props p = (Props)CustomProps[ctl];
        SetToolTip(ctl);
        return p.MinVal;
      }
      else
        return 0;
    }

    [DefaultValue(0)]
    public void SetMinValue(Control ctl, Decimal val)
    {
      if(val < 0)
        val = 0;

      if(CustomProps.Contains(ctl))
      {
        Props p = (Props)CustomProps[ctl];
        p.MinVal = val;
        CustomProps[ctl] = p;
        SetToolTip(ctl);
      }
      else
      {
        Props p = new Props();
        p.MinVal = val;
        CustomProps.Add(ctl, p);
        SetToolTip(ctl);
      }
    }

    public Decimal GetMaxValue(Control ctl)
    {
      if(CustomProps.Contains(ctl))
      {
        Props p = (Props)CustomProps[ctl];
        SetToolTip(ctl);
        return p.MaxVal;
      }
      else
        return 999;
    }

    [DefaultValue(999)]
    public void SetMaxValue(Control ctl, Decimal val)
    {
      if(val > 999)
        val = 999;

      if(CustomProps.Contains(ctl))
      {
        Props p = (Props)CustomProps[ctl];
        p.MaxVal = val;
        CustomProps[ctl] = p;
        SetToolTip(ctl);
      }
      else
      {
        Props p = new Props();
        p.MaxVal = val;
        CustomProps.Add(ctl, p);
        SetToolTip(ctl);
      }
    }

    #endregion

    #region Required property

    public bool GetRequired(Control ctl)
    {
      if(CustomProps.Contains(ctl))
      {
        Props p = (Props)CustomProps[ctl];
        SetToolTip(ctl);
        return p.Required;
      }
      else
        return false;
    }

    public void SetRequired(Control ctl, bool val)
    {
      if(CustomProps.Contains(ctl))
      {
        Props p = (Props)CustomProps[ctl];
        if(val == p.Required)
          return;

        p.Required = val;
        CustomProps[ctl] = p;
        SetToolTip(ctl);
        if(val)
        {
          ctl.KeyPress   += new KeyPressEventHandler(KeyPress);
          ctl.Validating += new CancelEventHandler(ValidateProp);
        }
        else
        {
          ctl.KeyPress   -= new KeyPressEventHandler(KeyPress);
          ctl.Validating -= new CancelEventHandler(ValidateProp);
        }
      }
      else
      {
        Props p = new Props();
        p.Required = val;

        CustomProps.Add(ctl, p);
        SetToolTip(ctl);
        ctl.Validating += new CancelEventHandler(ValidateProp);
      }
    }

    #endregion

    #region events

    private void KeyPress(object sender, KeyPressEventArgs e)
    {
      //Allow backspace
      if(e.KeyChar == (char)8)
        return;

      //Allow 0-9
      if(!Regex.IsMatch(e.KeyChar.ToString(), "[0-9]"))
        e.Handled = true;
    }

    private void ValidateProp(object sender, CancelEventArgs e)
    {
      Control ctl = (Control)sender;

      //Reset the error
      er.SetError(ctl, "");

      if(GetRequired(ctl))
      {
        if(ctl.Text == string.Empty)
        {
          er.SetError(ctl, "No value was entered when one was required");
          return;
        }

        if(GetRangeValueRequired(ctl))
        {
          Props p = (Props)CustomProps[ctl];
          if(Decimal.Parse(ctl.Text) < p.MinVal)
            er.SetError(ctl, "Value entered is less than minimum value");
          if(Decimal.Parse(ctl.Text) > p.MaxVal)
            er.SetError(ctl, "Value entered is greater than minimum value");
        }
      }
    }

    #endregion
  }

}
