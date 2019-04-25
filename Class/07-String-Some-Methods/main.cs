using System;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;  // return type : void
    // Func<object> print = Console.WriteLine; // return 결과가 있는 함수를 담을 수 있음

    string s;
    s = "ABC";
    print(s.Length == 3); // s object의 member 함수 Length

    s = "ABCDEF";
    print(s.IndexOf("CDE") == 2);
    print(s.IndexOf("ZZZ") == -1);

    s = "Mr Song";
    print(s.Replace("Mr", "Miss") == "Miss Song");

    int[] arrayA = {1, 3, 5, 7, 9};
    print(String.Join(" ", arrayA) == "1 3 5 7 9"); // String의 static method
    print(Stringify(arrayA) == "1 3 5 7 9");

    s = "1000,2000,3000";
    string[] prices = s.Split(','); // tokenize
    print(String.Join(" ", prices) == "1000 2000 3000");

    s = "1000, 2000, 3000";
    prices = s.Replace(" ", "").Split(',');
    print(String.Join(" ", prices) == "1000 2000 3000");    
    print("" == String.Empty && "" == string.Empty);

    s = "ABCDEF";
    print(s.Substring(1, 3) == "BCD"); // Substring((INT32)startIndex, (INT32)Length) 1주소부터 3개
    // print(s.Substring(7, 3));       // OutOfRangeException!!

  }

  public static string Stringify(int[] list) {
    return String.Join(" ", list);
  }
}
