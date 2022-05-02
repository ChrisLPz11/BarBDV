using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Capa_Negocio;

namespace Capa_Precentacion
{
    public partial class Form1 : Form
    {
        CNproducto objetoCN = new CNproducto();
        private string idproducto = null;
        private bool editar = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LeerProd();
        }

        private void LeerProd()
        {
            CNproducto objeto = new CNproducto();
            dataGridView1.DataSource = objeto.leerProd();
        }

        private void LimpiarForm()
        {
            txtNombre.Clear();
            txtDescrip.Clear();
            txtCant.Clear();
            txtPrec.Clear();
            txtEstado.Clear();
        }

        private void BtnGuadar_Click(object sender, EventArgs e)
        {
            {
                if (editar == false)
                {
                    try
                    {
                        objetoCN.InsProd(txtNombre.Text, txtDescrip.Text, txtPrec.Text, txtCant.Text, txtEstado.Text);
                        MessageBox.Show("A inserto correctamente");
                        LeerProd();
                        LimpiarForm();
                        editar = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se puede insertar por ", ex.Message);
                    }

                }
                if (editar == true)
                {
                    try
                    {
                        objetoCN.ActProd(txtNombre.Text, txtDescrip.Text, txtPrec.Text, txtCant.Text, txtEstado.Text, idproducto);
                        MessageBox.Show("Se editó correctamente");
                        LeerProd();
                        LimpiarForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo editar por " + ex);
                    }
                }
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    editar = true;
                    txtNombre.Text = dataGridView1.CurrentRow.Cells["NomProd"].Value.ToString();
                    txtDescrip.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                    txtPrec.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                    txtCant.Text = dataGridView1.CurrentRow.Cells["Cantidad"].Value.ToString();
                    txtPrec.Text = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
                }
                else
                    MessageBox.Show("Por Favor Seleccione la FIla");
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    idproducto = dataGridView1.CurrentRow.Cells["idProducto"].Value.ToString();
                    objetoCN.EliProd(idproducto);
                    MessageBox.Show("Se ha eliminado correctamente");
                    LeerProd();
                }
                else
                    MessageBox.Show("Seleccion una fila por favor");
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

    