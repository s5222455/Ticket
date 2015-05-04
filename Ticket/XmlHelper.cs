using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

public class XmlHelper
{
    #region xml对象序列化
    /// <summary>
    /// 将对象序列化为文件
    /// </summary>
    /// <param name="obj">操作的对象</param>
    /// <param name="path">保存路径</param>
    public static void SerilizeAnObject(object obj, string path)
    {
        System.IO.FileStream stream = new FileStream(path, FileMode.Create);
        try
        {
            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(obj.GetType());
            serializer.Serialize(stream, obj);
        }
        catch (Exception ex)
        {
            Console.WriteLine("SerilizeAnObject Exception: {0}", ex.Message);
        }
        finally
        {
            stream.Close();
            stream.Dispose();
        }
    }

    /// <summary>
    /// 序列化XML文件
    /// </summary>
    /// <param name="type">序列化类型</param>
    /// <param name="path">文件路径</param>
    /// <returns>序列化后的类型</returns>
    public static object DeserilizeAnObject(Type type, string path)
    {
        object obj = null;
        System.IO.FileStream stream = null;
        try
        {
            stream = new FileStream(path, FileMode.Open);
            System.Xml.XmlReader reader = new XmlTextReader(stream);
            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(type);
            obj = serializer.Deserialize(reader);
        }
        catch (Exception ex)
        {
            //Console.WriteLine("DeserilizeAnObject Exception: {0}", ex.Message);
        }
        finally
        {
            if (stream != null)
            {
                stream.Close();
                stream.Dispose();
            }
        }

        return obj;
    }

    public static string GetXmlData(string path)
    {
        string xmlData = string.Empty;
        XmlDocument doc = new XmlDocument();

        try
        {
            doc.Load(path);
            xmlData = doc.OuterXml;
        }
        catch
        {

        }

        return xmlData;
    }

    public static object Deserilize(Type t, string xmlData)
    {
        object obj = null;
        System.IO.FileStream stream = null;
        try
        {
            StringReader rdr = new StringReader(xmlData);
            System.Xml.XmlReader reader = new XmlTextReader(rdr);
            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(t);
            obj = serializer.Deserialize(reader);
        }
        catch (Exception ex)
        {
            Console.WriteLine("DeserilizeAnObject Exception: {0}", ex.Message);
        }
        finally
        {
            if (stream != null)
            {
                stream.Close();
                stream.Dispose();
            }
        }

        return obj;
    }
    #endregion
}

