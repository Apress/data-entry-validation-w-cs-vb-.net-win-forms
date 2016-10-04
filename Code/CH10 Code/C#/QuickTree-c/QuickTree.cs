using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Threading;

namespace QuickTree_c
{
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
  public class QuickTree : System.Windows.Forms.UserControl
  {

    #region vars

    private delegate void NodeAddDelegate(TreeNode[] tnodes);
    private               NodeAddDelegate NodeDelegate;

    private               EventHandler    onFillComplete;
    public event          EventHandler    FillComplete;

    private               ArrayList       tnodes;
    private               TreeNode        BaseNode;
    private               Thread          FillThread;
    private               bool            filling;
    private               bool            WaitForFill;

    #endregion

    public System.Windows.Forms.TreeView tree;
    private System.ComponentModel.Container components = null;

    public QuickTree()
    {
      InitializeComponent();

      tnodes          = new ArrayList();
      NodeDelegate    = new NodeAddDelegate(AddNodes);
      onFillComplete  = new EventHandler(OnFillComplete);
      filling         = false;
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
      this.tree = new System.Windows.Forms.TreeView();
      this.SuspendLayout();
      // 
      // tree
      // 
      this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tree.ImageIndex = -1;
      this.tree.Name = "tree";
      this.tree.SelectedImageIndex = -1;
      this.tree.Size = new System.Drawing.Size(150, 150);
      this.tree.TabIndex = 0;
      // 
      // UserControl1
      // 
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.tree});
      this.Name = "QuickTree";
      this.ResumeLayout(false);

    }
		#endregion

    #region properties/methods

    public bool OK2Fill
    {
      get{return !filling;}
    }

    public ArrayList Strings
    {
      set
      {
        if(!filling)
          tnodes = (ArrayList)value.Clone();
      }
    }

    public void StartFill(TreeNode node)
    {
      BaseNode = node;
      
      //Do not interrupt a fill
      if(filling)
        return;

      //Make sure that someone actually put this control on the form
      //This could have been called without intializing the tree.
      if(tree.IsHandleCreated)
      {
        filling = true;
        FillThread = new Thread(new ThreadStart(tnodeThread));
        FillThread.Start();
      }
      else
        WaitForFill = true;
    }

    public void StopFill()
    {
      //Obviously if I am not filling then no need to join threads
      if (!filling)
      {
        return;
      }

      if (FillThread.IsAlive)
      {
        FillThread.Abort();
        FillThread.Join();
      }

      FillThread = null;
      filling = false;
    }

    #endregion

    #region events/Delegates

    //If the user kills the program before the tree has filled then you will
    //need to stop the fill first.  This is why the Base.OnHandleDestroyed
    //is called after the stop fill.
    protected override void OnHandleDestroyed(EventArgs e)
    {
      if (!tree.RecreatingHandle)
        StopFill();
      base.OnHandleDestroyed(e);
    }

    //This overidden method sort of delays things a little if the calling program 
    //was too agressive and started a fill before the tree was ready to accept it
    protected override void OnHandleCreated(EventArgs e)
    {
      base.OnHandleCreated(e);
      if(WaitForFill)
      {
        WaitForFill = false;
        StartFill(BaseNode);
      }
    }

    //This method is called via a BeginInvoke by the background
    //thread
    private void AddNodes(TreeNode[] tnodes)
    {
      tree.BeginUpdate();

      if(BaseNode != null)
      {
        BaseNode.Nodes.AddRange(tnodes);
        BaseNode.Expand();
      }
      else
        tree.Nodes.AddRange(tnodes);

      tree.EndUpdate();
    }

    //This method is called by the background thread when it is
    //finished handing over all the nodes it needs to add.
    private void OnFillComplete(object sender, EventArgs e)
    {
      //Only call this delegate if someone has hooked up to it
      //otherwise it is null and you will get a major crash.  C# ONLY!!
      if(FillComplete != null)
        FillComplete(sender, e);
    }

    #endregion

    #region Worker Thread

    private void tnodeThread()
    {
      ArrayList NodeList = new ArrayList();
      Array NodeArray;

      try
      {
        tnodes.TrimToSize();
        for(int k=0; k<tnodes.Count; k++)
        {
          NodeList.Add(new TreeNode((string)tnodes[k]));
          if(decimal.Remainder((decimal)NodeList.Count, 20) == 0)
          {
            NodeArray = Array.CreateInstance(typeof(TreeNode), NodeList.Count);
            NodeList.CopyTo(NodeArray);
            IAsyncResult r = this.BeginInvoke(NodeDelegate, 
                                              new object[] {NodeArray});
            NodeList.Clear();
            //Sleep for 500 milliseconds to pretend we are doing something 
            //really complicated
            Thread.Sleep(300);
          }
        }
        if(NodeList.Count > 0)
        {
          NodeArray = Array.CreateInstance(typeof(TreeNode), NodeList.Count);
          NodeList.CopyTo(NodeArray);
          IAsyncResult r = this.BeginInvoke(NodeDelegate, 
                                            new object[] {NodeArray});
        }
      }
      finally
      {
        filling = false;
        //I could raise the event from here but it would be comming from
        //a different thread.  If A client did not know this was a multithreaded
        //control then it could expect the event to be raised from the same 
        //thread that the client is in.
        BeginInvoke(onFillComplete, new object[] {this, EventArgs.Empty});
      }

    }

    #endregion

	}
}
