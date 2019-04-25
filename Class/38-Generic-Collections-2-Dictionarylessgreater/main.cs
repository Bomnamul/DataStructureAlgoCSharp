// https://docs.microsoft.com/ko-kr/dotnet/api/system.collections.generic?view=netframework-4.7.2

// non generic to generic stack, queue,hashtable (H/W)
// 

using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    Dictionary<string, string> ht = new Dictionary<string, string>(); // 생성만 다르고 hash랑 똑같음
    ht.Add("txt", "notepad.exe");

  }
}