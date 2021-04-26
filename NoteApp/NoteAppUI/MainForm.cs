using System.Data;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    /// <summary>
    /// Пользовательский интерфейс 
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Экземпляр проекта для сериализации и десериализации
        /// </summary>
        private Project _project = new Project();

        /// <summary>
        /// Список отсортированных заметок, выводимых на экран
        /// </summary>
        private List<Note> _reviewedNotes = new List<Note>();

        /// <summary>
        /// Создаёт экземпляр формы MainForm
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            CategoryComboBox.Items.Add("All");
            var categories = Enum.GetValues(typeof(Category)).Cast<object>().ToArray();
            CategoryComboBox.Items.AddRange(categories);
            CategoryComboBox.SelectedItem = "All";

            _project = ProjectManager.LoadData(ProjectManager.DefaultFileName);
            UpdateListBox();

            //Выберает последнюю просматреваемую заметку, если она существует 
            if (NoteList.Items.Count > 0)
            {
                NoteList.SelectedIndex = _project.SelectedNoteIndex;
            }
        }

        /// <summary>
        /// Обновляет список заметок, отображаемых на главной форме
        /// </summary>
        public void UpdateListBox()
        {
            //Сортировка в соответствии с выбранной категорией
            if (CategoryComboBox.SelectedItem == (object)"All")
            {
                _project.Notes = _project.SortNotes(_project.Notes);
                _reviewedNotes = _project.Notes.ToList();
            }
            else
            {
                _reviewedNotes = _project.SortNotes(_project.Notes, (Category)CategoryComboBox.SelectedItem);
            }

            //Загружает поля в список заметок на экране
            NoteList.Items.Clear();
            foreach (Note note in _reviewedNotes)
            {
                NoteList.Items.Add(note.Name);
            }

            if (NoteList.Items.Count > 0)
            {
                NoteList.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Обновляет отображение правой панели главной формы.
        /// Выводит название, текст, категорию и даты выбранной заметки
        /// </summary>
        public void UpdateRightPanel()
        {
            var chosed = NoteList.SelectedIndex;
            if (chosed == -1)
            {
                TextBox.Text = "";
                NoteTitleLabel.Text = "Title";
                CategoryLabel.Text = "None";
                CreatedDateTimePicker.Value = DateTime.Now;
                ModificDateTimePicker.Value = DateTime.Now;
            }
            else
            {
                var currentNote = _reviewedNotes[chosed];
                TextBox.Text = currentNote.NoteText;
                NoteTitleLabel.Text = currentNote.Name;
                CategoryLabel.Text = currentNote.Category.ToString();
                CreatedDateTimePicker.Value = currentNote.DateCreate;
                ModificDateTimePicker.Value = currentNote.DateModific;
            }
        }

        /// <summary>
        /// Вызывает окно создания заметки
        /// </summary>
        private void AddNote()
        {
            var note = new Note();
            var noteForm = new NoteForm();
            noteForm.Note = note;
            noteForm.ShowDialog();
            if (noteForm.DialogResult == DialogResult.OK)
            {
                note = noteForm.Note;

                //Добавляет заметку в реальный список
                _project.Notes.Insert(0, note);
                //Добавляет заметку в ListBox
                NoteList.Items.Insert(0, note.Name);
                //Добавляет заметку в отображаемый список
                _reviewedNotes.Insert(0, note);

                NoteList.SelectedIndex = 0;

                ProjectManager.SaveData(_project, ProjectManager.DefaultFileName);
            }
        }

        /// <summary>
        /// Вызывает окно редактирования заметки
        /// </summary>
        private void EditNote()
        {
            var chosed = NoteList.SelectedIndex;

            if (chosed == -1)
            {
                return;
            }
            else
            {
                var note = _reviewedNotes[chosed];
                var editForm = new NoteForm();
                editForm.Note = note;
                editForm.ShowDialog();
                if (editForm.DialogResult == DialogResult.OK)
                {
                    note = editForm.Note;

                    //Заменяет заметку в реальном списке
                    var realIndex = _project.Notes.IndexOf(_reviewedNotes[chosed]);
                    _project.Notes.RemoveAt(realIndex);
                    _project.Notes.Insert(0, note);
                    //Заменяет заметку в отображаемом списке
                    _reviewedNotes.RemoveAt(chosed);
                    _reviewedNotes.Insert(0, note);
                    //Заменяет заметку в ListBox
                    NoteList.Items.RemoveAt(chosed);
                    NoteList.Items.Insert(0, note.Name);

                    NoteList.SelectedIndex = 0;

                    ProjectManager.SaveData(_project, ProjectManager.DefaultFileName);
                }
            }
        }

        /// <summary>
        /// Удаляет заметку при подтверждении
        /// </summary>
        private void RemoveNote()
        {
            var chosed = NoteList.SelectedIndex;

            if (chosed == -1)
            {
                return;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show
                    ("Are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    //Удаляет заметку в реальном списке
                    var realIndex = _project.Notes.IndexOf(_reviewedNotes[chosed]);
                    _project.Notes.RemoveAt(realIndex);
                    //Удаляет заметку в отображаемом  списке
                    _reviewedNotes.RemoveAt(chosed);
                    //Удаляет заметку в ListBox
                    NoteList.Items.RemoveAt(chosed);

                    if (NoteList.Items.Count > 0)
                    {
                        NoteList.SelectedIndex = 0;
                    }

                    ProjectManager.SaveData(_project, ProjectManager.DefaultFileName);
                }
            }
        }

        //Обработчик событий
        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateListBox();
            UpdateRightPanel();
        }

        private void NoteListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRightPanel();
        }

        private void MainForm_KeyDownPanel(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveNote();
            }
        }

        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            AddNote();
        }

        private void EditNoteButton_Click(object sender, EventArgs e)
        {
            EditNote();
        }

        private void DeleteNoteButton_Click(object sender, EventArgs e)
        {
            RemoveNote();
        }

        private void AddNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNote();
        }

        private void EditNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditNote();
        }

        private void RemoveNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveNote();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _project.SelectedNoteIndex = NoteList.SelectedIndex;
            ProjectManager.SaveData(_project, ProjectManager.DefaultFileName);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddNoteButton_Click_1(object sender, EventArgs e)
        {
            AddNote();
        }

        private void EditNoteButton_Click_1(object sender, EventArgs e)
        {
            EditNote();
        }

        private void DeleteNoteButton_Click_1(object sender, EventArgs e)
        {
            RemoveNote();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
