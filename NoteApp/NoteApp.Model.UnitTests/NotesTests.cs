using System;
using NUnit.Framework;


namespace NoteApp.UnitTests
{
    [TestFixture]
    public class NotesTests
    {
        ///<summary>
        ///Экземпляр класса для проведения тестов
        ///</summary>
        private Note _note;

        [SetUp]
        public void Note_Init()
        {
            _note = new Note();
        }

        [Test(Description = "Позитивный тест геттера и сеттера Name")]
        public void Name_CorrectValue_ReturnValue()
        {
            Note_Init();
            var expected = "Test Name for note";

            //Actual - полученный результат
            _note.Name = expected;
            var actual = _note.Name;

            //Assert - сравнение результата + текст сообщения об ошибке
            Assert.AreEqual(actual, expected,
            "Геттер или сеттер Name возвращает неправильный текст");
        }

        [Test(Description = "Присвоение значения Name более чем 50 символов ")]
        public void Name_LongName_ThrowsException()
        {
            Note_Init();    

            //Actual - полученный результат
            var wrongName = "rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr";

            //Accert - сравнение результата + текст сообщения об ошибке
            Assert.Throws<ArgumentException>(
               () => { _note.Name = wrongName; },
                   "Должно возникать исключение, если название длиннее 50 символов");
        }

        [Test(Description = "Присвоение пустой строки в качестве Name" +
            "По умолчанию - Без названия")]
        public void Name_EmptyString_ReturnUntitled()
        {
            Note_Init();
            var expected = "Untitled";

            //Actual - полученный результат
            _note.Name = "";
            var actual = _note.Name;

            //Accert - сравнение результата + текст сообщения об ошибке
            Assert.AreEqual(actual, expected,
                "Сеттер устанавливает неправильное название заметки");
        }

        [Test(Description = "Позитивный тест геттера и сеттера Category")]
        public void Category_CorrectValue_ReturnValue()
        {
            Note_Init();
            var expected = Category.People;

            //Actual - полученный результат
            _note.Category = expected;
            var actual = _note.Category;

            //Accert - сравнение результата + текст сообщения об ошибке
            Assert.AreEqual(expected, actual,
                "Геттер или сеттер Category возвращает неправильный объект");
        }

        [Test(Description = "Позитивный тест геттера и сеттера NoteText")]
        public void Text_CorrectValue_ReturnValue()
        {
            Note_Init();
            var expected = "Hello Hello Hello";

            //Actual - полученный результат
            _note.NoteText = expected;
            var actual = _note.NoteText;

            //Accert - сравнение результата + текст сообщения об ошибке
            Assert.AreEqual(expected, actual,
                "Геттер или сеттер Text возвращает неправильный объект");
        }

        [Test(Description = "Позитивный тест геттера и сеттера DateCreate")]
        public void Created_CorrectValue_ReturnValue()
        {
            Note_Init();
            var expected = DateTime.Now;

            //Actual 
            var actual = _note.DateCreate;

            //Accert - сравнение результата + текст сообщения об ошибке
            Assert.AreEqual(expected.Minute, actual.Minute,
                "Геттер Created возвращает неправильный объект");
        }

        [Test(Description = "Позитивный тест геттера и сеттера DateModific")]
        public void Modified_CorrectValue_ReturnValue()
        {
            Note_Init();
            var expected = DateTime.Now;

            //Actual 
            var actual = _note.DateModific;

            //Accert - сравнение результата + текст сообщения об ошибке
            Assert.AreEqual(expected.Minute, actual.Minute,
                "Геттер Modified возвращает неправильный объект");
        }

