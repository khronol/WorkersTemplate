using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersTemplate
{
    class Repository
    {
        Random rand;

        public ObservableCollection<Department> dep;

        public ObservableCollection<Worker> worker;
        public List<Worker> work;


        public Repository()
        {
            rand = new Random();
            this.worker = new ObservableCollection<Worker>();
            this.dep = new ObservableCollection<Department>();
        }
        // Размещение имен в базе данных firstNames
        string[] firstNames = new string[] {
                "Андрей",
                "Вадим",
                "Сергей",
                "Олег",
                "Илья",
                "Артур",
                "Максим",
                "Алексей"
            };

        // Размещение фамилий в базе данных lastNames
        string[] lastNames = new string[]
            {
                "Иванов",
                "Петров",
                "Васильев",
                "Кузнецов",
                "Князев",
                "Попов",
                "Щербаков",
                "Зорин",
                "Коновалов",
                "Соколов",
                "Лебедев",
                "Соловьёв",
                "Ленин",
                "Ульянов",
                "Зайцев",
                "Детков",
                "Волочай",
                "Щукин"
            };

        public void AddWorkers(int indexDep)
        {

            string employ = "";
            int slr = 0;
            int jak = worker.Count + 15;
            dep.Add(new Department($"Отдел_{indexDep}", indexDep));
            for (int i = worker.Count; i <= jak; i++)
            {

                if (i == 1) worker.Add(new Worker(0, "Директор", "Отдела", 34, "Директор", $"Отдел_{indexDep}", 15000));
                string firstName = firstNames[rand.Next(firstNames.Length)];
                string lastName = lastNames[rand.Next(lastNames.Length)];
                if (rand.Next(1, 3) == 1) employ = "Сотрудник";
                else employ = "Интерн";
                if (employ == "Сотрудник") slr = 2304;
                else slr = 500;
                int age = rand.Next(19, 25);
                worker.Add(new Worker((i + 1), firstName, lastName, age, employ, $"Отдел_{indexDep}", slr));

            }
            indexDep++;
        }



        public void JsonTestConvert()
        {
            string jsonW = JsonConvert.SerializeObject(worker);
            string jsonD = JsonConvert.SerializeObject(dep);
            File.WriteAllText(@"_JsonWorker.json", jsonW);
            File.WriteAllText(@"_JsonDep.json", jsonD);
        }

        public void JsonBack(string pathA, string pathB)
        {
            string jsonW = File.ReadAllText(pathA);
            string jsonD = File.ReadAllText(pathB);
            var tmpwork = JsonConvert.DeserializeObject<List<Worker>>(jsonW);
            var tmpdep = JsonConvert.DeserializeObject<List<Department>>(jsonD);
            var tmp = tmpwork[tmpwork.Count - 1].Id;
            for (int i = 0; i < tmp; i++)
            {
                var tmpworker = JsonConvert.DeserializeObject<List<Worker>>(jsonW);
                var tempW = tmpworker[i];
                worker.Add(tempW);
            }
            var tmps = tmpdep[tmpdep.Count - 1].Counter;
            for (int i = 0; i <= 4; i++)
            {
                var tmpdeps = JsonConvert.DeserializeObject<List<Department>>(jsonD);
                var tempD = tmpdeps[i];
                dep.Add(tempD);
            }
        }
        #region Методы сортировки каждого поля отдельно
        public void SotredById()
        {
            work = worker.OrderBy(x => x.Id).ToList<Worker>();

        }
        public void SotredByName()
        {
            work = worker.OrderBy(x => x.FirstName).ToList<Worker>();

        }
        public void SotredByLastName()
        {
            work = worker.OrderBy(x => x.LastName).ToList<Worker>();

        }
        public void SotredByAge()
        {
            work = worker.OrderBy(x => x.Age).ToList<Worker>();

        }
        public void SotredByPosition()
        {
            work = worker.OrderBy(x => x.Position).ToList<Worker>();

        }
        public void SotredByDepart()
        {
            work = worker.OrderBy(x => x.Department).ToList<Worker>();

        }
        public void SotredBySalary()
        {
            work = worker.OrderBy(x => x.Salary).ToList<Worker>();

        }
        #endregion
        /// <summary>
        /// Изменение сотрудника
        /// </summary>
        /// <param name="id">Идентификатор, устанавливается автоматически</param>
        /// <param name="firstName">Имя работника</param>
        /// <param name="lastName">Фамилия работника</param>
        /// <param name="age">Возраст</param>
        /// <param name="pos">Должность</param>
        /// <param name="department">Департамент</param>
        /// <param name="salary">Заработная плата</param>
        public void EditWorker(int id, string firstName, string lastName, int age, string pos, string department, int salary)
        {
            worker[id].FirstName = pos;
            worker[id].LastName = pos;
            worker[id].Age = age;
            worker[id].Position = pos;
            worker[id].Department = department;
            worker[id].Salary = salary;
        }
        /// <summary>
        /// Поиск и удаления работника
        /// </summary>
        /// <param name="id">Индивидуальный номер, предписанный каждому работнику</param>
        public void DeleteWorker(int id)
        {
            for (int i = 0; i < worker.Count; i++)
            {
                if (worker[i].Id == id) worker.Remove(worker[i]);
            }
        }
        /// <summary>
        /// Удаление всех работников с указанным департаментом работы
        /// </summary>
        /// <param name="deleteId">департамент для удаления</param>
        public void DeleteDepartment(string deleteId)
        {
            int point = 0;
            for (int i = 0; i < worker.Count; i++)
            {
                if (worker[i].Department.Equals($"{deleteId}"))
                {
                    point = worker[i].Id;
                    
                    break;
                }
            }
            
            for (int i = point; i < worker.Count;)
            {
                if (worker[i].Department.Equals($"{deleteId}")) worker.Remove(worker[i]);
                //if (!worker[i].Department.Contains(deleteId)) break;
                if (!worker[i].Department.Equals(deleteId))
                {
                    break;
                }
            }
            
        }
        public void DepDel(string deleteId)
        {
            for (int i = 0; i < dep.Count; i++)
            {
                if (dep[i].DepartmentName.Equals($"{deleteId}")) dep.Remove(dep[i]);
            }
            for (int i = 0; i < worker.Count; i++)
            {
                if(worker[i].Department.Equals($"{deleteId}")) worker.Remove(worker[i]);
            }
        }
    }
}
