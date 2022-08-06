namespace Footballers.DataProcessor
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
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            List<CoachDto> coachDtos = new List<CoachDto>();
            XmlRootAttribute coachesRoot = new XmlRootAttribute();
            coachesRoot.ElementName = "Coaches";

            XmlSerializer serializer = new XmlSerializer(typeof(List<CoachDto>), coachesRoot);

            using (StringReader reader = new StringReader(xmlString))
            {
                coachDtos = (List<CoachDto>)serializer.Deserialize(reader);
            }

            List<Coach> coaches = new List<Coach>();
            StringBuilder output = new StringBuilder();
            IMapper mapper = CreateMapper();

            foreach (var coachDto in coachDtos)
            {
                if (!IsValid(coachDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (String.IsNullOrEmpty(coachDto.Nationality))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                List<Footballer> validFootballers = new List<Footballer>();

                foreach (var footballer in coachDto.Footballers)
                {
                    if (!IsValid(footballer))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isContractStartDateValid = DateTime.TryParseExact(footballer.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);

                    bool isContractEndDateValid = DateTime.TryParseExact(footballer.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);

                    if(!isContractStartDateValid || !isContractEndDateValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime contractStartDate = DateTime.ParseExact(footballer.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
                    DateTime contractEndDate = DateTime.ParseExact(footballer.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);

                    if (contractStartDate > contractEndDate)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isPositionTypeValid = Enum.TryParse<PositionType>(footballer.PositionType.ToString(), out _);
                    bool isBestSkillTypeValid = Enum.TryParse<PositionType>(footballer.BestSkillType.ToString(), out _);

                    if(!isBestSkillTypeValid || !isPositionTypeValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Footballer currentFootballer = new Footballer();
                    currentFootballer.Name = footballer.Name;
                    currentFootballer.PositionType = (PositionType)footballer.PositionType;
                    currentFootballer.BestSkillType = (BestSkillType)footballer.BestSkillType;
                    currentFootballer.ContractEndDate = contractEndDate;
                    currentFootballer.ContractStartDate = contractStartDate;
                    validFootballers.Add(currentFootballer);
                }

                Coach currentCoach = new Coach();
                currentCoach.Name = coachDto.Name;
                currentCoach.Nationality = coachDto.Nationality;
                currentCoach.Footballers = validFootballers;
                coaches.Add(currentCoach);
                output.AppendLine(string.Format(SuccessfullyImportedCoach, currentCoach.Name, currentCoach.Footballers.Count));
            }

            context.AddRange(coaches);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            List<TeamDto> teamDtos = JsonConvert.DeserializeObject<List<TeamDto>>(jsonString);
            List<Team> teams = new List<Team>();
            StringBuilder output = new StringBuilder();

            List<int> existingFootballers = context.Footballers
                .Select(f => f.Id)
                .ToList();

            IMapper mapper = CreateMapper();

            foreach (var teamDto in teamDtos)
            {
                if (!IsValid(teamDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if(teamDto.Trophies <= 0)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                List<TeamFootballer> validFootballers = new List<TeamFootballer>();
                Team team = mapper.Map<Team>(teamDto);

                foreach (var footballer in teamDto.Footballers.Distinct())
                {
                    if (!existingFootballers.Contains(footballer))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    TeamFootballer currentTeamFootballer = new TeamFootballer();
                    currentTeamFootballer.FootballerId = footballer;
                    currentTeamFootballer.TeamId = team.Id;

                    validFootballers.Add(currentTeamFootballer);
                }

                team.TeamsFootballers = validFootballers;
                teams.Add(team);
                output.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
            }

            context.AddRange(teams);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        public static IMapper CreateMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<FootballersProfile>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
