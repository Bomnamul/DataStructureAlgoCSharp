using System;
using System.Collections.Generic; // IEnumerable를 쓰기위함

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    int[] array = {1, 2, 3};
    print(array.Stringify() == "1 2 3");

    print("abc".Stringify() == "a b c");
    print((new char[] {'a', 'b', 'c'}).Stringify() == "a b c");

    List<int> list2 = new List<int>() {8, 3, 2}; // Collections.List
    print(list2.Stringify() == "8 3 2");

    print((new int[] {1}).Stringify() == "1");
  }
}

public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) {
    return String.Join(" ", list);
  }
  // IEnumerable (열거 가능한 형태(array, list, stack, queue))
  // this 이후의 클래스에 집어넣는다?
  // <T>: Template(무엇인지 모름)

  // public static string Stringify(this string list) {
  //   return String.Join(" ", list);
  // }

  // public static string Stringify(this char[] list) {
  //   return String.Join(" ", list);
  // }

  //숙제3. Sum, Avg, Max ...를 ClassExtension으로 만들기
}