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

  public TreeNode LeftChild {
    get {
      if (children.Count >= 1)
        return children[0];
      return null;
    }
  }

  public TreeNode RightChild {
    get {
      if (children.Count >= 2)
        return children[1];
      return null;
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

  public IEnumerator GetEnumerator() {
    // using List<> Enumerator
    var list = new List<TreeNode>(); // 선형화를 시키면 list.GetEnumerator로 쉽게 사용가능
    IterativeDFS(Root, node => list.Add(node)); // callback (다방면으로 쓸 수 있어 매우 좋다)
    return list.GetEnumerator();
    // return new TreeNodeEnumerator(this);

  }

  public string Inorder(TreeNode node, Action<TreeNode> callback) {
    string s = "";
    if (node.LeftChild != null)
      s += Inorder(node.LeftChild, callback);
    s += node + " ";
    callback(node);
    if (node.RightChild != null)
      s += Inorder(node.RightChild, callback);
    
    return s;
  }

  public string Preorder(TreeNode node, Action<TreeNode> callback) {
    string s = "";
    s += node + " ";
    callback(node);
    if (node.LeftChild != null)
      s += Preorder(node.LeftChild, callback);
    if (node.RightChild != null)
      s += Preorder(node.RightChild, callback);
    
    return s;
  }
  public string Postorder(TreeNode node, Action<TreeNode> callback) {
    string s = "";
    if (node.LeftChild != null)
      s += Postorder(node.LeftChild, callback);
    if (node.RightChild != null)
      s += Postorder(node.RightChild, callback);
    s += node + " ";
    callback(node);

    return s;
  }
}

class MainClass 
{
  public static void Main (string[] args) 
  {
    Action<object> print = Console.WriteLine;

/*
            a
           / \
          b   c
         / \
        d   e
*/

    var binaryTree = new Tree();
    var root = new TreeNode("a");
    var b = new TreeNode("b");
    var c = new TreeNode("c");
    var d = new TreeNode("d");
    var e = new TreeNode("e");
    binaryTree.Root = root;

    root.AddChild(b); root.AddChild(c); // 보통 한 줄로 쓰지말라고 권장 (그냥 보기 편하니까 씀)
    b.AddChild(d); b.AddChild(e);

    print(binaryTree.Inorder(root, n => {}) == "d b e a c "); // Left, Root, Right
    print(binaryTree.Preorder(root, n => {}) == "a b d e c "); // Root, Left, Right
    print(binaryTree.Preorder(root, n => {}) == binaryTree.IterativeDFS(root, n => {}));
    print(binaryTree.Postorder(root, n => {}) == "d e b c a "); // Left, Right, Root
  }
}
