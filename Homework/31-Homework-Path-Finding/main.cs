using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    int[] list = {1, 12};
    print(list.Stringify() == " 1 12");

    byte[][] grid = new byte[][] {
      new byte[] {0, 0, 0, 1, 0, 0, 0},
      new byte[] {0, 0, 0, 1, 0, 1, 0},
      new byte[] {0, 0, 0, 0, 0, 1, 0},
      new byte[] {0, 0, 0, 0, 1, 1, 0},
      new byte[] {0, 0, 1, 1, 0, 0, 0},
      new byte[] {0, 0, 0, 0, 0, 1, 1},
      new byte[] {0, 0, 0, 0, 0, 0, 0}
    };
    
    var naive = new NaiveSearch(grid);
    naive.FindPath(new Node(0, 0), new Node(6, 6));
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
    var openList = new Queue<Node>();
    var closedList = new List<Node>();

    openList.Enqueue(start); // openList 검사?

    int count = 0;
    while (openList.Count > 0) {
      count++;
      Node current = openList.Dequeue();
      nodeGrid[current.X][current.Y]++;
      closedList.Add(current);

      if (current.Equals(goal)) {
        print("Goal !");
        Node c = current; // 끝에서부터 부모를 향해 linked list로 path 표현
        while (c.parent != null) {
          pathGrid[c.X][c.Y] = 7;
          c = c.parent;
        }
        Console.WriteLine(count);
        return true;
      } else {
        foreach(var n in Neighbors(current)) { // foreach 검사?
          if (n.X < 0 || n.X >= height || n.Y < 0 || n.Y >= width)
            continue;
          if (closedList.Contains(n))
            continue;
          if (openList.Contains(n))
            continue;
          if (grid[n.X][n.Y] == 1) // wall
            continue;
          
          // n.G = current.G + 1; // cost(c, n) = 1;
          costGrid[n.X][n.Y] = (byte)(costGrid[current.X][current.Y] + 1); // cost(c, n) = 1;
          n.parent = current;
          openList.Enqueue(n);
        }
      }
    }
    return false;
  }

  public static IEnumerable<Node>  Neighbors(Node c) {
    int x = c.X;
    int y = c.Y;
    yield return new Node(x - 1, y); // 생성자를 안쓰게 만드는게 좋다 (노드 안에 visited, cost를 넣는 방식으로 수정)
    yield return new Node(x, y + 1); // 이웃 중복 생성이 엄청나게 발생
    yield return new Node(x + 1, y); // openList 드간 node도 판별?
    yield return new Node(x, y - 1);
  }
}

public class Node : IEquatable<Node> {
  public int X {get; set;}
  public int Y {get; set;}
  // public int Cost {get; set;}
  // public int Visited {get; set;}
  // public int G {get; set;}
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
}
