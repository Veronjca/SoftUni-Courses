namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            List<ProjectDto> projectDtos = new List<ProjectDto>();
            XmlRootAttribute projectsRoot = new XmlRootAttribute();
            projectsRoot.ElementName = "Projects";

            XmlSerializer serializer = new XmlSerializer(typeof(List<ProjectDto>), projectsRoot);

            using (StringReader reader = new StringReader(xmlString))
            {
                projectDtos = (List<ProjectDto>)serializer.Deserialize(reader);
            }

            List<Project> projects = new List<Project>();
            StringBuilder output = new StringBuilder();
            IMapper mapper = CreateMapper();

            foreach (var projectDto in projectDtos)
            {
                if (!IsValid(projectDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                bool isProjectOpenDateValid = DateTime.TryParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);

                bool isProjectDueDateValid = DateTime.TryParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);

                if(projectDto.DueDate == "" || projectDto.DueDate is null)
                {
                    projectDto.DueDate = null;
                    isProjectDueDateValid = true;
                }

                if (!isProjectOpenDateValid || !isProjectDueDateValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                List<Task> validTasks = new List<Task>();

                foreach (var task in projectDto.Tasks)
                {
                    if (!IsValid(task))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isTaskOpenDateValid = DateTime.TryParseExact(task.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);

                    bool isTaskDueDateValid = DateTime.TryParseExact(task.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);

                    if(!isTaskOpenDateValid || !isTaskDueDateValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isExecutionTypeValid = Enum.TryParse<ExecutionType>(task.ExecutionType.ToString(), out _);
                    bool isLabelTypeValid = Enum.TryParse<ExecutionType>(task.LabelType.ToString(), out _);

                    if (!isExecutionTypeValid || !isLabelTypeValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }                  

                    DateTime taskOpenDate = DateTime.ParseExact(task.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);

                    DateTime taskDueDate = DateTime.ParseExact(task.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);

                    DateTime projectOpenDate = DateTime.ParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);

                    if (projectDto.DueDate != null)
                    {
                        DateTime projectDueDate = DateTime.ParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);

                        int isTaskOpenDateBeforeProjectOpenDate = DateTime.Compare(taskOpenDate, projectOpenDate);
                        int isTaskDueDateAfterProjectDueDate = DateTime.Compare(projectDueDate, taskDueDate);

                        if (isTaskDueDateAfterProjectDueDate < 0 || isTaskOpenDateBeforeProjectOpenDate < 0)
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }
                    }
                    else
                    {
                        int isTaskOpenDateBeforeProjectOpenDate = DateTime.Compare(taskOpenDate, projectOpenDate);
                        if (isTaskOpenDateBeforeProjectOpenDate < 0)
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }
                    }
                    
                    Task currentTask = mapper.Map<Task>(task);
                    validTasks.Add(currentTask);
                }

                Project currentProject = mapper.Map<Project>(projectDto);
                currentProject.Tasks = validTasks;
                projects.Add(currentProject);
                output.AppendLine(string.Format(SuccessfullyImportedProject, currentProject.Name, currentProject.Tasks.Count));
            }

            context.AddRange(projects);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            List<EmployeeDto> employeeDtos = JsonConvert.DeserializeObject<List<EmployeeDto>>(jsonString);

            List<Employee> employees = new List<Employee>();
            List<int> existingTaskIds = context.Tasks
                .Select(t => t.Id)
                .ToList();

            StringBuilder output = new StringBuilder();
            IMapper mapper = CreateMapper();

            foreach (var employeeDto in employeeDtos)
            {
                if (!IsValid(employeeDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if(!employeeDto.Username.All(l => Char.IsLetter(l) || Char.IsDigit(l) || Char.IsUpper(l)))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (!employeeDto.Username.All(l => Char.IsLetter(l) || Char.IsDigit(l) || Char.IsLower(l)))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                List<EmployeeTask> tasks = new List<EmployeeTask>();
                Employee currentEmployee = mapper.Map<Employee>(employeeDto);

                foreach (var task in employeeDto.Tasks.Distinct())
                {
                    if(!existingTaskIds.Contains(task))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    EmployeeTask currentTask = new EmployeeTask();
                    currentTask.EmployeeId = currentEmployee.Id;
                    currentTask.TaskId = task;
                    tasks.Add(currentTask);
                }


                currentEmployee.EmployeesTasks = tasks;
                employees.Add(currentEmployee);
                output.AppendLine(string.Format(SuccessfullyImportedEmployee, currentEmployee.Username, currentEmployee.EmployeesTasks.Count));
            }

            context.AddRange(employees);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        public static IMapper CreateMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TeisterMaskProfile>();
                cfg.CreateMissingTypeMaps = true;
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
