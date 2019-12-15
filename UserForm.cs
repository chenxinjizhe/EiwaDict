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
    public partial class UserForm : Form
    {
        private string user_id;
        public UserForm(string uid)
        {
            InitializeComponent();
            this.user_id = uid;
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        //単語検索
        private void button1_Click(object sender, EventArgs e)
        {
            QueryForm qf = new QueryForm(false);
            this.Hide();
            if (qf.ShowDialog() == DialogResult.OK)
                qf.Dispose();
            this.Show();
        }

        //ワードブック
        private void button2_Click(object sender, EventArgs e)
        {

        }

        //ログアウト
        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
