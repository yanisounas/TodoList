
using System.Windows.Forms;

namespace TodoList
{
    partial class MainForm
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
            this.minimizeBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.homeBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.homePanel = new System.Windows.Forms.Panel();
            this.doneList = new System.Windows.Forms.ListBox();
            this.wipList = new System.Windows.Forms.ListBox();
            this.todoList = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.homePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.FlatAppearance.BorderSize = 0;
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeBtn.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeBtn.Location = new System.Drawing.Point(1123, 1);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(15, 23);
            this.minimizeBtn.TabIndex = 10;
            this.minimizeBtn.Text = "";
            this.minimizeBtn.UseVisualStyleBackColor = true;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Location = new System.Drawing.Point(1139, 1);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(20, 23);
            this.closeBtn.TabIndex = 9;
            this.closeBtn.Text = "";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.logoutBtn);
            this.panel1.Controls.Add(this.homeBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 794);
            this.panel1.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe MDL2 Assets", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(0, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 122);
            this.button1.TabIndex = 15;
            this.button1.Text = "";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // logoutBtn
            // 
            this.logoutBtn.FlatAppearance.BorderSize = 0;
            this.logoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutBtn.Font = new System.Drawing.Font("Segoe MDL2 Assets", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.Location = new System.Drawing.Point(0, 328);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(120, 122);
            this.logoutBtn.TabIndex = 14;
            this.logoutBtn.Text = " ";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // homeBtn
            // 
            this.homeBtn.FlatAppearance.BorderSize = 0;
            this.homeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeBtn.Font = new System.Drawing.Font("Segoe MDL2 Assets", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeBtn.Location = new System.Drawing.Point(0, 72);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(123, 122);
            this.homeBtn.TabIndex = 12;
            this.homeBtn.Text = "";
            this.homeBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("FiraCode Nerd Font Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Todo List";
            // 
            // homePanel
            // 
            this.homePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.homePanel.Controls.Add(this.doneList);
            this.homePanel.Controls.Add(this.wipList);
            this.homePanel.Controls.Add(this.todoList);
            this.homePanel.Controls.Add(this.label4);
            this.homePanel.Controls.Add(this.label3);
            this.homePanel.Controls.Add(this.label2);
            this.homePanel.Location = new System.Drawing.Point(121, 23);
            this.homePanel.Name = "homePanel";
            this.homePanel.Size = new System.Drawing.Size(1038, 771);
            this.homePanel.TabIndex = 12;
            // 
            // doneList
            // 
            this.doneList.AllowDrop = true;
            this.doneList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.doneList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.doneList.Font = new System.Drawing.Font("FiraCode Nerd Font Mono", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doneList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.doneList.FormattingEnabled = true;
            this.doneList.ItemHeight = 24;
            this.doneList.Items.AddRange(new object[] { "Liste3Element1", "Liste3Element2", "Liste3Element3", "Liste3Element4" });
            this.doneList.Location = new System.Drawing.Point(742, 77);
            this.doneList.Name = "doneList";
            this.doneList.Size = new System.Drawing.Size(260, 626);
            this.doneList.TabIndex = 7;
            this.doneList.DragEnter += new System.Windows.Forms.DragEventHandler(this.doneList_DragEnter);
            this.doneList.DragLeave += new System.EventHandler(this.ListDragLeave);
            this.doneList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.doneList_MouseDown);
            // 
            // wipList
            // 
            this.wipList.AllowDrop = true;
            this.wipList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.wipList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wipList.Font = new System.Drawing.Font("FiraCode Nerd Font Mono", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wipList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.wipList.FormattingEnabled = true;
            this.wipList.ItemHeight = 24;
            this.wipList.Items.AddRange(new object[] { "Liste2Element1", "Liste2Element2", "Liste2Element3", "Liste2Element4" });
            this.wipList.Location = new System.Drawing.Point(388, 77);
            this.wipList.Name = "wipList";
            this.wipList.Size = new System.Drawing.Size(260, 626);
            this.wipList.TabIndex = 6;
            this.wipList.DragEnter += new System.Windows.Forms.DragEventHandler(this.wipList_DragEnter);
            this.wipList.DragLeave += new System.EventHandler(this.ListDragLeave);
            this.wipList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.wipList_MouseDown);
            // 
            // todoList
            // 
            this.todoList.AllowDrop = true;
            this.todoList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.todoList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.todoList.Font = new System.Drawing.Font("FiraCode Nerd Font Mono", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.todoList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.todoList.FormattingEnabled = true;
            this.todoList.ItemHeight = 24;
            this.todoList.Items.AddRange(new object[] { "Liste1Element1", "Liste1Element2", "Liste1Element3", "Liste1Element4" });
            this.todoList.Location = new System.Drawing.Point(35, 77);
            this.todoList.Name = "todoList";
            this.todoList.Size = new System.Drawing.Size(260, 626);
            this.todoList.TabIndex = 0;
            this.todoList.DragEnter += new System.Windows.Forms.DragEventHandler(this.todoList_DragEnter);
            this.todoList.DragLeave += new System.EventHandler(this.ListDragLeave);
            this.todoList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.todoList_MouseDoubleClick);
            this.todoList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.todoList_MouseDown);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("FiraCode Nerd Font Mono", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(836, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Done";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("FiraCode Nerd Font Mono", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(490, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "WIP";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("FiraCode Nerd Font Mono", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(125, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Todo";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1161, 792);
            this.Controls.Add(this.homePanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.minimizeBtn);
            this.Controls.Add(this.closeBtn);
            this.Font = new System.Drawing.Font("FiraCode Nerd Font Mono", 8.249999F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.panel1.ResumeLayout(false);
            this.homePanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ListBox wipList;
        private System.Windows.Forms.ListBox doneList;

        private System.Windows.Forms.ListBox todoList;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Button logoutBtn;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Panel homePanel;

        private System.Windows.Forms.Button homeBtn;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button minimizeBtn;

        #endregion
    }
}