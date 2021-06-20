using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NoteApp;


namespace NoteAppUI
{
    /// <summary>
    /// Пользовательский интерфейс
    /// </summary>
    public partial class NoteForm : Form
    {
        /// <summary>
        /// Поле для временного хранения переданных данных 
        /// </summary>
        private Note _note;

        /// <summary>
        /// Возвращает или задает данные извне
        /// </summary>
        public Note Note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = value;
                UpdateNoteForm();
            }
        }

        /// <summary>
        /// Создаёт экземпляр формы <see cref="NoteForm">
        /// </summary>
        public NoteForm()
        {
            InitializeComponent();
            var categories = Enum.GetValues(typeof(Category)).Cast<object>().ToArray();
            CategoryComboBox.Items.AddRange(categories);
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _note.Category = (Category)CategoryComboBox.SelectedItem;
        }

        private void MainTextBox_TextChanged(object sender, EventArgs e)
        {
            _note.NoteText = MainTextBox.Text;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (TitleTextBox.BackColor == Color.LightSalmon)
            {
                MessageBox.Show("Note name is too large: more than 50 characters", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Выводит значения при загрузке данных
        /// </summary>
        private void UpdateNoteForm()
        {
            TitleTextBox.Text = _note.Name;
            CategoryComboBox.SelectedItem = _note.Category;
            CreatedDateTimePicker.Value = _note.DateCreate;
            ModifiedTimePicker.Value = _note.DateModific;
            MainTextBox.Text = _note.NoteText;
        }

        private void TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _note.Name = TitleTextBox.Text;

                TitleTextBox.BackColor = Color.White;
                TitleToolTip.Active = false;
            }
            catch
            {
                TitleTextBox.BackColor = Color.LightSalmon;
                TitleToolTip.Active = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NoteForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void MainTextBox_TextChanged_1(object sender, EventArgs e)
        {

        }

       /* private void TitleTextBox_TextChanged_1(object sender, EventArgs e)
        {

        }*/

        /* private void TitleTextBox_TextChanged_1(object sender, EventArgs e)
         {

         }*/
    }
}
