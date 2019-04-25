using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;
    
    int[][] image = new int[][] { // 코스트 계산
      new int[] {0, 0, 0, 0, 0},
      new int[] {0, 0, 0, 0, 0},
      new int[] {0, 0, 0, 0, 0},
      new int[] {0, 0, 0, 0, 0},
      new int[] {0, 0, 0, 0, 0},
    };
    print(FindWay(image, 0, 0, 4, 4) == 8);
    print(FindWay(image, 0, 0, 2, 2) == 4);
    print(FindWay(image, 0, 0, 3, 0) == 3);
    print(FindWay(image, 0, 0, 1, 4) == 5);

    int[][] image2 = new int[][] {
      new int[] {0, 0, 0, 0, 0},
      new int[] {1, 1, 1, 1, 0},
      new int[] {0, 0, 0, 0, 0},
      new int[] {0, 1, 1, 1, 1},
      new int[] {0, 0, 0, 0, 0},
    };
    print(FindWay(image2, 0, 0, 4, 4) == 16);

    int[][] image3 = new int[][] {
      new int[] {0, 0, 0, 0, 0},
      new int[] {1, 0, 1, 1, 0},
      new int[] {0, 0, 0, 0, 0},
      new int[] {0, 1, 1, 1, 1},
      new int[] {0, 0, 0, 0, 0},
    };
    print(FindWay(image3, 0, 0, 4, 4) == 10);

    int[][] image4 = new int[][] {
      new int[] {0, 1, 1, 1, 1},
      new int[] {1, 1, 1, 1, 1},
      new int[] {1, 1, 1, 1, 1},
      new int[] {1, 1, 1, 1, 1},
      new int[] {1, 1, 1, 1, 0},
    };
    print(FindWay(image4, 0, 0, 4, 4) == -1);
  }

  public static int FindWay(int[][] image, int StartRow, int StartColumn, int EndRow, int EndColumn) {
    int width = image[0].Length;
    int height = image.Length;

    if (!(0 <= StartColumn && StartColumn < width))
      return -1;
    if (!(0 <= StartRow && StartRow < height))
      return -1;
    if (!(0 <= EndColumn && EndColumn < width))
      return -1;
    if (!(0 <= EndRow && EndRow < height))
      return -1;
    
    int road = image[StartRow][StartColumn];
    var q = new Queue<Pos>();
    q.Enqueue(new Pos(StartRow, StartColumn, 0));

    while (q.Count > 0) {
      Pos pos = q.Dequeue();
      int x = pos.X;
      int y = pos.Y;

      if (image[x][y] == road) {
        if (x - 1 >= 0 && image[x - 1][y] == road)
          q.Enqueue(new Pos(x - 1, y, pos.Cost + 1));
        if (y + 1 < width && image[x][y + 1] == road)
          q.Enqueue(new Pos(x, y + 1, pos.Cost + 1));
        if (x + 1 < height && image[x + 1][y] == road)
          q.Enqueue(new Pos(x + 1, y, pos.Cost + 1));
        if (y - 1 >= 0 && image[x][y - 1] == road)
          q.Enqueue(new Pos(x, y - 1, pos.Cost + 1));
      }
      if (x == EndRow && y == EndColumn) {
        return pos.Cost;
      }
    }
    return -1;
  }
}

class Pos {
  public int X {get; set;}
  public int Y {get; set;}
  public int Cost {get; set;}
  public Pos(int x, int y, int cost) {X = x; Y = y; Cost = cost;}
}

public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) {
    return String.Join(" ", list);
  }
}

/*
2019.04.08
숙제

1.
Merge Sort
divide and conquer
recursive
분할 정복 결합
https://gmlwjd9405.github.io/2018/05/08/algorithm-merge-sort.html

2. (19. H/W line 169)
linked list
yield return
foreachable

3.
http://theory.stanford.edu/~amitp/GameProgramming/AStarComparison.html
floodfill처럼
naive 하게 (bruteforce)
cost기억 (비용은 1)
못가는 길?
시작 지점 to 목표 지점

4. (55. Algo: Flood Fill...)
8방향?
*/
