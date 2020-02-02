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
        WordbookForm word_book_form ;
        public UserForm(string uid)
        {
            InitializeComponent();
            this.user_id = uid;
            word_book_form = new WordbookForm(user_id);
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        //単語検索
        private void button1_Click(object sender, EventArgs e)
        {
            QueryForm qf = new QueryForm(user_id);
            this.Hide();
            if (qf.ShowDialog() == DialogResult.OK)
                qf.Dispose();
            this.Show();
        }

        //ワードブック
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            word_book_form.UpdateComponents();
            if (word_book_form.ShowDialog() == DialogResult.OK)
                word_book_form.Hide();
            this.Show();
        }

        //ログアウト
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
