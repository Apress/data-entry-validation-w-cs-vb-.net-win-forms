using System;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Vlad_c
{
  /// <summary>
  /// Allow user to enter a regular expression for validation purposes
  /// </summary>
  
  [ProvideProperty("Required",          typeof(Control))]
  [ProvideProperty("RegularExpression", typeof(Control))]
  public class RegxValidate: Component, IExtenderProvider
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
      public bool Required  = false;
      public string Regx    = ".*";
    }

    #endregion

		public RegxValidate()
		{
		}

    bool IExtenderProvider.CanExtend(object target) 
    {
      //Target can be anything; like a ComboBox if needed
      //Target can be multiple things also
      if (target is TextBox) 
      {
        return true;
      }
      else
        return false;
    }

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
          ctl.Validating += new CancelEventHandler(ValidateProp);
        else
          ctl.Validating -= new CancelEventHandler(ValidateProp);
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

    #region Regular Expression property

    public string GetRegularExpression(Control ctl)
    {
      if(CustomProps.Contains(ctl))
      {
        Props p = (Props)CustomProps[ctl];
        SetToolTip(ctl);
        return p.Regx;
      }
      else
        return ".*";
    }

    [DefaultValue("")]
    public void SetRegularExpression(Control ctl, string val)
    {
      //Put something here to verify that regular expression is valid
      try
      {
        Regex.IsMatch("abcdefg", val);
      }
      catch(Exception e)
      {
        string err = "Invalid Regular Expression on:\n";
        err += ctl.Name + "\n\n" + e.Message;
        MessageBox.Show(err);
        er.SetError(ctl, "Invalid Regular Expression!!");
        return;
      }

      if(CustomProps.Contains(ctl))
      {
        Props p = (Props)CustomProps[ctl];
        p.Regx = val;
        CustomProps[ctl] = p;
      }
      else
      {
        Props p = new Props();
        p.Regx = val;
        CustomProps.Add(ctl, p);
      }
      SetToolTip(ctl);
    }

    #endregion

    #region events

    private void ValidateProp(object sender, CancelEventArgs e)
    {
      Control ctl = (Control)sender;

      //Reset the error
      er.SetError(ctl, "");

      if(GetRequired(ctl))
      {
        Props p = (Props)CustomProps[ctl];
        if(!Regex.IsMatch(ctl.Text, p.Regx))
          er.SetError(ctl, "Value did not match input restrictions");
        return;
      }
    }

    #endregion

    #region other stuff

    private void SetToolTip(Control ctl)
    {
      string tip = string.Empty;
      tp.Active = false;
      SetTooltipActive();
      Props p = (Props)CustomProps[ctl];
      if(p.Required)
        tip = "Regular Expression validation: " + p.Regx ;
      tp.SetToolTip(ctl, tip);
    }

    [Conditional("DEBUG")]
    private void SetTooltipActive()
    {
      tp.Active = true;
    }

    #endregion
	}
}
