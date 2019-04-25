using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    string s = "HelloWorld";                              // 1. StringLength
    print(StringLength(s) == 10);

    int[] scores = {3, 7, 9, 5, 1};                       // 2. MaxValue
    print(MaxValue(scores) == 9);

    int[] scores2 = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};      // 3. ClassExtension
    print(scores2.Sum() == 55);
    print(scores2.Avg() == 5.5);
    print(scores2.Max() == 10);
    print(scores2.Min() == 1);

    Stack stack = new Stack(new int[5]);                  // 4. Stack
    print(Stringify(Push(stack, 3)) == "3 0 0 0 0");
    print(Stringify(Push(stack, 9)) == "9 3 0 0 0");
    print(Stringify(Push(stack, 7)) == "7 9 3 0 0");
    print(Stringify(Push(stack, 5)) == "5 7 9 3 0");
    print(Stringify(Push(stack, 4)) == "4 5 7 9 3");
    print(Stringify(Push(stack, 2))); // error
    print(Pop(stack) == 4);
    print(Pop(stack) == 5);
    print(Pop(stack) == 7);
    print(Pop(stack) == 9);
    print(Pop(stack) == 3);
    print(Pop(stack)); // error
  }

  public static int StringLength(string list) {           // 1. StringLength
    if (list.Substring(1) == "") // .Substring 없이도 할 수 있음
      return 1;
    return StringLength(list.Substring(1)) + 1;
  }

  public static int MaxValue(int[] list) {                // 2. MaxValue
    int[] array = new int[list.Length - 1];
    for (int i = 0; i < list.Length - 1; i++) {
      array[i] = list[i + 1];
    }
    if (array.Length < 2) {
      if (list[0] > array[0])
        return list[0];
      return array[0];
      }
    if (list[0] > MaxValue(array))
      return list[0];
    return MaxValue(array);
  } // Array.Copy, Math.Max 사용 가능

  public class Stack {
    public int[] Array;
    public int Count = 0;
    public Stack(int[] _Array) {
      Array = _Array;
    }
  }

  public static int[] Push(Stack a, int n) {              // 4. Stack
    if (a.Count == a.Array.Length) {
      Console.WriteLine("Stack Overflow !");
      return a.Array;
    }
    for (int i = a.Array.Length - 1; i > 0; i--) {
      a.Array[i] = a.Array[i - 1];
    }
    a.Array[0] = n;
    a.Count++;
    return a.Array;
  } // 숫자 0번지에 밀어넣고 한 자리씩 뒤로 밈, Count 상승

  public static int Pop(Stack a) {
    if (a.Count == 0 ) {
      Console.WriteLine("Stack Underflow !");
      return 0;
    }
    int pop = a.Array[0];
    for (int i = 1; i < a.Array.Length; i++) {
      a.Array[i - 1] = a.Array[i];
    }
    a.Count--;
    return pop;
  } // 0번지에서 빼오고 한 자리씩 앞으로 당김, Count 감소

  public static string Stringify(int[] list) {
    return String.Join(" ", list);
  }
}

public static class ClassExtension {                      // 3. ClassExtension
  public static int Sum(this int[] list) {
    int s = 0;
    foreach(int n in list)
      s += n;
    return s;
  }

  public static double Avg(this int[] list) {
    return Sum(list) / (double)list.Length;
  }

  public static int Max(this int[] list) {
    int max = 0;
    for (int i = 0; i < list.Length; i++) {
      if (list[i] > max)
        max = list[i];
    }
    return max;
  }

  public static int Min(this int[] list) {
    int min = Max(list);
    for (int i = 0; i < list.Length; i++){
      if (list[i] < min)
        min = list[i];
    }
    return min;
  }
}

/*
숙제1. recursion 이용 문자열 길이 구하기 (하나하나 읽으면서(substring) count)
숙제2.           최대값 구하기 (ex. int[]의 최대값)
숙제3. Sum, Avg, Max ...를 ClassExtension으로 만들기
숙제4. stack 자료구조 구현?
      int type array로 구현
      push, pop 동작 확인
      testcase 알아서 하셈
*/
