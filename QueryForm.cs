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
    public partial class QueryForm : Form
    {
        private bool isNewLogin;
        public QueryForm(bool inl)
        {
            InitializeComponent();
            this.isNewLogin = inl;
        }

        //検索
        private void button1_Click(object sender, EventArgs e)
        {

        }

        //戻る
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
