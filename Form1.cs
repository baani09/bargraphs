using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace bargraph
{
    public partial class Form1 : Form
    {
        private int[] data;
        private readonly Color[] colors = { Color.Blue, Color.Red, Color.Green, Color.Orange, Color.Purple, Color.Brown, Color.Magenta };

        public Form1()
        {
            InitializeComponent();
            data = Array.Empty<int>();
            graphPanel.Paint += graphPanel_Paint;
        }

        private void btnDrawGraph_Click(object sender, EventArgs e)
        {
            data = txtData.Text.Split(',')
                                .Select(x => int.TryParse(x.Trim(), out int value) ? value : (int?)null)
                                .Where(x => x.HasValue)
                                .Select(x => x.Value)
                                .ToArray();

            if (data.Length > 0)
            {
                graphPanel.Invalidate();
            }
            else
            {
                MessageBox.Show("Please enter data points separated by commas.");
            }
        }

        private void graphPanel_Paint(object sender, PaintEventArgs e)
        {
            if (data.Length == 0) return;

            Graphics g = e.Graphics;
            int panelWidth = graphPanel.Width;
            int panelHeight = graphPanel.Height;

            int margin = 40;
            int numBars = data.Length;
            int barWidth = (panelWidth - 2 * margin) / numBars;
            int maxDataValue = Math.Max(data.Max(), Math.Abs(data.Min()));
            int chartHeight = panelHeight - 2 * margin;

            int xAxisYPosition = panelHeight / 2;
            g.DrawLine(Pens.Black, margin, margin, margin, panelHeight - margin);
            g.DrawLine(Pens.Black, margin, xAxisYPosition, panelWidth - margin, xAxisYPosition);

            int scaleStep = maxDataValue / 5;
            for (int i = -5; i <= 5; i++)
            {
                int y = xAxisYPosition - (int)(chartHeight * (i * scaleStep) / (double)(2 * maxDataValue));
                g.DrawLine(Pens.Gray, margin - 5, y, margin + 5, y);
                g.DrawString((i * scaleStep).ToString(), this.Font, Brushes.Black, 0, y - 8);
            }

            for (int i = 0; i < numBars; i++)
            {
                int barHeight = (int)((Math.Abs(data[i]) / (double)maxDataValue) * (chartHeight / 2));
                int xPosition = margin + i * barWidth;
                int yPosition = data[i] >= 0 ? xAxisYPosition - barHeight : xAxisYPosition;

                Brush brush = new SolidBrush(colors[i % colors.Length]);
                g.FillRectangle(brush, xPosition, yPosition, barWidth - 10, barHeight);

                string label = $"Bar {i + 1}";
                int labelYPosition = data[i] >= 0 ? yPosition - 20 : yPosition + barHeight + 5;
                g.DrawString(label, this.Font, Brushes.Black, xPosition, labelYPosition);
            }
        }
    }
}
