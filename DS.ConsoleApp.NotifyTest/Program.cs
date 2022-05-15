using DS.ConsoleApp.NotifyTest;

Account account = new Account(100);
account.Notify += DisplayMessage;       // добавляем обработчик DisplayMessage
account.Notify += DisplayRedMessage;    // добавляем обработчик DisplayMessage
account.Put(20);    // добавляем на счет 20
account.Notify -= DisplayRedMessage;     // удаляем обработчик DisplayRedMessage
account.Put(50);    // добавляем на счет 50

void DisplayMessage(string message) => Console.WriteLine(message);
void DisplayRedMessage(string message)
{
    // Устанавливаем красный цвет символов
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
    // Сбрасываем настройки цвета
    Console.ResetColor();
}
