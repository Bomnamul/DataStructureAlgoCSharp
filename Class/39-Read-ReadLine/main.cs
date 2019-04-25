using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    // char c = (char)Console.Read();
    // Console.Write(); 
    string str = Console.ReadLine();
    print(str);

    // 문자열 덧셈 ReadLine() 써서 바꿔보기
  }
}

public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) {
    return String.Join(" ", list);
  }
}
