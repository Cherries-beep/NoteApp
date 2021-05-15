using NUnit.Framework;

namespace NoteApp.UnitTests
{
    [TestFixture]
    class ProjectTests
    {
        /// <summary>
        /// Экземпляр класса Note для проведения тестов
        /// </summary>
        private Note _note;

        /// <summary>
        /// Экземпляр класса <see cref="Project"/> для проведения тестов
        /// </summary>
        private Project _project;

        [SetUp]
        public void Project_Init()
        {
            _note = new Note();
            _project = new Project();
        }

        [Test(Description = "Позитивный тест геттера и сеттера Notes")]
        public void Notes_CorrectValue_ReturnValue()
        {
            //Setup - инициализация проекта вынесена в атрибут [SetUp]
            var expected = _note;

            //Actual
            _project.Notes.Add(_note);
            var actual = _project.Notes[0];

            //Assert
            Assert.AreEqual(expected, actual,
                "Геттер или сеттер Notes возвращает неправильный " +
                "экземпляр класса Note");
        }

        [Test(Description = "Позитивный тест геттера и сеттера " +
            "SelectedNoteIndex")]
        public void SelectedNoteIndex_CorrectValue_ReturnValue()
        {
            //Setup - инициализация проекта вынесена в атрибут [SetUp]
            var expected = 30;

            //Actual
            _project.SelectedNoteIndex = 30;
            var actual = _project.SelectedNoteIndex;

            //Assert
            Assert.AreEqual(expected, actual,
                "Геттер или сеттер SelectedNoteIndex возвращает " +
                "неправильное значение");
        }


        [Test(Description = "Позитивный тест метода Sort")]
        public void Sort_CorrectValue_ReturnSortedList()
        {
            //Setup - инициализация проекта вынесена в атрибут [SetUp]
            InsertNote("FirstNote", _project, Category.Other);
            InsertNote("SecondNote", _project,Category.Other);
            InsertNote("ThirdNote", _project, Category.Other);

            var secondProject = new Project();
            InsertNote("ThirdNote", secondProject, Category.Other);
            InsertNote("SecondNote", secondProject, Category.Other);
            InsertNote("FirstNote", secondProject, Category.Other);
            var expected = secondProject.Notes;

            //Actual
            var actual = _project.SortNotes(_project.Notes);

            //Assert
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(expected[i].Name, actual[i].Name,
                    "Метод Sort возвращает Notes " +
                    "в неправильной последовательности");
            }
        }

        [Test(Description = "Позитивный тест метода Sort " +
            "с фильтром по конкретной категории")]
        public void CategorySort_CorrectValue_ReturnSortedList()
        {
            //Setup - инициализация проекта вынесена в атрибут [SetUp]
            InsertNote("FirstNote", _project, Category.Finance);
            InsertNote("SecondNote", _project, Category.Work);
            InsertNote("ThirdNote", _project, Category.Finance);

            var secondProject = new Project();
            InsertNote("ThirdNote", secondProject, Category.Finance);
            InsertNote("FirstNote", secondProject, Category.Finance);
            var expected = secondProject.Notes;

            //Actual
            _project.Notes = _project.SortNotes(_project.Notes, Category.Finance);
            var actual = _project.Notes;

            //Assert
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(expected[i].Name, actual[i].Name,
                    "Метод Sort возвращает Notes " +
                    "в неправильной последовательности");
            }
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(expected[i].Category, actual[i].Category,
                    "Метод Sort возвращает Notes " +
                    "с неправильным значением категории");
            }
        }

        /// <summary>
        /// Метод заполнения списка (вспомогательный)
        /// </summary>

        private void InsertNote(string TestName,
            Project testProject, Category testCategory)
        {
            
            System.Threading.Thread.Sleep(10);

            var testNote = new Note();
            testNote.Name = TestName;
            testNote.Category = testCategory;
            testProject.Notes.Add(testNote);
        }
    }
}
