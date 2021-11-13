using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IOAbstraction
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
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

            var lines = File.ReadAllLines(Txt_Path.Text);

            var builder = new StringBuilder();

            foreach (var line in lines)
            {
                if (!string.IsNullOrEmpty(line) && line.Contains(","))
                {
                    var parts = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    var name = parts[0];
                    var age = parts[1];
                    var profession = parts[2];
                    var message = $"Name: {name}, Age: {age}, Profession: {profession}.";

                    builder.AppendLine(message);
                }
            }

            Rtb_AllResults.Text = builder.ToString();
        }

        private void Btn_Get_Click(object sender, EventArgs e)
        {
            GetAll();
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            var line = Environment.NewLine + "Ahmed,36,Software Engineer";

            var text = TrimEndNewLine(File.ReadAllText(Txt_Path.Text)) + line;

            File.WriteAllText(Txt_Path.Text, text);

            GetAll();
        }

        private void Btn_Remove_Click(object sender, EventArgs e)
        {
            var lines = File.ReadAllLines(Txt_Path.Text);

            File.WriteAllLines(Txt_Path.Text, lines.Take(lines.Length - 1));

            GetAll();
        }

        private string TrimEndNewLine(string str)
        {
            var result = str;

            while (result.EndsWith(Environment.NewLine))
            {
                result = result.Substring(0, result.Length - Environment.NewLine.Length);
            }

            return result;
        }
    }
}