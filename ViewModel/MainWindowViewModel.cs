using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PhonebookDB.ViewModel;
using PhonebookDB.Models;

namespace PhonebookDB.ViewModel
{
    public class MainWindowVM : ViewModelBase
    {
        public IList<ListOfContacts> _contactsList = new List<ListOfContacts>();

        public ListOfContacts c = new ListOfContacts();

        public RelayCommand ConnectCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
   

        private string connectionString;
        private SqlConnection conn;
        private SqlCommand cmd_fill;



        public MainWindowVM()
        {

            connectionString = @"Data Source=localhost; Initial Catalog = PhonebookDB; Integrated Security=True";
            conn = new SqlConnection(connectionString);

            conn.Open();
            cmd_fill = new SqlCommand("SELECT * FROM ListOfContacts", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd_fill);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "ListOfContacts");

            try
            {
                if (_contactsList != null)
                {
                    foreach (DataRow dataRow in ds.Tables[0].Rows)
                    {
                        _contactsList.Add(new ListOfContacts
                        {
                            id = (int)dataRow["id"],
                            FirstName = dataRow["FirstName"].ToString(),
                            MiddleName = dataRow["MiddleName"].ToString(),
                            LastName = dataRow["LastName"].ToString(),
                            PhoneNumber = dataRow["PhoneNumber"].ToString(),
                            Gender = dataRow["Gender"].ToString()
                           

                        });
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                adapter.Dispose();
                conn.Close();
                conn.Dispose();
            }




            AddCommand = new RelayCommand(AddMethod, CanSave => true);
            UpdateCommand = new RelayCommand(UpdateMethod);

        }


        public IList<ListOfContacts> ListOfContacts
        {
            get { return _contactsList; }
            set { _contactsList = value; }
        }

        public bool CanSave
        {
            get { return !string.IsNullOrEmpty(c.id.ToString()) && !string.IsNullOrEmpty(c.FirstName); }
        }


        public void AddMethod(object message)
        {


            string connectionString;
            SqlConnection conn;
            connectionString = @"Data Source=localhost; Initial Catalog = PhonebookDB; Integrated Security=True";
            conn = new SqlConnection(connectionString);


            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO " +
                                "Contacts (FirstName, MiddleName, LastName, PhoneNumber, Gender)" +
                                "VALUES (@FirstName, @MiddleName, @LastName, @PhoneNumber, @Gender)";
            cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", c.MiddleName);
            cmd.Parameters.AddWithValue("@LastName", c.LastName);
            cmd.Parameters.AddWithValue("@PhoneNumber", c.PhoneNumber);
            cmd.Parameters.AddWithValue("@Gender", c.Gender);



            

        }

        public void UpdateMethod(object message)
        {
            MessageBox.Show("Updated Contact", "PhonebookDB", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
        }










    }
}