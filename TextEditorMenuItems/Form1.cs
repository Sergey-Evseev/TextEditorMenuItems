using System;
using System.Collections.Generic;
using System.ComponentModel;
/*Lesson 6. Task 1.Разработать текстовый редактор, организовать открытие 
/ сохранение текстовых файлов.
• В панели инструментов расположить кнопки (Открыть, сохранить, новый документ, 
  копировать, вырезать, вставить, отменить, 
• кнопка настройки редактора (цвет шрифта, цвет фона, шрифт)).
• Меню должно дублировать панель инструментов (+ выделить всё, + сохранить как).
• В Заголовке окна находиться полный путь к файлу.
• Организовать контекстное меню для окна редактора (Копировать, Вырезать, Вставить, 
Отменить).*/

using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TextEditorMenuItems
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            newToolStripButton.Click += newToolStripMenuItem_Click;

            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            openToolStripButton.Click += openToolStripMenuItem_Click;

            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            saveToolStripButton.Click += saveToolStripMenuItem_Click;
            
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click; 

            cutToolStripMenuItem.Click += cutToolStripMenuItem_Click;   
            cutToolStripButton.Click += cutToolStripMenuItem_Click;

            contextMenuStrip1 = new ContextMenuStrip();
            contextMenuStrip1.Items.Add("New");
            contextMenuStrip1.Items.Add("Open");
            contextMenuStrip1.Items.Add("Cut");
            contextMenuStrip1.Items.Add("Copy");
            contextMenuStrip1.Items.Add("Insert");
        }       

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "C:\\";
            dialog.Filter = "All Files(*.*)|*.*|Text Files(*txt)|*.txt";
            dialog.FilterIndex = 2;
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox.ReadOnly = false;
                contextMenuStrip1.Enabled = true;

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
