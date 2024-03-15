using BL.exceptions;
using BL.interfaces;
using BL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.managers
{
    public class AdresManager
    {
        private IFileProcessor fileProsessor;

        public AdresManager(IFileProcessor fileProsessor)
        {
            this.fileProsessor = fileProsessor;
        }

        public List<Adres> MakeAdresses(List<string> adresses)
        {
            List<Adres> adresList = new();
            foreach (string adress in adresses)
            {
                try
                {
                    string[] adresArray = adress.Split(',');
                    
                    adresList.Add(new Adres(adresArray[0], adresArray[1], adresArray[2]));
                } catch (Exception ex) { throw new DomeinException("AdresManager : MakeAdress", ex); }
            }
            return adresList;
        }
    }
}
