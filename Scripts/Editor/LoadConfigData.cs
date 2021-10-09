using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;

namespace MyFramework
{
    public class LoadConfigData:Editor
    {
        [MenuItem("MyFramework/CreatDataCode")]
        static void CreatData()
        {
            string[] array=  Resources.Load<TextAsset>("AllConfig").text.Split('\n');
            foreach (var name in array)
            {
                Debug.Log(name);
                CreatByName(name);
                
            }
        }
        static void CreatByName(string name)
        {
            using (FileStream fs = File.Open(Application.dataPath + "/Scripts/Data/"+name.Trim()+".cs", FileMode.OpenOrCreate))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
    {
        public class ");
                sb.Append(name.Trim() + @":Data
{
");

                string[] array = Resources.Load<TextAsset>(name.Trim()).text.Split('\n');
                for (int i = 1; i < array.Length-1; i++)
                {
                    string[] items= array[i].Split(',');
                    string str= items[1].ToString() + " " + items[0].ToString() + "=" + items[2].ToString();
                    sb.Append(str+@";
");
                }
                sb.Append(@"
}
}");


                byte[] bytes = Encoding.UTF8.GetBytes(sb.ToString());
                fs.Write(bytes, 0, bytes.Length);
            }
        }

    }
}
