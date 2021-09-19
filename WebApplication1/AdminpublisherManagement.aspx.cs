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
    public partial class AdminpublisherManagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView2.DataBind();
          
        }

        //add
        protected void Button2_Click(object sender, EventArgs e)
        {

            if (checkifExist())
            {
                Response.Write("<script>alert('publisher id is exist please select different one')</script>");

            }
            else
            {
                Addpublisher();
                //Addauthor();
            }


        }

        //update
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkifExist())
            {
                //Updateauthor();
                Updatepublisher();

            }
            else
            {
                Response.Write("<script>alert('auth id is not exist')</script>");

            }
        }
        //delete
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkifExist())
            {
                // Deleteauthor();
                Deletepublisher();
            }
            else
            {
                Response.Write("<script>alert('auth id is not exist')</script>");

            }

        }
        //go
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkifExist())
            {
                // Deleteauthor();
                getPublisherByID();
            }
            else
            {
                Response.Write("<script>alert('publisher id is not exist')</script>");

            }

        }
        void getPublisherByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tb1 where publisher_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Author ID');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        bool checkifExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tb1 where publisher_id='" + TextBox1.Text.Trim() + "';", con);
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
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");
                return false;

            }
        }

        void Addpublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand(" insert into publisher_master_tb1(publisher_id,publisher_name)" +
                 "values(@id, @name)  ", con);

                cmd.Parameters.AddWithValue("@id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Signup as author sucessfully');</script>");
                clearForm();
                GridView2.DataBind();






            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");

            }
        }
        void Updatepublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                /*SqlCommand cmd = new SqlCommand("Update author_master_tb set auth_name=@auth_name where authid='"+TextBox1.Text.Trim()+ "'",
                  con); */
                SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tb1 SET publisher_name=@name WHERE publisher_id='" + TextBox1.Text.Trim() + "'", con);


                cmd.Parameters.AddWithValue("@name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert(' authorname updated  sucessfully');</script>");
                clearForm();
                GridView2.DataBind();





            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");

            }

        }
        void Deletepublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand(" delete from publisher_master_tb1 where publisher_id='" + TextBox1.Text.Trim() + " '",
                  con);



                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert(' author is sucessfully deleted');</script>");
                clearForm();

                GridView2.DataBind();




            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");

            }

        }

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}