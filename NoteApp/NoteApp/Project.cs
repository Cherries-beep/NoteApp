using System.Collections.Generic;

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
    }




}

