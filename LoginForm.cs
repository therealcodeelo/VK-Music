namespace VK_Music
{
    public partial class LoginForm : Form
    {
        private List<Control> _controls;
        public LoginForm()
        {
            InitializeComponent();
            _controls = new List<Control> { authButton, codeeloGradientPanel1, codeeloTextBox1, codeeloTextBox2, label1, pictureBox1, pictureBox2 };
            _controls.ForEach(control =>
            {
                control.MouseEnter += Control_MouseEnter;
                control.MouseLeave += Control_MouseLeave;
            });
        }

        private void Control_MouseLeave(object? sender, EventArgs e) => Opacity = 0.9;

        private void Control_MouseEnter(object? sender, EventArgs e) => Opacity = 1;

        private void label1_Click(object sender, EventArgs e)
        {
            _controls.ForEach(control =>
            {
                control.MouseEnter -= Control_MouseEnter;
                control.MouseLeave -= Control_MouseLeave;
            });
            Application.Exit();
        }

        private void authButton_Click(object sender, EventArgs e)
        {
            VK.SignIn(codeeloTextBox1.Text, codeeloTextBox2.Text);
            if(VK.IsAuth)
            {
                Hide();
                new MainForm().Show();
            }
        }
    }
}