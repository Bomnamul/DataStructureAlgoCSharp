// https://magi82.github.io/process-thread/
// http://www.albahari.com/threading/part2.aspx

using System;
using System.Threading;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    print("Thread Id: " + Thread.CurrentThread.ManagedThreadId);

    var t = new Thread(Todo);
    print("Before: " + t.ThreadState);
    t.Start();
    print("After: " + t.ThreadState);

    // delegate void ThreadStart(); // callback을 넘김 but 안이쁘니 바로 line 13 처럼 Todo callback
    // var t2 = new Thread(new ThreadStart(Todo));
    // t2.Start();

    t.Join(); // main thread에 합류 할 때까지 대기
    // Console.ReadLine();

    print("End: " + t.ThreadState);
  }

  static void Todo() {
    Thread.Sleep(500); // 0.5s
    Console.WriteLine("Todo: " + Thread.CurrentThread.ManagedThreadId);
  }
}