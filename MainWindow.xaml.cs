using PhonebookDB.ViewModel;
using PhonebookDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;


namespace OJT_012022_Activity1_Ver2
{
   
    public partial class MainWindow : Window
    {

        private string connectionString;
        
        public List <ListOfContacts> MyListOfContacts { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowVM();
            connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PhonebookDB;";
          //load();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Details.ItemsSource);
            

        }

       
        public SqlCommand Command(string sp, SqlConnection conn) { return new SqlCommand(sp, conn); }



        public bool fieldChecker(object sender, EventArgs e)
        {
            bool res = true;
            TextBox[] textBoxes = { FirstName, MiddleName, LastName, PhoneNumber };

            foreach (TextBox i in textBoxes) { if (string.IsNullOrEmpty(i.Text)) { res = false; } }
            if (string.IsNullOrEmpty(Gender.Text)) { res = false; }

            return res;

        }


        public void execute(SqlConnection conn, SqlCommand cmd)
        {
            
                conn.Open();
                cmd.ExecuteNonQuery();
                //conn.Close();
  
        }

        public SqlCommand addParams(SqlCommand cmd, String[] strlist, String[] txtboxVal)
        {
            for (int i = 0; i < strlist.Length; i++) { cmd.Parameters.AddWithValue(strlist[i], txtboxVal[i]); }
            return cmd;
        }




        public void add_contact(object sender, EventArgs e)
        {
            bool check = fieldChecker(sender, e);

            if (check == true)
            {

                SqlConnection conn = Connect(connectionString);
                SqlCommand cmd = Command(conn);
                cmd.CommandText = 
           
                "INSERT INTO [dbo].[ListOfContacts] ([FirstName], [MiddleName], [LastName], [PhoneNumber], [Gender]) VALUES( @FirstName, @MiddleName, @LastName, @PhoneNumber, @gender)";

                cmd.Parameters.AddWithValue("@FirstName", FirstName.Text);
                cmd.Parameters.AddWithValue("@MiddleName", MiddleName.Text);
                cmd.Parameters.AddWithValue("@LastName", LastName.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber.Text);
                cmd.Parameters.AddWithValue("@gender", Gender.Text);

                execute(conn, cmd);

            }
            else
            {
                MessageBox.Show("Missing Fields");
            }


        }





        public SqlConnection Connect(string connectionString) { return new SqlConnection(connectionString); }
        public SqlCommand Command(SqlConnection conn) { return conn.CreateCommand(); }

        public void refreshOnClick(object sender, EventArgs e)
        {
            Details.SelectedItem = null;
            FirstName.Clear();
            MiddleName.Clear();
            LastName.Clear();
            PhoneNumber.Clear();
            Gender.SelectedIndex = -1;

        }


        public void update_contact(object sender, EventArgs e)
        {
            SqlConnection conn = Connect(connectionString);
            SqlCommand cmd = Command (conn);
            var selectedRow = Details.SelectedItem;
            ListOfContacts req = selectedRow as ListOfContacts;
            int id = req.id;
            cmd.CommandText = $"UPDATE ListOfContacts SET FirstName=@FirstName, MiddleName=@MiddleName, LastName=@LastName, PhoneNumber=@PhoneNumber, Gender=@Gender WHERE id= {id} ";
            cmd.Parameters.AddWithValue("@FirstName", FirstName.Text);
            cmd.Parameters.AddWithValue("@MiddleName", MiddleName.Text);
            cmd.Parameters.AddWithValue("@LastName", LastName.Text);
            cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber.Text);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            bool check = fieldChecker(sender, e);
            execute(conn, cmd);

        }

        public void delete_contact(object sender, EventArgs e)
        {

            SqlConnection conn = Connect(connectionString);
            SqlCommand cmd = Command(conn);
            var selectedRow = Details.SelectedItem;
            ListOfContacts req = selectedRow as ListOfContacts;
            int id = req.id;
            cmd.CommandText = $"DELETE FROM ListOfContacts WHERE id = {id}";
            execute(conn, cmd);
           

        }






    }
}
