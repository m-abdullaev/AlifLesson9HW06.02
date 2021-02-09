using System;

namespace AlifLesson9HW06._02
{
    class Program
    {
        static void Main(string[] args)
        {            
            string[] str = new string[] { "ant", "bison", "camel", "duck", "elephant" };                     
            Console.WriteLine(@"Please choose operation you would like to perform: 
                                    1. Pop
                                    2. Push
                                    3. Shift
                                    4. Unshift
                                    5. Only with beginning index
                                    6. With Beginning and ending indexe's
                                    7. Exit " 
                                        );            
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    {
                        Console.WriteLine(ArrayHelper.Pop<string>(ref str));                        
                    }
                    break;
                case 2:
                    Console.WriteLine("Please enter text");
                    string text = Console.ReadLine();
                    Console.WriteLine(ArrayHelper.Push<string>(ref str, text));
                    break;
                case 3:
                    Console.WriteLine(ArrayHelper.Shift<string>(ref str ));
                    break;
                case 4:
                    Console.WriteLine("Please enter text");
                    string text1 = Console.ReadLine();
                    Console.WriteLine(ArrayHelper.Push<string>(ref str, text1));
                    break;
                case 5:
                    {
                        var beginIndex = Convert.ToInt32(Console.ReadLine());
                        foreach (string i in ArrayHelper.Slice<string>(str, beginIndex))
                        {

                            Console.WriteLine(i);
                        }
                    }
                    break;
                case 6:
                    {
                        var beginIndex2 = Convert.ToInt32(Console.ReadLine());
                        var endIndex = Convert.ToInt32(Console.ReadLine());
                        foreach (string i in ArrayHelper.Slice<string>(str, beginIndex2, endIndex))
                        {

                            Console.WriteLine(i);
                        }
                    }
                    break;
                case 7:
                    return;
                    break;
            }                        
        }

    }

    public static class ArrayHelper
    {

        //Pop Methods
        public static T Pop<T>(ref T[] lastElement)
        {
            T arrLastElement = lastElement[lastElement.Length - 1];
            return arrLastElement;
        }

        //Push Methods
        public static int Push<T>(ref T[] addToLast, T updatedArray)
        {
            Array.Resize(ref addToLast, addToLast.Length + 1);
            addToLast[addToLast.Length - 1] = updatedArray;
            return addToLast.Length;
        }

        //Shift Methods
        public static T Shift<T>(ref T[] shiftElement)
        {
            T shift = shiftElement[0];
            for (int i = 0; i < shiftElement.Length - 1; i++)
            {
                shiftElement[i] = shiftElement[i + 1];
            }
            Array.Resize(ref shiftElement, shiftElement.Length - 1);
            return shift;
        }

        //Unshift Methods
        public static int UnShift<T>(ref T[] addToFirst, T toFirstElement)
        {
            Array.Resize(ref addToFirst, addToFirst.Length + 1);
            for (int i = addToFirst.Length - 1; i >= 1; i--)
            {
                addToFirst[i] = addToFirst[i - 1];
            }
            addToFirst[0] = toFirstElement;
            return addToFirst.Length - 1;
        }
        //Slice Method
        public static T[] Slice<T>(T[] arr)
        {
            return arr;
        }

        public static T[] Slice<T>(T[] arr, int beginIndex)
        {
            if (beginIndex > arr.Length)
            {
                return default;
            }

            if (beginIndex < 0)
            {
                beginIndex = arr.Length - Math.Abs(beginIndex);
            }

            int slice = arr.Length - beginIndex;
            T[] newArr = new T[slice];
            for (int i = 0; i < slice; i += 1)
            {
                newArr[i] = arr[beginIndex + i];
            }
            return newArr;
        }

        public static T[] Slice<T>(T[] arr, int beginIndex, int endIndex)
        {
            if (beginIndex > arr.Length)
            {
                T[] newAr = new T[0];
                return newAr;
            }

            if (beginIndex < 0)
            {
                beginIndex = arr.Length - Math.Abs(beginIndex);
            }

            if (endIndex < 0)
            {
                endIndex = arr.Length - Math.Abs(endIndex);
            }

            int slice = endIndex - beginIndex;
            T[] newArr = new T[slice];
            for (int i = 0; i < slice; i += 1)
            {
                newArr[i] = arr[beginIndex + i];
            }
            return newArr;
        }
    }
}