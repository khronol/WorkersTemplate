using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersTemplate
{
    class Department
    {
        private string departmentName;
        private int counter;

        public string DepartmentName { get { return this.departmentName; } set { this.departmentName = value; } }
        public int Counter { get { return this.counter; } }
        public Department()
        {
        }
        public Department(string DepartmentName, int Counter)
        {
            this.departmentName = DepartmentName;
            this.counter = Counter;
        }
        public override string ToString()
        {
            return $"{departmentName}";
        }
    }
}
