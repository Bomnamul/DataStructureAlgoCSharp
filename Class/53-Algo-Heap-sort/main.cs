// https://gmlwjd9405.github.io/2018/05/10/data-structure-heap.html

using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    var h = new MinHeap<int>();
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
    h.Remove(1);
    print(h.Stringify() == "0 2 1 7 5 3 8");
    print(h.Find(o => o == 2) == 2); // 있냐 없냐 확인
    
    h.Insert(1);
    h.Remove(0);
    print(h.RemoveTop() == 1);
    print(h.RemoveTop() == 1);
    print(h.RemoveTop() == 2);
    print(h.Stringify() == "3 5 8 7");
    print(h.RemoveTop() == 3);
    print(h.RemoveTop() == 5);
    print(h.RemoveTop() == 7);
    print(h.RemoveTop() == 8);
    print(h.Stringify() == "");
    try {
      print(h.RemoveTop());
    } catch {}

    var todoList = new MinHeap<Todo>();
    todoList.Insert(new Todo(0, 10, "Game")); // id, 우선순위, 내용
    todoList.Insert(new Todo(1, 1, "H/W"));
    todoList.Insert(new Todo(2, 5, "Drinking"));
    todoList.Insert(new Todo(3, 0, "Walking"));
    todoList.Insert(new Todo(4, 7, "Sleep"));

    todoList.Remove(todoList.Find(o=>o.id==3)); // RemoveTop()
    print(todoList.RemoveTop().ToString() == "1,H/W");
    print(todoList.RemoveTop().ToString() == "5,Drinking");
    print(todoList.RemoveTop().ToString() == "7,Sleep");
    print(todoList.RemoveTop().ToString() == "10,Game");

    // Heap sort
    int[] list = {7, 1, 3, 2, 5, 1, 8, 0};
    HeapSort(list);
    print(list.Stringify() == "0 1 1 2 3 5 7 8");
  }

  public static void HeapSort(int[] list) {
    var h = new MinHeap<int>();

    for (int i=0; i<list.Length; i++) {
      h.Insert(list[i]);
    }
    int j = 0;
    while (h.Count > 0) {
      list[j++] = h.RemoveTop();
    }
  }

  public class Todo : IComparable, IEquatable<Todo> {
    public int id;
    public int priority;
    public string desc;

    public Todo(int id, int priority, string desc) {
      this.id = id;
      this.priority = priority;
      this.desc = desc;
    }
    public int CompareTo(object other) {
      return priority.CompareTo(((Todo)other).priority);
    }

    public bool Equals(Todo t) {
      return id == t.id;
    }

    public override string ToString() {
      return priority.ToString() + "," + desc;
    }
  }
}

public class MinHeap<T> where T: IComparable, IEquatable<T>{
  List<T> list;

  public int Count {
    get {
      return list.Count;
    }
  }

  public MinHeap() {
    list = new List<T>();
  }

  public void Insert(T v) {
    list.Add(v);
    HeapifyUp(list.Count - 1);
  }

  public void HeapifyUp(int i) {
    if (i < 1)
      return;
    int p = Parent(i);
    // if (list[p] > list[i]) { 
    if (list[p].CompareTo(list[i]) > 0) {
      list.Swap(p, i);
      HeapifyUp(p);
    }
  }

  public T RemoveTop() { // 숙제 (극단적일 경우를 생각해야함)
    if (list.Count > 0) {
      T v = list[0];
      list[0] = list[list.Count - 1];
      list.RemoveAt(list.Count - 1);
      HeapifyDown(0);
      return v;
    } else {
      throw new InvalidOperationException("No Data");
    }
  }

  public void Remove(T v) { // 숙제 (동일한 것 있으면 첫 번째 것 삭제, v param은 value)
    if (list.Count > 0) {
      int index = list.FindIndex(o=>o.Equals(v));
      if (index != -1) {
        list[index] = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
        HeapifyDown(index);
      }
    }
  }

  void HeapifyDown(int p) { // 숙제
    if (list.Count <= 1)
      return;
    int l = LChild(p);
    int r = RChild(p);
    if (IsLeaf(p))
      return;
    if (r > list.Count - 1) { // Only l
      // if (list[l] < list[p]) {
      if (list[l].CompareTo(list[p]) < 0) {
        list.Swap(l, p);
        return;
      }
    } else { // l and r exist
      if (list[l].CompareTo(list[r]) <= 0) {
        if (list[l].CompareTo(list[p]) < 0) {
          list.Swap(l, p);
          HeapifyDown(l);
        }
      } else {
        if (list[r].CompareTo(list[p]) < 0) {
          list.Swap(r, p);
          HeapifyDown(r);
        }
      }
    }
  }
  
  // print(h.Find(o=>o==2) == 2);
  // Func<int, bool> f == Predicate<T> (return 값이 true,false인 param 1개인 조건문일 때 사용)
  public T Find(Predicate<T> f) {
    int i = list.FindIndex(f);
    if (i != -1)
      return list[i];
    else
      return default(T);
  }

  public string Stringify() {
    return list.Stringify();
  }

  int Parent(int i) {return (i - 1) / 2;}
  int LChild(int i) {return 2 * (i + 1) - 1;}
  int RChild(int i) {return LChild(i) + 1;}
  bool IsLeaf(int i) {return LChild(i) > list.Count - 1;}
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
