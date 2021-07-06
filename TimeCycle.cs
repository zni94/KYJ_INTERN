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
    public partial class TimeCycle : Form
    {
        public TimeCycle()
        {
            InitializeComponent();
            AddGroupBox();
        }

        // database connection information
        NpgsqlConnection npgConnection = new NpgsqlConnection("Server=localhost;Port=5432;Username=postgres;Password=udmt;Database=DYPRemoteDB");

        // global parameter
        DataTable Temp_Info = new DataTable(); DataTable Cycle_Info = new DataTable();
        DataTable Cycle = new DataTable();

        DateTimePicker TimeStart; DateTimePicker TimeEnd;

        TextBox TextDate; ComboBox comboTag;

        string strDate;
        string strTag; string strTag2;
        string strHourS; string strHourE;
        string strCommand;

        // 한 Cycle은 1~69 0 이다.
        List<int> CycleStart = new List<int>(); // Cycle의 시작은 1부터
        List<int> CycleEnd = new List<int>(); // Cycle의 끝은 0까지
        int j = 0;

        // Winform Design 설정
        private void AddGroupBox()
        {
            // Group1에 달력을 삽입.
            Group1.Name = "Calendar";
            this.Controls.Add(Group1);

            MonthCalendar monthCalendar = monthCalendar1;
            Group1.Controls.Add(monthCalendar);

            // 날짜 및 시간에 대한 정보를 Group2로 묶음
            Group2.Name = "Info";
            this.Controls.Add(Group2);

            TextDate = tbDate;
            Group2.Controls.Add(TextDate);

            TimeStart = tbTimeS; TimeEnd = tbTimeE;
            TimeStart.CustomFormat = "HH:mm:ss"; TimeEnd.CustomFormat = "HH:mm:ss";
            Group2.Controls.Add(TimeStart); Group2.Controls.Add(TimeEnd);

            comboTag = tbTag1;
            Group2.Controls.Add(comboTag);
        }

        private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            tbDate.Text = monthCalendar1.SelectionStart.ToShortDateString();
        } // 달력의 데이터에 변화가 있을 시 달력의 값을 인풋변수로서 받는다. Clear

        // Npgsql 연동 밑 데이터를 불러와서 DataTable에 넣는 작업.
        // Datatable에 들어간 데이터를 Form에서 Datagridview로 보여주는 작업.
        private void btnSearch1_Click(object sender, EventArgs e)
        {
            Temp_Info.Reset(); Cycle_Info.Reset();

            npgConnection.Open(); // Server를 여는 작업.

            try
            {
                strDate = tbDate.Text; // 받아온 날짜를 하나의 문자열로 변환
                strTag = tbTag1.Text; // D00011 : MC#A front mold temperature

                if (strTag == "D00011" || strTag == "D00012")
                {
                    strTag2 = "D01002"; // D00011과 D00012의 싸이클시간
                }
                else
                {
                    strTag2 = "D02002"; // D00131과 D00132의 싸이클 시간
                }
                strHourS = tbTimeS.Text; // 받아온 시간을 문자열로 변환.
                strHourE = tbTimeE.Text; // 받아온 시간으로 부터 1시간 뒤 까지.

                SQL(strCommand, "temperature", "tbl_log_temperature", strDate, strHourS, strHourE, strTag, Temp_Info);
                
                dataGridView1.DataSource = Temp_Info;

                SQL(strCommand, "cycle", "tbl_log_cycle", strDate, strHourS, strHourE,  strTag2, Cycle_Info);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            npgConnection.Close();
        } // Temperature Info 에 관한 DataTable을 만드는 작업.

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            npgConnection.Open(); // Server를 여는 작업.

            TimeControl(Cycle_Info.Select(), new string[2], new DateTime[2]);

            npgConnection.Close();
        } // Cycle Info에 대한 Datatable을 만드는 작업.

        private void BtnAnalysis1_Click(object sender, EventArgs e)
        {
            npgConnection.Open();

            MinMax(Temp_Info, Temp_Info.Select(), Chart.ChartAreas[0], 0);

            // X,Y축에 대해서 차트의 구간을 지정 후 해당 구간에 대하여 확대해 볼 수 있음.
            Chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();

            Chart.ChartAreas[0].CursorX.IsUserEnabled = true;
            Chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            Chart.ChartAreas[0].CursorX.IntervalType = DateTimeIntervalType.Seconds;
            Chart.ChartAreas[0].CursorX.Interval = 10D;

            Chart.ChartAreas[0].AxisX.ScaleView.SmallScrollSizeType = DateTimeIntervalType.Seconds;
            Chart.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = 10D;

            Chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            Chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            npgConnection.Close();
        } // 시간에 대한 차트1

        private void BtnAnalysis2_Click(object sender, EventArgs e)
        {
            npgConnection.Open();

            CycleNumber.Text = j.ToString();

            MinMax(Cycle, Cycle.Select(), Chart.ChartAreas[1], 1);
            Chart.ChartAreas[1].AxisX.IntervalType = DateTimeIntervalType.Minutes;
            Chart.ChartAreas[1].AxisX.Interval = 0.5D;

            Cal(Cycle.Select());

            npgConnection.Close();
        } // 싸이클에 대한 차트2

        private void Button1_Click(object sender, EventArgs e)
        {
            npgConnection.Open();

            if (j > 0)
            {
                j = j - 1;
                CycleNumber.Text = j.ToString();
            }

            TimeControl(Cycle_Info.Select(), new string[2], new DateTime[2]);

            MinMax(Cycle, Cycle.Select(), Chart.ChartAreas[1], 1);
            Chart.ChartAreas[1].AxisX.IntervalType = DateTimeIntervalType.Minutes;
            Chart.ChartAreas[1].AxisX.Interval = 0.5D;

            Cal(Cycle.Select());

            npgConnection.Close();
        } // ChartAreas 2에서 Prev btn

        private void Button2_Click(object sender, EventArgs e)
        {
            npgConnection.Open();

            if (j < CycleStart.Count -1)
            {
                j = j + 1;
                CycleNumber.Text = j.ToString();
            }

            TimeControl(Cycle_Info.Select(), new string[2], new DateTime[2]);

            MinMax(Cycle, Cycle.Select(), Chart.ChartAreas[1], 1);
            Chart.ChartAreas[1].AxisX.IntervalType = DateTimeIntervalType.Minutes;
            Chart.ChartAreas[1].AxisX.Interval = 0.5D;

            Cal(Cycle.Select());

            npgConnection.Close();
        } // ChartAreas 2에서 Next btn

        private void TimeControl(DataRow[] data2, String[] str, DateTime[] dt)
        {
            Cycle.Clear();

            if (CycleStart.Count == 0)
            {
                for (int i = 0; i < data2.Length; i++)
                {
                    if (data2[i]["cycle"].ToString() == "1")
                    {
                        CycleStart.Add(i);
                    }

                    if (data2[i]["cycle"].ToString() == "0")
                    {
                        CycleEnd.Add(i);
                    }
                }
            }

            if(CycleNumber.Items.Count == 0)
            {
                for(int i = 0; i < CycleStart.Count;  i++)
                {
                    CycleNumber.Items.Add(i);
                }
            }

            DateTime.TryParse(data2[CycleStart[j]]["timestamp"].ToString(), null, System.Globalization.DateTimeStyles.AssumeLocal, out dt[0]);
            DateTime.TryParse(data2[CycleEnd[j]]["timestamp"].ToString(), null, System.Globalization.DateTimeStyles.AssumeLocal, out dt[1]);

            str[0] = dt[0].ToString("HH:mm:ss");
            str[1] = dt[1].ToString("HH:mm:ss");

            SQL(strCommand, "temperature", "tbl_log_temperature", strDate, str[0], str[1], strTag, Cycle);
            dataGridView2.DataSource = Cycle;
        } // Prev와 Next btn이 활성화 될 때 Time 구간을 Control하는 함수.

        private void Cal(DataRow[] data)
        {
            double sum = 0; double avg = 0; double variance = 0;
            List<double> Var = new List<double>();

            // Cycle에서 Temperature의 Sum과 Avg
            for (int i = 0; i < data.Length; i++)
            {
                sum = sum + Convert.ToDouble(data[i]["temperature"]);
                avg = sum / data.Length;
            }
            // Cycle에서 Temperature의 분산.
            for (int i = 0; i < data.Length; i++)
            {
                variance = Math.Pow(Convert.ToDouble(data[i]["temperature"]) - avg, 2) / data.Length;
                Var.Add(variance);
            }
            for (int i = 0; i < Var.Count - 1; i++)
            {
                variance += Var[i];
            }

            Calculate.Text = "Average : " + avg.ToString("##.##") + " Variance : " + variance.ToString("##.##");
        } // 평균과 분산을 구함

        private void SQL(string command, string name, string tablename, string date, string S_time, string E_time, string tag, DataTable data)
        {
            command = // SQL query (search values for selected date and address)
                                "SELECT value as " + name + ", timestamp FROM " + tablename + " " +
                                "WHERE timestamp ::TEXT BETWEEN '" + date + " " + S_time + "%' And '" + date + " " + E_time + "' " +
                                "AND address = '" + tag + "' " +
                                "ORDER BY timestamp ";

            NpgsqlDataAdapter dataAdapterT = new NpgsqlDataAdapter(command, npgConnection);
            dataAdapterT.Fill(data);
        }  // 반복되는 Query를 함수로 만듦으로써 반복을 줄인다.

        private void MinMax(DataTable table, DataRow[] data, ChartArea area, int k)
        {
            Chart.Series[k].Points.Clear();

            Chart.DataSource = table;
            Chart.Series[k].ChartType = SeriesChartType.Line;
            Chart.Series[k].XValueType = ChartValueType.Time;
            area.AxisX.LabelStyle.Format = "HH:mm:ss";

            //Cycle을 찾는 작업
            for (int i = 0; i < data.Length; i++)
            {
                Chart.Series[k].Points.AddXY(data[i]["timestamp"], data[i]["temperature"]);
            }

            // y축의 min값을 설정
            var ymin = 9999;

            for (int i = 0; i < data.Length; i++)
            {
                if (ymin > Convert.ToInt32(data[i]["temperature"]))
                {
                    ymin = Convert.ToInt32(data[i]["temperature"]);
                    ymin = (ymin / 10) * 10;
                }
            }
            area.AxisY.Minimum = ymin;
        } // 각 차트에서 데이터를 input하고 X,Y축의 Min Max값을 설정.

        private void btnSearch3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Passvalue = tbTag1.Text; // tbTag1에 저장된 " D00011" 값을 Form2의 tbTag2.Text에 저장
            form2.ShowDialog();
        }

        private void CycleNumber_TextChanged(object sender, EventArgs e)
        {
            j = Convert.ToInt32(CycleNumber.Text);

            TimeControl(Cycle_Info.Select(), new string[2], new DateTime[2]);

            MinMax(Cycle, Cycle.Select(), Chart.ChartAreas[1], 1);
            Chart.ChartAreas[1].AxisX.IntervalType = DateTimeIntervalType.Minutes;
            Chart.ChartAreas[1].AxisX.Interval = 0.5D;

            Cal(Cycle.Select());
        }
    }
}