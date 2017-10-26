using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OrderConfirm : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            ConnectGrid();
            if (Session["tot_price"] != null)
                totlb.Text = "Amount to be paid: " + (decimal)Session["tot_price"];
        }
    }

    private void ConnectGrid()
    {
        SqlConnection con = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = GroceryDB; Integrated Security = True");
        String id = GetIDFromCookie();
        SqlDataAdapter Adp = new SqlDataAdapter("select * from items where id in (" + id +")", con);
        DataTable Dt = new DataTable();
        Adp.Fill(Dt);
        Items.DataSource = GetNewDT(Dt);
        Items.DataBind();
    }

    private string GetIDFromCookie()
    {
        String str = "";
        //Check whether the cookie available or not.
        //Creating a cookie.
        HttpCookie cok = Request.Cookies[Request.QueryString["cook"]];

        if (cok != null)
        {
            //Getting multiple values from single cookie.
            NameValueCollection nameValueCollection = cok.Values;

            //Iterate the unique keys.
            foreach (string key in nameValueCollection.AllKeys)
            {
                str += key + ", ";
            }

        }
        return str.Substring(0,str.Length - 2);
    }

    private DataTable GetNewDT(DataTable dt)
    {
        DataColumn qty = new DataColumn("Quantty", typeof(System.Int32));
        dt.Columns.Add(qty);
        HttpCookie cok = Request.Cookies[Request.QueryString["cook"]];
        string[] arr = new string[100];
        if (cok != null)
        {
            //Getting multiple values from single cookie.
            NameValueCollection nameValueCollection = cok.Values;
            int i = 0;
            //Iterate the unique keys.
            foreach (string key in nameValueCollection.AllKeys)
            {
                arr[i++] = cok[key];
            }
            i = 0;
            foreach (DataRow row in dt.Rows)
            {
                row["Quantty"] = arr[i++];
            }
        }
        return dt;
    }

    protected void chkbtn_Click(object sender, EventArgs e)
    {
        successlb.Text = "Order Confirmed! " + "Mode of Payment is " + mopddl.SelectedItem.Text + " and Delivery Time is : " + dtrbl.SelectedItem.Text; 
        //System.Threading.Thread.Sleep(1000);
        Session.Clear();
        //Response.Redirect("Login.aspx");
    }

}