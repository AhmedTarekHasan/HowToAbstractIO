using System;
using System.Windows.Forms;
using IOAbstraction.DataManager.Model;
using IOAbstraction.SystemFileOperationsManager;

namespace IOAbstraction
{
    public partial class FrmMain : Form
    {
        private MainApplication.MainApplication m_MainApplication;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void Btn_Browse_Click(object sender, EventArgs e)
        {
            if (Ofd_Browse.ShowDialog() == DialogResult.OK)
            {
                Txt_Path.Text = Ofd_Browse.FileName;

                var ntfsOperationsManager = new NtfsOperationsManager();
                var dataTransformer = new DataTransformer.DataTransformer();

                var dataFileRepository =
                    new DataFileRepository.DataFileRepository(ntfsOperationsManager, Txt_Path.Text);

                var dataManager = new DataManager.DataManager(dataFileRepository, dataTransformer);

                m_MainApplication = new MainApplication.MainApplication(dataManager);
            }
        }

        private void GetAll()
        {
            Rtb_AllResults.Clear();
            var lines = m_MainApplication.GetAllToPresentInUi();
            Rtb_AllResults.Text = String.Join(Environment.NewLine, lines);
        }

        private void Btn_Get_Click(object sender, EventArgs e)
        {
            GetAll();
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            m_MainApplication.Add(new DataEntry("Ahmed", "36", "Software Engineer"));
            GetAll();
        }

        private void Btn_Remove_Click(object sender, EventArgs e)
        {
            m_MainApplication.Remove();
            GetAll();
        }
    }
}