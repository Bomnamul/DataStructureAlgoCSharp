using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    foreach(int n in OddNumbers())
      print(n);

    print("\n");
    IEnumerator<int> enumerator = OddNumbers().GetEnumerator();
    while(enumerator.MoveNext())
      print(enumerator.Current);
  }

   // 컴파일러가 알아서 판단후 enumerator를 만듦
   // Tree Traversal: serialization 하지 않고 가능
  public static IEnumerable<int> OddNumbers() { // Async Function (동시처리 가능, co-routine)
    yield return 1;
    yield return 3;
    yield return 5;
  }
}