namespace InternPractice1
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbWeek = new System.Windows.Forms.ComboBox();
            this.Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.DataSearch = new System.Windows.Forms.Button();
            this.all_illustrate = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Day7 = new System.Windows.Forms.TextBox();
            this.Day1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ImptSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DailyCB = new System.Windows.Forms.ComboBox();
            this.NextBtn = new System.Windows.Forms.Button();
            this.PrevBtn = new System.Windows.Forms.Button();
            this.DailyCheck = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbWeek
            // 
            this.tbWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbWeek.FormattingEnabled = true;
            this.tbWeek.Items.AddRange(new object[] {
            "5월 1주차",
            "5월 2주차",
            "5월 3주차",
            "5월 4주차"});
            this.tbWeek.Location = new System.Drawing.Point(105, 20);
            this.tbWeek.Name = "tbWeek";
            this.tbWeek.Size = new System.Drawing.Size(121, 24);
            this.tbWeek.TabIndex = 3;
            this.tbWeek.SelectedIndexChanged += new System.EventHandler(this.TbTag_SelectedIndexChanged);
            // 
            // Chart
            // 
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.Name = "ChartArea1";
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.Name = "ChartArea2";
            this.Chart.ChartAreas.Add(chartArea1);
            this.Chart.ChartAreas.Add(chartArea2);
            this.Chart.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.Chart.Location = new System.Drawing.Point(12, 12);
            this.Chart.Name = "Chart";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.PaleGreen;
            series1.CustomProperties = "PixelPointWidth=25";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.SkyBlue;
            series2.CustomProperties = "PixelPointWidth=25";
            series2.Name = "Series2";
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.OrangeRed;
            series3.CustomProperties = "PixelPointWidth=25";
            series3.Name = "Series3";
            series4.ChartArea = "ChartArea2";
            series4.Color = System.Drawing.Color.Transparent;
            series4.CustomProperties = "PixelPointWidth=10";
            series4.MarkerSize = 2;
            series4.Name = "Series4";
            series4.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.Chart.Series.Add(series1);
            this.Chart.Series.Add(series2);
            this.Chart.Series.Add(series3);
            this.Chart.Series.Add(series4);
            this.Chart.Size = new System.Drawing.Size(710, 364);
            this.Chart.TabIndex = 2;
            this.Chart.Text = "chart1";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(6, 22);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 4;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.MonthCalendar1_DateChanged);
            // 
            // DataSearch
            // 
            this.DataSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DataSearch.Location = new System.Drawing.Point(6, 101);
            this.DataSearch.Name = "DataSearch";
            this.DataSearch.Size = new System.Drawing.Size(220, 23);
            this.DataSearch.TabIndex = 7;
            this.DataSearch.Text = "All Production Quantity";
            this.DataSearch.UseVisualStyleBackColor = true;
            this.DataSearch.Click += new System.EventHandler(this.DataSearch_Click);
            // 
            // all_illustrate
            // 
            this.all_illustrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.all_illustrate.Location = new System.Drawing.Point(6, 20);
            this.all_illustrate.Name = "all_illustrate";
            this.all_illustrate.Size = new System.Drawing.Size(220, 23);
            this.all_illustrate.TabIndex = 8;
            this.all_illustrate.Text = "Illustration";
            this.all_illustrate.UseVisualStyleBackColor = true;
            this.all_illustrate.Click += new System.EventHandler(this.Analysis_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Format = "yyyy-MM-dd HH:mm:ss";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(6, 20);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.Format = "yyyy-MM-dd HH:mm:ss";
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(440, 85);
            this.dataGridView1.TabIndex = 9;
            // 
            // Day7
            // 
            this.Day7.BackColor = System.Drawing.SystemColors.Window;
            this.Day7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Day7.Location = new System.Drawing.Point(105, 73);
            this.Day7.Name = "Day7";
            this.Day7.ReadOnly = true;
            this.Day7.Size = new System.Drawing.Size(121, 22);
            this.Day7.TabIndex = 11;
            // 
            // Day1
            // 
            this.Day1.BackColor = System.Drawing.SystemColors.Window;
            this.Day1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Day1.Location = new System.Drawing.Point(105, 46);
            this.Day1.Name = "Day1";
            this.Day1.ReadOnly = true;
            this.Day1.Size = new System.Drawing.Size(121, 22);
            this.Day1.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.monthCalendar1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(728, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 196);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calendar";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(12, 384);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(710, 114);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Production Quantity";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Format = "yyyy-MM-dd HH:mm:ss";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.Location = new System.Drawing.Point(469, 20);
            this.dataGridView2.Name = "dataGridView2";
            dataGridViewCellStyle4.Format = "yyyy-MM-dd HH:mm:ss";
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(235, 85);
            this.dataGridView2.TabIndex = 9;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.ImptSearch);
            this.groupBox4.Controls.Add(this.DataSearch);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.tbWeek);
            this.groupBox4.Controls.Add(this.Day7);
            this.groupBox4.Controls.Add(this.Day1);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox4.Location = new System.Drawing.Point(728, 215);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(232, 161);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Data Search";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(3, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "End date";
            // 
            // ImptSearch
            // 
            this.ImptSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImptSearch.Location = new System.Drawing.Point(6, 130);
            this.ImptSearch.Name = "ImptSearch";
            this.ImptSearch.Size = new System.Drawing.Size(220, 23);
            this.ImptSearch.TabIndex = 0;
            this.ImptSearch.Text = "Imported Quantity";
            this.ImptSearch.UseVisualStyleBackColor = true;
            this.ImptSearch.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(3, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Start date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Select week";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DailyCB);
            this.groupBox3.Controls.Add(this.NextBtn);
            this.groupBox3.Controls.Add(this.PrevBtn);
            this.groupBox3.Controls.Add(this.DailyCheck);
            this.groupBox3.Controls.Add(this.all_illustrate);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox3.Location = new System.Drawing.Point(728, 384);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(232, 114);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data Analysis";
            // 
            // DailyCB
            // 
            this.DailyCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DailyCB.FormattingEnabled = true;
            this.DailyCB.Location = new System.Drawing.Point(87, 81);
            this.DailyCB.Name = "DailyCB";
            this.DailyCB.Size = new System.Drawing.Size(58, 24);
            this.DailyCB.TabIndex = 12;
            this.DailyCB.SelectedIndexChanged += new System.EventHandler(this.DailyCB_SelectedIndexChanged);
            // 
            // NextBtn
            // 
            this.NextBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.NextBtn.Location = new System.Drawing.Point(151, 80);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(75, 26);
            this.NextBtn.TabIndex = 11;
            this.NextBtn.Text = "Next";
            this.NextBtn.UseVisualStyleBackColor = true;
            this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // PrevBtn
            // 
            this.PrevBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.PrevBtn.Location = new System.Drawing.Point(6, 80);
            this.PrevBtn.Name = "PrevBtn";
            this.PrevBtn.Size = new System.Drawing.Size(75, 26);
            this.PrevBtn.TabIndex = 10;
            this.PrevBtn.Text = "Prev";
            this.PrevBtn.UseVisualStyleBackColor = true;
            this.PrevBtn.Click += new System.EventHandler(this.PrevBtn_Click);
            // 
            // DailyCheck
            // 
            this.DailyCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.DailyCheck.Location = new System.Drawing.Point(6, 51);
            this.DailyCheck.Name = "DailyCheck";
            this.DailyCheck.Size = new System.Drawing.Size(220, 23);
            this.DailyCheck.TabIndex = 9;
            this.DailyCheck.Text = "Daily Check";
            this.DailyCheck.UseVisualStyleBackColor = true;
            this.DailyCheck.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 508);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Chart);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox tbWeek;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button DataSearch;
        private System.Windows.Forms.Button all_illustrate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox Day7;
        private System.Windows.Forms.TextBox Day1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox DailyCB;
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.Button PrevBtn;
        private System.Windows.Forms.Button DailyCheck;
        private System.Windows.Forms.Button ImptSearch;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}