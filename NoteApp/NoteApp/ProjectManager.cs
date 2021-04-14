using System;
using Newtonsoft.Json;
using System.IO;
namespace NoteApp
{
    static public class ProjectManager
    {
        private static string _pathfile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\NoteApp\\NoteApp.json";

        public static string DefaultFileName
        {
            get
            {
                return _pathfile;
            }
        }

        /// <summary>
        /// Метод сохранения объекта Project в файл.
        /// </summary>
        public static void SaveData(Project project, string FileName)
        {
            var folder = Path.GetDirectoryName(FileName);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            //Создаём экземпляр сериализатора
            var serializer = new JsonSerializer();
            //Открываем поток для записи в файл с указанием пути
            using (StreamWriter sw = new StreamWriter(FileName))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и передаем объект, который хотим сериализовать
                serializer.Serialize(writer, project);
            }
        }


        /// <summary>
        /// Метод загрузки объекта Project из файла.
        ///</summary>
        public static Project LoadData(string FileName)//проверки
        {

            var readingProject = new Project();
            if (File.Exists(FileName))
            {
                try
                {
                    var serializer = new JsonSerializer();
                    //Открываем поток для чтения из файла с указанием пути
                    using (var sr = new StreamReader(FileName))
                    using (var reader = new JsonTextReader(sr))
                        //Вызываем десериализацию и явно преобразуем результат в целевой тип данных
                        readingProject = (Project)serializer.Deserialize<Project>(reader);
                }

                catch
                {
                    return new Project();
                }
                if (readingProject != null)
                {
                    return readingProject;
                }
            }
            return new Project();
        }
    }
}
