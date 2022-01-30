using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analizador
{
    public partial class frmPrincipal : Form
    {
        List<char> _numeros = new List<char>(new char[] { '0','1','2','3','4','5','6','7','8','9'});
        List<char> _variables = new List<char>(new char[] { 'A', 'B', 'C','D','E','F','G','H','I','J','K','L','M','N','Ñ','O','P','Q','R','S','T','U','V','W','X','Y','Z'});
        List<char> _operadores = new List<char>(new char[] { '+', '-', '*', '/' });
        List<char> _delimitadores = new List<char>(new char[] { '(', ')', '{','}'});
        List<char> punto = new List<char>(new char[] { '.'});
        List<char> relacionales= new List<char>(new char[] { '<', '>' });
        DataTable _tblResultados = new DataTable();

        public frmPrincipal()
        {
            InitializeComponent();           
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            _tblResultados.Columns.Add("Token", typeof(char));
            _tblResultados.Columns.Add("Tipo", typeof(string));
        }      

        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            _tblResultados.Clear();

            List<char> _elementos = txtExpresion.Text.Replace(" ","").ToCharArray().ToList();

            if (_elementos.Count > 0)
            {
                DataRow _fila;

                foreach (char elemento in _elementos)
                {
                    _fila = _tblResultados.NewRow();

                    if (_numeros.Contains(elemento))
                    {
                        _fila["Token"] = elemento;
                        _fila["Tipo"] = "Número";
                    }
                    else if (_variables.Contains(elemento.ToString().ToUpper()[0]))
                    {
                        _fila["Token"] = elemento;
                        _fila["Tipo"] = "Variable";
                    }
                    else if (_operadores.Contains(elemento))
                    {
                        _fila["Token"] = elemento;
                        _fila["Tipo"] = "Operador";
                    }
                    else if (_delimitadores.Contains(elemento))
                    {
                        _fila["Token"] = elemento;
                        _fila["Tipo"] = "Delimitador";
                    } 
                    else if (punto.Contains(elemento))
                    {
                        _fila["Token"] = elemento;
                        _fila["Tipo"] = "Punto";
                    } else if (relacionales.Contains(elemento))
                    {
                        _fila["Token"] = elemento;
                        _fila["Tipo"] = "Relacionale";
                    }
                    else
                    {
                        _fila["Token"] = elemento;
                        _fila["Tipo"] = "Error";
                    }

                    _tblResultados.Rows.Add(_fila);
                }

                dgvResultados.DataSource = _tblResultados;
                dgvResultados.Refresh();
            }
            else
            {
                dgvResultados.DataSource = null;
                dgvResultados.Refresh();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtExpresion.Clear();
            _tblResultados.Clear();
            dgvResultados.DataSource = null;
            dgvResultados.Refresh();
        }

        private void dgvResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
