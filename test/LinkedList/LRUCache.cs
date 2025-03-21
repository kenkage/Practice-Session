using System;
namespace test.LinkedList
{
    public class Node
    {
        public int key, val;
        public Node next;
        public Node prev;

        public Node(int key, int val)
        {
            this.val = val;
            this.key = key;
            this.next = null;
            this.prev = null;
        }
    }

    public class LRUCache
    {
        private int capacity;
        private Dictionary<int, Node> cache;  // Stores key and its corresponding node in the linked list
        private Node head, tail;

        public LRUCache(int cap)
        {
            capacity = cap;
            cache = new Dictionary<int, Node>();

            // Dummy head and tails to dimplify edge cases. We won't be requiring to handle null cases
            head = new Node(0, 0);
            tail = new Node(0, 0);
            head.next = tail;
            tail.prev = head;
        }

        // Helper method to add a node to the front of the list (most recently used)
        private void AddToFront(Node node)
        {
            node.next = head.next;
            node.prev = head;
            head.next.prev = node;
            head.next = node;
        }

        // Helper method to remove a node from its current position in the list
        private void Remove(Node node)
        {
            node.prev.next = node.next;
            node.next.prev = node.prev;
        }

        // Get the value of a key from the cache
        public int Get(int key)
        {
            if (cache.ContainsKey(key))
            {
                Node node = cache[key];
                MoveToFront(node);
                return node.val;
            }
            return -1;  // Key not found
        }

        private void MoveToFront(Node node)
        {
            // Move the accessed node to the front (most recently used)
            Remove(node);
            AddToFront(node);
        }

        // Set a key-value pair in the cache
        public void Set(int key, int value)
        {
            if (cache.ContainsKey(key))
            {
                // Update the existing node's value and move it to the front
                Node node = cache[key];
                node.val = value;
                MoveToFront(node);
            }
            else
            {
                // If the cache is at full capacity, remove the least recently used (LRU) item
                if (cache.Count == capacity)
                {
                    // Remove from the cache and the doubly linked list (remove from the tail)
                    Node lru = tail.prev;
                    Remove(lru);
                    cache.Remove(lru.key);
                }

                // Insert the new node
                Node newNode = new Node(key, value);
                cache[key] = newNode;
                AddToFront(newNode);
            }
        }

        //static void Main()
        //{
        //    // Console.WriteLine("Enter capacity of the cache:");
        //    string[] input = Console.ReadLine().Split(' ');
        //    int cap = int.Parse(input[0]);
        //    LRUCache cache = new LRUCache(cap);

        //    // Console.WriteLine("Enter number of queries:");
        //    int Q = int.Parse(input[1]);

        //    List<int> result = new List<int>();

        //    for (int i = 0; i < Q; i++)
        //    {
        //        string[] query = Console.ReadLine().Split(' ');

        //        if (query[0] == "SET")
        //        {
        //            int key = int.Parse(query[1]);
        //            int value = int.Parse(query[2]);
        //            cache.Set(key, value);
        //        }
        //        else if (query[0] == "GET")
        //        {
        //            int key = int.Parse(query[1]);
        //            int res = cache.Get(key);
        //            result.Add(res);  // Store the result
        //        }
        //    }

        //    foreach (var res in result)
        //    {
        //        Console.WriteLine(res);
        //    }
        //}
    }
}


