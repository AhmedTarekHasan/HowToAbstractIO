using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IOAbstraction;

namespace IOAbstraction
{
    public partial class FrmMain : Form
    {
        private readonly IFileManager m_FileManager;

        public FrmMain()
        {
            InitializeComponent();
            m_FileManager = new FileManager();
        }

        private void Btn_Browse_Click(object sender, EventArgs e)
        {
            if (Ofd_Browse.ShowDialog() == DialogResult.OK)
            {
                Txt_Path.Text = Ofd_Browse.FileName;
            }
        }

        private void GetAll()
        {
            Rtb_AllResults.Clear();

            Rtb_AllResults.Text = m_FileManager.GetAllData(Txt_Path.Text);
        }

        private void Btn_Get_Click(object sender, EventArgs e)
        {
            GetAll();
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            var line = "Ahmed,36,Software Engineer";

            m_FileManager.AddNewDataEntry(Txt_Path.Text, line);

            GetAll();
        }

        private void Btn_Remove_Click(object sender, EventArgs e)
        {
            m_FileManager.RemoveLastDataEntry(Txt_Path.Text);

            GetAll();
        }
    }
}