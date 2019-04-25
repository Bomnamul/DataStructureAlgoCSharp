using System;
using System.Collections;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    Stack stack = new Stack();
    stack.Push(100);
    stack.Push(200);
    stack.Push(300);
    stack.Push(400);
    stack.Push(500);
    print(stack.Count == 5);
    print((int)stack.Peek() == 500);
    print(stack.ToArray().Stringify() == "500 400 300 200 100");

    while (stack.Count > 0)
      print(stack.Pop()); // object 타입으로 나오지만 print에 ToString이 있기때문에 int 타입으로 표현해줌
    print(stack.Count == 0);
  }
}

public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) {
    return String.Join(" ", list);
  }
}