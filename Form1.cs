using System.IO;

namespace Bloco_de_notas
{
    public partial class Form1 : Form
    {
        private SaveFileDialog SalvarDialogo;
        private OpenFileDialog AbrirDialogo;
        private FontDialog FonteDialogo;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            FonteDialogo = new FontDialog();
        }

        private void CriarNovo()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.richTextBox1.Text))
                {
                    this.Text = "Sem título";
                    this.richTextBox1.Text = String.Empty;
                }
                else
                {
                    MessageBox.Show("Arquivo não foi salvo!");
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
       
        private void AbrirArquivo()
        {
            try
            {
                AbrirDialogo = new OpenFileDialog();

                if (AbrirDialogo.ShowDialog() == DialogResult.OK)
                {
                    this.richTextBox1.Text = File.ReadAllText(AbrirDialogo.FileName);
                    this.Text = AbrirDialogo.FileName;
                }
                else
                {
                    MessageBox.Show("Erro ao abrir o Arquivo!");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                AbrirDialogo = null;
            }

        }
        private void SalvarArquivo()
        {
            try
            {
                SalvarDialogo = new SaveFileDialog();
                SalvarDialogo.Filter = "Arquivo de Texto (*.txt) | *.txt";       
                if (SalvarDialogo.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(SalvarDialogo.FileName, this.richTextBox1.Text);
                    this.Text = SalvarDialogo.FileName;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        private void AlterarFonte()
        {
            try
            {
                if(FonteDialogo.ShowDialog() == DialogResult.OK)
                {
                    this.richTextBox1.Font = FonteDialogo.Font;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {

            }
        }


        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirArquivo();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CriarNovo();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalvarArquivo();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fonteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlterarFonte();
        }

      
    }
}