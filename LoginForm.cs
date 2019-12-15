using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace EiwaDict
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object result = null;
            string nname;
            string password;
            string user_id;
            nname = textBox1.Text.Trim();
            password = textBox4.Text.Trim();
            if (nname == "")
            {
                MessageBox.Show("ユーザー名を入力してください！");
                return;
            }
            if (password == "")
            {
                MessageBox.Show("パスワードを入力してください！");
                return;
            }
            //String connectstr = "Data Source=desktop-l8v4jp3;Initial Catalog=Dic_jp;Integrated Security=True";
            //SqlConnection sqlCnt = new SqlConnection(connectstr);
            //sqlCnt.Open();
            //SqlCommand cmd1 = sqlCnt.CreateCommand();
            //cmd1.CommandType = CommandType.Text;
            //cmd1.CommandText = "Select id from user_table where nickname = @nickname and psword = CONVERT(char(32),HashBytes('MD5',@password),2)";
            //cmd1.Parameters.Add("@nickname", SqlDbType.VarChar);
            //cmd1.Parameters.Add("@password", SqlDbType.VarChar);
            //cmd1.Parameters["@nickname"].Value = nname;
            //cmd1.Parameters["@password"].Value = password;
            //try
            //{
            //    result = cmd1.ExecuteScalar();
            //}
            //catch (SqlException er)
            //{
            //    MessageBox.Show(er.Message);
            //}
            //sqlCnt.Close();
            //if (result == null)
            //{
            //    MessageBox.Show("ユーザー名とパスワードが一致していません！");
            //    return;
            //}
            //MessageBox.Show("ログイン成功");
            //user_id = result.ToString();
            //if (loginOpt == false)//main menu
            //{
            //    this.Hide();
            //    UserForm uf = new UserForm(user_id);
            //    if (uf.ShowDialog() == DialogResult.OK)//logout
            //        uf.Dispose();
            //}
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
