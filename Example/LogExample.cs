#if UNIT_TEST
//开启Log.Info,只有定义了该宏定义Log.info才会输出到Console平台
//可以添加到File -> Build Settings -> Player Setting -> Other Settings -> Scripting Define Symbols中,开启全局Log.Info
//该定义如果放在某个脚本中，只能控制该脚本中的Log.Info的显示和隐藏
#define LOG_INFO

//开启Log.Warning,只有定义了该宏定义Log.Warning才会输出到Console平台
//可以添加到File -> Build Settings -> Player Setting -> Other Settings -> Scripting Define Symbols中,开启全局Log.Warning
//该定义如果放在某个脚本中，只能控制该脚本中的Log.Warning的显示和隐藏
#define LOG_WARNING

//同时也可以使用Log.RemoveFlag(intValue);来过滤标志为 intValue 的 message 
//同时也可以使用Log.AddFlag(intValue);来重新显示标志为 intValue 的 message
//建议在正式环境中使用宏定义来开关

//注：Log.Error和Log.Exception没有提供关闭方法，所以只要在需要抛出Error和Exception的时候再使用Log.Error和Log.Exception
//否则，请使用Log.Info并设置醒目的ColorName来达到醒目的目的

using System;
using System.Collections.Generic;
using ThirdParty.Debug;
using ThirdParty.Util;
using UnityEngine;

public class LogExample : MonoBehaviour
{
    void Awake()
    {
        //Debug.Log("Log.Info");
        Log.Info("Log.Info\nabcdefghijklmn\nopqrstuvw\nxyz", ColorName.Lime);

        //Debug.Log("<color=green>Log.Info with Color</color>")
        Log.Info("Log.Info with Color", ColorName.Green);

        //Default show all msg
        //Debug.Log("<color=green>You can set a flag to determine whether this message is displayed</color>")
        Log.Info("You can set a flag to determine whether this msg is displayed", ColorName.Green, 10);

        //You can remove some msg you do not care about by removing the flag 
        Log.RemoveFlag(10);
        //Will not be printed to the console
        Log.Info("You can remove some msg you do not care about by removing the flag", ColorName.Green, 10);
        
        //You can reprint the filtered msg by adding the flag
        Log.AddFlag(10);
        //Debug.Log("<color=green>You can reprint the filtered msg by adding the flag</color>")
        Log.Info("You can reprint the filtered msg by adding the flag", ColorName.Green, 10);

        //Debug.LogWarning("Log.Warning")
        Log.Warning("Log.Warning");

        //Debug.LogWarning("Log.Warning", gameObject)
        Log.Warning("Log.Warning", gameObject);

        //Debug.LogError("Log.Error")
        Log.Error("Log.Error");

        //Debug.LogError("Log.Error", gameObject)
        Log.Error("Log.Error", gameObject);

        //Debug.LogErrorFormat("Log.Error{0},{1},{2}", 1, 2, 3);
        Log.ErrorFormat("Log.Error{0},{1},{2}", 1, 2, 3);

        //Debug.LogErrorFormat(gameObject, "Log.Error{0},{1},{2}", 1, 2, 3);
        Log.ErrorFormat(gameObject, "Log.Error{0},{1},{2}", 1, 2, 3);

        //Debug.LogException(new Exception("Log.Exception"));
        Log.Exception(new Exception("Log.Exception"));

        int[] iArray = new[] {1, 2, 3, 4, 5};
        
        //StringBuilder stringBuilder = new StringBuilder();
        //stringBuilder.Append("iArray").Append("\n");
        //stringBuilder.Append("[<").Append(0).Append(", ").Append(iArray[0]).Append(">");
        //for (int index = 1; index < iArray.Length; ++index)
        //    stringBuilder.Append(", <").Append(index).Append(", ").Append(iArray[index]).Append(">");
        //stringBuilder.Append("]");
        //Debug.Log(stringBuilder.ToString());
        Log.Info("iArray\ntest kkk", iArray);
        

        //Debug.Log($"<color=green>{stringBuilder.ToString()}</color>");
        Log.Info("iArray\ntest kkk", iArray, ColorName.Green);

        List<string> sList = new List<string>() {"a", "b", "c", "d", "e"};
        
        //StringBuilder stringBuilder = new StringBuilder();
        //stringBuilder.Append("sList").Append("\n");
        //stringBuilder.Append("[<").Append(0).Append(", ").Append(sList[0]).Append(">");
        //for (int index = 1; index < sList.Count; ++index)
        //    stringBuilder.Append(", <").Append(index).Append(", ").Append(sList[index]).Append(">");
        //stringBuilder.Append("]");
        //Debug.Log(stringBuilder.ToString());
        Log.Info("sList\ntest kkk", sList);

        //Debug.Log($"<color=green>{stringBuilder.ToString()}</color>");
        Log.Info("sList\ntest kkk", sList, ColorName.Green);

        Queue<float> fQueue = new Queue<float>();
        fQueue.Enqueue(0.1f);
        fQueue.Enqueue(1.2f);
        fQueue.Enqueue(2.3f);
        fQueue.Enqueue(3.4f);
        fQueue.Enqueue(4.5f);

        //StringBuilder stringBuilder = new StringBuilder();
        //stringBuilder.Append("fQueue").Append("\n");
        //using (IEnumerator<float> enumerator = fQueue.GetEnumerator())
        //{
        //    enumerator.MoveNext();
        //    stringBuilder.Append("{<").Append(enumerator.Current).Append(">");
        //    while (enumerator.MoveNext())
        //        stringBuilder.Append(", <").Append(enumerator.Current).Append(">");
        //}
        //stringBuilder.Append("}");
        //Debug.Log(stringBuilder.ToString());
        Log.Info("fQueue\ntest kkk", fQueue);
        
        //Debug.Log($"<color=green>{stringBuilder.ToString()}</color>");
        Log.Info("fQueue\ntest kkk", fQueue, ColorName.Green);

        Dictionary<int, string> dictionary = new Dictionary<int, string>()
            {{0, "a"}, {1, "b"}, {2, "c"}, {3, "d"}, {4, "e"}, {5, "f"}};
        
        //StringBuilder stringBuilder = new StringBuilder();
        //stringBuilder.Append("dictionary").Append("\n");
        //using (IEnumerator<KeyValuePair<int, string>> enumerator = dictionary.GetEnumerator())
        //{
        //    enumerator.MoveNext();
        //    KeyValuePair<int, string> current = enumerator.Current;
        //    stringBuilder.Append("{<").Append(current.Key).Append(", ").Append(current.Value).Append(">");
        //    while (enumerator.MoveNext())
        //    {
        //        current = enumerator.Current;
        //        stringBuilder.Append(", <").Append(current.Key).Append(", ").Append(current.Value).Append(">");
        //    }
        //}
        //stringBuilder.Append("}");
        //Debug.Log(stringBuilder.ToString());
        Log.Info("Dictionary\ntest kkk", dictionary);
        
        //Debug.Log($"<color=green>{stringBuilder.ToString()}</color>");
        Log.Info("Dictionary\ntest kkk", dictionary, ColorName.Green);
    }
}
#endif