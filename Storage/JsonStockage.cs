using Logic;
using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Storage
{
    public class JsonStockage : IStockage
    {

        public Notebook Create()
        {
            Notebook res;
            try
            {
            FileStream fichier = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\notebook.json", FileMode.OpenOrCreate);
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Notebook));

            res = serializer.ReadObject(fichier) as Notebook;
            }
            catch
            {
                res = new Notebook();

            }
            return res;
        }

        public Notebook Load()
        {
            return Create();
        }

        public void Update(Notebook n)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Notebook));
            FileStream fichier = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\notebook.json", FileMode.Create);

            serializer.WriteObject(fichier, n);
            fichier.Close();
        }
    }
}
