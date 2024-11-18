using System;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;
using static System.Net.WebRequestMethods;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Текст уведомления:");
        string notificationText = Console.ReadLine();

        Console.WriteLine("Задержка в секундах:");
        if (!int.TryParse(Console.ReadLine(), out int delayInSeconds))
        {
            Console.WriteLine("Некорректное значение задержки.");
            return;
        }

        Console.WriteLine($"Уведомление покажется через {delayInSeconds} секунд(-ы)...");

        await Task.Delay(delayInSeconds * 1000);
        int conversationId = 384928;

        new ToastContentBuilder()
            .AddText(notificationText)
            .AddInputTextBox("tbReply", placeHolderContent: "Ответить")
            .AddButton(new ToastButton()
                .SetContent("Reply")
                .AddArgument("action", "reply")
                .SetBackgroundActivation())
            .AddButton(new ToastButton()
                .SetContent("Like")
                .AddArgument("action", "like")
                .SetBackgroundActivation())
            .AddButton(new ToastButton()
                .SetContent("View"))
            .AddArgument("conversationId", conversationId)
            .Show();

        Console.WriteLine("Уведомление отправлено.");
    }
}