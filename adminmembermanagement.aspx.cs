using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        
        //Go
        protected void LinkButton4_click(object sender, EventArgs e)
        {
            getUserByID();

        }
        //Activate
        protected void LinkButton1_click(object sender, EventArgs e)
        {
            updateMemberStatusByID("active");

        }
         //pending
        protected void LinkButton2_click(object sender, EventArgs e)
        {
            updateMemberStatusByID("pending");
        }
        //deactivate
        protected void LinkButton3_click(object sender, EventArgs e)
        {
            updateMemberStatusByID("deactive");
        }
        //delete user
        protected void Button2_Click(object sender, EventArgs e)
        {
            DeletememberbyId();

        }

        void getUserByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from member_master_tb1 where member_id='" + TextBox1.Text.Trim() +"'", con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {


                        TextBox2.Text= dr.GetValue(0).ToString();
                        TextBox7.Text = dr.GetValue(10).ToString();
                        TextBox8.Text = dr.GetValue(1).ToString();
                        TextBox8.Text = dr.GetValue(1).ToString();

                        TextBox3.Text = dr.GetValue(2).ToString();

                        TextBox4.Text = dr.GetValue(3).ToString();
                        TextBox9.Text = dr.GetValue(4).ToString();
                        TextBox10.Text = dr.GetValue(5).ToString();

                        TextBox11.Text = dr.GetValue(6).ToString();
                        TextBox6.Text = dr.GetValue(7).ToString();

                        /* Response.Write("<script>alert('Login sucessful');</script>");
                         Session["username"] = dr.GetValue(8).ToString();
                         Session["fullname"] = dr.GetValue(0).ToString();
                         Session["role"] = "user";
                         Session["status"] = dr.GetValue(10).ToString(); */


                    }
                   
                }
                else
                {


                    Response.Write("<script>alert('Invalid credentials');</script>");


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ')</script>");
            }
        }

        bool checkIfMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tb1 where member_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void updateMemberStatusByID(string status)
        {

            if (checkIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE member_master_tb1 SET account_status='" + status + "' WHERE member_id='" + TextBox1.Text.Trim() + "'", con);
                   
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Member Status Updated');</script>");



                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + " ')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid credentials ')</script>");
            }

            clearForm();
        }


       void DeletememberbyId()
        {
            if (checkIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand(" delete from member_master_tb1 where member_id='" + TextBox1.Text.Trim() + " ' ", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Deleted member sucessfully');</script>");
                    clearForm();
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert(' " + ex.Message + " ');</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('Member id is not exist ')</script>");
            }
            clearForm();
        }

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox6.Text = "";
        }
        protected void TextBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}