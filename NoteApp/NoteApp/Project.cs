using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private List<Note> notes;

        /// <summary>
        /// Своство заметок.
        /// </summary>
        public List<Note> Notes
        {
            get { return notes; }
            set
            {
                notes = value;
            }
        }
    }





}

