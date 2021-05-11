using System;
using Newtonsoft.Json;

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
            private set { _created = DateTime.Now; }
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

        /// <summary>
        /// Создает экземпляр <see cref="Note"> по умолчанию
        /// </summary>
        public Note()
        {
        }
        /// <summary>
        /// Создает экземпляр <see cref="Note"> для сериализации и десериализации
        /// </summary>
        /// <param name="title">Название заметки</param>
        /// <param name="text">Текст заметки</param>
        /// <param name="category">Категория заметки</param>
        /// <param name="created">Время создания заметки</param>
        /// <param name="modified">Время последнего редактирования заметки</param>
        [JsonConstructor]
        public Note(string name, string text, Category category,
            DateTime created, DateTime modified)
        {
            Name = name;
            NoteText = text;
            Category = category;
            DateCreate = created;
            DateModific = modified;
        }

        /// <summary>
        /// Конструктор с пользовательскими значениями 
        /// даты создания и последнего редактирования.
        /// Только для проведения тестов!
        /// </summary>
        /// <param name="testTime">Время создания</param>
        public Note(DateTime testTime)
        {
            DateCreate = testTime;
            DateModific = testTime;
        }
    }

}
