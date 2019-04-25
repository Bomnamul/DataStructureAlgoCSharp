// https://jiwondh.github.io/2017/10/15/tree/

using System;
using System.Collections;
using System.Collections.Generic;

class TreeNode {
  public int childCount = 0;
  public TreeNode parent = null;
  public List<TreeNode> children; // 가변가능한 List 
  public string Name{get; set;}
  public TreeNode(string name) {
    Name = name;
    children = new List<TreeNode>();
  }

  public void AddChild(TreeNode c) {
    c.parent = this;
    children.Add(c);  // List의 Add함수
    childCount++;
  }
}

class Tree { // : IEnumerable 
  public TreeNode Root { get; set; }
  
  public string IterativeDFS(TreeNode node, Action<string> callback)  { // 자주쓰는 패턴 스택을이용한 DFS
    string s = "";
    Stack<TreeNode> stack = new Stack<TreeNode>();
    stack.Push(node);

    while (stack.Count > 0) {
      TreeNode n = stack.Pop();
      s += n.Name + " ";
      callback(n.Name);

      for(int i = n.children.Count-1; i >= 0; i--)
        stack.Push(n.children[i]);
    }
    return s;
  }

  public string RecursiveDFS(TreeNode node) { // 재귀호출을 이용한 DFS방식출력
    string s = node.Name + " ";
    foreach(var n in node.children)
      s += RecursiveDFS(n);
    return s;
  }

  public string IterativeBFS(TreeNode node) { // 큐를 이용한 BFS (재귀호출은 불가능) 작성해오기
    string s = "";
    Queue<TreeNode> queue = new Queue<TreeNode>(); // var 쓰는 것을 권장
    queue.Enqueue(node);

    while (queue.Count > 0) {
      TreeNode n = queue.Dequeue();
      s += n.Name + " ";

      for(int i = 0; i < n.children.Count; i++)
        queue.Enqueue(n.children[i]);
    }
    return s;
  }

  public int Degree() {
    int result = 0;
    Stack<TreeNode> stack = new Stack<TreeNode>();
    stack.Push(Root);

    while (stack.Count > 0) {
      TreeNode n = stack.Pop();

      if (n.childCount > result) {
        result = n.childCount;
      }
      for(int i = n.children.Count-1; i >= 0; i--)
        stack.Push(n.children[i]);
    }
    return result;
  }

  public int Depth(TreeNode node) { // linear로 ?
    int edge = 0;
    if (node.parent != null) {
      edge++;
    } else {
      return edge;
    }
    return edge + Depth(node.parent);
  }

  public int Height() {
    int result = 0;
    Stack<TreeNode> stack = new Stack<TreeNode>();
    stack.Push(Root);

    while (stack.Count > 0) {
      TreeNode n = stack.Pop();

      if (Depth(n) > result) {
        result = Depth(n);
      }
      for(int i = n.children.Count-1; i >= 0; i--)
        stack.Push(n.children[i]);
    }
    return result;
  }

  // public IEnumerator GetEnumerator() {
  //   return new NameEnumerator(this);
  // }

  // class NameEnumerator : IEnumerator {
  //   Tree t;

  //   public NameEnumerator(Tree t) {
  //     this.t = t;
  //   }

  //   public bool MoveNext() {

  //   }

  //   public object Current {

  //   }

  //   public void Reset() {

  //   }
  // }
}

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    Tree tree = new Tree();
    TreeNode root = new TreeNode("root");
    TreeNode a = new TreeNode("a");
    TreeNode b = new TreeNode("b");
    TreeNode c = new TreeNode("c");
    TreeNode d = new TreeNode("d");
    TreeNode e = new TreeNode("e");
    TreeNode f = new TreeNode("f");
    TreeNode g = new TreeNode("g");
    TreeNode h = new TreeNode("h");
    TreeNode i = new TreeNode("i");
    tree.Root = root;
    
    root.AddChild(a); root.AddChild(b); root.AddChild(c);
    a.AddChild(d); a.AddChild(e);
    b.AddChild(f); b.AddChild(g);
    g.AddChild(h); g.AddChild(i);

  /*
                 root
              /   |   \
            a     b     c
           / \   / \
          d   e f   g
                   / \
                  h   i
  */

    //DFS == Stack방식
    //BFS == Queue방식

    print(tree.IterativeDFS(root, s=>{}) == "root a d e b f g h i c ");
    print(tree.RecursiveDFS(root) == "root a d e b f g h i c ");
    print(tree.IterativeBFS(root) == "root a b c d e f g h i ");
    print(tree.Depth(a) == 1);
    print(tree.Depth(f) == 2);
    print(tree.Depth(i) == 3);
    print(tree.Degree() == 3);
    print(tree.Height() == 3);

    // foreach (string n in tree) {
    //   print(n);
    // }
  }
}

// Node depth, Tree degree, Tree height 만들어오기
// doubly linked list, foreachable 가능하게 만들어오기
// Tree, foreachable (DFS방식 이용)

/*
  public string IterativeBFS(TreeNode node) { // Queue
    return "";
  }

  임의의 노드를 주면 그 노드의...
  임의의 트리를 주면 ...
  Node depth, Tree degree, Tree height
  iterative 순회하면서 기억 + 변형

  doubly linked list, foreachable하게 바꾸기
  레퍼런스를 하나씩 옮겨가며

  오늘 배운 Tree도 foreachable하게
  dfs 방식...
*/