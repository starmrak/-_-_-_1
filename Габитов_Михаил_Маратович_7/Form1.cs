using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Габитов_Михаил_Маратович_7
{
    public partial class Form1 : Form
    {
        const int n = 7;
        const int sizeText = 50;
        public int[,] map = new int[n, n];
        public Button[,] texts = new Button[n, n];
        bool isEndGame = false;
        bool IsChosen = false;
        int ButI = 0;
        int ButJ = 0;
        public Form1()
        {
            InitializeComponent();
            GenerateMap();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        public void CreateMap()
        {
            for(int i = 0; i<n; i++)
            {
                for(int j=0; j<n;j++)
                {
                    if(i<2&&j>=2&&j<=4)
                    {
                        Button textBox = new Button();
                        texts[i, j] = textBox;
                        textBox.Size = new Size(sizeText, sizeText);
                        textBox.Text = map[i, j].ToString();
                        textBox.Text = "";
                        texts[i,j].BackColor = Color.Green;
                        textBox.Location = new Point(j * sizeText, i * sizeText);
                        this.Controls.Add(textBox);
                    }
                    if (i > 1 && i < 3)
                    {
                        Button textBox = new Button();
                        texts[i, j] = textBox;
                        textBox.Size = new Size(sizeText, sizeText);
                        textBox.Text = map[i, j].ToString();
                        textBox.Text = "";
                        if(j==2)
                        {
                        texts[i=2, j=2].Text = "Л";
                        }
                        if (j == 4)
                        {
                            texts[i = 2, j = 4].Text = "Л";
                        }
                        textBox.Location = new Point(j * sizeText, i * sizeText);
                        this.Controls.Add(textBox);
                    }    
                    if (i > 2 && i<5)
                    {
                        Button textBox = new Button();
                        texts[i, j] = textBox;
                        textBox.Size = new Size(sizeText, sizeText);
                        textBox.Text = map[i, j].ToString();
                        textBox.Text = "К";
                        textBox.Location = new Point(j * sizeText, i * sizeText);
                        this.texts[i, j].Click += new System.EventHandler(this.Chicken_Press);
                        this.Controls.Add(textBox);
                    }
                    if (i > 4 && j >= 2 && j <= 4)
                    {
                        Button textBox = new Button();
                        texts[i, j] = textBox;
                        textBox.Size = new Size(sizeText, sizeText);
                        textBox.Text = map[i, j].ToString();
                        textBox.Text = "К";
                        this.texts[i, j].Click += new System.EventHandler(this.Chicken_Press);
                        textBox.Location = new Point(j * sizeText, i * sizeText);
                        this.Controls.Add(textBox);
                    }
                }
            }
        }
        public void GenerateMap()
        {
            CreateMap();
        }
        private void Chicken_Press(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if ((texts[i,j] == button) && (texts[i,j].Text == "") && (IsChosen))
                    {
                        if (((i == ButI) && (j == ButJ)) || ((i == ButI - 1) && (ButJ == j)) || ((ButI == i) && ((j == ButJ - 1) || (j == ButJ + 1))))
                        {
                            texts[i,j].Text = "К";
                            texts[ButI,ButJ].Text = "";
                            IsChosen = false;
                            ButI = 0;
                            ButJ = 0;
                        }
                        break;
                    }
                    if ((texts[i,j] == button) && (texts[i,j].Text == "К") && (!IsChosen))
                    {
                        ButI = i;
                        ButJ = j;
                        IsChosen = true;
                        break;
                    }
                }
            }
        }
    }
}
