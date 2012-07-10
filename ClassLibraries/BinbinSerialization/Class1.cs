using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BinbinSerialization
{
    public static class SerializerExtension
    {
        public static TType XmlDeserialize<TType>(this TType t, string sXml) where TType : class
        {
            return SerializerHelper.XmlDeserialize<TType>(sXml);
        }
        public static string XmlSerialize<TType>(this TType draftOrderInfo)
        {
            return SerializerHelper.XmlSerialize<TType>(draftOrderInfo);
        }
    }
    public static class SerializerHelper
    {
        public static TType XmlDeserialize<TType>(string sXml) where TType : class
        {
            using (var reader = new StringReader(sXml))
            {
                var serializer = new XmlSerializer(typeof(TType));
                var deserialize = serializer.Deserialize(reader) as TType;
                return deserialize;
            }
        }
        public static string XmlSerialize<TType>(TType draftOrderInfo)
        {
            string xml;
            var serializer = new XmlSerializer(typeof(TType));
            using (var stream = new MemoryStream())
            {
                serializer.Serialize(stream, draftOrderInfo);
                stream.Seek(0, 0);
                var streamReader = new StreamReader(stream);
                xml = streamReader.ReadToEnd();
            }
            return xml;
        }
    }
}
