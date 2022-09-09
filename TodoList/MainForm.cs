using System;
using System.Drawing;
using System.Windows.Forms;
using TodoList.ORM.Entity;

namespace TodoList
{
    public partial class MainForm : Form
    {
        private readonly Login _loginForm;
        private bool _dragging = false;
        private Point _cursorPoint;
        private Point _formPoint;
        
        public UserEntity User;

        public MainForm()
        {
            InitializeComponent();
            _loginForm = new Login();
            _loginForm.MainForm = this;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (User != null) return;
            Hide();
            _loginForm.Show();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _cursorPoint = Cursor.Position;
            _formPoint = Location;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(_cursorPoint));
                Location = Point.Add(_formPoint, new Size(dif));
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }
    }
}