using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace Task_2
{
    public partial class MainWindow
    {
        private readonly List<BuildingProject> _projects = new List<BuildingProject>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddProjectButton_Click(object sender, RoutedEventArgs e)
        {

            DateTime startDate, plannedEndDate;
            double squareMeters;
            
            try
            {
                squareMeters = double.Parse(SquareMetersTextBox.Text);
                startDate = DateTime.ParseExact(StartDateTextBox.Text, "ddMMyyyy HH:mm:ss", CultureInfo.InvariantCulture);
                plannedEndDate = DateTime.ParseExact(PlannedEndDateTextBox.Text, "ddMMyyyy HH:mm:ss", CultureInfo.InvariantCulture);
                
            }
            catch (FormatException)
            {
                MessageBox.Show("Неправильне введення. Будь ласка, введіть правильні значення.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var project = new BuildingProject
            {
                CompanyName = CompanyNameTextBox.Text,
                ProjectName = ProjectNameTextBox.Text,
                SquareMeters = squareMeters,
                StartDate = startDate,
                PlannedEndDate = plannedEndDate,
                Status = StatusComboBox.Text
            };

            _projects.Add(project);

            MessageBox.Show("Проєкт успішно додано.");
        }

        private void ShowAllProjectsButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayProjects(_projects);
        }

        private void ShowQ4ProjectsButton_Click(object sender, RoutedEventArgs e)
        {
            var currentDate = DateTime.Now;
            var q4Projects = _projects.Where(p =>
                p.Status == "Будується" &&
                p.PlannedEndDate.Year == currentDate.Year &&
                p.PlannedEndDate.Month >= 10 && p.PlannedEndDate.Month <= 12).ToList();
            
            DisplayProjects(q4Projects);
            MessageBox.Show(string.Join(", ", q4Projects.Select(project => project.ProjectName)));
        }

        private void ShowYearEndProjectsButton_Click(object sender, RoutedEventArgs e)
        {
            var currentDate = DateTime.Now;
            var yearEndProjects = _projects.Where(p =>
                p.PlannedEndDate.Year == currentDate.Year).ToList();
            
            var count = yearEndProjects.Count;
            var totalSquareMeters = yearEndProjects.Sum(p => p.SquareMeters);
            var message = $"Кількість проектів: {count}\nЗагальна площа житла: {totalSquareMeters} м²";
            
            DisplayProjects(yearEndProjects);
            MessageBox.Show(message, "Проекти наприкінці року\"");
        }

        private void ShowMinTermProjectButton_Click(object sender, RoutedEventArgs e)
        {
            if (_projects.Count == 0)
            {
                MessageBox.Show("Проєктів немає.");
                return;
            }

            var minTermProject = new List<BuildingProject> { _projects.OrderBy(p => (p.PlannedEndDate - p.StartDate).TotalDays).First() };
            DisplayProjects(minTermProject);
            // MessageBox.Show($"Проєкт з найкоротшим терміном будівництва\n{minTermProject.ProjectName} - {minTermProject.Status}\nТермін будівництва: {(minTermProject.PlannedEndDate - minTermProject.StartDate).TotalDays} днів");
        }

        private void ShowUnfulfilledCompaniesButton_Click(object sender, RoutedEventArgs e)
        {
            var currentDate = DateTime.Now;
            var unfulfilledCompanies = _projects.Where(p =>
                p.Status == "Будується" &&
                (currentDate - p.PlannedEndDate).TotalDays > 180).ToList();

            if (!unfulfilledCompanies.Any())
            {
                MessageBox.Show("Жодна компанія не має невиконаних зобов'язань.");
            }
            else
            {
                DisplayProjects(unfulfilledCompanies);
            }

        }

        private void DisplayProjects(List<BuildingProject> projectList)
        {
            ProjectsListBox.Items.Clear();
            foreach (var project in projectList)
            {
                ProjectsListBox.Items.Add($"{project.CompanyName} - {project.ProjectName}, " +
                                          $"площа {project.SquareMeters} м², " +
                                          $"початок будівництва {project.StartDate}, " +
                                          $"закінчення будівництва {project.PlannedEndDate}, " +
                                          $"статус: {project.Status.ToLower()}, " +
                                          $"{(project.PlannedEndDate - project.StartDate).Days} днів на будівництво");
            }
        }
    }
}

internal struct BuildingProject
{
    public string CompanyName;
    public string ProjectName;
    public double SquareMeters;
    public DateTime StartDate;
    public DateTime PlannedEndDate;
    public string Status;
}