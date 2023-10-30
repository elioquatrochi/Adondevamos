using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adondevamos.Page
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
if (Session["usuario"] != null)
            {
                divuser.Visible = true;
                lblusuario.Text = Session["usuario"].ToString();


            }
            else
            {
                divuser.Visible = false;
                lblusuario.Text = string.Empty;

            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Session["Id"] = null;
            Response.Redirect("Login");
            HttpContext.Current.Session.Abandon();
        }
    }
}