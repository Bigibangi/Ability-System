using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class XMLOperation {

    public void Serealize(object item, string path) {
        var serializer = new XmlSerializer(item.GetType());
        var writer = new StreamWriter(path);
        serializer.Serialize(writer.BaseStream, item);
        writer.Close();
    }

    public static T Deserialize<T>(string path)
        where T : ScriptableObject {
        var serializer = new XmlSerializer(typeof(T));
        var reader = new StreamReader(path);
        T deserialized = (T)serializer.Deserialize(reader.BaseStream);
        reader.Close();
        return deserialized;
    }
}