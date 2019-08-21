using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace chat2._0.GuiPackage
{
    public partial class Expression : UserControl
    {
        List<Image> _images = new List<Image>();

        private void LoadImages()
        {
            DirectoryInfo dir = new DirectoryInfo("../Debug/Faces");
            foreach (FileInfo file in dir.GetFiles())
            {
                if (String.Compare(file.Extension, ".gif", true) == 0)
                {
                    _images.Add(Image.FromFile(file.FullName));
                }
            }
        }

        public EventHandler OnSelectExpression;
        public static Expression Instance = new Expression();

        public Expression()
        {
            InitializeComponent();
            LoadImages();
            LoadForm();
        }

        public void LoadForm()
        {
            int idx = 0;
            foreach (Image img in _images)
            {
                if (img != null)
                {
                    PictureBox pb = new PictureBox();
                    pb.Size = new Size(40, 30);
                    pb.Location = new Point(40 * (idx % 10), 30 * (idx / 10));
                    pb.Image = img;
                    pb.Click += OnPictureBoxClick;
                    idx++;
                    this.Controls.Add(pb);
                }
                else
                {
                    break;
                }
            }
            this.Show();
        }

        private void OnPictureBoxClick(object sender, EventArgs e)
        {
            if (OnSelectExpression != null)
            {
                OnSelectExpression(sender, e);
            }
        }
    }
}
