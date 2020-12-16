using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace I4GUI2020VintereksamenWpfApp.Data
{
    //class Repository
    //{
    //    internal static void ReadFile(string fileName, out ObservableCollection<Person> persons)
    //    {
    //        // Create an instance of the XmlSerializer class and specify the type of object to deserialize.
    //        XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Person>));
    //        try
    //        {
    //            TextReader reader = new StreamReader(fileName);
    //            persons = (ObservableCollection<Person>)serializer.Deserialize(reader);
    //            reader.Close();
    //        } catch (Exception e)
    //        {
    //            persons = null;
    //        }
    //    }

    //    internal static void SaveFile(string fileName, ObservableCollection<Person> persons)
    //    {
    //        // Create an instance of the XmlSerializer class and specify the type of object to serialize.
    //        XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Person>));
    //        TextWriter writer = new StreamWriter(fileName);
    //        // Serialize all the agents.
    //        serializer.Serialize(writer, persons);
    //        writer.Close();
    //    }
    //}
}