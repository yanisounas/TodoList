using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TodoList.ORM.Abstract;
using TodoList.ORM.Entity;
using TodoList.ORM.Repository;

namespace TodoList
{
    public partial class Login : Form
    {
        private bool _dragging = false;
        private Point _cursorPoint;
        private Point _formPoint;

        public MainForm MainForm;
        
        public Login()
        {
            InitializeComponent();
        }

        private void TryLogin()
        {
            if (String.IsNullOrWhiteSpace(username.Text) || String.IsNullOrWhiteSpace(password.Text))
            {
                if (String.IsNullOrWhiteSpace(username.Text)) MessageBox.Show(@"Username is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (String.IsNullOrWhiteSpace(password.Text)) MessageBox.Show(@"Password is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (UserRepository.UserExist(username.Text, password.Text))
                {
                    UserEntity userEntity = Repository.GetEntityBy<UserEntity>("username", username.Text);
                    
                    Close();
                    
                    MainForm.User = userEntity;
                    MainForm.Show();
                }
                else
                {
                    MessageBox.Show(@"Can't find user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Can't find user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
            MainForm.Close();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            TryLogin();
        }

        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TryLogin();
            }
        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TryLogin();
            }
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _cursorPoint = Cursor.Position;
            _formPoint = Location;
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(_cursorPoint));
                Location = Point.Add(_formPoint, new Size(dif));
            }
        }

        private void Login_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }
    }
}
