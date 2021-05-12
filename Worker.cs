using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersTemplate
{
    class Worker
    {
        Department dep = new Department();
        #region Конструкторы

        public Worker()
        {

        }

        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="FirstName">Имя</param>
        /// <param name="LastName">Фамилия</param>
        /// <param name="Position">Должность</param>
        /// <param name="Department">Отдел</param>
        /// <param name="Salary">Оплата труда</param>
        public Worker(int Id, string FirstName, string LastName, int Age, string Position, string Department, int Salary)
        {
            this.id = Id;
            this.firstName = FirstName;
            this.lastName = LastName;
            this.age = Age;
            this.department = Department;
            this.salary = Salary;
            this.position = Position;
        }

        #endregion

        #region Методы
        public string Print() // Метод вывода на экран данных
        {
            return $"{this.id,3} {this.firstName,8} {this.lastName,7} {this.age,12} {this.position,12} {this.salary,10}_руб {this.department,10} {this.projects,15}";
        }

        #endregion

        #region Свойства

        /// <summary>
        /// Номер сотрудника
        /// </summary>
        public int Id { get { return this.id; } set { this.id = value; } }
        /// <summary>
        /// Количество проектов
        /// </summary>
        public int Projects { get { return this.projects; } set { this.projects = value; } }


        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get { return this.firstName; } set { this.firstName = value; } }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get { return this.lastName; } set { this.lastName = value; } }

        /// <summary>
        /// Уникальный номер
        /// </summary>
        public int Age { get { return this.age; } set { this.age = value; } }

        /// <summary>
        /// Должность
        /// </summary>
        public string Position { get { return this.position; } set { this.position = value; } }

        /// <summary>
        /// Отдел
        /// </summary>
        public string Department { get { return this.department; } set { this.department = value; } }

        /// <summary>
        /// Оплата труда
        /// </summary>
        public int Salary { get { return this.salary; } set { this.salary = value; } }


        #endregion

        #region Поля


        private int id;

        private int projects;

        /// <summary>
        /// Поле "Имя"
        /// </summary>
        private string firstName;

        /// <summary>
        /// Поле "Фамилия"
        /// </summary>
        private string lastName;

        /// <summary>
        /// Уникальный номер
        /// </summary>
        private int age;


        /// <summary>
        /// Поле "Должность"
        /// </summary>
        private string position;

        /// <summary>
        /// Поле "Отдел"
        /// </summary>
        private string department;

        /// <summary>
        /// Поле "Оплата труда"
        /// </summary>
        private int salary;

        #endregion

        public override string ToString()
        {
            return $"{department}";
        }
    }
}
