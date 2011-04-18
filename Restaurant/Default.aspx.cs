using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RestaurantApp;

public partial class _Default : System.Web.UI.Page
{
    protected DataTable dtOrder = null;
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            DataTable dt = RestaurantBiz.getDishItems();
            GridView1.DataSource = dt;
            GridView1.DataSourceID = "";
            GridView1.DataBind();

            dtOrder = new DataTable();
            Session["order"] = dtOrder;
            PrepareOrderTable();

            GridView2.DataSource = dtOrder;
            GridView2.DataBind();
        }
        else
        {
            dtOrder = (DataTable)Session["order"];
            if (dtOrder == null)
            {
                dtOrder = new DataTable();
                Session["order"] = dtOrder;
                PrepareOrderTable();
            }
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

    protected void GridView1_DataBinding(object sender, EventArgs e)
    {
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Order")
        {
            // property to an Integer.
            int index = Convert.ToInt32(e.CommandArgument);

            // Retrieve the row that contains the button clicked
            // by the user from the Rows collection. Use the
            // CommandSource property to access the GridView control.
            GridView customersGridView = (GridView)e.CommandSource;
            GridViewRow row = customersGridView.Rows[index];

            DataRow rOrder = dtOrder.Rows.Add();

            rOrder["Id"] = Convert.ToInt64(row.Cells[0].Text);
            rOrder["Name"] = row.Cells[1].Text;
            rOrder["Quantity"] = 1;
            rOrder["SubPrice"] = row.Cells[3].Text;
            rOrder["Price"] = row.Cells[3].Text;

            // Create a new ListItem object for the customer in the row.


            if ((row.FindControl("TextBox1") != null) && row.FindControl("TextBox1").GetType().ToString().Contains("TextBox"))
            {
                TextBox tb = (TextBox)row.FindControl("TextBox1");
                try
                {
                    int quant = Convert.ToInt16(tb.Text);

                    rOrder["Quantity"] = quant;
                    rOrder["SubPrice"] = (Convert.ToDouble(row.Cells[3].Text) * quant).ToString("C");
                }
                catch (Exception ex)
                {
                    
                }
            }


            DataRow r = GvOrder1.TableOrder.Rows.Add();

            for (int i = 0; i < r.Table.Columns.Count; i++)
            {
                r[i] = rOrder[i];
            }

            GvOrder1.Update();

            GridView2.DataSource = dtOrder;
            GridView2.DataBind();

        }
    }
    protected void GridView2_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
       
    }

    protected void GridView2_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
  
        
    }
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int count = e.RowIndex;

        long id = (long)e.Keys["Id"];

        foreach (DataRow r in dtOrder.Rows)
        {
            if ((long)r[0] == id)
            {
                dtOrder.Rows.Remove(r);
                GvOrder1.TableOrder.Rows.RemoveAt(count);
                break;
            }
        }

        GridView2.DataSource = dtOrder;
        GridView2.DataBind();
    }
    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int i = e.RowIndex;

        DataRow rOrder = dtOrder.Rows[i];

        try
        {
            //int quant = Convert.ToInt16( e.NewValues[0]);

            GridViewRow row = GridView2.Rows[e.RowIndex];
            int quant = Convert.ToInt16(((TextBox)(row.Cells[1].Controls[0])).Text);

            string s = (string)rOrder[4];

            if (s[0] > '9' || s[0] <= '0')
            {
                s = s.Substring(1);
            }
            
            rOrder["SubPrice"] = (Convert.ToDouble(s) * quant).ToString("C");

            rOrder["Quantity"] = quant;

            GridView2.EditIndex = -1;

            GridView2.DataSource = dtOrder;
            GridView2.DataBind();
        }
        catch (Exception ex)
        {

        }

        
    }
    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView2.EditIndex = e.NewEditIndex;
        GridView2.DataSource = dtOrder;
        GridView2.DataBind();
    }
    protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //e.Cancel = true;
        GridView2.EditIndex = -1;
        GridView2.DataSource = dtOrder;
        GridView2.DataBind();
    }
}
