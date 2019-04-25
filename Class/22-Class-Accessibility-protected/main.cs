using System;

class Point {
  protected int x; // 상속받은 class는 건드릴 수 있다
  protected int y;
}

class DerivedPoint : Point {
  public static void Main (string[] args) {
    DerivedPoint dpoint = new DerivedPoint();
    dpoint.x = 10;
  }
}