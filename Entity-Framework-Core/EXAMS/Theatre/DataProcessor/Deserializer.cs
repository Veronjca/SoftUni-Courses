namespace Theatre.DataProcessor
{
    using AutoMapper;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            List<PlayDto> playDtos = new List<PlayDto>();
            XmlRootAttribute playsRoot = new XmlRootAttribute();
            playsRoot.ElementName = "Plays";

            XmlSerializer serializer = new XmlSerializer(typeof(List<PlayDto>), playsRoot);

            using (StringReader reader = new StringReader(xmlString))
            {
                playDtos = (List<PlayDto>)serializer.Deserialize(reader);
            }

            IMapper mapper = CreateMapper();
            List<Play> plays = new List<Play>();
            StringBuilder output = new StringBuilder();

            foreach (var playDto in playDtos)
            {
                TimeSpan duration = TimeSpan.ParseExact(playDto.Duration, "c", CultureInfo.InvariantCulture);
                bool isGenreValid = Enum.TryParse<Genre>(playDto.Genre, out _);

                if (!IsValid(playDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }
                else if(duration.TotalMinutes < 60)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }else if(!isGenreValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Play currentPlay = mapper.Map<Play>(playDto);
                plays.Add(currentPlay);
                output.AppendLine(string.Format(SuccessfulImportPlay, playDto.Title, playDto.Genre.ToString(), playDto.Rating));
            }
          

            context.AddRange(plays);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            List<CastDto> castDtos = new List<CastDto>();
            XmlRootAttribute castsRoot = new XmlRootAttribute();
            castsRoot.ElementName = "Casts";

            XmlSerializer serializer = new XmlSerializer(typeof(List<CastDto>), castsRoot);

            using (StringReader reader = new StringReader(xmlString))
            {
                castDtos = (List<CastDto>)serializer.Deserialize(reader);
            }

            List<Cast> casts = new List<Cast>();
            StringBuilder output = new StringBuilder();
            IMapper mapper = CreateMapper();

            foreach (var castDto in castDtos)
            {
                if(!IsValid(castDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Cast currentCast = mapper.Map<Cast>(castDto);
                casts.Add(currentCast);
                output.AppendLine(string.Format(SuccessfulImportActor, currentCast.FullName, $"{(currentCast.IsMainCharacter ? "main" : "lesser")}"));
            }

            context.AddRange(casts);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            List<TheatreDto> theatreDtos = JsonConvert.DeserializeObject<List<TheatreDto>>(jsonString);

            List<Theatre> theatres = new List<Theatre>();
            StringBuilder output = new StringBuilder();
            IMapper mapper = CreateMapper();

            foreach (var theatreDto in theatreDtos)
            {
                List<Ticket> validTickets = new List<Ticket>();

                if(!IsValid(theatreDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var ticket in theatreDto.Tickets)
                {
                    if(!IsValid(ticket))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket currentTicket = new Ticket();
                    currentTicket = mapper.Map<Ticket>(ticket);
                    validTickets.Add(currentTicket);
                }

                Theatre currentTheatre = new Theatre();
                currentTheatre = mapper.Map<Theatre>(theatreDto);
                currentTheatre.Tickets = validTickets;
                theatres.Add(currentTheatre);
                output.AppendLine(string.Format(SuccessfulImportTheatre, currentTheatre.Name, currentTheatre.Tickets.Count));
            }

            context.AddRange(theatres);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }

        public static IMapper CreateMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TheatreProfile>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
