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
    public partial class QueryForm : Form
    {
        private String connectstr = "Data Source=MYCOMPUTER\\SQLEXPRESS;Initial Catalog=EiwaDB;Integrated Security=True";
        private SqlConnection sqlCnt;
        private SqlDataAdapter sda;
        private DataSet ds;
        private string user_id;
        private bool isNewLogin = false;
        public QueryForm()
        {
            InitializeComponent();
            sqlCnt = new SqlConnection(connectstr);
        }

        public QueryForm(string uid)
        {
            InitializeComponent();
            sqlCnt = new SqlConnection(connectstr);
            user_id = uid;
        }

        //検索
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("検索したい単語を入力してください");
                return;
            }
            sqlCnt.Open();
            SqlCommand cmd = sqlCnt.CreateCommand();
            cmd.CommandText = "Select top 15 word, paraphase,id from dictionary where word like @text+'%'";
            cmd.Parameters.Add(new SqlParameter("@text", textBox1.Text.Trim()));
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            int flag = sda.Fill(ds, "dictionary");
            if (flag == 0)
            {
                label1.Text = "検索結果が見つかりませんでした";
                sqlCnt.Close();
                return;
            }
            label1.Text = flag.ToString() + "個の結果が見つかりました、ダブルクリックで詳細解釈が見られます";
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "dictionary";
            sqlCnt.Close();
            dataGridView1.Columns[0].HeaderText = "英単語";
            dataGridView1.Columns[1].HeaderText = "解釈";
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 600;
            dataGridView1.Columns[2].Visible = false;
        }

        //戻る
        private void button3_Click(object sender, EventArgs e)
        {
            if (!isNewLogin)
                this.Close();
            else
            {
                this.Hide();
                UserForm uf = new UserForm(user_id);
                if (uf.ShowDialog() == DialogResult.OK)
                    uf.Dispose();
                this.Close();
            }
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
                if(pf.IsNewLogin)
                    this.isNewLogin = pf.IsNewLogin;
                pf.Dispose();
            }
            this.Show();
            //MessageBox.Show(dataGridView1.CurrentRow.Cells[2].Value.ToString());
        }
    }
}
