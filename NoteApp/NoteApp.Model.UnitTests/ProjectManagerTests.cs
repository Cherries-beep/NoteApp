using NUnit.Framework;
using System;
using System.IO;

namespace NoteApp.UnitTests

{ 
    [TestFixture]
    class ProjectManagerTests
    {
        // <summary>
        /// Экземпляр класса Note для проведения тестов
        /// </summary>
        private Note _note;

        /// <summary>
        /// Экземпляр класса Project для проведения тестов
        /// </summary>
        private Project _project;

        /// <summary>
        /// Путь к директории с тестовыми файлами
        /// </summary>
        private static string _currentPath = Path.GetFullPath
            (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"))
            + "TestData\\";

        /// <summary>
        /// Путь к корректному файлу
        /// </summary>
        private string _saveFilePath = _currentPath + "SavedFile.notes";

        /// <summary>
        /// Путь к корректному файлу
        /// </summary>
        private string _correctFilePath = _currentPath + "CorrectFile.notes";

        /// <summary>
        /// Некорректный путь к файлу
        /// </summary>
        private string _uncorrectFilePath = _currentPath + "NonExistFile.notes";

        /// <summary>
        /// Путь к повреждённому файлу
        /// </summary>
        private string _damagedFilePath = _currentPath + "DamagedFile.notes";

        [SetUp]
        public void Project_Init()
        {
            _note = new Note(new DateTime(2000, 01, 01));
            _project = new Project();
            _project.Notes.Add(_note);
        }

        [Test(Description = "Позитивный тест геттера Notes")]
        public void DefaultPath_CorrectValue_ReturnValue()
        {
            //Setup - инициализация проекта вынесена в атрибут [SetUp]
            var expected = Environment.GetFolderPath
               (Environment.SpecialFolder.ApplicationData)
               + "\\NoteApp\\NoteApp.json";

            //Actual
            var actual = ProjectManager.DefaultFileName;

            //Assert
            Assert.AreEqual(expected, actual,
                "Геттер DefaultPath возвращает неправильный путь");
        }

        [Test(Description = "Позитивный тест сериализации")]
        public void SaveToFile_CorrectValue_ReturnValue()
        {
            //Setup - инициализация проекта вынесена в атрибут [SetUp]
            var expected = File.ReadAllText(_correctFilePath);

            //Act
            ProjectManager.SaveData(_project, _saveFilePath);
            var actual = File.ReadAllText(_saveFilePath);

            //Assert
            Assert.AreEqual(expected, actual,
                "Метод SaveToFile возвращает неправильный проект");
        }

        [Test(Description = "Позитивный тест десериализации - папка существует")]
        public void LoadFromFile_CorrectValue_ReturnValue()
        {
            //Setup - инициализация проекта вынесена в атрибут [SetUp]
            var expected = _project;

            //Act
            var actual = ProjectManager.LoadData(_correctFilePath);

            //Assert
            Assert.AreEqual(expected.SelectedNoteIndex, actual.SelectedNoteIndex,
                "Метод LoadFromFile возвращает неправильный проект");
            Assert.AreEqual(expected.Notes[0].Name, actual.Notes[0].Name,
                "Метод LoadFromFile возвращает неправильный проект");
            Assert.AreEqual(expected.Notes[0].NoteText, actual.Notes[0].NoteText,
                "Метод LoadFromFile возвращает неправильный проект");
            Assert.AreEqual(expected.Notes[0].Category, actual.Notes[0].Category,
                "Метод LoadFromFile возвращает неправильный проект");
            Assert.AreEqual(expected.Notes[0].DateCreate, actual.Notes[0].DateCreate,
                "Метод LoadFromFile возвращает неправильный проект");
            Assert.AreEqual(expected.Notes[0].DateModific, actual.Notes[0].DateModific,
                "Метод LoadFromFile возвращает неправильный проект");
        }

        [Test(Description = "Негативный тест десериализации - папки не существует")]
        public void LoadFromFile_UncorrectPath_ReturnNewProject()
        {
            //Setup - инициализация проекта вынесена в атрибут [SetUp]
            var expected = new Project();

            //Act
            var actual = ProjectManager.LoadData(_uncorrectFilePath);

            //Assert
            Assert.AreEqual(expected.Notes, actual.Notes,
                "Метод LoadFromFile возвращает неправильный проект");
            Assert.AreEqual(expected.SelectedNoteIndex, actual.SelectedNoteIndex,
                "Метод LoadFromFile возвращает неправильный проект");
        }

        [Test(Description = "Тест десериализации если файл повреждён")]
        public void LoadFromFile_DamagedFile_ReturnNewProject()
        {
            //Setup - инициализация проекта вынесена в атрибут [SetUp]
            var expected = new Project();

            //Act
            var actual = ProjectManager.LoadData(_damagedFilePath);

            //Assert
            Assert.AreEqual(expected.Notes, actual.Notes,
                "Метод LoadFromFile возвращает неправильный проект");
            Assert.AreEqual(expected.SelectedNoteIndex, actual.SelectedNoteIndex,
                "Метод LoadFromFile возвращает неправильный проект");
        }

    }
}
