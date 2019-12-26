using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C3
{
    public partial class Form1 : Form
    {
        List<Student> ls = new List<Student> {
            new Student(){StuID=1, Name="张三",Sex='男', Age=19 ,Bday=Convert.ToDateTime("2009-1-1"),Hobby="吃饭" },
            new Student(){StuID=2, Name="王六",Sex='男', Age=29, Bday=Convert.ToDateTime("2009-1-1"),Hobby="吃饭" },
            new Student(){StuID=3, Name="麻子",Sex='女', Age=20, Bday=Convert.ToDateTime("2009-1-1"),Hobby="吃饭" },
            new Student(){StuID=4, Name="张八",Sex='男', Age=18, Bday=Convert.ToDateTime("2009-1-1"),Hobby="吃饭" },
            new Student(){StuID=5, Name="刘浪",Sex='女', Age=21, Bday=Convert.ToDateTime("2009-1-1"),Hobby="吃饭" },
        };
        int index = 1;
        int size = 2;
        int count = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            count = ls.Count % size == 0 ? ls.Count / size : ls.Count / size + 1;
            bind();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!= "")
            {
                var linq=ls.Where(s=>s.Name.Contains(textBox1.Text)).Skip((index - 1) * size).Take(size).ToList();
                count = ls.Count % size == 0 ? ls.Count / size : ls.Count / size + 1;
                dataGridView1.DataSource = linq.ToList() ;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ls.Count(s => s.Age > 20).ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ls.Where(s=>s.Sex=='男').Max(s => s.Age).ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ls.Where(s => s.Sex == '女').Min(s => s.Age).ToString());

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ls.Where(s => s.Sex == '男').Average(s => s.Age).ToString());
        }
        private void bind()
        {
            dataGridView1.DataSource = ls.Skip((index - 1) * size).Take(size).ToList() ;

        }
        private void button6_Click(object sender, EventArgs e)
        {
            index = 1;
                bind();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (index > 1)
            {
                index--;
                bind();

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(index<count)
            {
                index++;
                bind();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            index = count;
            bind();
        }

        private void button10_Click(object sender, EventArgs e)
        {
             int[] numbers = { 3, 71, 66, 22, 35, 43, 35, 26, 22, 101 };
            //a > 从 numbers 数组中第一个偶数开始，提取紧随其后的连续偶数-- > 结果是 66,22
            var linq = numbers.SkipWhile(a => a % 2 != 0).Where(a => a % 2==0);
            StringBuilder str = new StringBuilder();
            foreach (var item in linq)
            {
                str.Append(item + "\t");
            }
            MessageBox.Show(str.ToString());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //b > 从 numbers 数组中第一个 35 开始，提取随后的所有奇数-- > 35,43,35,101
            int[] numbers = { 3, 71, 66, 22, 35, 43, 35, 26, 22, 101 };
            var linq = numbers.SkipWhile(a => a!=35).Where(a => a % 2 != 0);
            StringBuilder str = new StringBuilder();
            foreach (var item in linq)
            {
                str.Append(item + "\t");
            }
            MessageBox.Show(str.ToString());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int[] numbers = { 3, 71, 66, 22, 35, 43, 35, 26, 22, 101 };
            MessageBox.Show(@"最小值" + numbers.Min()+ "最大值" + numbers.Max()
                +"平均值"+numbers.Average()+"和"+numbers.Sum());
        }
    }
}
