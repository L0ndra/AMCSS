using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMCSS
{
    public partial class Form1 : Form
    {
        const int N = 4;
        double[,] Matrix;
        double[] X;
        public Form1()
        {
            InitializeComponent();
        }
        void FillMatrix()
        {
            Matrix = new double[N+1, N + 1];
            Matrix[0, 0] = Convert.ToDouble(textBox1.Text);
            Matrix[0, 1] = Convert.ToDouble(textBox2.Text);
            Matrix[0, 2] = Convert.ToDouble(textBox3.Text);
            Matrix[0, 3] = Convert.ToDouble(textBox4.Text);
            Matrix[0, 4] = Convert.ToDouble(textBox5.Text);
            Matrix[1, 0] = Convert.ToDouble(textBox6.Text);
            Matrix[1, 1] = Convert.ToDouble(textBox7.Text);
            Matrix[1, 2] = Convert.ToDouble(textBox8.Text);
            Matrix[1, 3] = Convert.ToDouble(textBox9.Text);
            Matrix[1, 4] = Convert.ToDouble(textBox10.Text);
            Matrix[2, 0] = Convert.ToDouble(textBox11.Text);
            Matrix[2, 1] = Convert.ToDouble(textBox12.Text);
            Matrix[2, 2] = Convert.ToDouble(textBox13.Text);
            Matrix[2, 3] = Convert.ToDouble(textBox14.Text);
            Matrix[2, 4] = Convert.ToDouble(textBox15.Text);
            Matrix[3, 0] = Convert.ToDouble(textBox16.Text);
            Matrix[3, 1] = Convert.ToDouble(textBox17.Text);
            Matrix[3, 2] = Convert.ToDouble(textBox18.Text);
            Matrix[3, 3] = Convert.ToDouble(textBox19.Text);
            Matrix[3, 4] = Convert.ToDouble(textBox20.Text);
            for(int i=0;i<N;i++)
            {
                Matrix[4, i] = i + 1;
            }
            X = new double[N];
        }
        void MainElement()
        {
            for(int k=N;k> 1;k--)
            {
                double max = Matrix[0, 0];
                double[] m = new double[k];
                int r = 0, c = 0;
                for(int i =0;i< k;i++)
                {
                    for (int j = 0; j< k;j++)
                    {
                        if(Matrix[i,j]>max)
                        {
                            max = Matrix[i, j];
                            r = i;
                            c = j;
                        }
                    }
                }
                for(int i = 0; i<k;i++)
                {
                    m[i] = -Matrix[i, c] / max;
                    if (i == r)
                        m[i] = 0; 
                }
                for(int i=0;i<k;i++)
                {
                    for(int j=0;j< k;j++)
                    {
                        Matrix[i, j] += Matrix[r, j] * m[i];
                    }
                    Matrix[i, N] += Matrix[r, N] * m[i];
                }
                for(int i = 0; i<N+1;i++)
                {
                    double d = Matrix[r, i];
                    Matrix[r, i] = Matrix[k - 1, i];
                    Matrix[k - 1, i] = d;
                }
                for(int i = 0; i<N+1; i++)
                {
                    double d = Matrix[i, c];
                    Matrix[i, c] = Matrix[i, k - 1];
                    Matrix[i, k - 1] = d;
                }
            }
            for(int i=0;i< N;i++)
            {
                double sum = Matrix[i, N];
                for(int j=0;j< i;j++)
                {
                    sum -= Matrix[i, j] * X[j];
                }
                X[i] = sum / Matrix[i, i];
            }

        }
        double GetI(int i)
        {
            for (int j = 0; j < N; j++)
                if (Matrix[N, j] == i)
                    return X[j];
            return 0; 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FillMatrix();
            MainElement();
            textBox21.Text = Convert.ToString(GetI(1));
            textBox22.Text = Convert.ToString(GetI(2));
            textBox23.Text = Convert.ToString(GetI(3));
            textBox24.Text = Convert.ToString(GetI(4));

        }
    }
}
