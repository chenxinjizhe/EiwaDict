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

namespace EiwaDict
{
    public partial class ParaphaseForm : Form
    {
        private const String connectstr = "Data Source=MYCOMPUTER\\SQLEXPRESS;Initial Catalog=EiwaDB;Integrated Security=True";
        private SqlConnection sqlCnt;
        private string user_id;

        public string User_id
        {
            get { return user_id; }
        }
        private bool isNewLogin = false;
        public bool IsNewLogin
        {
            get { return isNewLogin; }
        }
        private int word_id;
        public ParaphaseForm(string uid, string wd, string p, int wid)
        {
            InitializeComponent();
            user_id = uid;
            label1.Text = wd;
            word_id = wid;
            sqlCnt = new SqlConnection(connectstr);
            sqlCnt.Open();
            SqlCommand cmd = sqlCnt.CreateCommand();
            cmd.CommandType = CommandType.Text;
            textBox1.Text = p;
            if (user_id != null)
            {
                cmd.CommandText = "Select count(*) from word_table where wid = @wid and uid = @uid";
                cmd.Parameters.Add("@wid", SqlDbType.Int);
                cmd.Parameters.Add("@uid", SqlDbType.VarChar);
                cmd.Parameters["@wid"].Value = word_id;
                cmd.Parameters["@uid"].Value = user_id;
                int result = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (result > 0)
                {
                    button2.Text = "ワードブックに加えてあります";
                    button2.Enabled = false;
                }
            }
            sqlCnt.Close();
        }
        
        //ワードブックに加える
        private void button2_Click(object sender, EventArgs e)
        {
            if (user_id == null)
            {
                MessageBox.Show("先にログインしてください");
                LoginForm lf = new LoginForm(true);
                this.Hide();
                if (lf.ShowDialog() == DialogResult.OK)
                {
                    this.user_id = lf.User_id;
                    this.isNewLogin = true;
                    lf.Dispose();
                }
                this.Show();
            }

            if(user_id == null)
            {
                isNewLogin = false;
                return;
            }
            sqlCnt.Open();
            SqlCommand cmd = sqlCnt.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select count(*) from word_table where wid = @wid and uid = @uid";
            cmd.Parameters.Add("@wid", SqlDbType.Int);
            cmd.Parameters.Add("@uid", SqlDbType.VarChar);
            cmd.Parameters["@wid"].Value = word_id;
            cmd.Parameters["@uid"].Value = user_id;
            int result = Int32.Parse(cmd.ExecuteScalar().ToString());
            if (result > 0)
            {
                button2.Text = "ワードブックに加えてあります";
                button2.Enabled = false;
                return;
            }
            cmd.CommandText = "Insert into word_table Values(@wid,@uid,getdate())";
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("単語をワードブックに加えました");
                button2.Text = "ワードブックに加えてあります";
                button2.Enabled = false;
            }
            catch (SqlException er)
            {
                MessageBox.Show(er.ToString());
            }
            sqlCnt.Close();
        }

        //戻る
        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ParaphaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

    }
}
