// https://docs.microsoft.com/ko-kr/dotnet/api/system.collections.ienumerable?view=netframework-4.7.2
// https://docs.microsoft.com/ko-kr/dotnet/api/system.collections.ienumerator?view=netframework-4.7.2

using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    var names = new List<string>() {"John", "Tom", "Peter"}; // 이런 경우 var사용 권장, 타입이 모호하면 x

    string s = "";
    foreach(var name in names) {
      s += name + " ";
    }
    Console.WriteLine(s == "John Tom Peter ");

    s = "";
    var enumerator = names.GetEnumerator(); // List<string>.Enumerator
    while (enumerator.MoveNext()) { // MoveNext 다음 것이 있으면 넘겨주고 없으면 false
      s += enumerator.Current + " ";
    }
    Console.WriteLine(s == "John Tom Peter ");

    string nick = "Game Academy"; // or string nick = new string(new char[] {'G', 'a' ... 'm', 'y'});
    s = "";
    var stringEnumerator = nick.GetEnumerator(); // CharEnumerator
    while (stringEnumerator.MoveNext()) {
    s += stringEnumerator.Current;
    }
    Console.WriteLine(s == "Game Academy");
  }
}
