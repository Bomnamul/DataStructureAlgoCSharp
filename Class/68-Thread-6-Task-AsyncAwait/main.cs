using System;
using System.Threading;
using System.Threading.Tasks;

class MainClass {
  public static void Main (string[] args) {
    Chain();
    Console.ReadLine();
  }

  public static async void Chain() { // async 키워드(중간에 block될 수 있음)를 쓰면 내부에 await가 있다
    int a = await Task<int>.Run( () => { // task가 종료될 때 까지 기다림
      Thread.Sleep(100);
      Console.WriteLine("1 task");
      return 100;
    });
    int b = await Task<int>.Run( () => {
      Thread.Sleep(100);
      Console.WriteLine("1 task");
      return 200 + a;
    });
    int result = await Task<int>.Run( () => {
      Thread.Sleep(100);
      Console.WriteLine("1 task");
      return 300 + b;
    });
    Console.WriteLine(result == 600);
  } // 이 함수는 0.3초 동안 제어권을 다른 곳에 넘겨 줌, DB작업도 async로 사용?
}