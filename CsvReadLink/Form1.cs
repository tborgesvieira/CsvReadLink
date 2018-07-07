using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CsvReadLink
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSelecionar_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var list = File.ReadAllLines(openFileDialog.FileName)
                    .Select(a => a.Split(';'))
                    .Select(c=> new Cliente()
                    {
                        Id = Convert.ToInt32(c[0]),
                        Nome = c[1],
                        Telefone = c[2]
                    })
                    .ToList();

                dataGridView.DataSource = list;
                
            }
        }
    }
}
