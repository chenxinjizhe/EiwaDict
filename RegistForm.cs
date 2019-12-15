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
    public partial class RegistForm : Form
    {

        private String connectstr = "Data Source=desktop-l8v4jp3;Initial Catalog=Dic_jp;Integrated Security=True";
        private SqlConnection sqlCnt;
        public RegistForm()
        {
            InitializeComponent();
        }

        private void RegistForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nname;
            string password;
            string password1;
            nname = textBox1.Text.Trim();
            password = textBox4.Text.Trim();
            password1 = textBox5.Text.Trim();


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
            if (password1 == "")
            {
                MessageBox.Show("パスワードを再度入力してください！");
                return;
            }
            if (password != password1)
            {
                MessageBox.Show("パスワードは一致していません！");
                return;
            }
            if (nname.Length > 20)
            {
                MessageBox.Show("ユーザー名が長すぎます。");
                return;
            }
            //sqlCnt = new SqlConnection(connectstr);
            //sqlCnt.Open();
            //SqlCommand cmd1 = sqlCnt.CreateCommand();
            //cmd1.CommandType = CommandType.Text;
            //cmd1.CommandText = "Select count(*) from user_table where nickname = @nickname";
            //cmd1.Parameters.Add("@nickname", SqlDbType.VarChar);
            //cmd1.Parameters["@nickname"].Value = nname;
            //if (Int32.Parse(cmd1.ExecuteScalar().ToString()) >= 1)
            //{
            //    MessageBox.Show("ユーザー名が存在しています！");
            //    sqlCnt.Close();
            //    return;
            //}
            //SqlCommand cmd = sqlCnt.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "Insert into user_table Values(Left(NewID(),8),@nickname,CONVERT(char(32),HashBytes('MD5',@password),2))";
            //cmd.Parameters.Add("@nickname", SqlDbType.VarChar);
            //cmd.Parameters.Add("@password", SqlDbType.VarChar);
            //cmd.Parameters["@nickname"].Value = nname;
            //cmd.Parameters["@password"].Value = password;
            //try
            //{
            //    cmd.ExecuteNonQuery();
            //    MessageBox.Show("登録成功しました。");
            //}
            //catch (SqlException er)
            //{
            //    MessageBox.Show(er.ToString());
            //}
            //sqlCnt.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
