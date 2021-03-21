using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static void SaveDate(Project project, string nameFile)
        {
            //Создаём экземпляр сериализатора
            JsonSerializer serializer = new JsonSerializer();
            //Открываем поток для записи в файл с указанием пути
            using (StreamWriter sw = new StreamWriter(nameFile))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и передаем объект, который хотим сериализовать
                serializer.Serialize(writer, project);
            }
        }
        public static Project LoadDate(string nameFile)
        {
            Project project = null;
            //Создаём экземпляр сериализатора
            JsonSerializer serializer = new JsonSerializer();
            //Открываем поток для чтения из файла с указанием пути
            using (StreamReader sr = new StreamReader(nameFile))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                //Вызываем десериализацию и явно преобразуем результат в целевой тип данных
                project = (Project)serializer.Deserialize<Project>(reader);
            }
            
            return project;

        }
    }
   
}
