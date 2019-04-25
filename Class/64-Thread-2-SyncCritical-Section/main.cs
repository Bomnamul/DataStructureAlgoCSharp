using System;
using System.Threading;

// Lock에 사용되면 안되는 object
// 1. this
// 2. string
// 3. GetType(): Type

class Counter {
  public int Count {get; set;}
  readonly object thisLock = new object();
  public void Increase() {
    // Critical Section(CS)
    lock (thisLock) { // thread syncronization
      Count++; // 동 시간대에 하나의 thread만 진입해야 함
    }
  }
}

class MainClass {
  public static void Main (string[] args) {
    var c = new Counter();
    var t1 = new Thread(c.Increase);
    var t2 = new Thread(c.Increase);
    t1.Start();
    t2.Start();

    Console.ReadLine();
  }
}