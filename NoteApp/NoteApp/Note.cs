using System;

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
        private string _name = "Untitled";
        
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
        private DateTime _created = DateTime.Now;

        /// <summary>
        /// Дата и время последнего редактирования.
        /// </summary>
        private DateTime _modified = DateTime.Now;

        /// <summary>
        /// Устанавливает и возвращает значение категории заметки.
        /// </summary>
        public Category Category
        {
            get { return _category; }
            set
            {
                _category = value;
                DateModific = DateTime.Now;
            }
        }

        /// <summary>
        /// Устанавливает или возвращает значение названия заметки.
        ///Устанавливает время последнего изменения.
        /// </summary>
        public string Name
        {
            get { return _name; }

            set
            {

                if (value.Length > 50)

                {
                    throw new ArgumentException("Количество символов в заметке не может превышать 50");
                }
                else if (value == "")
                {
                    _name = "Untitled";
                    DateModific = DateTime.Now;
                }
                else
                {
                    _name = value;
                    DateModific = DateTime.Now;
                }

            }
        }

        /// <summary>
        /// Устанавливает и возвращает значение текста заметки
        /// </summary>
        public string NoteText
        {
            get { return _text; }
            set 
            {
                _text = value;
                DateModific = DateTime.Now;
            }

        }

        /// <summary>
        /// Устанавливает и возвращает значение даты создания заметки.
        /// </summary>
        public DateTime DateCreate
        {

            get { return _created; }

            

        }

        /// <summary>
        /// Устанавливает и возвращает значение даты последнего редактирования заметки.
        /// </summary>
        public DateTime DateModific 
        {
            get { return _modified; }

            set
            {
                _modified = value;

            }

        } 

        /// <summary>
        /// Реализация интерфейса IClonable
        /// </summary>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

}
