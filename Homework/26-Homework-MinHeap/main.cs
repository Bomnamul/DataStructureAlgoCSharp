// https://gmlwjd9405.github.io/2018/05/10/data-structure-heap.html

using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    var h = new MinHeap();
    h.Insert(7);
    print(h.Stringify() == "7");
    h.Insert(1);
    print(h.Stringify() == "1 7");
    h.Insert(3);
    h.Insert(2);
    h.Insert(5);
    h.Insert(1);
    h.Insert(8);
    h.Insert(0);
    print(h.Stringify() == "0 1 1 2 5 3 8 7");

    print(h.Find(o => o == 2) == 2); // 있냐 없냐 확인
    
    print(h.RemoveTop() == 0);
    print(h.Stringify() == "1 1 3 2 5 7 8");
    print(h.RemoveTop() == 1);
    print(h.RemoveTop() == 2);
    print(h.Stringify() == "1 3 8 5 7");
    h.Remove(o => o == 3);
    print(h.Stringify() == "1 5 8 7");
    h.Remove(o => o == 5);
    print(h.Stringify() == "1 7 8");
  }
}

public class MinHeap {
  List<int> list;

  public MinHeap() {
    list = new List<int>();
  }

  public void Insert(int v) {
    list.Add(v);
    HeapifyUp(list.Count - 1);
  }

  public void HeapifyUp(int i) {
    if (i < 1)
      return;
    int p = Parent(i);
    if (list[p] > list[i]) {
      list.Swap(p, i);
      HeapifyUp(p);
    }
  }

  public void HeapifyDown(int i) { // 숙제 // 자식의 유무, 2개인지 1개인지
    int lc = LChild(i);
    int rc = RChild(i);
    
    if (rc <= list.Count - 1) {
      if (list[lc] < list[rc]) {
        list.Swap(lc, i);
        HeapifyDown(lc);
      } else {
        list.Swap(rc, i);
        HeapifyDown(rc);
      }
    } else if (lc <= list.Count - 1) {
      list.Swap(lc, i);
      HeapifyDown(lc); // 없어도 상관없음
    } else {
      return;
    }
  }

  public int RemoveTop() { // 숙제
    int top = list[0];
    list.Swap(0, list.Count - 1);
    list.Remove(list[list.Count - 1]);
    HeapifyDown(0);
    return top;
  }

  public void Remove(Predicate<int> v) { // 숙제 (동일한 것 있으면 첫 번째 것 삭제, v param은 value)
    int i = list.FindIndex(v);
    if (i != -1) {
      list.Swap(i, list.Count - 1);
      list.Remove(list[list.Count - 1]);
      HeapifyDown(i);
    }
  }
  
  // print(h.Find(o=>o==2) == 2);
  // Func<int, bool> f == Predicate<T> (return 값이 true,false인 param 1개인 조건문일 때 사용)
  public int Find(Predicate<int> f) {
    int i = list.FindIndex(f);
    if (i != -1)
      return list[i];
    else
      return -1;
  }

  public string Stringify() {
    return list.Stringify();
  }

  int Parent(int i) {return (i - 1) / 2;}
  int LChild(int i) {return 2 * (i + 1) - 1;}
  int RChild(int i) {return LChild(i) + 1;}
}

public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) {
    return String.Join(" ", list);
  }

  public static IList<T> Swap<T>(this IList<T> list, int i, int j) {
    T temp = list[i];
    list[i] = list[j];
    list[j] = temp;
    return list;
  }
}

/*
Zero base
P(i) = (i - 1) / 2
L(i) = 2 * (i + 1) - 1
R(i) = L(i) + 1

insert

Remove (숙제)

HeapifyUp
*/
