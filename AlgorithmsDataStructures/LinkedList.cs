using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class NodeOld
    {
        public int value;
        public NodeOld next;
        public NodeOld(int _value) { value = _value; }
    }

    public class LinkedList
    {
        public NodeOld head; 
        public NodeOld tail; 

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(NodeOld _item)
        {
            if (head == null)
            {
                head = _item;
            }
            else
            {
                tail.next = _item;
            }
            tail = _item;
        }

        public NodeOld Find(int _value)
        {
            NodeOld node = head;
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

        public List<NodeOld> FindAll(int _value)
        {
            List<NodeOld> nodes = new List<NodeOld>();
            NodeOld node = head;
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
            if (head == null)
            {
                return false;
            }

            if (head.value == _value)
            {
                if (tail == head)
                {
                    tail = null;
                }
                head = head.next;
                return true;
            }

            NodeOld previousNode = head;
            NodeOld node = head.next;

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
            NodeOld node = head;
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
            NodeOld node = head;

            int count = 0;

            while (node != null)
            {
                count++;
                node = node.next;
            }

            return count;
        }

        public bool InsertAfter(NodeOld _nodeAfter, NodeOld _nodeToInsert)
        {
            NodeOld node = head;

            if (node == null)
            {
                AddInTail(_nodeToInsert);
            }
            
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
