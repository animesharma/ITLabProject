using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainPage : System.Web.UI.Page
{
    Dictionary<String, int> cart = new Dictionary<string, int>();
    decimal tot_price = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ConnectGrid();
        }
        else
        {
            if(Session["cart"]!=null)
            cart = (Dictionary<String, int>)Session["cart"];
            if(Session["tot_price"]!=null)
                tot_price = (decimal)Session["tot_price"];
        }
    }

    private void ConnectGrid()
    {
        SqlConnection con = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = GroceryDB; Integrated Security = True");
        SqlDataAdapter Adp = new SqlDataAdapter("select * from items", con);
        DataTable Dt = new DataTable();
        Adp.Fill(Dt);
        Items.DataSource = Dt;
        Items.DataBind();
    }

    protected void grid_qty_TextChanged(object sender, EventArgs e)
    {
        GridViewRow row = Items.Rows[((sender as TextBox).NamingContainer as GridViewRow).RowIndex];
        Label subTotal = (Label)row.Cells[4].Controls[0].FindControl("grid_st");
        Label price = (Label)row.Cells[2].Controls[0].FindControl("grid_price");
        Label id = (Label)row.Cells[0].Controls[0].FindControl("grid_id");
        TextBox quan = (TextBox)sender;
        if (quan.Text == "")
        {
            if (cart.ContainsKey(id.Text))
            {
                tot_price -= decimal.Parse(price.Text) * cart[id.Text];
                cart.Remove(id.Text);
                subTotal.Text = "";
                updateTotalField();
            }
            return;
        }
        decimal st = decimal.Parse(price.Text) * int.Parse(quan.Text);
        subTotal.Text = "Rs. " + st;
        if (cart.ContainsKey(id.Text))
        {
            tot_price -= cart[id.Text] * decimal.Parse(price.Text);
            cart[id.Text] = int.Parse(quan.Text);
            tot_price += cart[id.Text] * decimal.Parse(price.Text);
        }
        else
        {
            cart[id.Text] = int.Parse(quan.Text);
            tot_price += cart[id.Text] * decimal.Parse(price.Text);
        }
        updateTotalField();
    }

    private void updateTotalField()
    {
        total.Text = "TOTAL : Rs. " + tot_price;
        Session["cart"] = cart;
        Session["tot_price"] = tot_price;
    }

    protected void searchbtn_Click(object sender, EventArgs e)
    {

    }
}