namespace DrawButtons
{
    public partial class Form1 : Form
    {
        private Point buttonTopLeft = Point.Empty;
        private Button currentButton = null;
        private int buttonIndex = 0;
        private Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();

            MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    buttonTopLeft = e.Location;
                    currentButton = new Button
                    {
                        Location = e.Location,
                        Text = (buttonIndex++).ToString(),
                        BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256))
                    };
                    Controls.Add(currentButton);
                    currentButton.BringToFront();
                }
            };

            MouseMove += (s, e) =>
            {
                if (!buttonTopLeft.IsEmpty)
                {
                    currentButton.Location = new Point(
                        Math.Min(e.X, buttonTopLeft.X),
                        Math.Min(e.Y, buttonTopLeft.Y)
                    );
                    currentButton.Width = Math.Abs(e.X - buttonTopLeft.X);
                    currentButton.Height = Math.Abs(e.Y - buttonTopLeft.Y);
                }
            };

            MouseUp += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    buttonTopLeft = Point.Empty;
                    currentButton = null;
                }
            };
        }
    }
}