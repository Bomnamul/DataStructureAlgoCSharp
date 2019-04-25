using System;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    print(Plus(10, 10) == 20); // testcase부터 만드는게 편하다

    MainClass mc = new MainClass();
    print(mc.Plus2(10, 10) == 20);

    // Array 1D
    int[] scores = new int[] {2, 4, 5, 3, 6, 8, 1, 7};
    // int[] scores = new int[8]; 이렇게도 사용 가능
    print(Sum(scores) == 36);
    print(Avg(scores) == 4.5);
    // print(Min(scores) == 1); Homework
    // print(Max(scores) == 8); Homework

    // Array 2D
    int[,] list2d = {
      {10, 20},
      {30, 40},
      {50, 60}
    };
    print(list2d[2,0] == 50);

    // Array 3D
    int[,,] list3d = {
      {
        {10, 20},
        {30, 40},
        {50, 60}
      },
      {
        {70, 80},
        {90, 100},
        {110, 120}
      }
    };
    int sum = 0;
    for (int i = 0; i < list3d.GetLength(0); i++) {     // int[this,,]
      for (int j = 0; j < list3d.GetLength(1); j++) {   // int[,this,]
        for (int k = 0; k < list3d.GetLength(2); k++) { // int[,,this]
          sum += list3d[i, j, k];
        }
      }
    }
    print(sum == 10+20+30+40+50+60+70+80+90+100+110+120);

    // Jagged Array(aka 가변배열)
    int[][] image = new int[][] {
      new int[] {0, 0, 0, 0, 0, 0, 0},
      new int[] {0, 0, 1, 1, 1, 0, 0},
      new int[] {0, 0, 1, 0, 1, 0, 0},
      new int[] {0, 0, 1, 0, 1, 0, 0},
      new int[] {0, 0, 1, 0, 1, 0, 0},
      new int[] {0, 0, 1, 1, 1, 0, 0},
      new int[] {0, 0, 0, 0, 0, 0, 0}
    };
    print(image[1][2] == 1);
  }

  public static int Sum(int[] list) {
    int s = 0;
    // for (int i = 0; i < list.Length; i++)
    // s += list[i];
    foreach(int n in list)
      s += n;
    return s;
  }

  public static double Avg(int[] list) {
    return Sum(list) / (double)list.Length; // int / int면 소숫점이 날아감 but 나머지 하나가 double(더 큼)이면 double로 해줌
  }

  public static int Plus(int a, int b) { // static : 태초부터 존재
    return a + b;
  }
  public int Plus2(int a, int b) { // MainClass를 new로 생성해야 사용 가능
    return a + b;
  }
}