namespace bargraph
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtData = new TextBox();
            btnDrawGraph = new Button();
            graphPanel = new Panel();
            SuspendLayout();
            // 
            // txtData
            // 
            txtData.Location = new Point(21, 26);
            txtData.Name = "txtData";
            txtData.Size = new Size(200, 27);
            txtData.TabIndex = 0;
            // 
            // btnDrawGraph
            // 
            btnDrawGraph.Location = new Point(57, 81);
            btnDrawGraph.Name = "btnDrawGraph";
            btnDrawGraph.Size = new Size(100, 30);
            btnDrawGraph.TabIndex = 1;
            btnDrawGraph.Text = "Generate";
            btnDrawGraph.UseVisualStyleBackColor = true;
            btnDrawGraph.Click += btnDrawGraph_Click;
            // 
            // graphPanel
            // 
            graphPanel.Location = new Point(309, 26);
            graphPanel.Name = "graphPanel";
            graphPanel.Size = new Size(450, 300);
            graphPanel.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 403);
            Controls.Add(graphPanel);
            Controls.Add(btnDrawGraph);
            Controls.Add(txtData);
            Name = "Form1";
            Text = "Bar Graph";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtData;
        private Button btnDrawGraph;
        private Panel graphPanel;
    }
}
