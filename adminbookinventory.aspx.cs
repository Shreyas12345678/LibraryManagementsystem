using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class adminbookinventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Fillauthorpublisher();
            GridView1.DataBind();
        }
      
        

        //Add
        protected void Button1_click(object sender, EventArgs e)
        {

            if (checkiBookifExist())
            {
                Response.Write("<script>alert('already there try some other! ')</script>");
            }
            else
            {
                Addnewbook();

            }
        }
        //update
        protected void Button3_clcik(object sender, EventArgs e)
        {

            if (checkiBookifExist())
            {

                UpdateBookid();
            }
            else
            {
                Response.Write("Book does not exist");
            }


        }
        //delete
        protected void Button2_click(object sender, EventArgs e)
        {

        }

        //Go
        protected void Button4_Click(object sender, EventArgs e)
        {

        }

        bool checkiBookifExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tb1 where book_id='" + TextBox1.Text.Trim() + "' OR book_name='" + TextBox2.Text.Trim() + "';", con);
                
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

        void Fillauthorpublisher()
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
                SqlCommand cmd = new SqlCommand("select auth_name from author_master_tb1", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "auth_name";
                DropDownList3.DataBind();


                 cmd = new SqlCommand("select publisher_name from publisher_master_tb1", con);
                 da = new SqlDataAdapter(cmd);
                 dt = new DataTable();
                 da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "publisher_name";
                DropDownList2.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");

            }
        }
        void Addnewbook()

        {

            try
            {

                string filepath = "~/BooksInventory_images/books1.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("BooksInventory_images/" + filename));
                filepath = "~/BooksInventory_images/" + filename;



                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                /*  SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tb1(book_id,book_name,author_name,publisher_name,publish_date,language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock) values(@book_id,@book_name,@author_name,@publisher_name,@publish_date,@language,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock)", con);*/
                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tb1(book_id,book_name,author_name) values(@book_id,@book_name,@author_name)", con);
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                
                cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
               /* cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                
                cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);   
                cmd.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", TextBox4.Text.Trim());*/
                

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book added successfully');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }



        }

        void UpdateBookid()
        {


            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        


    }
}