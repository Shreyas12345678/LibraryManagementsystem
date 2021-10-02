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
    public partial class Adminauthormanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //add button click
        protected void Button2_Click(object sender, EventArgs e)
        {
           

                if (checkifExist())
                {
                    Response.Write("<script>alert('auth id is exist please select different one')</script>");

                }
                else
                {

                    Addauthor();
                }

           
          }
        //update
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkifExist())
            {
                Updateauthor();

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
                Deleteauthor();

            }
            else
            {
                Response.Write("<script>alert('auth id is not exist')</script>");

            }

        }

        //Go
        protected void Button1_Click(object sender, EventArgs e)
        {
            getAuthorByID();
        }

        //user defined function for checking author present or not

        void getAuthorByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from author_master_tb1 where authid='" + TextBox1.Text.Trim() + "';", con);
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

                SqlCommand cmd = new SqlCommand("SELECT * from author_master_tb1 where authid='" + TextBox1.Text.Trim() + "';", con);
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

        void Addauthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand(" insert into author_master_tb1(authid,auth_name)"+
                 "values(@authid, @auth_name)  ", con);

                cmd.Parameters.AddWithValue("@authid", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@auth_name", TextBox2.Text.Trim());
                
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Signup as author sucessfully');</script>");
                clearForm();
                GridView1.DataBind();






            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");

            }

        }

        void Updateauthor()
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
                SqlCommand cmd = new SqlCommand("UPDATE author_master_tb1 SET auth_name=@auth_name WHERE authid='" + TextBox1.Text.Trim() + "'", con);


                cmd.Parameters.AddWithValue("@auth_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert(' authorname updated sucessfully sucessfully');</script>");
                clearForm();
                GridView1.DataBind();





            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");

            }
        }
       void Deleteauthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand(" delete from author_master_tb1 where authid='" + TextBox1.Text.Trim() + " '",
                  con);

               

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert(' author is sucessfully deleted');</script>");
                clearForm();

                GridView1.DataBind();




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