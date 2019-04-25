using System;
using System.Collections;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {

    int[][] image = new int[][] {
      new int[] {0, 0, 0, 0, 0, 0, 0},
      new int[] {0, 0, 1, 1, 1, 0, 0},
      new int[] {0, 0, 1, 0, 1, 0, 0},
      new int[] {0, 0, 1, 0, 1, 0, 0},
      new int[] {0, 0, 1, 0, 1, 0, 0},
      new int[] {0, 0, 1, 1, 1, 0, 0},
      new int[] {0, 0, 0, 0, 0, 0, 0},
    };
    PrintImage(image);

    FloodFill(image, 2, 3, 7);
    Console.WriteLine();
    PrintImage(image);
    FloodFill(image, 0, 3, 7);
    Console.WriteLine();
    PrintImage(image);
    FloodFill(image, 0, 0, 0);
    Console.WriteLine();
    PrintImage(image);
    FloodFill(image, 1, 2, 9);
    Console.WriteLine();
    PrintImage(image);
    FloodFill(image, -1, 2, 4);
    Console.WriteLine();
    PrintImage(image);
    FloodFill(image, 100, 2, 4);
    Console.WriteLine();
    PrintImage(image);
    FloodFill(image, 0, -2, 4);
    Console.WriteLine();
    PrintImage(image);
    FloodFill(image, 0, 200, 4);
    Console.WriteLine();
    PrintImage(image);
  }

  public static void PrintImage(int[][] list) {
    for (int i = 0; i < list.Length; i++) {
      for (int j = 0; j < list.Length; j++) {
        Console.Write(list[i][j] + " ");
      }
      Console.WriteLine();
    }
  }

  public static void FloodFill(int[][] image, int a, int b, int replace) {
    if (a < 0 || a >= image.Length || b < 0 || b >= image.Length) {
      Console.WriteLine("Out of Index Exception !");
      return;
    }

    var q = new Queue<Node>();
    int target = image[a][b];
    q.Enqueue(new Node(a, b));

    while (q.Count > 0) {
      Node node = q.Dequeue();
      if (image[node.x][node.y] == target) {
        image[node.x][node.y] = replace;
        if (node.x - 1 >= 0 && node.y >= 0 && node.x - 1 < image.Length && node.y < image.Length) {
          q.Enqueue(new Node(node.x - 1,node.y));
        }
        if (node.x + 1 >= 0 && node.y >= 0 && node.x + 1 < image.Length && node.y < image.Length) {
          q.Enqueue(new Node(node.x + 1,node.y));
        }
        if (node.x >= 0 && node.y - 1 >= 0 && node.x < image.Length && node.y - 1 < image.Length) {
          q.Enqueue(new Node(node.x,node.y - 1));
        }
        if (node.x >= 0 && node.y + 1 >= 0 && node.x < image.Length && node.y + 1 < image.Length) {
          q.Enqueue(new Node(node.x,node.y + 1));
        }
      }
    }
  }

  public class Node {
    public int x;
    public int y;
    public Node (int x, int y) {
      this.x = x;
      this.y = y;
    }
  }
}
/*
2019.04.08
숙제
1. Flood Fill
가변 (2차원) array
paint 빈칸 색 채우기?
시작 칸, 목표 색, 대체 색

보는 방향은 십자(좌우상하)
초기의 찍은값 i에서 4방향 훑어보기

queue에다 집어놓고 꺼내서 훑어보고 바꾼뒤 자식(바꾼놈)을 집어놓고 꺼냄?
bfs로 동작



int [][] image = new int[][] {
  new int[] {0, 0, 0, 0, 0, 0, 0},
  ...
}

testcase?

8방향도 가능 (해볼까?)
*/
