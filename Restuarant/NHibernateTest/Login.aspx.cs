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
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ITransaction tx = null;
            ISession session = null;
            try
            {
                session = NHibernateHelper.GetCurrentSession();

                tx = session.BeginTransaction();

                DishItem princess = new DishItem();
                princess.Name = "Sesame Prawn Toast";
                princess.Desc = "Deep fried Toasts with Prawn powder and sesame";
                princess.Price = 4.40F;

                session.Save(princess);
                tx.Commit();

                NHibernateHelper.CloseSession();

                TextBox1.Text = "Successfully added Sesame Prawn Toast";
            }
            catch (Exception ex)
            {
                TextBox1.Text += ex.Message;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    TextBox1.Text += ex.Message;
                }

            }
            finally
            {
                if ((tx != null) && (tx.IsActive))
                    tx.Rollback();
                if (session != null && session.IsOpen)
                    session.Close();

            }

        }
    }
}
