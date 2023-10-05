using Entidades;
namespace MiCalculadora
{
    public partial class FrmCalculadora : Form
    {
        public FrmCalculadora()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.cmbOperacion.Items.AddRange(new object[] { '+', '-', '/', '*' });
            this.rdbDecimal.Checked = true;
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {

        }

        private void FrmCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Desea cerrar la calculadora?", "Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void rdbBinario_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBinario.Checked)
            {
                setResultado();
            }
        }

        private void rdbDecimal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDecimal.Checked)
            {
                setResultado();
            }
        }

        private void setResultado()
        {
        }

        private void txtPrimerOperador_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSegundoOperador_TextChanged(object sender, EventArgs e)
        {

        }
    }
}