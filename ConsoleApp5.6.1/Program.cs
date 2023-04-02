namespace ConsoleApp5._6._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var user = CreateUser();
            PrintUser(user);
        }

        static (string Name, string Surname, byte Age, string[] PetNames, string[] Colors) CreateUser()
        {
            (string Name, string Surname, byte Age, string[] PetNames, string[] Colors) user;

            Console.WriteLine("Введите имя");
            user.Name = Console.ReadLine();

            Console.WriteLine("Введите фамилию");
            user.Surname = Console.ReadLine();

            user.Age = GetByte("Введите ваш возраст");

            Console.WriteLine("Есть ли у вас животные?  Только Да или Нет");
            var hasPets = GetBool();
            if(hasPets)
            {
                user.PetNames = GetPetNames();
            }
            else 
            {
                user.PetNames = new string[0];
            }

            user.Colors = GetColors();
            return user;
        }

        // Ввод массива кличек
        static string[] GetPetNames()
        {
            var count = GetByte("Введите количество питомцев");
            var names = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Введите имя {0} питомца", i + 1);
                names[i] = Console.ReadLine();
            }

            return names;
        }

        // Ввод массива цветов
        static string[] GetColors()
        {
            var count = GetByte("Введите количество любимых цветов");
            var names = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Введите {0} цвет", i + 1);
                names[i] = Console.ReadLine();
            }

            return names;
        }


        // Ввод и проверка правильности числа от 1 до 255
        static byte GetByte(string message)
        {
            byte result;
            string val;
            do
            {
                Console.WriteLine(message);
                val = Console.ReadLine();

            } while (! byte.TryParse(val, out result) || result == 0);

            return result;
        }

        // Ввод и проверка логического значения
        static bool GetBool()
        {
            var val = Console.ReadLine();

            if (val == "Да")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void PrintUser((string Name, string Surname, byte Age, string[] PetNames, string[] Colors) user)
        {
            Console.WriteLine("Имя пользователя: {0}", user.Name);
            Console.WriteLine("Фамилия пользователя: {0}", user.Surname);
            Console.WriteLine("Возраст пользователя: {0}", user.Age);

            for (int i = 0; i < user.PetNames.Length; i++)
            {
                Console.WriteLine("Питомец {0}: {1}", i + 1, user.PetNames[i]);
            }

            for (int i = 0; i < user.Colors.Length; i++)
            {
                Console.WriteLine("Любимый цвет {0}: {1}", i + 1, user.Colors[i]);
            }
        }
    }
}