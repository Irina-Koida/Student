using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Menu
    {
        public void MenuMain(List<Student> stlist)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Выберите действие по-номеру:");
                Console.WriteLine("1.Поставить оценку \n2.Максимальная оценка по предмету \n3.Минимальная оценка по предмету");
                Console.WriteLine("4.Средний балл по всем предметам\n");
                Console.Write("Выбор: ");
                int action;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out action) && action > 0 && action <= 4) break;
                    Console.WriteLine("Ошибка ввода. Выберете опцию от 1 до 4 и нажмите \"Enter\"");
                }
                Console.Write("Введите имя студента(Ирина, Инна, Имма) и нажмите \"Enter\": ");
                string student = Console.ReadLine();
                if (CheckStudent(student, stlist, out int idx))
                {
                    Console.WriteLine($"Выбран студент: {stlist[idx].Name}");
                    switch (action)
                    {
                        case 1:
                            AddMarks(stlist, idx);
                            break;
                        case 2: 
                            MaxMark(stlist, idx);
                            break;
                        case 3: 
                            MinMark(stlist, idx);
                            break;
                        case 4: 
                            MiddleMarkForOll(stlist, idx);
                            break;
                        default:
                            Console.WriteLine("Не правильный ввод");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"Студент с именем {student} не найден!");
                    Console.WriteLine();
                }
                Console.WriteLine("Для продолжения работы нажмите \"Enter\"" + "\nЧтобы закрыть програму нажмите \"Esc\"");
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            Console.WriteLine("Для продолжения работы нажмите \"Enter\"" + "\nЧтобы закрыть програму нажмите \"Esc\"");
        }

        private static bool CheckStudent(string name, List<Student> student, out int res)
        {                                                 
            bool check = false;                                                                                                               
            for (res = 0; res < student.Count; res++)
            {
                if (name.ToLower() == student[res].Name.ToLower())
                {
                    check = true;
                    break;
                }
            }
            return check;
        }

        static void AddMarks(List<Student> stlist, int idx)
        {
            Console.WriteLine("<---Добавить оценку--->");
            Console.WriteLine("Выберите предмет по-номеру и нажмите \"Enter\":");
            var keys = stlist[idx].Diary.Keys.ToArray();

            for (int i = 0; i < keys.Length; i++)
            {
                Console.WriteLine($"{ i + 1 }. { keys.GetValue(i) }");
            }
            Console.Write("Выбор: ");
            int subj;
            // out заставляет метод ссылаться на ту же переменную, которая была передана в метод. 
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out subj) && subj > 0 && subj <= 4) break;
                Console.WriteLine("Ошибка ввода. Выберете опцию от 1 до 4 и нажмите \"Enter\"");
            }
            Console.Write($"Текущие оценки по предмету {stlist[idx].Subjects[subj - 1]}: ");
            foreach (int i in stlist[idx].GetAllMarksForSubject(stlist[idx].Subjects[subj - 1]))
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Поставьте оценку (1-100) или несколько оценок, через запятую ',' и нажмите \"Enter\": ");
            string[] input = Console.ReadLine().Split(',');
            int[] Marks = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                Marks[i] = Convert.ToInt32(input[i].Trim());
            }
            if (stlist[idx].PutMark(stlist[idx].Subjects[subj - 1], Marks))
            {
                Console.WriteLine("Оценки добавлены!");
            }
            else
            {
                Console.WriteLine("Оценка вне диапазона!");
            }
            Console.Write($"Текущие оценки по предмету {stlist[idx].Subjects[subj - 1]}: ");
            foreach (int i in stlist[idx].GetAllMarksForSubject(stlist[idx].Subjects[subj - 1]))
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void MaxMark(List<Student> stlist, int idx)
        {
            Console.WriteLine("<---Максимальная оценка по предмету--->");
            Console.WriteLine("Выберите предмет:");
            var keys = stlist[idx].Diary.Keys.ToArray();
            for (int i = 0; i < keys.Length; i++)
            {
                Console.WriteLine($"{ i + 1 }. { keys.GetValue(i) }");
            }
            Console.Write("Выбор: ");
            int subj;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out subj) && subj > 0 && subj <= 4) break;
                Console.WriteLine("Ошибка ввода. Выберете опцию от 1 до 4 и нажмите \"Enter\"");
            }
            subj -= 1;
            Console.Write($"Максимальный балл по предмету {stlist[idx].Subjects[subj]}: " +
                $"{stlist[idx].GetMax(stlist[idx].Subjects[subj])}");
            Console.WriteLine();
        }

        static void MinMark(List<Student> stlist, int idx)
        {
            Console.WriteLine("<---Минимальная оценка по предмету--->");
            Console.WriteLine("Выберите предмет:");
            var keys = stlist[idx].Diary.Keys.ToArray();
            for (int i = 0; i < keys.Length; i++)
            {
                Console.WriteLine($"{ i + 1 }. { keys.GetValue(i) }");
            }
            Console.Write("Выбор: ");
            int subj;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out subj) && subj > 0 && subj <= 4) break;
                Console.WriteLine("Ошибка ввода. Выберете опцию от 1 до 4 и нажмите \"Enter\"");
            }
            subj -= 1;
            Console.Write($"Минимальный балл по предмету {stlist[idx].Subjects[subj]}: " +
                $"{stlist[idx].GetMin(stlist[idx].Subjects[subj])}");
            Console.WriteLine();
        }

        static void MiddleMarkForOll(List<Student> stlist, int idx)
        {
            Console.WriteLine("<---Средний балл по всем предметам--->");
            Console.WriteLine($"Средний балл: {stlist[idx].GetAverage()}");
            Console.WriteLine();
        }
    }
}
