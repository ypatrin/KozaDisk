using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Editor.Class
{
    class Serializer
    {
        //types:
        // N = null
        // s = string
        // i = int
        // d = double
        // a = array (hashtable)

        private readonly NumberFormatInfo _nfi;
        public Encoding StringEncoding = new UTF8Encoding();

        public bool XmlSafe = true;
        //This member tells the serializer wether or not to strip carriage returns from strings when serializing and adding them back in when deserializing

        private int _pos; //for unserialize
        private Dictionary<List<object>, bool> _seenArrayLists; //for serialize (to infinte prevent loops) lol
        private Dictionary<Dictionary<object, object>, bool> _seenHashtables; //for serialize (to infinte prevent loops)

        public Serializer()
        {
            _nfi = new NumberFormatInfo { NumberGroupSeparator = "", NumberDecimalSeparator = "." };
        }

        public object Deserialize(string str)
        {
            _pos = 0;
            return deserialize(str);
        }

        private object deserialize(string str)
        {
            if (str == null || str.Length <= _pos)
                return new Object();

            int start, end, length;
            string stLen;
            switch (str[_pos])
            {
                case 'N':
                    _pos += 2;
                    return null;
                case 'b':
                    char chBool = str[_pos + 2];
                    _pos += 4;
                    return chBool == '1';
                case 'i':
                    start = str.IndexOf(":", _pos) + 1;
                    end = str.IndexOf(";", start);
                    var stInt = str.Substring(start, end - start);
                    _pos += 3 + stInt.Length;
                    return Int32.Parse(stInt, _nfi);
                case 'd':
                    start = str.IndexOf(":", _pos) + 1;
                    end = str.IndexOf(";", start);
                    var stDouble = str.Substring(start, end - start);
                    _pos += 3 + stDouble.Length;
                    return Double.Parse(stDouble, _nfi);
                case 's':
                    start = str.IndexOf(":", _pos) + 1;
                    end = str.IndexOf(":", start);
                    stLen = str.Substring(start, end - start);
                    var bytelen = Int32.Parse(stLen);
                    length = bytelen;
                    if ((end + 2 + length) >= str.Length) length = str.Length - 2 - end;
                    var stRet = str.Substring(end + 2, length);
                    while (StringEncoding.GetByteCount(stRet) > bytelen)
                    {
                        length--;
                        stRet = str.Substring(end + 2, length);
                    }
                    _pos += 6 + stLen.Length + length;
                    if (XmlSafe) stRet = stRet.Replace("n", "rn");
                    return stRet;
                case 'a':
                    start = str.IndexOf(":", _pos) + 1;
                    end = str.IndexOf(":", start);
                    stLen = str.Substring(start, end - start);
                    length = Int32.Parse(stLen);
                    var htRet = new Dictionary<object, object>(length);
                    var alRet = new List<object>(length);
                    _pos += 4 + stLen.Length; //a:Len:{
                    for (int i = 0; i < length; i++)
                    {
                        var key = deserialize(str);
                        var val = deserialize(str);

                        if (alRet != null)
                        {
                            if (key is int && (int)key == alRet.Count)
                                alRet.Add(val);
                            else
                                alRet = null;
                        }
                        htRet[key] = val;
                    }
                    _pos++;
                    if (_pos < str.Length && str[_pos] == ';')
                        _pos++;
                    return alRet != null ? (object)alRet : htRet;
                default:
                    return "";
            }
        }
    }
}
