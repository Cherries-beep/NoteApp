using System.Collections.Generic;
using System.Linq;

namespace NoteApp
{
    /// <summary>
    /// Класс Project, хранящий данные о заметках.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Список заметок.
        /// </summary>
        private List<Note> _notes;

        /// <summary>
        /// Возвращает или задает список заметок.
        /// </summary>
        public List<Note> Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
            }
        }

        // <summary>
        /// Индекс последней просматриваемой заметки
        /// </summary>
        public int SelectedNoteIndex
        {
            get;
            set;
        } = -1;

        /// <summary>
        /// Сортировка списока заметок по дате редактирования
        /// </summary>
        public List<Note> SortNotes(List<Note> notes)
        {
            var sortNotes = notes.OrderByDescending(note => note.DateModific).ToList();
            return sortNotes;
        }

        /// <summary>
        /// Сортирует список заметок по дате редактирования, 
        /// оставляя заметки конкретной категории
        /// </summary>
        public List<Note> SortNotes(List<Note> notes, Category category)
        {
            var categoryNotes = notes.Where(note => note.Category == category).ToList();
            var sortedNotes = categoryNotes.OrderByDescending(note => note.DateModific).ToList();
            return sortedNotes;
        }

    }
   
}

