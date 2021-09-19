using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e) 
        {
            try
            {
                if (Session["role"] != null)
                {

                    if (Session["role"].Equals("user"))
                    {
                        LinkButton11.Visible = false;
                        LinkButton12.Visible = false;
                        LinkButton8.Visible = false;
                        LinkButton9.Visible = false;
                        LinkButton10.Visible = false;

                        LinkButton1.Visible = false;
                        LinkButton2.Visible = false;
                        LinkButton3.Visible = true;
                        LinkButton7.Visible = true;
                        LinkButton6.Visible = true;

                        LinkButton7.Text = "Hello" + Session["fullname"].ToString();

                    }
                    else if (Session["role"].Equals("admin"))
                    {

                        LinkButton11.Visible = true;
                        LinkButton12.Visible = true;
                        LinkButton8.Visible = true;
                        LinkButton9.Visible = true;
                        LinkButton10.Visible = true;
                        LinkButton6.Visible = false;

                        LinkButton1.Visible = false;
                        LinkButton2.Visible = false;
                        LinkButton3.Visible = true;
                        LinkButton7.Visible = true;
                        LinkButton7.Text = "Hello Admin";

                    }


                    else if (Session["role"].Equals(""))
                    {
                        LinkButton1.Visible= true;
                        LinkButton2.Visible = true;
                        LinkButton3.Visible = false;
                        LinkButton7.Visible = true;
                        LinkButton6.Visible = true;

                        LinkButton11.Visible = false;
                        LinkButton12.Visible = false;
                        LinkButton8.Visible = false;
                        LinkButton9.Visible = false;
                        LinkButton10.Visible = false;




                    }
                }
                else
                {
                    Session["role"] = "";

                }



            }
            catch(Exception ex)
            {
                Response.Write(ex);
            }
           

        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("Adminauthormanagement.aspx");


           }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminpublisherManagement.aspx");

        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {

            Response.Redirect("adminbookinventory.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("Adminbookissuing.aspx");


        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");

        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";


            LinkButton1.Visible = true; // user login link button
            LinkButton2.Visible = true;
            LinkButton3.Visible = false; // logout link button
            LinkButton7.Visible = true; // hello user link button


            LinkButton6.Visible = true; // admin login link button
            LinkButton11.Visible = false; // author management link button
            LinkButton12.Visible = false; // publisher management link button
            LinkButton8.Visible = false; // book inventory link button
            LinkButton9.Visible = false; // book issuing link button
            LinkButton10.Visible = false; // member management link button
            LinkButton7.Text = "Hello User";

            Response.Redirect("Homepage.aspx");

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Userlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usersignup.aspx");
        }
    }
}