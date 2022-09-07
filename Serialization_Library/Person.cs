using System;
using System.Collections.Generic;

using System.Runtime.Serialization; // Gerekli namespace eklenir
using System.Runtime.Serialization.Formatters.Binary; // Binary serialization için

namespace Serialization_Library
{
    [Serializable] // Sınıfı serileştirme için uygun hale getirir.
    public class Person : ISerializable
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int ID { get; set; }

        public Person(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context) // Kaydedilecek özellikleri alan metod
        {
            info.AddValue("İsim", Name);
            info.AddValue("Soyisim", LastName);
        }

        public Person(SerializationInfo info, StreamingContext context) 
        // Bir constructor metot yaratılarak kaydedilen değerleri tekrar sınıf içerisine atam
        {
            Name = (string)info.GetValue("Name", typeof(string));
            LastName = (string)info.GetValue("Soyisim", typeof(string));
        }
    }
}
