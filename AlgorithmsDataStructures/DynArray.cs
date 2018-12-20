using System;

namespace AlgorithmsDataStructures
{
    public class DynArray<T>
    {
        public const int DefaultCapacity = 16;

        public int count;
        public int Count
        {
            get { return count; }
        }

        public int capacity;
        public int Capacity
        {
            get { return capacity; }
        }

        public T[]
            array;

        public DynArray()
        {
            count = 0;
            MakeArray(DefaultCapacity);
        }


        public void MakeArray(int _newCapacity)
        {
            capacity = _newCapacity;
            if (capacity < DefaultCapacity)
            {
                capacity = DefaultCapacity;
            }

            T[] newArray = new T[capacity];
            for (int i = 0; i < count; i++)
            {
                if (i >= capacity) //если новое значение capacity меньше чем count, "обрезаем" оставшиеся элементы
                {
                    count = capacity;
                    break;
                }

                newArray[i] = array[i];
            }

            array = newArray;
        }


        public T GetItem(int _index)
        {
            if (_index < 0 || _index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            return array[_index];
        }

        public void Append(T _item)
        {
            if (count + 1 > capacity)
            {
                MakeArray(SizeUp(capacity));
            }

            count++;

            array[count - 1] = _item;
        }


        public void Insert(T _item, int _index)
        {
            if (_index < 0 ||_index > count)
            {
                throw new IndexOutOfRangeException();
            }

            count++;

            if (count >= capacity)
            {
                capacity = SizeUp(capacity);

                T[] newArray = new T[capacity];
                for (int i = count - 1; i >= 0; i--)
                {
                    if (i == _index)
                    {
                        newArray[_index] = _item;
                        continue;
                    }

                    if (i > _index)
                    {
                        newArray[i] = array[i - 1];
                    }
                    else
                    {
                        newArray[i] = array[i];
                    }
                }

                array = newArray;
                return;
            }


            for (int i = count - 1; i > _index; i--)
            {
                array[i] = array[i - 1];
            }

            array[_index] = _item;
        }


        public void Remove(int _index)
        {
            if (_index < 0 ||_index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            count--;

            if (count * 2 < capacity)
            {
                capacity = SizeDown(capacity);

                T[] newArray = new T[capacity];
                for (int i = 0; i < count; i++)
                {
                    if (i >= _index)
                    {
                        newArray[i] = array[i + 1];
                    }
                    else
                    {
                        newArray[i] = array[i];
                    }
                }

                array = newArray;
                return;
            }

            for (int i = _index; i < count; i++)
            {
                array[i] = array[i + 1];
            }

            array[count] = default(T);
        }

        public int SizeUp(int _currentCapacity)
        {
           int  newCapacity = _currentCapacity * 2;
            return newCapacity;
        }

        public int SizeDown(int _currentCapacity)
        {
            int newCapacity = (int) (_currentCapacity / 1.5);
            if (newCapacity < DefaultCapacity)
            {
                newCapacity = DefaultCapacity;
            }

            return newCapacity;
        }
    }
}
