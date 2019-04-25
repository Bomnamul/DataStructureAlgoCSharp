using System;
using System.Threading;
using System.Threading.Tasks;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    print("in Main: " + Thread.CurrentThread.ManagedThreadId);
    // 1.
    var task0 = new Task( () => {
      Thread.Sleep(1000);
      print("in task: " + Thread.CurrentThread.ManagedThreadId);
    });
    // task0.Start();
    task0.RunSynchronously(); // 더 이상 진행되지 않고 block (sync하게 처리하고 싶을 때 사용)

    // 2.
    Task task1 = Task.Run( () => {
      for (int i = 0; i < 5; i++) {
        Thread.Sleep(1000);
        print("in task1: " + Thread.CurrentThread.ManagedThreadId);
      }
    });

    // 3.
    Task task2 = Task.Factory.StartNew( () => print("task2 !"));

    task0.Wait();
    task1.Wait();
    task2.Wait();
  }
}