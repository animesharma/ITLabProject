using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager : System.Web.UI.Page
{


    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["Theme"] != null)
        {
            Page.Theme = Session["Theme"].ToString();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void query_Click(object sender, EventArgs e)
    {
        queryp.Visible = true;
    }

    protected void execute_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = GroceryDB; Integrated Security = True");
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(querytb.Text, con);
            cmd.ExecuteNonQuery();
        }catch(Exception x)
        {
            quelb.Text = x.Message.ToString();
        }
        finally
        {
            con.Close();
        }

    }
}