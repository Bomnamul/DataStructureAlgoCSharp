using System;
using System.Collections;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;
  
    ArrayList list = new ArrayList();
    list.Add(100); // object type이라 Boxing되어 들어감
    print((int)list[0] == 100);
    list.Add(200);
    print(list.Count == 2); // ICollection에 Count{get;} : int property가 들어 있음
    // list.Insert(5, 300); // ArgumentOutOfRangeException ! 차곡차곡 넣을 것
    list.Insert(2, 300);
    print((int)list[2] == 300);
    
    list.Remove(100);
    print(list.Count == 2);
    print((int)list[0] == 200);
    print((int)list[1] == 300);

    foreach(var v in list) // IEnumerable 인터페이스를 만족하기에 가능
      print(v);

    print(list.Contains(200) == true);
    print(list.Contains(700) == false);
  }
}

// https://docs.microsoft.com/ko-kr/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2
// C# Collections Class Hierarchy