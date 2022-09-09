using System;
using System.Drawing;
using System.Windows.Forms;
using TodoList.ORM.Entity;

namespace TodoList
{
    public partial class MainForm : Form
    {
        private Login _loginForm;
        private bool _dragging = false;
        private Point _cursorPoint;
        private Point _formPoint;
        private object _listBoxItem = null;
        private bool _isOut = false;
        
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


        private void logoutBtn_Click(object sender, EventArgs e)
        {
            User = null;
            Hide();
            try
            {
                _loginForm.Show();
            }
            catch (Exception)
            {
                _loginForm = new Login();
                _loginForm.MainForm = this;
                _loginForm.Show();
            }
        }

        private void ListDragLeave(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;
            
            _listBoxItem = lb.SelectedItem;
            lb.Items.Remove(lb.SelectedItem);
        }

        private void ListDragEnter(ListBox listBox)
        {
            if (_listBoxItem != null)
            {
                listBox.Items.Add(_listBoxItem);
                _listBoxItem = null;
            }
        }

        private void ListMouseDown(ListBox listBox, int x, int y)
        {
            _listBoxItem = null;

            int index = listBox.IndexFromPoint(x, y);
            if (index == -1) return;

            string elementValue = listBox.Items[index].ToString();
            DragDropEffects dragDropEffects = DoDragDrop(elementValue, DragDropEffects.All);
        }
       
        private void todoList_DragEnter(object sender, DragEventArgs e)
        {
            ListDragEnter(todoList);
        }
        
        private void wipList_DragEnter(object sender, DragEventArgs e)
        {
            ListDragEnter(wipList);
        }

        private void doneList_DragEnter(object sender, DragEventArgs e)
        {
            ListDragEnter(doneList);
        }

        private void todoList_MouseDown(object sender, MouseEventArgs e)
        {
            ListMouseDown(todoList, e.X, e.Y);
        }

        private void wipList_MouseDown(object sender, MouseEventArgs e)
        {
            ListMouseDown(wipList, e.X, e.Y);
        }

        private void doneList_MouseDown(object sender, MouseEventArgs e)
        {
            ListMouseDown(doneList, e.X, e.Y);
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if (_isOut)
            {
                _listBoxItem = null;
                _isOut = false;
            }
        }

        private void todoList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = todoList.IndexFromPoint(e.X, e.Y);
            if (index == -1) return;

            MessageBox.Show(todoList.Items[index].ToString());
        }
    }
}