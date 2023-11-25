using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace VirtualBox_To_VMware_Converter
{

    public partial class Form1 : Form
    {
        private string selectedFilePath;
        private string vmdkFilePath;

        public Form1()
        {
            InitializeComponent();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "VMDK Files (*.vmdk)|*.vmdk";
            saveFileDialog.Title = "Save Converted VMDK File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                vmdkFilePath = saveFileDialog.FileName;
                guna2TextBox2.Text = vmdkFilePath;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "VDI Files (*.vdi)|*.vdi";
            openFileDialog.Title = "Select a VDI File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName;
                guna2TextBox1.Text = selectedFilePath;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedFilePath))
            {
                string virtualBoxPath = "C:\\Program Files\\Oracle\\VirtualBox\\";

                if (!string.IsNullOrEmpty(vmdkFilePath))
                {
                    // VirtualBox VBoxManage komutunu çalıştırarak dönüştürme işlemini gerçekleştirir
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = Path.Combine(virtualBoxPath, "VBoxManage.exe");
                    startInfo.Arguments = $"clonehd \"{selectedFilePath}\" \"{vmdkFilePath}\" --format VMDK";
                    startInfo.RedirectStandardOutput = true;
                    startInfo.UseShellExecute = false;
                    startInfo.CreateNoWindow = true;

                    Process process = new Process();
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();

                    MessageBox.Show("Dönüşüm tamamlandı. Dosya kaydedildiği konuma: " + vmdkFilePath);
                }
                else
                {
                    MessageBox.Show("Lütfen kaydedilecek dosyanın yolu seçin.");
                }
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