        [Test(Description = "Позитивный тест стандартного конструктора класса Note")]
        public void NoteConstructor_CorrectValue_ReturnValue()
        {
            Note_Init();
            var expectedTitle = "Untitled";
            string expectedText = null;
            var expectedCategory = Category.Work;
            var expectedCreated = DateTime.Now;
            var expectedModified = DateTime.Now;

            //Actual - стандартный конструктор вызывается в атрибуте [SetUp]
            var actual = _note;

            //Assert
            Assert.AreEqual(expectedTitle, actual.Name,
                "Стандартный конструктор возвращает неправильное имя заметки");
            Assert.AreEqual(expectedText, actual.NoteText,
                "Стандартный конструктор возвращает неправильный текст заметки");
            Assert.AreEqual(expectedCategory, actual.Category,
                "Стандартный конструктор возвращает неправильную категорию заметки");
            Assert.AreEqual(expectedCreated.Minute, actual.DateCreate.Minute,
                "Стандартный конструктор возвращает неправильное время создания заметки");
            Assert.AreEqual(expectedModified.Minute, actual.DateModific.Minute,
                "Стандартный конструктор возвращает неправильное время" +
                 "последнего редактирования заметки");
        }

        [Test(Description = "Позитивный тест Json конструктора класса Note")]
        public void NoteJsoneConstructor_CorrectValue_ReturnValue()
        {
            Note_Init();
            var expectedTitle = "TestTitle";
            var expectedText = "TestText";
            var expectedCategory = Category.Work;
            var expectedCreated = DateTime.Now;
            var expectedModified = DateTime.Now;

            //Actual
            var actual = new Note(expectedTitle, expectedText, expectedCategory,
            expectedCreated, expectedModified);

            //Assert
            Assert.AreEqual(expectedTitle, actual.Name,
                "Json конструктор возвращает неправильное имя заметки");
            Assert.AreEqual(expectedText, actual.NoteText,
                "Json конструктор возвращает неправильный текст заметки");
            Assert.AreEqual(expectedCategory, actual.Category,
                "Json конструктор возвращает неправильную категорию заметки");
            Assert.AreEqual(expectedCreated.Minute, actual.DateCreate.Minute,
                "Json конструктор возвращает неправильное время создания заметки");
            Assert.AreEqual(expectedModified.Minute, actual.DateModific.Minute,
                "Json конструктор возвращает неправильное время" +
                 "последнего редактирования заметки");
        }

        [Test(Description = "Позитивный тест конструктора для тестов")]
        public void NoteTestConstructor_CorrectValue_ReturnValue()
        {
            Note_Init();
            var expectedName = "Untitled";
            string expectedText = null;
            var expectedCategory = Category.Work;
            var expectedCreated = new DateTime(2000, 01, 01);
            var expectedModified = expectedCreated;

            //Actual
            var actual = new Note(new DateTime(2000, 01, 01));

            //Assert
            Assert.AreEqual(expectedName, actual.Name,
                "Стандартный конструктор возвращает неправильное имя заметки");
            Assert.AreEqual(expectedText, actual.NoteText,
                "Стандартный конструктор возвращает неправильный текст заметки");
            Assert.AreEqual(expectedCategory, actual.Category,
                "Стандартный конструктор возвращает неправильную категорию заметки");
            Assert.AreEqual(expectedCreated.Minute, actual.DateCreate.Minute,
                "Стандартный конструктор возвращает неправильное время создания заметки");
            Assert.AreEqual(expectedModified.Minute, actual.DateModific.Minute,
                "Стандартный конструктор возвращает неправильное время" +
                 "последнего редактирования заметки");
        }

        [Test(Description = "Позитивный тест метода Clone")]
        public void Clone_CorrectValue_ReturnValue()
        {
            Note_Init(); 
            Note expected = _note;

            //Actual
            var actual = (Note)_note.Clone();

            //Assert
            Assert.AreEqual(expected.Name, actual.Name, "Метод Clone устанавливает " +
            "неправильное значение Title");
            Assert.AreEqual(expected.NoteText, actual.NoteText, "Метод Clone устанавливает " +
           "неправильное значение Text");
            Assert.AreEqual(expected.Category, actual.Category, "Метод Clone устанавливает " +
           "неправильное значение Category");
            Assert.AreEqual(expected.DateCreate, actual.DateCreate, "Метод Clone устанавливает " +
           "неправильное значение Created");
            Assert.AreEqual(expected.DateModific, actual.DateModific, "Метод Clone устанавливает " +
           "неправильное значение Modified");
        }
    }

}
