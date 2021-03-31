using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    /// <summary>
    /// Заметки
    /// </summary>
    public class Note : ICloneable
    {
        /// <summary>
        /// Название заметки.
        /// </summary>
        private string _name;
        
        /// <summary>
        /// Категория заметки.
        /// </summary>
        private Category _category;
        
        /// <summary>
        /// Текст заметки.
        /// </summary>
        private string _text;
        
        /// <summary>
        /// Дата и время создания заметки.
        /// </summary>
        private DateTime _created;
        /// <summary>
        /// Дата и время последнего редактирования.
        /// </summary>
        private DateTime _modified;

        /// <summary>
        /// Свойство категории заметки.
        /// </summary>
        public Category Category
        {
            get { return _category; }
            set
            {
                _category = value;
            }
        }

        /// <summary>
        /// Свойство названия заметки.
        /// </summary>
        public string Name
        {
            get { return _name; }

            set
            {

                if (value.Length < 50)

                {
                    throw new ArgumentException("Количество символов в заметке не может превышать 50");
                }
                else if (value.Length != 0)
                {
                    throw new ArgumentException("Количество символов в заметке не может быть нулевым");
                }

                else
                {
                    _name = value;
                }

            }
        }

        /// <summary>
        /// Свойство текста заметки
        /// </summary>
        public string NoteText
        {
            get { return _text; }

            set { _text = value; }

        }

        /// <summary>
        /// Свойство даты создания заметки.
        /// </summary>
        public DateTime DateCreate
        {

            get { return _created; }

        }

        /// <summary>
        /// Свойство даты последнего редактирования заметки.
        /// </summary>
        public DateTime DateModific
        {
            get { return _modified; }

            set
            {
                _modified = DateTime.Now;

            }

        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }

    

}
