using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.ComponentModel;

public class EnumHelper
{
    /// <summary>
    /// 获得枚举值的Description特性的值，一般是消息的搜索码
    /// </summary>
    /// <param name="value">要查找特性的枚举值</param>
    /// <returns>返回查找到的Description特性的值，如果没有，就返回.ToString()</returns>
    public static string GetEnumDescription(Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());
        DescriptionAttribute[] attributes =
          (DescriptionAttribute[])fi.GetCustomAttributes(
          typeof(DescriptionAttribute), false);
        return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
    }

    /*如何使用:
     * 
     * GetEnumDescription(typeof(TravelType), "Wholesalers")
     * 
     */

    /// <summary>
    /// 根据特定的枚举值名称获得枚举值的Description特性的值
    /// </summary>
    /// <param name="value">枚举类型</param>
    /// <param name="name">枚举值的名称</param>
    /// <returns>返回查找到的Description特性的值，如果没有，就返回.ToString()</returns>
    public static string GetEnumDescription(System.Type value, string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            FieldInfo fi = value.GetField(name);
            DescriptionAttribute[] attributes =
              (DescriptionAttribute[])fi.GetCustomAttributes(
              typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : name;
        }
        return "";
    }

    /*
        如何使用:
        rblGender.DataSource = EnumUtility.ConvertEnumToListItems(typeof(TravelType));
        rblGender.DataTextField = "Text";
        rblGender.DataValueField = "Value";
        rblGender.DataBind();
        rblGender.SelectedIndex = 0;
     */
    /// <summary>
    /// 将指定枚举类型转换成List，用来绑定ListControl
    /// </summary>
    /// <param name="enumType">枚举类型</param>
    /// <returns></returns>
    public static List<ListItem> ConvertEnumToListItems(Type enumType)
    {
        if (enumType.IsEnum == false) { return null; }
        List<ListItem> list = new List<ListItem>();
        Type typeDescription = typeof(DescriptionAttribute);
        System.Reflection.FieldInfo[] fields = enumType.GetFields();
        string strText = string.Empty;
        int strValue;
        foreach (FieldInfo field in fields)
        {
            if (field.IsSpecialName) continue;
            strValue = (int)field.GetRawConstantValue();
            object[] arr = field.GetCustomAttributes(typeDescription, true);
            if (arr.Length > 0)
            {
                strText = (arr[0] as DescriptionAttribute).Description;
            }
            else
            {
                strText = field.Name;
            }

            list.Add(new ListItem(strText, strValue));
        }
        return list;
    }

    public static string EnumToHtmlElement(Type enumType)
    {
        var items = ConvertEnumToListItems(enumType);
        if (items == null || items.Count <= 0)
            return string.Empty;

        StringBuilder sb = new StringBuilder();
        sb.Append(string.Format("<select id='{0}'>", enumType.Name));

        foreach (var item in items)
        {
            sb.Append(string.Format("<option value='{0}'>{1}</option>", item.Value, item.Text));
        }

        sb.Append("</select>");

        return sb.ToString();
    }
}

public class ListItem
{
    public ListItem(string text, int value)
    {
        Text = text;
        Value = value;
    }

    public string Text { get; set; }

    public int Value { get; set; }
}
