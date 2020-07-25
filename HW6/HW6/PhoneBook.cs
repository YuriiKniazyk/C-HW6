using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HW6
{
    public class PhoneBook
    {
        private string readWriteWritePath = @"D:\Web\Training\SoftServe\HomeWork\HW6\HW6\phones.txt";
        private string _newWritePath = @"D:\Web\Training\SoftServe\HomeWork\HW6\Phones.txt";
        private string _newWritePathLastFile = @"D:\Web\Training\SoftServe\HomeWork\HW6\New.txt";

        private readonly List<string> _phoneNumberFromFile = new List<string>();

        public void WriteDataToFile(Dictionary<string, string> data)
        {
            using (StreamWriter sw = new StreamWriter(readWriteWritePath, false, System.Text.Encoding.Default))
            {
                foreach (var item in data)
                {
                    sw.WriteLine($"{item.Key}-{item.Value}");
                }
            }
        }

        public void ReadFile()
        {
            using (StreamReader sr = new StreamReader(readWriteWritePath, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var s = line.Split('-')[1];
                    _phoneNumberFromFile.Add(s);
                }
            }
        }

        public void WritePhoneToNewFile()
        {
            using (StreamWriter sw = new StreamWriter(_newWritePath, false, System.Text.Encoding.Default))
            {
                foreach (var item in _phoneNumberFromFile)
                {
                    sw.WriteLine(item);
                }
            }
        }

        public string FindName(string name)
        {
            string answer = "";

            using (StreamReader sr = new StreamReader(readWriteWritePath, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var s = line.Split('-')[0];
                    if (s == name)
                    {
                        return answer = $"{line}";
                    }
                    else
                    {
                        return answer = $"Data not found!!";
                    }
                }
            }

            return answer;
        }

        public void ChangePhoneNumberWriteToNewFile()
        {
            using (StreamWriter sw = new StreamWriter(_newWritePathLastFile, false, System.Text.Encoding.Default))
            {
                foreach (var item in _phoneNumberFromFile)
                {
                    if (item[0] != '+')
                    {
                        var s = item;
                        s = "+3" + item;
                        sw.WriteLine(s);
                    }
                    else
                    {
                        sw.WriteLine(item);
                    }
                }
            }
        }
    }
}