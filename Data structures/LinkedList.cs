using System;
using System.Collections.Generic;

class LinkedList {
  public List<Node> linkedList = new List<Node>();
  
  private Node lastNode;
  private Node firstNode;
  private int nextFree;
  private int start;
  
  public void print(string mode)
  {
    List<int> hey = default(List<int>);
    if (mode == "indices")
    {
      hey = traverseIndexes();
    } else if (mode == "values")
    {
      hey = traverseValues();
    }

    if (hey != default(List<int>))
    {
      foreach (int n in hey)
      {
        Console.WriteLine(n);
      }
      Console.WriteLine("---");
    }

    if (mode == "non-contiguous")
    {
      foreach (Node n in linkedList)
      {
        Console.WriteLine($"value:{n.value}, pointer:{n.pointer}");
      }
    }
  }

  public void populate(){
    linkedList.Add(new Node(2,2));
    linkedList.Add(new Node(5, 3));
    linkedList.Add(new Node(4,1));
    linkedList.Add(new Node(7,4));
    linkedList.Add(new Node(9, -1));
  }

  public LinkedList(){
    populate();
    setList();
  }

  public void setList()
  {
    int lowest = int.MaxValue;
    foreach (Node n in linkedList){
      if (n.value < lowest){
        firstNode = n;
        lowest = firstNode.value;
      }
      if (n.pointer == -1){
        lastNode = n;
      }
    }
    nextFree = linkedList.Count;
    start = linkedList.IndexOf(firstNode);
  }
  public void AddData(int data)
  {
    int hey = adjustPointers(data);
    linkedList.Add(new Node(data,hey));
    setList();
  }

  public void removeData(int data)
  {
    List<int> values = traverseValues();
    List<int> indices = traverseIndexes();

    int index = -1; // index of the value to be removed
    int prevInd = -1; // index of the previous value which's pointer will be updated
    int v = -1; // index in the values and indices arrays of the value

    for (int i = 0; i < values.Count; i++)
    {
      if (data == values[i])
      {
        // sets the values of the index, prevInd and v
        index = indices[i];
        v = i;
        Console.WriteLine($"v:{i}");
        if (i - 1 >= 0)
        {
          // only sets the previous index if the value to be removed is not the first node
          prevInd = indices[i - 1];
          Console.WriteLine($"prevIND: {prevInd}");
          Console.WriteLine($"prev value: {values[i-1]}");
        }
        else
        {
          // if the first node is being removed
          prevInd = -2;
        }
      }
    }

    if (index != -1 && prevInd != -1 && v != -1) // check to see if value is in list
    {
      if (prevInd != -2)
      {
        // sets pointer of node to previous node
        int pointer = linkedList[index].pointer;
        linkedList[prevInd].pointer = pointer;
        linkedList.RemoveAt(index);
        indices.RemoveAt(v);
        Console.WriteLine($"length after removal:{linkedList.Count}");
      }
      for (int i = 0; i < linkedList.Count; i++)
      {
        if (indices[i] >= index) // if pointers are larger than the value's pointer removed
        {
          if (linkedList[indices[i]].pointer != -1)
          {
            Console.WriteLine($"i:{i}");
            linkedList[indices[i]].pointer = linkedList[indices[i]].pointer - 1;
          }
        }

        if (linkedList[indices[i]].pointer == linkedList.Count-1)
        {
          linkedList[indices[i]].pointer -= 1;
        }
      }
      // linkedList.RemoveAt(index);
    }
    else
    {
      Console.WriteLine("Item not in list");
    }
    setList();

    // for (int i = 0; i < values.Count; i++)
    // {
    //   if (prevInd != -1)
    //   {
    //     indices[v-1] = 
    //   }
    //   if (indices[i] > index)
    //   {
    //     
    //   }
    // }
  }

  public void remove(int data)
  {
    List<int> values = traverseValues();
    List<int> indices = traverseIndexes();

    int index = -1;
    int prevInd = -1;
    int v = -1;

    for (int i = 0; i < values.Count; i++)
    {
      if (values[i] == data)
      {
        v = i;
      }
    }

    if (v == 0)
    {
      
    }else if (v == values.Count - 1)
    {
      
    }
    else
    {
      
    }
  }
  
  public int adjustPointers(int data)
  {
    List<int> values = traverseValues();
    List<int> indices = traverseIndexes();
    for (int i = 0; i<linkedList.Count;i++)
    {
      if (data < values[i])
      {
        if (i > 0 && i < linkedList.Count - 2)
        {
          int nextpointer = linkedList[indices[i - 1]].pointer;
          linkedList[indices[i - 1]].pointer = nextFree;
          return nextpointer;
        }

        if (i == 0)
        {
          return indices[0];
        } 
      }
    }
    linkedList[indices[indices.Count - 1]].pointer = nextFree;
    return -1;
  }

  public List<int> traverseValues()
  {
    List<int> returnArray = new List<int>{firstNode.value};
    bool complete = false;
    int pointer = firstNode.pointer;
    
    while (!complete)
    {
      returnArray.Add(linkedList[pointer].value);
      pointer = linkedList[pointer].pointer;
      if (pointer == -1)
      {
        complete = true;
      }
    }
    return returnArray;
  }

  public List<int> traverseIndexes(){
    List<int> returnArray = new List<int>{linkedList.IndexOf(firstNode)};
    bool complete = false;
    int pointer = firstNode.pointer;
    while (!complete)
    {
      returnArray.Add(pointer);
      pointer = linkedList[pointer].pointer;
      if (pointer == -1)
      {
        complete = true;
      }
    }
    return returnArray;
  }
}