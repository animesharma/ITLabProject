using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Initial : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["login"] != null)
        {
            l0.Text = "Welcome " + Session["login"].ToString();
            logout.Visible = true;
        }
        if (Session["manager"] != null)
        {
            if(Session["manager"].ToString() == "True")
                mmode.Visible = true;
        }

        if (Session["theme"] != null)
            theme_ddl.SelectedValue = (String) Session["theme"];

        if (Page.IsPostBack)
        {
            return;
        }
    }

    protected void Register_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }

    protected void Login_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void logout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("Login.aspx");
    }

    protected void mm_Click(Object sender, EventArgs e)
    {
        Response.Redirect("Manager.aspx");
    }

    protected void theme_ddl_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((String)Session["Theme"] == "Monochrome")
        {
            Session["Theme"] = "DarkGrey";
        }else if((String)Session["Theme"] == "DarkGrey")
        {
            Session["Theme"] = "Monochrome";
        }
        else
        {
            Session["Theme"] = theme_ddl.SelectedValue;
        }
        Server.Transfer(Request.FilePath);
    }
}
