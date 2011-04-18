using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserControl_GvOrder : System.Web.UI.UserControl
{
    protected DataTable dtOrder;

    public bool Editable { get; set; }

    public DataTable TableOrder
    { get 
        {

            string tablename = this.Parent.ClientID + "order";
            dtOrder = (DataTable)Session[tablename];
            if (dtOrder == null)
            {
                dtOrder = new DataTable();
                Session[tablename] = dtOrder;
                PrepareOrderTable();
            }
            return dtOrder;
        }
     }

    protected override void  OnInit(EventArgs e)
    {
 	     base.OnInit(e);
            Editable = true;
    }

    public void Update()
    {
        GvOrder.Columns[3].Visible = Editable;
        GvOrder.Columns[4].Visible = Editable;
        GvOrder.DataSource = TableOrder;
        GvOrder.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            Update();
        }
    }

    protected void PrepareOrderTable()
    {
        dtOrder.TableName = "OrderItem";
        dtOrder.Columns.Add("Id", System.Type.GetType("System.Int64"));
        dtOrder.Columns.Add("Name", System.Type.GetType("System.String"));
        dtOrder.Columns.Add("Quantity", System.Type.GetType("System.Int32"));
        dtOrder.Columns.Add("SubPrice", System.Type.GetType("System.String"));
        dtOrder.Columns.Add("Price", System.Type.GetType("System.String"));
    }

 protected void GvOrder_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
       
    }

    protected void GvOrder_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
  
        
    }
    protected void GvOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int count = e.RowIndex;

        long id = (long)e.Keys["Id"];

        foreach (DataRow r in TableOrder.Rows)
        {
            if ((long)r[0] == id)
            {
                dtOrder.Rows.Remove(r);
                break;
            }
        }

        Update();
    }
    protected void GvOrder_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int i = e.RowIndex;

        DataRow rOrder = TableOrder.Rows[i];

        try
        {
            //int quant = Convert.ToInt16( e.NewValues[0]);

            GridViewRow row = GvOrder.Rows[e.RowIndex];
            int quant = Convert.ToInt16(((TextBox)(row.Cells[1].Controls[0])).Text);

            string s = (string)rOrder[4];

            if (s[0] > '9' || s[0] <= '0')
            {
                s = s.Substring(1);
            }
            
            rOrder["SubPrice"] = (Convert.ToDouble(s) * quant).ToString("C");

            rOrder["Quantity"] = quant;

            GvOrder.EditIndex = -1;

            Update();
        }
        catch (Exception ex)
        {

        }

        
    }
    protected void GvOrder_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GvOrder.EditIndex = e.NewEditIndex;
        Update();
    }
    protected void GvOrder_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //e.Cancel = true;
        //GvOrder.EditIndex = -1;
        //Update();
    }

}