using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zametki_Bal_Kuz
{
    internal class AppData
    {
        public static int user_id;
        public static string user_name;
        public static string user_token;

        // Токен пользователя - это ключ к аккаунту
        // Если имеется ключ (токен), то мы можем впустить пользователя без ввода логина и пароля

        public static void setUserToken(string token) {
            // Запись токена пользователя в файл
            try {
                File.WriteAllText("userToken.txt", token);
                Console.WriteLine("Текст успешно записан в файл.");
            }
            catch (IOException ex) {
                Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
            }

        }

        public static string getUserToken() {
            // Получение токена пользователя из файла
            try {
                if (File.Exists("userToken.txt")) {
                    string textFromFile = File.ReadAllText("userToken.txt");
                    return textFromFile;
                }
                else {
                    Console.WriteLine("Файл не существует.");
                }
            }
            catch (IOException ex) {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }

            return "Ошибка";
        }
    }
}
