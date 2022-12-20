using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_8_1_Forms
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			textBox1.Text = "";
			textBox2.Text = "";
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				Regex r = new Regex(@"\b[аеёиоуыэюя]\S*\b", RegexOptions.IgnoreCase);
				string str = textBox1.Text;
				
				if (str.Length < 1)
				{
					throw new Exception();
				}
				
				string afterStr = r.Replace(str, "");

				for (int i = 0; i < afterStr.Length - 1; i++)
				{
					if (afterStr[i] == ' ' && afterStr[i + 1] == ' ')
					{
						afterStr = afterStr.Remove(i, 1);

						if (i < 0)
						{
							i--;
						}
					}
				}
				if (afterStr[0] == ' ')
				{
					afterStr = afterStr.Remove(0, 1);
				}

				textBox2.Text = ("Строка, после удаления слов, начинающихся на гласные\r\n" + afterStr);
			}
			catch
			{
				textBox2.Text = "Строка пустая!";
			}
		}
	}
}
