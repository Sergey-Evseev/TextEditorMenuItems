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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TextEditorMenuItems
{
    public partial class Form1 : Form
    {
        
        //переменная для хранения адреса файла
        public string path { get; set; } = ""; ///
        public Form1()
        {
            InitializeComponent();
            newToolStripMenuItem.Click += newToolStripMenuItem_Click; ////////
            newToolStripButton.Click += newToolStripMenuItem_Click;   ///////

            openToolStripMenuItem.Click += openToolStripMenuItem_Click; //
            openToolStripButton.Click += openToolStripMenuItem_Click; //

            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click; ///
            saveToolStripButton.Click += saveToolStripMenuItem_Click; /////
            
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click; ////

            selectAllToolStripMenuItem.Click += selectAllToolStripMenuItem_Click; //

            copyContextMenuStrip.Click += CopyToolStripMenuItem_Click; //
            copyToolStripMenuItem.Click += CopyToolStripMenuItem_Click; //
            CopyToolStripButton.Click += CopyToolStripMenuItem_Click; //

            cutToolStripMenuItem.Click += cutToolStripMenuItem_Click; //  
            cutToolStripButton.Click += cutToolStripMenuItem_Click; //
            cutContextMenuStrip.Click += cutToolStripMenuItem_Click; //

            cancelContextMenuStrip.Click += cancelToolStripMenuItem_Click;//
            cancelToolStripMenuItem.Click += cancelToolStripMenuItem_Click; // 
            
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e) //
        //https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.forms.textboxbase.canundo?view=windowsdesktop-7.0
        {
            if (textBox.CanUndo == true) //если метод возвращает true 
            {
                textBox.Undo(); //то можно вызвать Undo метод для отмены посл. операции
                textBox.ClearUndo(); //очистка буфера чтобы предотвратить redo
            }
        }             

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Copy();
        } //

        //обработчик нажатия кнопки "New" меню File и панели инструментов
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();            
            dialog.Filter = "All Files(*.*)|*.*|Text Files(*.txt)|*.txt";
            dialog.FilterIndex = 2;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox.ReadOnly = false;
                contextMenuStrip1.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                insertToolStripMenuItem.Enabled = true;
                cancelToolStripMenuItem.Enabled = true;
                selectAllToolStripMenuItem.Enabled = true;

                saveToolStripButton.Enabled = true;
                CopyToolStripButton.Enabled = true;
                cutToolStripButton.Enabled = true;
                insertToolStripButton.Enabled = true;

                path = dialog.FileName;
                Text = $"Text editor - {path}";
                StreamWriter writing = new StreamWriter(path, false, Encoding.Default);
                writing.Write(textBox.Text);
                writing.Close();
            }

        }//

        //обработчик открытия файла
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "C:\\";
            dialog.Filter = "All Files(*.*)|*.*|Text Files(*txt)|*.txt";
            dialog.FilterIndex = 2;
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox.ReadOnly = false; //
                contextMenuStrip1.Enabled = true; //
                saveToolStripMenuItem.Enabled = true; //
                saveAsToolStripMenuItem.Enabled = true; //
                cutToolStripMenuItem.Enabled = true; //
                copyToolStripMenuItem.Enabled = true; //
                insertToolStripMenuItem.Enabled = true; //
                cancelToolStripMenuItem.Enabled = true; //
                selectAllToolStripMenuItem.Enabled = true; //

                saveToolStripButton.Enabled = true; //
                CopyToolStripButton.Enabled = true; //
                cutToolStripButton.Enabled = true; //
                insertToolStripButton.Enabled = true; //

                path = dialog.FileName; //
                Text = $"Text editor - {path}"; //
                StreamReader reader = new StreamReader(dialog.FileName, Encoding.Default); //
                textBox.Text = reader.ReadToEnd(); //
                reader.Close(); //
            }
        } //
        
        //обработчик сохранения файла
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "All Files(*.*)|*.*|Text Files(*txt)|*.txt";
            dialog.FilterIndex = 2;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Text = $"Text editor - {dialog.FileName}";
                path = dialog.FileName;
                StreamWriter writer = new StreamWriter(dialog.FileName, false,
                    Encoding.Default);
                writer.Write(textBox.Text);
                writer.Close();
            }
        } //

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (path != "")
            {
                StreamWriter writer = new StreamWriter(path, false, Encoding.Default);
                writer.Write(textBox.Text);
                writer.Close();
            }
            else MessageBox.Show("Choose file for saving!", "Warning", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }//

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Cut();
        } /// 
   
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.SelectAll();
        } //
    }
}
