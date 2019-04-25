// http://theory.stanford.edu/~amitp/GameProgramming/Heuristics.html
// http://theory.stanford.edu/~amitp/GameProgramming/AStarComparison.html

using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    int[] list = {1, 12};
    print(list.Stringify() == " 1 12");

    byte[][] grid = new byte[][] {
      new byte[] {0, 0, 0, 0, 0, 0, 0},
      new byte[] {0, 0, 0, 0, 0, 0, 0},
      new byte[] {0, 0, 0, 0, 0, 0, 0},
      new byte[] {0, 0, 0, 0, 0, 0, 0},
      new byte[] {0, 0, 0, 0, 0, 0, 0},
      new byte[] {0, 0, 0, 0, 0, 0, 0},
      new byte[] {0, 0, 0, 0, 0, 0, 0}
    };
    
    var naive = new NaiveSearch(grid);
    naive.FindPath(new Node(3, 3), new Node(6, 6));
    print(naive.pathGrid[0].Stringify());
    print(naive.pathGrid[1].Stringify());
    print(naive.pathGrid[2].Stringify());
    print(naive.pathGrid[3].Stringify());
    print(naive.pathGrid[4].Stringify());
    print(naive.pathGrid[5].Stringify());
    print(naive.pathGrid[6].Stringify());
    print("");
    print(naive.costGrid[0].Stringify());
    print(naive.costGrid[1].Stringify());
    print(naive.costGrid[2].Stringify());
    print(naive.costGrid[3].Stringify());
    print(naive.costGrid[4].Stringify());
    print(naive.costGrid[5].Stringify());
    print(naive.costGrid[6].Stringify());
    print("");
    print(naive.nodeGrid[0].Stringify());
    print(naive.nodeGrid[1].Stringify());
    print(naive.nodeGrid[2].Stringify());
    print(naive.nodeGrid[3].Stringify());
    print(naive.nodeGrid[4].Stringify());
    print(naive.nodeGrid[5].Stringify());
    print(naive.nodeGrid[6].Stringify());
  }
}

public class NaiveSearch {
  byte[][] grid;
  public byte[][] pathGrid;
  public byte[][] costGrid;
  public byte[][] nodeGrid;

  public NaiveSearch(byte[][] grid) {
    this.grid = grid;
    this.pathGrid = new byte[grid.Length][];
    for (int i = 0; i < grid.Length; i++) {
      this.pathGrid[i] = new byte[grid[0].Length];
    }
    this.costGrid = new byte[grid.Length][];
    for (int i = 0; i < grid.Length; i++) {
      this.costGrid[i] = new byte[grid[0].Length];
    }
    this.nodeGrid = new byte[grid.Length][];
    for (int i = 0; i < grid.Length; i++) {
      this.nodeGrid[i] = new byte[grid[0].Length];
    }
  }

  public bool FindPath(Node start, Node goal) {
    Action<object> print = Console.WriteLine;

    int width = grid[0].Length;
    int height = grid.Length;
    var openList = new MinHeap<Todo>();
    var closedList = new List<Node>();

    openList.Insert(new Todo(D(start, goal), start));
    while (openList.Count > 0) {
      Node current = openList.RemoveTop().node;
      closedList.Add(current);
      nodeGrid[current.X][current.Y]++;

      if (current.Equals(goal)) {
        print("Goal !");
        Node c = current; // 끝에서부터 부모를 향해 linked list로 path 표현
        while (c.parent != null) {
          pathGrid[c.X][c.Y] = 7;
          c = c.parent;
        }
        return true;
      } else {
        foreach(var n in Neighbors(current)) {
          if (n.X < 0 || n.X >= height || n.Y < 0 || n.Y >= width)
            continue;
          if (openList.Find(o => o.node.Equals(n)) != null) {
            if (openList.Find(o => o.node.Equals(n)).node.G <= current.G + 1) {
              continue;
            }
          }
          if (closedList.Contains(n))
            continue;
          if (grid[n.X][n.Y] == 1) // wall
            continue;
          
          n.G = current.G + 1; // cost(c, n) = 1;
          costGrid[n.X][n.Y] = (byte)(costGrid[current.X][current.Y] + 1); // cost(c, n) = 1;
          n.parent = current;
          openList.Insert(new Todo(Heuristic(n, goal) + n.G, n));
        }
      }
    }
    return false;
  }

  public static IEnumerable<Node>  Neighbors(Node c) {
    int x = c.X;
    int y = c.Y;
    yield return new Node(x - 1, y);
    yield return new Node(x, y + 1);
    yield return new Node(x + 1, y);
    yield return new Node(x, y - 1);
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

  public static int Heuristic(Node start, Node goal) {
    int dx = Math.Abs(start.X - goal.X);
    int dy = Math.Abs(start.Y - goal.Y);
    return dx + dy;
  }

  public static int D(Node start, Node goal) {
    int d = Heuristic(start, goal) + start.G;
    return d;
  }
}

public class Todo : IComparable, IEquatable<Todo> {
    public int priority;
    public Node node;

    public Todo(int priority, Node node) {
      this.priority = priority;
      this.node = node;
    }
    public int CompareTo(object other) {
      return priority.CompareTo(((Todo)other).priority);
    }

    public bool Equals(Todo t) {
      return this.node == t.node;
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

  public T RemoveTop() {
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

  void HeapifyDown(int p) {
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

public class Node : IEquatable<Node> {
  public int X {get; set;}
  public int Y {get; set;}
  public int G {get; set;}
  public Node parent;

  public Node(int x, int y) {
    X = x;
    Y = y;
    parent = null;
  }

  public bool Equals(Node other) {
    return X == other.X && Y == other.Y;
  }
}

public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) {
    string s = "";
    foreach(var v in list) {
      s += string.Format("{0, 2}", v) + " "; // v의 2자리까지만
    }
    if (s.Length > 0) {
      s = s.Substring(0, s.Length - 1); // 마지막 공백 제거
    }
    return s;
  }

  public static IList<T> Swap<T>(this IList<T> list, int i, int j) {
    T temp = list[i];
    list[i] = list[j];
    list[j] = temp;
    return list;
  }
}

/*
2019.04.11
1.
A* Algorithm (8방향일 경우도 해볼 것 (wall사이 대각 이동 못하게), Breaking ties)
Heap
closedList or hashmap, hashset
*/