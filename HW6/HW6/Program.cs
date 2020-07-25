using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>(9);
            dictionary.Add("Yurii", "+380500110641");
            dictionary.Add("Mama", "80500110642");
            dictionary.Add("Tato", "80500110643");
            dictionary.Add("Arsen", "+380500110644");
            dictionary.Add("Sasha", "+380500110645");
            dictionary.Add("Masha", "+380500110646");
            dictionary.Add("Nina", "80500110647");
            dictionary.Add("Dima", "+380500110648");
            dictionary.Add("Katya", "+380500110649");

            try
            {
                PhoneBook book = new PhoneBook();
                book.WriteDataToFile(dictionary);
                book.ReadFile();
                book.WritePhoneToNewFile();

                Console.WriteLine("Please enter name: ");
                string name = Console.ReadLine();

                Console.WriteLine(book.FindName(name));
                book.ChangePhoneNumberWriteToNewFile();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
