using System;
using System.Collections;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;
  
    DLinkedList<string> dlist = new DLinkedList<string>();
    dlist.AddLast("one");                                          // AddLast
    print(dlist.Stringify() == "one");
    dlist.AddLast("two");
    print(dlist.Stringify() == "onetwo");
    dlist.AddLast("three");
    print(dlist.Stringify() == "onetwothree");
    print(dlist.Count == 3);

    dlist.AddFirst("Fone");                                        // AddFirst
    print(dlist.Stringify() == "Foneonetwothree");
    dlist.AddFirst("Ftwo");
    print(dlist.Stringify() == "FtwoFoneonetwothree");
    dlist.AddFirst("Fthree");
    print(dlist.Stringify() == "FthreeFtwoFoneonetwothree");
    print(dlist.Count == 6);

    // foreach (string d in dlist) {
    //   Console.WriteLine(d);
    // }
    
    string str = "";
    foreach (var n in dlist.EnumNode(dlist.head)) {
      str += n.data + " ";
    }
    print(str == "Fthree Ftwo Fone one two three ");

    // print(dlist.ReverseStringify() == "threetwooneFoneFtwoFthree"); // ReverseStringify
    // print(dlist.Search("one").data == "one");

    // print(dlist.RemoveFirst() == "Fthree");                         // RemoveFirst
    // print(dlist.Stringify() == "FtwoFoneonetwothree");
    // dlist.RemoveFirst();
    // dlist.RemoveFirst();
    // print(dlist.Stringify() == "onetwothree");
    // print(dlist.Count == 3);

    // print(dlist.RemoveLast() == "three");                           // RemoveLast
    // dlist.RemoveLast();
    // dlist.RemoveLast();
    // print(dlist.RemoveLast() == null);
    // print(dlist.Count == 0);

  }
}

public class DLinkedList<T> : IEnumerable { // where T: IEquatable<T>, where는 제약 조건 T는 IE~를 만족해야 한다
  public Node head;
  public Node tail;

  public class Node {
  public T data;
  public Node next;
  public Node prev;
}

  public DLinkedList() {
    head = tail = null;
  }

  public int Count {
    get {
      Node current = head;
      int count = 0;
      while (current != null) {
        current = current.next;
        count++;
      }
    return count;
    }
  }

  public void AddLast(T obj) {
    Node newNode = new Node();
    newNode.prev = null;
    newNode.data = obj;
    newNode.next = null;
    if (head == null) {
      head = tail = newNode;
    } else {
      newNode.prev = tail;
      tail.next = newNode;
      tail = newNode;
    }
  }

  public void AddFirst(T obj) {
    Node newNode = new Node();
    newNode.prev = null;
    newNode.data = obj;
    newNode.next = null;
    if (head == null) {
      head = tail = newNode;
    } else {
      newNode.next = head;
      head.prev = newNode;
      head = newNode;
    }
  }

  public T RemoveFirst() {
    if (head == null) {
      return default(T);
    } else if (head == tail) {
      T v = head.data;
      head = tail = null;
      return v;   
    } else {
      T v = head.data;
      head = head.next;
      head.prev = null;
      return v;
    }
  }

  public T RemoveLast() {
    if (head == null) {
      return default(T);
    } else if (head == tail) {
      T v = tail.data;
      tail = head = null;
      return v;
    } else {
      T v = tail.data;
      tail = tail.prev;
      tail.next = null;
      return v;
    }
  }

  public string Stringify() {
    Node current = head;
    string s = "";
    while (current != null) {
      s += current.data;
      current = current.next;
    }
    return s;
  }

  public string ReverseStringify() {
    Node current = tail;
    string s = "";
    while (current != null) {
      s += current.data;
      current = current.prev;
    }
    return s;
  }

  public Node Search(T obj) {
    Node result = head;
    while (result != null) {
      if (result.data.Equals(obj)) // 다른 타입 쓸 경우 문제 생길 수 있음 (interface 만들어야 함)
        break;
      result = result.next;
    }
    return result;
  }

  public IEnumerable<Node> EnumNode(Node node) { // Yield
    var queue = new Queue<Node>();
    queue.Enqueue(node);
    while (queue.Count > 0) {
      Node n = queue.Dequeue();
      yield return n;
      if (n.next != null) {
        queue.Enqueue(n.next);
      }
    }
  }

  public IEnumerator GetEnumerator() {
    // var list = new List<Node>();
    // 리스트 담기 ....

    // return list.GetEnumerator();

    return new NodeEnumerator(this);
  }

  class NodeEnumerator : IEnumerator {
    DLinkedList<T> d;

    public NodeEnumerator(DLinkedList<T> d) {
      this.d = d;
    }

    public bool MoveNext() {
      if (d.head.next != null) {
        d.head = d.head.next;
        return true;
      } else {
        return false;
      }
    }

    public object Current {
      get {
        return d.head.prev.data;
      }
    }

    public void Reset() {
      d.head = null;
    }
  }
}

// Doubly Linked List로 바꾸기
// AddLast(), AddFirst(), RemoveFirst(), RemoveLast(), ReverseStringify()
// Node Search(str) (Node ref를 return)
