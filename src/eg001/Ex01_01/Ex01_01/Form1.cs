using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex01_01
{
    public partial class Form1 : Form
    {
        private string address = "c:\\";
        public Form1()
        {
            InitializeComponent();
        }

        private void 关闭所有ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            this.openFileDialog1.ShowDialog();
            StreamWriter s = new StreamWriter(address + "\\Menu.ini", true);
            s.WriteLine(openFileDialog1.FileName);//写入 INI 文件
            s.Flush();
            s.Close();
            ShowWindows(openFileDialog1.FileName);
        }

        //自定义方法ShowWindows()用来加载北京图片并显示窗体
        public void ShowWindows(string fileName)
        {
            Image p = Image.FromFile(fileName);
            Form f = new Form();
            f.MdiParent = this;
            f.BackgroundImage = p;
            f.Show();
        }

        //读取INI文件并将信息加入菜单
        private void Form1_Load()
        {
            StreamReader sr = new StreamReader(address + "\\Menu.ini");
            int i = this.文件ToolStripMenuItem.DropDownItems.Count - 2;
            //读取INI文件
            while (sr.Peek() >= 0)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem(sr.ReadLine());
                this.文件ToolStripMenuItem.DropDownItems.Insert(i, menuItem);
                i++;
                menuItem.Click += new EventHandler(menuItem_Click);
            }
            sr.Close();
        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
