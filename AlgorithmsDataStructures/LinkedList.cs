using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next;
        public Node(int _value) { value = _value; }
    }

    public class LinkedList
    {
        public Node head;
        public Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null) head = _item;
            else tail.next = _item;
            tail = _item;
        }

        public Node Find(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) return node;
                node = node.next;
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    nodes.Add(node);
                }

                node = node.next;
            }

            return nodes;
        }

        public bool Remove(int _value)
        {
            if (head.value == _value)
            {
                head = head.next;
                if (tail.value == _value)
                {
                    tail = null;
                }
                return true;
            }

            Node previousNode = head;
            Node node = head.next;

            while (node != null)
            {
                if (node.value == _value)
                {
                    previousNode.next = node.next;
                    if (node == tail)
                    {
                        tail = previousNode;
                    }
                    return true;
                }

                previousNode = node;
                node = node.next;
            }

            return false;
        }

        public void RemoveAll(int _value)
        {
            Node node = head;
            while (node != null)
            {
                Remove(_value);
                node = node.next;
            }
        }

        public void Clear()
        {
            head = null;
            tail = null;
        }

        public int Count()
        {
            Node node = head;

            int count = 0;

            while (node != null)
            {
                count++;
                node = node.next;
            }

            return count;
        }

        public bool InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            Node node = head;

            while (node != null)
            {
                if (node == _nodeAfter)
                {
                    if (node == tail)
                    {
                        tail = _nodeToInsert;
                    }
                    _nodeToInsert.next = node.next;
                    node.next = _nodeToInsert;

                    return true;
                }

                node = node.next;
            }

            return false;
        }

    }
}