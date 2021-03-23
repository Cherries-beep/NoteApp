using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    /// <summary>
    /// Класс заметок
    /// </summary>
    public class Note

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
        private string _textNote;
        /// <summary>
        /// Дата и время создания заметки.
        /// </summary>
        private DateTime _dateCreate;
        /// <summary>
        /// Дата и время последнего редактирования.
        /// </summary>
        private DateTime _dateModific;

        /// <summary>
        /// Свойство категории заметки.
        /// </summary>
        public Category Category
        {
            get { return _category; }
            set
            {
                switch (value)
                {
                    case Category.Work:
                        {
                            _category = Category.Work;
                            break;
                        }
                    case Category.Home:
                        {
                            _category = Category.Home;
                            break;
                        }
                    case NoteApp.Category.HealthAndSport:
                        {
                            _category = NoteApp.Category.HealthAndSport;
                            break;
                        }
                    case Category.People:
                        {
                            _category = Category.People;
                            break;
                        }
                    case Category.Documents:
                        {
                            _category = Category.Documents;
                            break;
                        }
                    case Category.Finance:
                        {
                            _category = Category.Finance;
                            break;
                        }
                    case Category.Different:
                        {
                            _category = Category.Different;
                            break;
                        }
                    default:

                        break;
                }

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
        public string TextNote
        {
            get { return _textNote; }

            set { _textNote = value; }

        }

        /// <summary>
        /// Свойство даты создания заметки.
        /// </summary>
        public DateTime DateCreate
        {

            get { return _dateCreate; }

        }

        /// <summary>
        /// Свойство даты последнего редактирования заметки.
        /// </summary>
        public DateTime DateModific
        {
            get { return _dateModific; }

            set
            {
                _dateModific = DateTime.Now;

            }

        }

    }

    

}
