using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace CasoPro1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Kobu"].ConnectionString);

        private void dgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void ListaClientes()
        {
            using (SqlDataAdapter df = new SqlDataAdapter("Usp_ListaClientes_Neptuno", cn))
            {
                df.SelectCommand.CommandType = CommandType.StoredProcedure;
                df.SelectCommand.Parameters.AddWithValue("@Name", txtNombre.Text);
                using (DataSet Da = new DataSet())
                {
                    df.Fill(Da, "Clientes");
                    dgClientes.DataSource = Da.Tables["Clientes"];
                    lblTotal.Text = Da.Tables["Clientes"].Rows.Count.ToString();
                }
            }

        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            ListaClientes();

        }
    }
}
