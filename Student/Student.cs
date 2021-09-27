using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Student
    {
        public string Name { get; private set; }

        public Dictionary<string, List<int>> Diary { get; private set; }

        public readonly string[] Subjects = { "C#", "Manual", "English", "History" };

        public Student(string name)
        {
            Name = name;
            Diary = new Dictionary<string, List<int>>(4)
            {
                { Subjects[0], new List<int>() { 50, 79, 88, 98 } },
                { Subjects[1], new List<int>() { 45, 65, 80, 36 } },
                { Subjects[2], new List<int>() { 55, 58, 89, 52 } },
                { Subjects[3], new List<int>() { 57, 67, 77, 99 } }
            };
        }

        public bool PutMark(string subject, int[] mark)
        {
            bool check = false;
            if (Diary.ContainsKey(subject))
            {
                foreach (int marks in mark)
                {
                    if ((marks >= 0) && (marks <= 100))
                    {
                        check = true;
                    }
                    else
                    {
                        check = false;
                        return check;
                    }
                }
                Diary[subject].AddRange(mark);
            }
            return check;
        }

        public int GetMax(string subject)
        {
            int max = 0;
            if (Diary.ContainsKey(subject))
            {
                foreach (int i in Diary[subject])
                {
                    if (i > max)
                    {
                        max = i;
                    }
                }
            }
            return max;
        }

        public int GetMin(string subject)
        {
            int min = 0;
            if (Diary.ContainsKey(subject))
            {
                min = Diary[subject][0];
                foreach (int i in Diary[subject])
                {
                    if (i < min)
                    {
                        min = i;
                    }
                }
            }
            return min;
        }

        public int GetAverage()
        {
            int aver = 0;
            List<int> AllMarks = new List<int>();

            foreach (KeyValuePair<string, List<int>> keyValue in Diary)
            {
                foreach (int mark in keyValue.Value)
                {
                    AllMarks.Add(mark);
                }
            }
            foreach (int i in AllMarks)
            {
                aver += i;
            }
            aver /= AllMarks.Count;
            return aver;
        }

        public List<int> GetAllMarksForSubject(string subject)
        {
            List<int> res = new List<int>();

            if (Diary.ContainsKey(subject))
            {
                foreach (int i in Diary[subject])
                {
                    res.Add(i);
                }
            }
            return res;
        }
    }
}
