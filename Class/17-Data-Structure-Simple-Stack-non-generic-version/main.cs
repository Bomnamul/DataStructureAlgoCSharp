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

    int v;
    print(s.Pop(out v) == true);
    print(v == 30);
    print(s.Pop(out v) == true);
    print(v == 20);
    print(s.Pop(out v) == true);
    print(v == 10);
    print(s.Pop(out v) == false);
    print(s.Stringify() == String.Empty);
    print(s.Count == 0);
    // s.Count = 100; // error ! (set이 없어서 읽기전용)
  }
}

public class Stack {
  int[] data;
  int size;
  int top = -1;

   // property: 속성
  public int Count {
    get {
      return top + 1;
    } // get: 읽을 때, set: 쓸 때 { 호출 }
  }

  public Stack(int size) {
    data = new int[size];
    this.size = size;
  }
  public bool Push(int value) {
    if (top == size - 1)
      return false;
    data[++top] = value;
    return true;
  }
  public bool Pop(out int v) {
    if (top == -1) {
      v = -1; // 쓰던말던 쓰레기값을 넣어 리턴해줌 
      return false;
    }
    v = data[top--];
    return true;
  }
  public string Stringify() {
    int[] list = new int[top + 1];
    Array.Copy(data, list, top + 1); // data배열의 값을 list에 top + 1개만큼 복사
    return list.Stringify();
  }
}

public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) { // 지금은 외워쓰자
    return String.Join(" ", list);
  }
}

// non generic: template이 아님 only for int type

/*
숙제1. class 만들기
구현은 안해도되고 함수 정의 (타입도 할 수 있으면 ㄱ)
testcode 에러는 안나게
사진 코스트 
공격 대상 enum?

숙제2. Bubble Sort 구현
*/
