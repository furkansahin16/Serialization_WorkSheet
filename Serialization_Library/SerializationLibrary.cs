using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Serialization_Library
{
    public class SerializationLibrary
    {
        public SerializationLibrary()
        {
            #region BinarySerialization
            
            Person newPerson = new Person("Furkan", "Şahin");

            Stream stream = File.Open("PersonData.dat", FileMode.OpenOrCreate);
            // Stream türünde bir kayıt dosyası tanımlarız. Kayıt dosyası mevcut değilse oluştururuz

            BinaryFormatter bf = new BinaryFormatter();

            stream.Close();

            bf.Serialize(stream, newPerson);

            stream = File.Open("PersonData.dat", FileMode.Open);

            newPerson = (Person)bf.Deserialize(stream);

            stream.Close();

            #endregion

            #region XML Serialization
            
            XmlSerializer xs = new XmlSerializer(typeof(Person));

            using (TextWriter tw = new StreamWriter(@"C:\Kullanıcılar\Furkan\Masaüstü"))
            {
                xs.Serialize(tw, newPerson);
            }

            XmlSerializer deserializer = new XmlSerializer(typeof(Person));

            TextReader tr = new StreamReader(@"C:\Kullanıcılar\Furkan\Masaüstü");

            object obj = deserializer.Deserialize(tr);

            newPerson = (Person)obj;

            tr.Close();

            #endregion


        }
    }
}
