using System;

namespace ConsoleApplication1
{
    // Создадим несколько делегатов имитирующих 
    // простейшую форму регистрации
    /// <summary>
    /// /asdas
    /// </summary>
    /// <param name="s"></param>/**/
    /// <returns></returns>\\///**/
    delegate int /* int тип возвращаемого значения функции-делегата */ LengthLogin(string s); // определили делегат
    delegate bool BoolComparingPassword(string s1, string s2);

    class Program
    {/*\*/
        private static void SetLogin()
        {
            Console.Write("Введите логин: ");
            string login = Console.ReadLine();

            // Используем лямбда-выражение
            LengthLogin lengthLoginDelegate = (s) => s.Length; // под делегат задали лямда

            int lengthLogin = lengthLoginDelegate(login); //успользуем лябду
            if (lengthLogin > 25)
            {
                Console.WriteLine("Слишком длинное имя\n");

                // Рекурсия на этот же метод, чтобы ввести заново логин
                SetLogin();
            }
        }

        static void Main()
        {
            SetLogin();

            Console.Write("Введите пароль: ");
            string password1 = Console.ReadLine();
            Console.Write("Повторите пароль: ");
            string password2 = Console.ReadLine();

            // Используем лямбда выражение
            BoolComparingPassword bp/*delegat-object*/ = (s1, s2) /* in params to lamba*/=> s1 == s2;/* lamba-function*/

            if (bp(password1, password2))
                Console.WriteLine("Регистрация удалась!");
            else
                Console.WriteLine("Регистрация провалилась. Пароли не совпадают");

            Console.ReadLine();
        }
    }
}