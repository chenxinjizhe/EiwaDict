using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EiwaDict
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //単語検索
        private void button1_Click(object sender, EventArgs e)
        {
            QueryForm qf = new QueryForm();
            this.Hide();
            if (qf.ShowDialog() == DialogResult.OK)
                qf.Dispose();
            this.Show();
        }

        //登録
        private void button2_Click(object sender, EventArgs e)
        {
            RegistForm rf = new RegistForm();
            this.Hide();
            if (rf.ShowDialog() == DialogResult.OK)
            {
                rf.Dispose();
            }
            this.Show();
        }

        //ログイン
        private void button3_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            this.Hide();
            if (lf.ShowDialog() == DialogResult.OK)
                this.Show();
        }

        //閉じる
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
