using System;

namespace Project.Code.DynamicArrayExample
{
    public class DynArray<T>
    {
        public const int DefaultCapacity = 16;

        private int count;
        public int Count
        {
            get { return count; }
        }

        private int capacity;
        public int Capacity
        {
            get { return capacity; }
        }

        private T[]
            array; //можно было заменить nullable int на просто object, но для упрощения тестирования GetItem() оставил так

        public DynArray()
        {
            count = 0;
            MakeArray(DefaultCapacity);
        }

        //Сложность O(n), где n - count, то есть количество копируемых элементов
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

        //Сложность O(1), прямой доступ по индексу
        public T GetItem(int _index)
        {
            if (_index < 0 || _index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            return array[_index];
        }

        //Сложность O(1) при условии, что новый count не превысит capacity и O(n), где n - count, при превышении capacity
        public void Append(T _item)
        {
            if (count + 1 > capacity)
            {
                MakeArray(SizeUp(capacity));
            }

            count++;

            array[count - 1] = _item;
        }

        //Сложность O(count - _index), то есть количество элементов, которые необходимо сдвинуть при условии, что новый count не превысит capacity
        //Сложность O(n), где n - count, при превышении capacity (копируем элементы до _index и сдвигаем (count - _index) элементов)
        public void Insert(T _item, int _index)
        {
            if (_index < 0 ||_index > count)
            {
                throw new IndexOutOfRangeException();
            }

            count++;

            //не использовал MakeArray, иначе при вставке в начало сложность выросла бы до ~O(n^2) в худшем случае(вставка в начало)
            //так как пришлось бы сначала скопировать все элементы, а потом их все сдвинуть
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

        //Сложность O(count - _index), то есть количество элементов, которые необходимо сдвинуть при условии, что новый count не превысит capacity
        //Сложность O(n), где n - count, при превышении capacity (копируем элементы до _index и сдвигаем (count - _index) элементов)
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