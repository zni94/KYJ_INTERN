using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Windows.Forms.DataVisualization.Charting;

namespace InternPractice1
{
    public partial class Form2 : System.Windows.Forms.Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // database connection information
        NpgsqlConnection npgConnection = new NpgsqlConnection("Server=localhost;Port=5432;Username=postgres;Password=udmt;Database=DYPRemoteDB");

        // Form2에서 쓰일 전역 변수
        DataTable Info1 = new DataTable(); DataTable Info2 = new DataTable(); DataTable Info3 = new DataTable();
        DataTable Group = new DataTable(); DataTable Group2 = new DataTable();

        List<int> count = new List<int>();

        String[] day = new string[7];

        string strCommand; string tbTag; string tbTag2; string tbTag3;

        int j = 0;

        private string Form2_value;
        public string Passvalue
        {
            get { return Form2_value; }
            set { Form2_value = value; }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            tbTag = Passvalue;
        }

        private void TbTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime[] time = new DateTime[1];

            switch (tbWeek.Text)
            {
                case "5월 1주차":
                    Day1.Text = "2019-05-06";
                    break;
                case "5월 2주차":
                    Day1.Text = "2019-05-13";
                    break;
                case "5월 3주차":
                    Day1.Text = "2019-05-20";
                    break;
                case "5월 4주차":
                    Day1.Text = "2019-05-27";
                    break;
            }
            DateTime.TryParse(Day1.Text, null, System.Globalization.DateTimeStyles.AssumeLocal, out time[0]);
            monthCalendar1.SetDate(time[0]);
        }
        // ComboBox에서 해당 주차를 선택할 시 각 주의 월요일의 Datetime을 Text로 받아와 datatime으로 parsing한다.
        // 이어서 해당 Datetime으로 달력을 이동.

        private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime[] times = new DateTime[2];

            for (int i = 0; i < day.Length; i++)
            {
                day[i] = monthCalendar1.SelectionStart.AddDays(i).ToShortDateString();
            }
            DateTime.TryParse(day[0], null, System.Globalization.DateTimeStyles.AssumeLocal, out times[0]);
            DateTime.TryParse(day[6], null, System.Globalization.DateTimeStyles.AssumeLocal, out times[1]);

            Day1.Text = day[0]; Day7.Text = day[6];

            monthCalendar1.SelectionRange = new SelectionRange(times[0], times[1]);
        }
        // 위에서 MonthCalendar1에 변화가 발생하므로 자동적으로 다음의 이벤트가 진행됨.

        private void Prod_SQL(string command, string value, string tablename, string name, string date, string tag, DataTable data)
        {
            command = // SQL query (search values for selected date and address)
                                "SELECT count(" + value + ") as " + name + " FROM  " + tablename + " " +
                                "WHERE timestamp ::TEXT LIKE '" + date + " %' " +
                                "AND address = '" + tag + "' ";

            NpgsqlDataAdapter dataAdapterT = new NpgsqlDataAdapter(command, npgConnection);
            dataAdapterT.Fill(data);
        }

        private void DataSearch_Click(object sender, EventArgs e)
        {
            npgConnection.Open();

            Info1.Clear(); Info2.Clear(); Group.Clear();
            try
            {
                switch (tbTag)
                {
                    case "D00011":
                        tbTag2 = "D04033"; tbTag3 = "D04030";
                        break;
                    case "D00012":
                        tbTag2 = "D04033"; tbTag3 = "D04030";
                        break;
                    case "D00131":
                        tbTag2 = "D05033"; tbTag3 = "D05030";
                        break;
                    case "D00132":
                        tbTag2 = "D05033"; tbTag3 = "D05030";
                        break;
                }
                Group.Columns.Add("all"); Group.Columns.Add("imported"); Group.Columns.Add("defective"); Group.Columns.Add("datetime");

                for (int i = 0; i < day.Length; i++)
                {
                    Prod_SQL(strCommand, "*", "tbl_log_product", "all", day[i], tbTag2, Info1);
                    Prod_SQL(strCommand, "*", "tbl_log_product", "imported", day[i], tbTag3, Info2);

                    DataRow[] all = Info1.Select();
                    DataRow[] imported = Info2.Select();

                    Group.Rows.Add(all[i]["all"], imported[i]["imported"], (Convert.ToInt32(all[i]["all"]) - Convert.ToInt32(imported[i]["imported"])).ToString(), day[i]);
                }

                if (DailyCB.Items.Count == 0)
                {
                    for (int i = 0; i < day.Length; i++)
                    {
                        count.Add(i);
                    }

                    for (int i = 0; i < count.Count; i++)
                    {
                        DailyCB.Items.Add(i);
                    }
                }

                dataGridView1.DataSource = Group;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            npgConnection.Close();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            Refresh_data(j);
        }

        private void Analysis_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Chart.Series.Count; i++)
            {
                Chart.Series[i].Points.Clear();
                Chart.Legends.Clear();
            } // Chart에 남아있는 Point를 Clear하는 과정

            DataRow[] all = Group.Select();
            //DataRow[] ipt_dft = Group.Select();

            Chart.DataSource = Group;
            Chart.Series[0].Name = "All"; Chart.Series[1].Name = "Imported"; Chart.Series[2].Name = "Defective"; Chart.Series[3].Name = "Day";

            Chart.Series["All"].ChartType = SeriesChartType.Column; Chart.Series["Imported"].ChartType = SeriesChartType.Column; Chart.Series["Defective"].ChartType = SeriesChartType.Column; Chart.Series["Day"].ChartType = SeriesChartType.Column;

            // Chart의 Legend를 추가
            Chart.Legends.Add("Defective"); Chart.Legends.Add("Imported"); Chart.Legends.Add("All"); Chart.Legends.Add("Day");

            // Chart Series에 Legend를 Mapping
            Chart.Series[0].Legend = "All"; Chart.Series[1].Legend = "Imported"; Chart.Series[2].Legend = "Defective"; Chart.Series[3].Legend = "Day";

            // Legend를 ChartArea1 안으로 Docking
            Chart.Legends["All"].DockedToChartArea = "ChartArea1"; Chart.Legends["Imported"].DockedToChartArea = "ChartArea1"; Chart.Legends["Defective"].DockedToChartArea = "ChartArea1"; Chart.Legends["Day"].DockedToChartArea = "ChartArea2";
            Chart.Legends["All"].IsDockedInsideChartArea = true; Chart.Legends["Imported"].IsDockedInsideChartArea = true; Chart.Legends["Defective"].IsDockedInsideChartArea = true; Chart.Legends["Day"].IsDockedInsideChartArea = true;

            // Legend의 Font Size 조정

            // Group에 있는 값들을 X,Y 축에 추가.
            for (int i = 0; i < Group.Rows.Count; i++)
            {
                Chart.Series[0].Points.AddXY(all[i]["datetime"], all[i]["all"]);
                Chart.Series[1].Points.AddXY(all[i]["datetime"], all[i]["imported"]);
                Chart.Series[2].Points.AddXY(all[i]["datetime"], all[i]["defective"]);
            }
            Chart.ChartAreas[0].AxisY.Interval = 100;
            Chart.ChartAreas[1].AxisY.Interval = 100;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DailyCB.Text = j.ToString();

            for (int i = 0; i < Chart.Series.Count; i++)
            {
                Chart.Series[i].Points.Clear();
            } // Chart에 남아있는 Point를 Clear하는 과정

            DataRow[] Daily = Group.Select();

            Chart.Series[0].Points.AddXY(Daily[count[j]]["datetime"], Daily[count[j]]["all"]);
            Chart.Series[1].Points.AddXY(Daily[count[j]]["datetime"], Daily[count[j]]["imported"]);
            Chart.Series[2].Points.AddXY(Daily[count[j]]["datetime"], Daily[count[j]]["defective"]);

            DataRow[] Day = Group2.Select();

            for (int i = 0; i < Day.Count(); i++)
            {
                Chart.Series[3].Points.AddXY(Day[i]["Line"], Day[i]["Imported"]);
            }
        }

        private void PrevBtn_Click(object sender, EventArgs e)
        {
            if (j > 0)
            {
                j = j - 1;
                DailyCB.Text = j.ToString();
            }

            Refresh_data(j);
            Chart_Add(j);
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            if (j < count.Count - 1)
            {
                j = j + 1;
                DailyCB.Text = j.ToString();
            }

            Refresh_data(j);
            Chart_Add(j);
        }

        private void DailyCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            j = Convert.ToInt32(DailyCB.Text);

            Refresh_data(j);
            Chart_Add(j);
        }

        private void Chart_Add(int k)
        {
            for (int i = 0; i < Chart.Series.Count; i++)
            {
                Chart.Series[i].Points.Clear();
            } // Chart에 남아있는 Point를 Clear하는 과정

            DataRow[] Daily = Group.Select();
            DataRow[] Day = Group2.Select();

            Chart.Series[0].Points.AddXY(Daily[count[k]]["datetime"], Daily[count[k]]["all"]);
            Chart.Series[1].Points.AddXY(Daily[count[k]]["datetime"], Daily[count[k]]["imported"]);
            Chart.Series[2].Points.AddXY(Daily[count[k]]["datetime"], Daily[count[k]]["defective"]);
            
            for(int i = 0; i < Day.Length; i++)
            {
                Chart.Series[3].Points.AddXY(Day[i]["Line"], Day[i]["Imported"]);
            }
        }

        private void Refresh_data(int k)
        {
            Info3.Clear(); Group2.Clear();

            String[] tag1 = { "D04101", "D04103", "D04105", "D04107" };
            String[] tag2 = { "D05101", "D05103", "D05105", "D05107" };

            switch (tbTag3)
            {
                case "D04030":
                    for (int i = 0; i < tag1.Count(); i++)
                    {
                        Prod_SQL(strCommand, "value", "tbl_log_product", "imported", day[count[k]], tag1[i], Info3);
                    }
                    break;
                case "D05030":
                    for (int i = 0; i < tag2.Count(); i++)
                    {
                        Prod_SQL(strCommand, "value", "tbl_log_product", "imported", day[count[k]], tag2[i], Info3);
                    }
                    break;
            }

            DataRow[] Tag = Info3.Select();
            DataRow[] Day = Group.Select();

            if (Group2.Columns.Count == 0)
            {
                Group2.Columns.Add("Imported"); Group2.Columns.Add("Line");
            }

            Group2.Rows.Add(Day[count[k]]["imported"], Day[count[k]]["datetime"]);

            for (int i = 0; i < tag1.Length; i++)
            {
                Group2.Rows.Add(Tag[i]["Imported"], tag1[i]);
            }

            dataGridView2.DataSource = Group2;
        }
    }
}
