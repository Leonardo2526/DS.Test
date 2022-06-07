using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.ConsoleApp.NotifyTest
{
    internal class AccountOutput
    {
        public static void CallAccountAddRemove()
        {
            Account account = new Account(100);
            account.Notify += DisplayMessage;       // добавляем обработчик DisplayMessage
            account.Notify += DisplayRedMessage;    // добавляем обработчик DisplayMessage
            account.Put(20);    // добавляем на счет 20
            account.Notify -= DisplayRedMessage;     // удаляем обработчик DisplayRedMessage
            account.Put(50);    // добавляем на счет 50
        }

        public static void CallAccountAdd()
        {
            Account account = new Account(100);
            account.Notify += DisplayMessage;   // Добавляем обработчик для события Notify
            account.Put(20);    // добавляем на счет 20
            Console.WriteLine($"Сумма на счете: {account.Sum}");
            account.Take(70);   // пытаемся снять со счета 70
            Console.WriteLine($"Сумма на счете: {account.Sum}");
            account.Take(180);  // пытаемся снять со счета 180
            Console.WriteLine($"Сумма на счете: {account.Sum}");
        }

        public static void CallEventArg()
        {
            AccountWithEventArg acc = new AccountWithEventArg(100);
            acc.Notify += DisplayArgMessage;
            acc.Put(20);
            acc.Take(70);
            acc.Take(150);
        }

        static void DisplayMessage(string message) => Console.WriteLine(message);
        static void DisplayRedMessage(string message)
        {
            // Устанавливаем красный цвет символов
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            // Сбрасываем настройки цвета
            Console.ResetColor();
        }

        static void DisplayArgMessage(AccountWithEventArg sender, AccountEventArgs e)
        {
            Console.WriteLine($"Сумма транзакции: {e.Sum}");
            Console.WriteLine(e.Message);
            Console.WriteLine($"Текущая сумма на счете: {sender.Sum}");
        }
    }
}
