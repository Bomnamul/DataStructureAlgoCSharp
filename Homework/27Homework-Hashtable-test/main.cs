using System;
using System.Collections.Generic;


class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    Hashtable<string, string> ht = new Hashtable<string, string>(5);
    ht.Add("txt", "notepad.exe");
    ht.Add("bmp", "paint.exe");
    ht.Add("dib", "paint.exe");
    ht.Add("rtf", "wordpad.exe");
    print(ht.Count == 4);

    ht.Add("txt", "winword.exe"); // key는 unique해야 함
    ht.Add("bmp", "winword.exe");
    print(ht.Count == 4);

    // ht["max"] = "3dsmax.exe"; // array 참조 연산자를 사용가능?
    // print(ht.Count == 5);

    // print((string)ht["max"] == "3dsmax.exe");

    print(ht.ContainsKey("txt") == true);
    print(ht.ContainsKey("bmp") == true);
    print(ht.ContainsKey("dib") == true);
    print(ht.ContainsKey("rtf") == true);

    // ht.Remove("bmp");
    // print(ht.ContainsKey("bmp") == false);

    // Hashtable users = new Hashtable();
    // users[100] = new User(100, "djyang", 26);
    // users[101] = new User(101, "brown", 30);
    // users[102] = new User(102, "hash", 10);
    // print(users.Count == 3);
  }
}

public class Hashtable<TKey, TValue> {
  LinkedList<Node>[] Bucket;
  public int Count;

  public Hashtable(int size) {
    Bucket = new LinkedList<Node>[size];
    Count = 0;
  }

  public int HashFunc(TKey key) {
    return key.ToString().Length;
  }

  public void Add(TKey key, TValue data) { // key 값을 받아 해시 함수를 적용시켜 주소를 정하고 Node 형식으로 data를 저장
    int hashIndex = HashFunc(key) % Bucket.Length;

    if (Bucket[hashIndex] == null) {
      Node node = new Node(key, data);
      Bucket[hashIndex].AddFirst(node);
      Count++;
    } else if (ContainsKey(key) == true) {
      // linked list로 뒤에 붙어있을 수도 있으니 확인해줘야함
      Console.WriteLine("Already exist !");
    } else {
      Node node = new Node(key, data);
      Bucket[hashIndex].AddFirst(node);
      Count++;
    }
  }

  // public void Remove(TKey key) { // key 값에 해당하는 위치를 찾아 삭제
  // // 해싱주소 찾아서 삭제, 리스트 서칭도 있어야 할듯?
  //   int hashIndex = HashFunc(key) % Bucket.Length;
  //   Node linkedNode = Bucket[hashIndex].next;
    
  //   if (ContainsKey == true) {
  //     if (Bucket[hashIndex].next.nodeKey.Equals(key))
  //       Bucket[hashIndex].next = null;
  //     else {
  //       while (linkedNode != null) {
  //         if (linkedNode.nodeKey.Equals(key)) {
  //           if (linkedNode.next != null) {

  //           } else {

  //           }
  //         }
  //         linkedNode = linkedNode.next;
  //       }
  //     }
  //   }
  // }

  // public void Indexer {

  // }

  public bool ContainsKey(TKey key) { // 해당 key값이 해시테이블에 있으면 true 아니면 false;
    int hashIndex = HashFunc(key) % Bucket.Length;

    Bucket[hashIndex].Contains(key);
    // 해싱주소 찾아서 확인, 리스트 서칭도 있어야 할듯?
  }

  public class Node {
    public TKey nodeKey;
    public TValue nodeData;
    public Node next;

    public Node(TKey key, TValue data) {
      nodeKey = key;
      nodeData = data;
      next = null;
    }
  }
}

// public class User {
//   public int Id {get; set;}
//   public string Name {get; set;}
//   public int Age {get; set;}
//   public User(int id, string name, int age) {
//     Id = id;
//     Name = name;
//     Age = age;
//   }
// }

public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) {
    return String.Join(" ", list);
  }
}

// https://en.wikipedia.org/wiki/Hash_table

// hashtable 구현
// Collection(non generic) hashtable? 에 있는 인터페이스 ? 위키보셈
// HashTable(1) : Linked List 2개부터 Tree?
// add, remove, indexer, generic하게 ? stringify(순서?), count, containskey 함수 구현
// (key 문자열의 길이 / 해시 버켓)의 나머지
// 충돌 날 경우 linked 리스트로 이어버림
// 찾을 때는 해시값을 보고 어드레스를 찾아간 다음 linked list로 찾아감 (chaining)
// bucket을 linked list... 해도됨 (hard)
// open addressing?

/*
hash = hashfunc(key)
index = hash % array_size

지금은 해시함수 string 길이로 하자
*/
