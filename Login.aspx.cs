using System;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string user = Request.QueryString["user"];
        if (user != null)
        {
            emailtb.Text = user;
        }
    }

    protected void Login_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = GroceryDB; Integrated Security = True");
        try
        {
            con.Open();

            bool exists = false;

            // create a command to check if the username exists
            using (SqlCommand cmd = new SqlCommand("select count(*) from USERS where Email = @Email AND Password = @Password", con))
            {
                cmd.Parameters.AddWithValue("Email", emailtb.Text);
                cmd.Parameters.AddWithValue("Password", getHashSha256(passtb.Text));
                exists = (int)cmd.ExecuteScalar() > 0;
            }

            if (exists)
                successlb.Text = "Authentication Successful!";
            else successlb.Text = "Authentication Unsuccessful! Please try again!";
        } catch (Exception x)
        {
            successlb.Text = x.Message.ToString();
        }
    }

    public static string getHashSha256(string text)
    {
        byte[] bytes = Encoding.Unicode.GetBytes(text);
        SHA256Managed hashstring = new SHA256Managed();
        byte[] hash = hashstring.ComputeHash(bytes);
        string hashString = string.Empty;
        foreach (byte x in hash)
        {
            hashString += String.Format("{0:x2}", x);
        }
        return hashString;
    }
}