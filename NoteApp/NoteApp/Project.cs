using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
        /// Своство заметок.
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

