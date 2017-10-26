using System;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Register_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = GroceryDB; Integrated Security = True");
        try
        {
            con.Open();
            
            bool exists = false;

            // create a command to check if the username exists
            using (SqlCommand cmd = new SqlCommand("select count(*) from USERS where Email = @Email", con))
            {
                cmd.Parameters.AddWithValue("Email", emailtb.Text);
                exists = (int)cmd.ExecuteScalar() > 0;
            }

            // if exists, show a message error
            if (exists)
                successlb.Text = "This username has been using by another user.";
            else
            {
                // does not exists, so, persist the user
                using (SqlCommand cmd = new SqlCommand("INSERT INTO USERS values (@Email, @Password, @Name, @Address, @Contact)", con))
                {
                    cmd.Parameters.AddWithValue("Email", emailtb.Text);
                    cmd.Parameters.AddWithValue("Password", getHashSha256(passtb.Text));
                    cmd.Parameters.AddWithValue("Name", nametb.Text);
                    cmd.Parameters.AddWithValue("Address", addtb.Text);
                    cmd.Parameters.AddWithValue("Contact", conttb.Text);

                    cmd.ExecuteNonQuery();
                }

                successlb.Text = "User Successfully Registered.";
                String urlRed = "Login.aspx?user=" + Server.UrlEncode(emailtb.Text);
                Response.Redirect(urlRed);
            }
            
        }
        catch (Exception x)
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