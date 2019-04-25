using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    Stack s = new Stack(3);
    print(s.Stringify() == String.Empty);
    print(s.Count == 0);
    s.Push(10);
    print(s.Count == 1);
    s.Push(20);
    s.Push(30);
    print(s.Count == 3);
    print(s.Stringify() == "10 20 30");
    print(s.Push(40) == false);
    print(s.Stringify() == "10 20 30");
    print(s.Count == 3);

    object v;
    print(s.Pop(out v) == true);
    print((int)v == 30);
    print(s.Pop(out v) == true);
    print((int)v == 20);
    print(s.Pop(out v) == true);
    print((int)v == 10);
    print(s.Pop(out v) == false);
    print(s.Stringify() == String.Empty);
    print(s.Count == 0);
    // s.Count = 100; // error ! (set이 없어서 읽기전용)
  
    Stack s1 = new Stack(5);
    s1.Push("Hi");
    s1.Push("There");
    s1.Push("How");
    s1.Push("About");
    s1.Push(100);
    print(s1.Stringify() == "Hi There How About 100");
    print(s1.Pop(out v) == true);
    print((int)v == 100);
  }
}

public class Stack {
  object[] data;
  int size;
  int top = -1;

   // property: 속성
  public int Count {
    get {
      return top + 1;
    } // get: 읽을 때, set: 쓸 때 { 호출 }
  }

  public Stack(int size) {
    data = new object[size];
    this.size = size;
  }
  public bool Push(object value) {
    if (top == size - 1)
      return false;
    data[++top] = value;
    return true;
  }
  public bool Pop(out object v) {
    if (top == -1) {
      v = null; // 쓰던말던 쓰레기값을 넣어 리턴해줌 
      return false;
    }
    v = data[top--];
    return true;
  }
  public string Stringify() {
    object[] list = new object[top + 1];
    Array.Copy(data, list, top + 1); // data배열의 값을 list에 top + 1개만큼 복사
    return list.Stringify();
  }
}

public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) { // 지금은 외워쓰자
    return String.Join(" ", list);
  }
}
