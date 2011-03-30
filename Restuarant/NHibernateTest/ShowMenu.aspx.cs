using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


using NHibernate;
using NHibernate.Cfg;
using Restaurant;


namespace NHibernateTest
{
    
   
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected DataSet ds;

        protected DataSet dsOrder;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["menu"] == null)
            {
                ds = new DataSet();
                dsOrder = new DataSet();
                FillItemTable();
                PrepareOrderTable();
                Session["menu"] = ds;
                Session["order"] = dsOrder;
            }
            else
            {
                ds = (DataSet)Session["menu"];
                dsOrder = (DataSet)Session["order"];
            }



            GridView1.DataSource = ds;
            GridView2.DataSource = dsOrder;

            if (!IsPostBack)
            {
                GridView1.DataSourceID = "";
                GridView1.DataBind();
                GridView2.DataBind();
            }            

        }

        protected void PrepareOrderTable()
        {
            DataTable dtOrder = dsOrder.Tables.Add();
            dtOrder.TableName = "OrderItem";
            dtOrder.Columns.Add("Id", System.Type.GetType("System.Int64"));
            dtOrder.Columns.Add("Name", System.Type.GetType("System.String"));
            dtOrder.Columns.Add("Quantity", System.Type.GetType("System.Int32"));
            dtOrder.Columns.Add("Price", System.Type.GetType("System.String"));
        }

        protected void FillItemTable()
        {
            //SELECT [Id], [Name], [Descript], [Price] FROM [DishItem]


            ISession session = NHibernateHelper.GetCurrentSession();
            ITransaction tx = session.BeginTransaction();

            DataTable dt = ds.Tables.Add();

            IQuery query = session.CreateQuery("select c from DishItem as c where c.Id <= :MaxID");
            query.SetInt64("MaxID", 10);
            
            dt.TableName = "DishItem";

            dt.Columns.Add("Id",System.Type.GetType("System.Int64"));
            dt.Columns.Add("Name",System.Type.GetType("System.String"));
            dt.Columns.Add("Descript",System.Type.GetType("System.String"));
            dt.Columns.Add("Price",System.Type.GetType("System.String"));            
            foreach (DishItem item in query.Enumerable())
            {
                DataRow row = dt.NewRow();
                row["Id"] = item.Id;
                row["Name"] = item.Name;
                row["Descript"] = item.Desc;
                row["Price"] = item.Price.ToString("f2");
                dt.Rows.Add(row);
            }

            tx.Commit();

            NHibernateHelper.CloseSession();
        }

        protected void GridView1_DataBinding(object sender, EventArgs e)
        {
            // "<p> oops, there is no data here !</p>";

           
           

           

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //
            if (e.CommandName == "Order")
            {
               // property to an Integer.
              int index = Convert.ToInt32(e.CommandArgument);

              // Retrieve the row that contains the button clicked
              // by the user from the Rows collection. Use the
              // CommandSource property to access the GridView control.
              GridView customersGridView = (GridView)e.CommandSource;
              GridViewRow row = customersGridView.Rows[index];

              DataRow rOrder = dsOrder.Tables[0].Rows.Add();

              rOrder["Id"] = Convert.ToInt64( row.Cells[0].Text);
              rOrder["Name"] = row.Cells[1].Text;
              rOrder["Quantity"] = 1;
              rOrder["Price"] = row.Cells[3].Text;

              // Create a new ListItem object for the customer in the row.


              if ((row.FindControl("TextBox1") != null) && row.FindControl("TextBox1").GetType().ToString().Contains("TextBox"))
              {
                  TextBox tb = (TextBox)row.FindControl("TextBox1");
                  try
                  {
                      int quant = Convert.ToInt16(tb.Text);

                      rOrder["Quantity"] = quant;
                      rOrder["Price"] = (Convert.ToDouble( row.Cells[3].Text) * quant).ToString("C");
                  }
                  catch(Exception ex)
                  {
                  }
              }

              GridView2.DataBind();

            }
        }
    }
}
