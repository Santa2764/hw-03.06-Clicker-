namespace hw_03._06__Clicker_
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timerRemainder = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timerStart = new System.Windows.Forms.Timer();

        enum MaxValue { MaxSecondsStart = 3, MaxSecondsClicks = 10 };
        static int remainderSeconds = 3;
        static int remainderSecondsClicks = 10;

        static int counterClicks = 0;

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClickCounter";

            InitializeTimerRemainder();
            InitializeTimerStart();
            
        }

        private void InitializeTimerRemainder()
        {
            timerRemainder.Interval = 1000;
            timerRemainder.Tick += RemainderTimer;
        }

        private void InitializeTimerStart()
        {
            timerStart.Interval = 1000;
            timerStart.Tick += ClickTimer;
        }


        private void RemainderTimer(object? sender, EventArgs e)
        {
            timerLabel.Text = $"Start:  {--remainderSeconds}";
            if (remainderSeconds == 0) 
            {
                timerRemainder.Stop();
                remainderSeconds = (int)MaxValue.MaxSecondsStart; 
                StartMainTimer(); 
            }
        }

        private void ClickTimer(object? sender, EventArgs e)
        {
            timerLabel.Text = $"End:  {--remainderSecondsClicks}";
            if (remainderSecondsClicks == 0) 
            {
                timerStart.Stop(); 
                clickButton.Visible = false; 
                remainderSecondsClicks = (int)MaxValue.MaxSecondsClicks;
                MessageBox.Show($"CLicks: {counterClicks}", "Message");
                counterClicks = 0;
                Close();
            }
        }


        private void StartRemainderTimer()
        {
            timerLabel.Visible = true; 
            timerLabel.Text = $"Start:  {remainderSeconds}";
            timerRemainder.Start();
        }

        private void StartMainTimer()
        {
            clickButton.Visible = true;
            timerLabel.Text = $"End:  {remainderSecondsClicks}";
            timerStart.Start();
        }

        private void Start_MouseClick(object sender, MouseEventArgs e)
        {
            Controls.Remove(startButton);
            Controls.Remove(exitButton);
            StartRemainderTimer();
        }

        private void Click_MouseClick(object sender, MouseEventArgs e)
        {
            counterClicks++;
        }

        private void Exit_MouseClick(object sender, MouseEventArgs e)
        {
            var answer = MessageBox.Show("Do you want exit?", "Questions", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes) Close();
        }
    }
}