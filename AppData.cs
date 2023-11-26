using System;
using System.Collections.Generic;
using System.Drawing;
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

        public static Color fontColor = HexToColor("#ffffff");
        public static Color backColor1 = HexToColor("#505e82");
        public static Color backColor2 = HexToColor("#303f56");

        public static string selectedTheme = "dark";
       
        public static void changeTheme()
        {
            if (selectedTheme == "dark") 
            {
                selectedTheme = "light";
                fontColor = HexToColor("#000");
                backColor1 = HexToColor("#ffffff");
                backColor2 = HexToColor("#eeeff2");

                return;
            }
            selectedTheme = "dark";
            fontColor = HexToColor("#ffffff");
            backColor1 = HexToColor("#505e82");
            backColor2 = HexToColor("#303f56");
        }
        static Color HexToColor(string hex)
        {
            hex = hex.TrimStart('#'); // Удаление символа # (если он есть)

            int rgb = Convert.ToInt32(hex, 16); // Преобразование HEX в число
            Color color = Color.FromArgb((rgb >> 16) & 0xFF, (rgb >> 8) & 0xFF, rgb & 0xFF); // Разбор числа на компоненты R, G, B

            return color;
        }
        // Токен пользователя - это ключ к аккаунту
        // Если имеется ключ (токен), то мы можем впустить пользователя без ввода логина и пароля

        public static void setUserToken(string token) {
            // Запись токена пользователя в файл
            return; 

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
