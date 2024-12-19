using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grocery_store
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }


     

        private void button1_Click(object sender, EventArgs e)
        {
            string username = text2.Text;
            string Password = text3.Text;
            string Fullname = text4.Text;
            string  roleid = text5.Text;

            // Connection string to connect to the SQL Server database  
            string connStr = "Data Source=DESKTOP-677VPCL\\SQLEXPRESS;Initial Catalog=InventoryDB;Integrated Security=True";

            // Create a new SqlConnection  
            using (SqlConnection con = new SqlConnection(connStr))
            {
                // Try to open the connection  
                try
                {
                    con.Open();

                    // Define the SQL query to insert the user info into the user_info table  
                    string query = "INSERT INTO user_info (username,password,Fullname,role_id) VALUES (@n,@p,@f,@rid)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Add parameters with values  
                        
                        cmd.Parameters.Add(new SqlParameter("@n", username));
                        cmd.Parameters.Add(new SqlParameter("@p", Password));
                        cmd.Parameters.Add(new SqlParameter("@f", Fullname));
                        cmd.Parameters.Add(new SqlParameter("@rid", roleid));

                        // Execute the command  
                        int result = cmd.ExecuteNonQuery();

                        // Check if the insertion was successful  
                        if (result > 0)
                        {
                            MessageBox.Show("User information saved successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Failed to save user information.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that may have occurred.  
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void signup_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
