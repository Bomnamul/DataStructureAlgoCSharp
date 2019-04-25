// https://jiwondh.github.io/2017/10/15/tree/

using System;
using System.Collections;
using System.Collections.Generic;

class TreeNode
{
  public string Name{get; set;}
  public List<TreeNode> children; // 가변가능한 List 
  public TreeNode parent;
  public TreeNode(string name)
  {
    Name = name;
    children = new List<TreeNode>();
    parent = null;
  }

  public void AddChild(TreeNode c)
  {
    children.Add(c);  // List의 Add함수
    c.parent = this;
  }

  public int Degree {
    get {
      return children.Count;
    }
  }

  public bool isLeaf {
    get {
      return Degree == 0;
    }
  }

  public override string ToString() {
    return Name;
  }
}

class Tree : IEnumerable
{
  public TreeNode Root { get; set; }
  
  public string IterativeDFS(TreeNode node, Action<TreeNode> callback)  
  // 자주쓰는 패턴 스택을이용한 DFS
  {
    string s = "";
    Stack<TreeNode> stack = new Stack<TreeNode>();
    stack.Push(node);

    while(stack.Count > 0)
    {
      TreeNode n = stack.Pop();
      s += n.Name + " ";
      callback(n);

      for(int i = n.children.Count-1; i >= 0; i--)
        stack.Push(n.children[i]);
    }
    return s;
  }

  public string RecursiveDFS(TreeNode node) // 재귀호출을 이용한 DFS방식출력
  {
    string s = node.Name + " ";
    foreach(var n in node.children)
      s += RecursiveDFS(n);
    return s;
  }

  public string IterativeBFS(TreeNode node, Action<TreeNode> callback) // 큐를 이용한 BFS (재귀호출은 불가능) 작성해오기
  {
    string s = "";
    var queue = new Queue<TreeNode>();
    queue.Enqueue(node);

    while (queue.Count > 0) {
      TreeNode n = queue.Dequeue();
      s += n.Name + " ";
      callback(n);

      foreach(var c in n.children)
        queue.Enqueue(c);
    }
    return s;
  }

  public int DepthOfNode(TreeNode node) {
    int count = 0;
    TreeNode current = node;
    while (current.parent != null) {
      count++;
      current = current.parent;
    }
    return count;
  }

  public int Degree {
    get {
      int maxDegree = 0;
      IterativeBFS(Root, node => { // 노드 하나를 읽을때마다 callback (외워두자)
        if (node.Degree > maxDegree)
        maxDegree = node.Degree;
      });
      return maxDegree;
    }
  }

  public int Height { // 전체를 돌리면 O(n * logn) 비효율적... isLeaf도 절반이 줄었지만 n이 무한대로 늘어나면 비효율적...
    get {
      int maxDepth = 0;
      IterativeBFS(Root, node => {
        if (node.isLeaf) {
          int d = DepthOfNode(node);
          if (d > maxDepth)
            maxDepth = d;
        }
      });
      return maxDepth;
    }
  }

  public int HeightFast { // O(n)
    get {
      int maxDepth = 0;
      Stack<TreeNode> stack = new Stack<TreeNode>();
      stack.Push(Root);
      while(stack.Count > 0) {
        if (stack.Count > maxDepth)
          maxDepth = stack.Count - 1;
        TreeNode n = stack.Pop();
        for (int i = n.children.Count - 1; i >= 0; i--)
          stack.Push(n.children[i]);
      }
      return maxDepth;
    }
  }

  public IEnumerator GetEnumerator() {
    // 1. using List<> Enumerator
    var list = new List<TreeNode>(); // 선형화를 시키면 list.GetEnumerator로 쉽게 사용가능
    IterativeDFS(Root, node => list.Add(node)); // callback (다방면으로 쓸 수 있어 매우 좋다)
    return list.GetEnumerator();

    // 2. return new TreeNodeEnumerator(this);
  }

    // 3. using yield return
  public IEnumerable<TreeNode> EnumDFS(TreeNode node) {
    var stack = new Stack<TreeNode>();
    stack.Push(node);
    while (stack.Count > 0) {
      TreeNode n = stack.Pop();
      yield return n;
      for (int i = n.children.Count - 1; i >= 0; i--)
        stack.Push(n.children[i]);
    }
  }

  class TreeNodeEnumerator : IEnumerator {
    Tree tree;
    List<TreeNode> list;
    int position = -1;

    public TreeNodeEnumerator(Tree _tree) {
      tree = _tree;
      list = new List<TreeNode>();
      tree.IterativeDFS(tree.Root, node => list.Add(node));
      // or tree.IterativeBFS(tree.Root, node => list.Add(node));
    }

    public bool MoveNext() {
      if (position < list.Count - 1) {
        position++;
        return true;
      } else {
        return false;
      }
    }

    public object Current {
      get {
        return list[position];
      }
    }

    public void Reset() {
      position = -1;
    }
  }
}

class MainClass 
{
  public static void Main (string[] args) 
  {
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

    //DFS == Stack방식
    //BFS == Queue방식

    print(tree.IterativeDFS(root, node=>{}) == "root a d e b f g h i c ");
    print(tree.RecursiveDFS(root) == "root a d e b f g h i c ");
    print(tree.IterativeBFS(root, node=>{}) == "root a b c d e f g h i ");

    print("\t\tH/W");
    print(tree.DepthOfNode(root) == 0);
    print(tree.DepthOfNode(h) == 3);

    print(root.Degree == 3);
    print(tree.Degree == 3);

    print(tree.Height == 3);
    print(tree.HeightFast == 3);

    string str = "";
    foreach(var n in tree)
      str += n + " ";
    print(str == "root a d e b f g h i c "); // serialization 해서 짬

    str = "";
    foreach(var n in tree.EnumDFS(tree.Root))
      str += n + " ";
    print(str == "root a d e b f g h i c ");
  }
}

// Node depth, Tree degree, Tree height 만들어오기
// doubly linked list, foreachable 가능하게 만들어오기
// Tree, foreachable (DFS방식 이용)