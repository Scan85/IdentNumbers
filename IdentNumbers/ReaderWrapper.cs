using IdentNumbers.Contracts;
using System;
using System.Collections.Generic;
using System.IO;

namespace IdentNumbers
{
    public class ReaderWrapper : IReaderWrapper
    {
        public List<string> ReadFile(string path)
        {
            try
            {
                string line;
                var stringList = new List<string>();

                StreamReader file = new StreamReader(path);

                while ((line = file.ReadLine()) != null)
                {
                    stringList.Add(line);
                }
                file.Close();
                return stringList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}