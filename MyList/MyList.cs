using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Security.Cryptography.X509Certificates;

namespace MyList
{
    // <T>는 제네릭(Generic)으로, 어떤 데이터 타입(int, string 등)이든 담을 수 있게 합니다.
    internal class MyList<T>
    {
        public T[] array;    // 데이터를 실제로 저장할 내부 배열
        private int count;     // 현재 리스트에 저장된 실제 데이터의 개수

        // 외부에서 개수를 확인할 수 있게 해주는 프로퍼티 (읽기 전용)
        public int Count { get { return count; } }

        private int capacity;  // 내부 배열의 전체 물리적 공간 크기
        public int Capacity { get { return capacity; } }

        // 생성자: 클래스가 처음 만들어질 때 초기 상태를 설정
        public MyList()
        {
            array = new T[4];    // 처음에 4칸짜리 배열을 만듭니다.
            count = 0;           // 데이터는 아직 없으므로 0
            capacity = array.Length; // 초기 용량은 4
        }

        // 데이터를 추가하는 메서드
        public void Add(T _data)
        {
            // [체크] 만약 현재 데이터 개수가 배열 용량과 같다면 (즉, 꽉 찼다면)
            if (count == capacity)

                Resize(); // 배열의 크기를 키우는 작업을 실행


            array[count] = _data; // 현재 빈 칸(count 인덱스)에 데이터를 삽입
            count++;              // 데이터 개수를 1 증가
        }

        // 배열이 꽉 찼을 때 새롭고 큰 배열로 교체하는 메서드
        private void Resize()
        {
            // 1. 기존 용량의 2배 크기로 새로운 용량 설정 (보통 2배씩 늘림)
            capacity = capacity * 2;

            // 2. 더 넓은 새 집(배열)을 메모리에 생성
            T[] tempArray = new T[capacity];

            // 3. [반복문] 이 과정이 핵심! 
            // 구 주소(array)에 있는 데이터를 신 주소(tempArray)로 하나씩 이사시킴
            for (int i = 0; i < count; i++)
            {
                tempArray[i] = array[i]; // 기존 배열의 i번째 데이터를 새 배열의 i번째로 복사
            }

            // 4. 이제 내부 배열 변수가 새 배열을 가리키도록 업데이트
            // 기존의 작은 배열은 가비지 컬렉터(GC)에 의해 메모리에서 해제됩니다.
            array = tempArray;
            capacity = array.Length;

            //새로운 배열 생성: T[] tempArray = new T[count * 2]; 를 통해 기존보다 2배 큰 새로운 공간을 메모리에 할당합니다. 이때 tempArray는 비어 있는 상태입니다.

            //데이터 복사: tempArray[i] = array[i]; 반복문을 통해 기존 배열에 들어있던 값들을 하나씩 새 배열의 같은 인덱스 위치로 복사합니다.
        }


        public void Insert(int _index, T _data)
        {
            for (int i = count; i > _index; i--)
                array[i] = array[i - 1];

            array[_index] = _data;
            count++;
        }


        public void Remove(T _data)
        {
            for (int i = 0; i < count; i++)
            {
                if (_data.Equals(array[i]))
                {

                    //Console.WriteLine($"{i} 일때 같이 있습니다.");
                    //  array[5] = array[4];
                    //  array[4] = array[5];

                    for (int j = i; j < count - 1; j++)
                        array[j] = array[j + 1];
                    count--;
                    break;

                }


            }
        }

        public void RemoveAt(int _index) 
        {
            for(int i = _index;  i < count; i++)
                array[i] = array[i + 1];
            count--;
        }

       

       
    }
}

