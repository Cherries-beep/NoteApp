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
        /// Устанавливает и возвращает значение категории заметки.
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
        /// Устанавливает и возвращает значение названия заметки.
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
        /// Устанавливает и возвращает значение текста заметки
        /// </summary>
        public string NoteText
        {
            get { return _text; }

            set { _text = value; }

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
                _modified = DateTime.Now;

            }

        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }

    

}
