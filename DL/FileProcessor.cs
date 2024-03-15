using BL.exceptions;
using BL.interfaces;
using System;

namespace DL
{
    public class FileProcessor : IFileProcessor
    {
        public List<string> ReadAdresses(string filename)
        {
            try
            {
                List<string> adresses = new List<string>();
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        adresses.Add(line.Trim());
                    }
                    return adresses;
                }
            } catch (Exception ex) { throw new DomeinException("FileProsessor : ReadAdresses", ex); }
        }
    }
}
