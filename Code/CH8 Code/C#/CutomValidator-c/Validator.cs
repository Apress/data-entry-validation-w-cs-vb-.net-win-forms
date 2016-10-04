using System;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;

namespace CutomValidator_c
{

  [ProvideProperty("Required", typeof(Control))]
  public class Validator : Component,
                           IExtenderProvider
	{

    private System.Collections.Hashtable Props = new System.Collections.Hashtable();

		public Validator()
		{
    }

    bool IExtenderProvider.CanExtend(object target) 
    {
      if (target is TextBox || target is ComboBox) 
        return true;
      else
        return false;
    }


    public bool GetRequired(Control ctl)
    {
      if(Props.Contains(ctl))
        return (bool)Props[ctl];
      else
        return false;
    }

    public void SetRequired(Control ctl, bool val)
    {
      if(Props.Contains(ctl))
        Props[ctl] = val;
      else
      {
        Props.Add(ctl, val);
        ctl.Validating += new CancelEventHandler(ValidateProp);
      }
    }

    private void ValidateProp(object sender, CancelEventArgs e)
    {
      Control ctl = (Control)sender;
      if(GetRequired(ctl))
        if(ctl.Text == string.Empty)
          e.Cancel = true;
    }

  }
}
