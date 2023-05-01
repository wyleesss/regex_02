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
                          "[1] -> з консолі |введеня паролів через кому в один рядок| (малі об'єми)\n" +
                          "[2] -> з файлу |кожний пароль повинен бути з нового рядка| (великі об'єми)\n\n" +
                          "_");
            keyInfo = Console.ReadKey();
        }
        while (keyInfo.KeyChar != '1' && keyInfo.KeyChar != '2');

        Console.Clear();

        switch (keyInfo.KeyChar)
        {
            case '1':

                Console.Write("введіть паролі через кому (пробіли між комами вважаються за частину пароля):\n" +
                              "=> ");

                string input = new string(Console.ReadLine());
                string[] passwords = input.Split(',');

                Console.Clear();
                Console.WriteLine("допустимі паролі:\n");

                foreach (string password in passwords)
                {
                    if (regex.IsMatch(password))
                        Console.WriteLine(password);
                }

                break;

            case '2':
                Console.Write("введіть шлях до файлу:\n" +
                              "=> ");
                try
                {
                    using (StreamReader fileStream = new(new string(Console.ReadLine())))
                    {
                        Console.Clear();
                        Console.WriteLine("допустимі паролі:\n");

                        string? read;

                        while ((read = fileStream.ReadLine()) != null) 
                        {
                            if (regex.IsMatch(read))
                                Console.WriteLine(read);
                        }

                        fileStream.Close();
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                break;
        }
    }
}
