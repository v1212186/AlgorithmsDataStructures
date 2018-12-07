using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class LinkedList2
    {
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _node)
        {
            if (head == null)
            {
                head = _node;
                _node.prev = null;
                _node.next = null;
            }
            else
            {
                tail.next = _node;
                _node.prev = tail;
            }
            tail = _node;
        }

        public Node Find(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    return node;
                }

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
            Node node = head;

            if (node == null)
            {
                return false;
            }

            if (node.value == _value)
            {
                RemoveHead();
                return true;
            }

            while (node != null)
            {
                if (node.value == _value)
                {
                    node.prev.next = node.next;
                    if (node == tail)
                    {
                        tail = node.prev;
                    }
                    else
                    {
                        node.next.prev = node.prev;
                    }
                    return true;
                }
                node = node.next;
            }

            return false;
        }

        public void RemoveAll(int _value)
        {
            Node node = head;

            while (node != null)
            {
                if (node.value == _value)
                {
                    if (head == node)
                    {
                        RemoveHead();
                        node = head;
                        continue;
                    }

                    node.prev.next = node.next;
                    if (node == tail)
                    {
                        tail = node.prev;
                    }
                    else
                    {
                        node.next.prev = node.prev;
                    }
                }

                node = node.next;
            }
        }

        private void RemoveHead()
        {
            if (head.next != null)
            {
                head.next.prev = null;
            }
            if (tail == head)
            {
                tail = null;
            }
            head = head.next;

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

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            if (_nodeAfter == null)
            {
                if (Count() == 0)
                {
                    InsertAsFirst(_nodeToInsert);
                }
                else
                {
                    AddInTail(_nodeToInsert);
                }

                return;
            }

            Node node = head;

            while (node != null)
            {
                if (node == _nodeAfter)
                {
                    if (node == tail)
                    {
                        tail = _nodeToInsert;
                    }
                    else
                    {
                        _nodeAfter.next.prev = _nodeToInsert;
                    }

                    _nodeToInsert.prev = _nodeAfter;
                    _nodeToInsert.next = _nodeAfter.next;
                    _nodeAfter.next = _nodeToInsert;

                    return;
                }

                node = node.next;
            }
        }

        public void InsertAsFirst(Node _node)
        {
            if (head == null)
            {
                head = _node;
                tail = _node;
            }
            else
            {
                _node.next = head;
                head.prev = _node;
                head = _node;
            }
        }
    }
}
