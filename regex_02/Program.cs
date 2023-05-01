using System.Text.RegularExpressions;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        ConsoleKeyInfo keyInfo;

        string pattern = new string(@"^(?=.*[a-z])(?=.*[0-9])(?=.*[A-Z])(?=.*[*#+@])(?!.*\s).{4,6}$");
        Regex regex = new(pattern);

        do
        {
            Console.Clear();
            Console.Write("оберіть спосіб зчитання даних:\n\n" +
                          "[1] -> з консолі (малі об'єми)\n" +
                          "[2] -> з файлу (великі об'єми)\n\n" +
                          "_");
            keyInfo = Console.ReadKey();
        }
        while (keyInfo.KeyChar != '1' && keyInfo.KeyChar != '2');

        Console.Clear();

        switch (keyInfo.KeyChar)
        {
            case '1':
                break;

            case '2':
                Console.Write("введіть шлях до файлу:\n" +
                              "=> ");
                try
                {
                    using (Stream fileStream = File.OpenRead(new string(Console.ReadLine())))
                    {
                    }
                }
                catch
                {

                }

                break;
        }
    }
}