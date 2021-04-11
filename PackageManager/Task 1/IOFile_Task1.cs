//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;

//namespace PackageManager
//{
//    public class IOFile_Task1
//    {
//        public List<string[]> Read()
//        {
//            String line = "";
//            List<string[]> list = new List<string[]>();
//            try
//            {
//                //Pass the file path and file name to the StreamReader constructor
//                StreamReader sr = new StreamReader("C:\\Users\\kojoc\\source\\repos\\PackageManager\\PackageManager\\Task 1\\Data\\deps.in");
//                //read first line
//                line = sr.ReadLine();
//                //Continue to read until you reach end of file
//                while (line != null)
//                {
//                    var listItem = line.Split(' ');
//                    list.Add(listItem);
//                    //Read the next line
//                    line = sr.ReadLine();
//                }
//                //close the file
//                sr.Close();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("Exception: " + e.Message);
//            }

//            return list;
//        }

//        public void Write(List<string> list)
//        {
//            try
//            {
//                //Open the File
//                StreamWriter sw = new StreamWriter("C:\\Users\\kojoc\\source\\repos\\PackageManager\\PackageManager\\Task 1\\Data\\task1.out", true, Encoding.ASCII);

//                //Write out the numbers 1 to 10 on the same line.
//                foreach (var item in list)
//                {
//                    sw.WriteLine(item);
//                }

//                //close the file
//                sw.Close();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("Exception: " + e.Message);
//            }
//        }
//    }
//}
