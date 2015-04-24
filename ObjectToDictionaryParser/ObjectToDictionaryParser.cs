using System.Collections.Generic;
using System.Reflection;

namespace ObjectToDictionaryParser
{
    public static class ObjectToDictionaryParser
    {
        /// <summary>
        /// parsing any object to dictionary ex.
        /// object:
        /// var x = { a="fd",b=5 };
        /// dic:
        /// Key: x.a Val: fd
        /// Key: x.b Val: 5
        /// </summary>
        /// <param name="obj">any object you want to pass</param>
        /// <param name="dic">dictionary object to put all params</param>
        /// <param name="nullVal">show or not null values</param>
        public static void parseObjectToDictionary(object obj, Dictionary<string,string> dic, bool nullVal){
            parseObjectToDictionary(obj, dic, nullVal,"");
        }
        private static void parseObjectToDictionary(object obj, Dictionary<string,string> dic, bool nullVal, string str)
        {
            var props = obj.GetType().GetProperties();
            if (obj.GetType().IsArray)
            {
                object[] array = (object[])obj;
                for (int i = 0; i < array.Length; i++)
                {
                    string s = str + obj.GetType().Name.Remove(obj.GetType().Name.Length - 2, 2) + [ + i + ].;
                    parseObjectToDictionary(array.GetValue(i), dic,nullVal, s);
                }
                return;
            }
            foreach (PropertyInfo p in props)
            {
                if (p.PropertyType.IsArray)
                {
                    object[] arr = (object[])p.GetValue(obj);
                    for (int i = 0; i < arr.Length; i++)
                    {
                        string s = str + p.Name.Remove(p.Name.Length - 2, 2) + [ + i + ].;
                        parseObjectToDictionary(arr.GetValue(i), dic,nullVal, s);
                    }
                    continue;
                }
                if (p.PropertyType.IsNested)
                {
                    string xx = str + p.Name + ".";
                    parseObjectToDictionary(p.GetValue(obj, null), dic,nullVal, xx);
                }
                else
                {
                    try
                    {
                        dic.Add(str + p.Name, p.GetValue(obj, null).ToString());
                    }
                    catch 
                    {
                        if(nullVal){
                            dic.Add(str + p.Name,"null");
                        }
                    }
                }
            }
        }
    }
}
