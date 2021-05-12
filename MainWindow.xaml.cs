using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace WorkersTemplate
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository rep = new Repository();
        ObservableCollection<Worker> db = new ObservableCollection<Worker>();
        Worker workers = new Worker();
        Random rand = new Random();
        int join = 1;
        public MainWindow()
        {
            InitializeComponent();
            rep.JsonBack(@"_JsonWorker.json", @"_JsonDep.json");
            ListView.ItemsSource = rep.worker;
            this.Title = $"Всего сотрудников: {rep.worker.Count - 1}";

            cbDeps.ItemsSource = rep.dep;
            cbDeps.SelectedIndex = -1;

        }
        int kak = 6;
        /// <summary>
        /// Подгружает сотрудников из json файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddWorkersAuto(object sender, RoutedEventArgs e)
        {

            rep.AddWorkers(kak);
            kak++;
        }
        /// <summary>
        /// Добавление нового департамента и сотрудников в нем автоматически
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            join++;
            rep.AddWorkers(kak);
            kak++;
            ListView.ItemsSource = rep.worker;

            this.Title = $"Всего сотрудников: {rep.worker.Count}";
        }
        /// <summary>
        /// Разветвление и добавление сотрудников в новый департамент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepCopytbtn_Click(object sender, RoutedEventArgs e)
        {
            if (NewDepbtn.IsInitialized) join = kak;
            join = join * 10 + kak;
            rep.AddWorkers(join);
            ListView.ItemsSource = rep.worker;


            this.Title = $"Всего сотрудников: {rep.worker.Count}";
        }
        /// <summary>
        /// Кнопка изменения сотрудника, в ручную
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (boxId.Text == "")
            {
                MessageBox.Show("Вы не выбрали пользователя для редактирования!", "Ошибка!");
            }
            else
            {

                int workerId = Convert.ToInt32(boxId.Text);
                string workerFirstName = boxName.Text;
                string workerLastName = boxLastName.Text;
                int age = int.Parse(boxAge.Text);
                string pos = boxPosition.Text;
                string dep = boxDep.Text;
                int sal = int.Parse(boxSalary.Text);
                rep.EditWorker(workerId, workerFirstName, workerLastName, age, pos, dep, sal);
                ListView.ItemsSource = rep.worker;
            }
        }
        /// <summary>
        /// Сохранение всех данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            rep.JsonTestConvert();
        }
        /// <summary>
        /// Удаление сотрудника по его уникальному идентификатору
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dltBtn_Click(object sender, RoutedEventArgs e)
        {
            if (boxId.Text == "")
            {
                MessageBox.Show("Вы не выбрали пользователя для удаления!", "Ошибка!");
            }
            else
            {

                int workerId = Convert.ToInt32(boxId.Text); // Идентификатор работника, который отображен в поле ID для его поиска и удаления

                this.Title = $"Всего сотрудников: {rep.worker.Count - 2}";
                rep.DeleteWorker(workerId);
            }
        }
        /// <summary>
        /// Удаление департамента рабочих
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dltDep_Click(object sender, RoutedEventArgs e)
        {
            if (cbDeps.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали департамент для удаления!", "Ошибка!");
            }
            else
            {
                string what = cbDeps.Text;
                DialogResult dialogResult = MessageBox.Show("Вы уверены что хотите удалить департамент сотрудников?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    rep.DeleteDepartment(what);
                    this.Title = $"Всего сотрудников: {rep.worker.Count}";
                    ListView.ItemsSource = rep.worker;
                    cbDeps.SelectedIndex = -1;
                    rep.DepDel(what);
                }
            }
        }

        private void cbDeps_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbDeps.SelectedIndex != -1) ListView.ItemsSource = rep.worker.Where(find);

        }
        private bool find(Worker arg)
        {
            return arg.Department == (cbDeps.SelectedItem as Department).DepartmentName;

        }

        #region Сортировка
        private void headerId(object sender, RoutedEventArgs e)
        {
            rep.SotredById();
            ListView.ItemsSource = rep.work;
        }

        private void headerName(object sender, RoutedEventArgs e)
        {
            rep.SotredByName();
            ListView.ItemsSource = rep.work;
        }

        private void headerAge(object sender, RoutedEventArgs e)
        {
            rep.SotredByAge();
            ListView.ItemsSource = rep.work;
        }

        private void headerSur(object sender, RoutedEventArgs e)
        {
            rep.SotredByLastName();
            ListView.ItemsSource = rep.work;
        }

        private void headerPos(object sender, RoutedEventArgs e)
        {
            rep.SotredByPosition();
            ListView.ItemsSource = rep.work;
        }

        private void headerDep(object sender, RoutedEventArgs e)
        {
            rep.SotredByDepart();
            ListView.ItemsSource = rep.work;
        }

        private void headerSal(object sender, RoutedEventArgs e)
        {
            rep.SotredBySalary();
            ListView.ItemsSource = rep.work;
        }
        #endregion
    }
}
