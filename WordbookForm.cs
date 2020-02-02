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
    public partial class WordbookForm : Form
    {
        private string user_id;
        private String connectstr = "Data Source=MYCOMPUTER\\SQLEXPRESS;Initial Catalog=EiwaDB;Integrated Security=True";
        private SqlConnection sqlCnt;
        private SqlDataAdapter sda;
        private DataSet ds;
        public WordbookForm(string uid)
        {
            InitializeComponent();
            sqlCnt = new SqlConnection(connectstr);
            user_id = uid;
            sqlCnt.Open();
            SqlCommand cmd = sqlCnt.CreateCommand();
            cmd.CommandText = "select word, paraphase,d.id from dictionary d join word_table w on d.id = w.wid where w.uid = @user_id";
            cmd.Parameters.Add(new SqlParameter("@user_id", user_id));
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            int flag = sda.Fill(ds, "dictionary");
            if (flag == 0)
            {
                label1.Text = "ワードブックに単語がありません";
                sqlCnt.Close();
                return;
            }
            label1.Text = "ダブルクリックで詳細解釈が見られます";
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "dictionary";
            sqlCnt.Close();
            dataGridView1.Columns[0].HeaderText = "英単語";
            dataGridView1.Columns[1].HeaderText = "解釈";
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 600;
            dataGridView1.Columns[2].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult AF = MessageBox.Show("指定された単語をワードブックから削除しますか？", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (AF == DialogResult.OK)
            {
                sqlCnt.Open();
                SqlCommand cmd1 = sqlCnt.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "Delete from word_table where wid = @wid";
                cmd1.Parameters.Add("@wid", SqlDbType.Int);
                cmd1.Parameters["@wid"].Value = Int32.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                try
                {
                    cmd1.ExecuteNonQuery();
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                }
                catch(SqlException er)
                {
                    MessageBox.Show(er.ToString());
                    sqlCnt.Close();
                }
                sqlCnt.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WordbookForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ParaphaseForm pf = new ParaphaseForm(user_id, dataGridView1.CurrentRow.Cells[0].Value.ToString(),
            dataGridView1.CurrentRow.Cells[1].Value.ToString(),
            Int32.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()));
            this.Hide();
            if (pf.ShowDialog() == DialogResult.OK)
            {
                this.user_id = pf.User_id;
                pf.Dispose();
            }
            this.Show();
        }
   
        public void UpdateComponents()
        {
            sqlCnt = new SqlConnection(connectstr);
            sqlCnt.Open();
            SqlCommand cmd = sqlCnt.CreateCommand();
            cmd.CommandText = "select word, paraphase,d.id from dictionary d join word_table w on d.id = w.wid where w.uid = @user_id";
            cmd.Parameters.Add(new SqlParameter("@user_id", user_id));
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            int flag = sda.Fill(ds, "dictionary");
            if (flag == 0)
            {
                label1.Text = "ワードブックに単語がありません";
                sqlCnt.Close();
                return;
            }
            label1.Text = "ダブルクリックで詳細解釈が見られます";
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "dictionary";
            sqlCnt.Close();
            dataGridView1.Columns[0].HeaderText = "英単語";
            dataGridView1.Columns[1].HeaderText = "解釈";
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 600;
            dataGridView1.Columns[2].Visible = false;
        }
    }
}
