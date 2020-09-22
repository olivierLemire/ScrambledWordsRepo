using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab2
{
    class FileReader
    {
        public string[] Read(String filename)
        {
            var path = filename;
            string[] wordList = File.ReadAllLines(path);
            return wordList;
        }
    }
}
