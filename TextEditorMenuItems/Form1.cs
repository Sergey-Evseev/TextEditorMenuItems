using System;
using System.Collections.Generic;
using System.ComponentModel;
/*Lesson 6. Task 1.Разработать текстовый редактор, организовать открытие 
/ сохранение текстовых файлов.
• В панели инструментов расположить кнопки (Открыть, сохранить, новый документ, 
копировать, вырезать, вставить, отменить, кнопка настройки 
редактора (цвет шрифта, цвет фона, шрифт)).
• Меню должно дублировать панель инструментов (+ выделить всё, + сохранить как).
• В Заголовке окна находиться полный путь к файлу.
• Организовать контекстное меню для окна редактора (Копировать, Вырезать, Вставить, 
Отменить).*/

using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditorMenuItems
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}
