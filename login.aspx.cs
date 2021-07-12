using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webapp.BL;
namespace webapp
{
    public partial class login : System.Web.UI.Page
    {
        protected void btn_login_Click(object sender, EventArgs e)
        {
            admin_entity ad = new admin_entity { a_user = TextBox1.Text, a_pwd = TextBox2.Text };
            bal_ ob = new bal_();
            string str = ob.login(ad);
            switch(str)
            {
                case "user":
                    Response.Write("<script>invalid user!!!</script>");
                    TextBox1.Text = "";
                    TextBox1.Focus();
                    break;
                case "pwd":
                    Response.Write("<script>invalid password!!!</script>");
                    TextBox2.Text = "";
                    TextBox2.Focus();
                    break;
                case "error":
                    Response.Write("<script>pls check database error!!!</script>");
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox1.Focus();
                    break;
                case "error1":
                    Response.Write("<script>pls login error!!!</script>");
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox1.Focus();
                    break;
                default:
                    string[] arr = str.Split(',');
                    //login success
                    Response.Write("<script>thx for login </script>");
                    Session.Add("login", Session.SessionID.ToString());
                    Response.Cookies["login"]["name"] = arr[0];
                    Response.Cookies["login"]["user"] = arr[1];
                    Response.Cookies["login"]["password"] = arr[2];
                    Session.Timeout = 40;
                    Response.Redirect("dashboard_home.aspx");
                    break;
            }
        }
        protected void btn_cancel_Click(object sender, EventArgs e)
        {

        }
    }
}




