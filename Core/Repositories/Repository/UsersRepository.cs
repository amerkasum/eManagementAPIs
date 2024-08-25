using Core.DatabaseContext;
using Core.Repositories.IRepository;
using Helpers.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Update;
using Models.Entities;
using Models.Entities.Dtos;
using Models.Entities.Dtos.Desktop;
using Models.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Helpers.Constants.Enumerations;

namespace Core.Repositories.Repository
{
    public class UsersRepository : Repository<Users>, IUsersRepository
    {
        public UsersRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Users GetByFirstName(string name)
        {
            return _context.Users.FirstOrDefault(x => x.FirstName.Equals(name));
        }

        public Users GetByLastName(string name)
        {
            return _context.Users.FirstOrDefault(x => x.LastName.Equals(name));
        }

        public bool DoesEmailAlreadyExist(string email)
        {
            return _context.Users.Where(x => !x.IsDeleted && x.IsActive).Any(x => x.Email == email);
        }

        public Users GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        public Users GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }

        public IEnumerable<UsersDto> GetUsers(string fullName) {
            
            var workingAbsences = _context.WorkingAbsences.Include(x => x.AbsenceType)
                .Where(x => !x.IsDeleted && x.StartDate.Date >= DateTime.Now.Date).ToList();

            List<PositionsDto> positions = _context.UserPositions.Include(x => x.Position).Where(x => !x.IsDeleted).Select(x => new PositionsDto {
                Id = x.Position.Id,
                UserId = x.UserId,
                Code = x.Position.Code,
                Name = x.Position.Name
            }).ToList();

            List<UsersDto> results = _context.Users
              .Where(x => fullName == null || x.FullName.ToUpper() == fullName.ToUpper() && !x.IsDeleted)
              .AsEnumerable()  // Switch to in-memory processing
              .Select(x => {
                  var position = positions.FirstOrDefault(y => y.UserId == x.Id);
                  var absence = workingAbsences.FirstOrDefault(y => y.UserId == x.Id);
             
                  return new UsersDto
                  {
                      FullName = x.FullName,
                      Id = x.Id,
                      Email = x.Email,
                      ImageUrl = x.ImageUrl ?? "assets/user.jpg",
                      PhoneNumber = x.PhoneNumber,
                      JobPositionCode = position?.Code ?? "0",
                      JobPositionName = position != null ? System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(position.Name.ToLower()) : "Unknown",
                      Availability = absence?.AbsenceType?.Name ?? "AVAILABLE"
                  };
              }).ToList();

            return results;
        }

        public UserProfileDto GetUserProfileDtoByUserId(int userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);

            var position = _context.UserPositions.Include(x => x.Position).FirstOrDefault(x => !x.IsDeleted && x.UserId == userId);
            var residence = _context.UserResidence.Include(x => x.City).FirstOrDefault(x => x.UserId == userId).City.Name;

            var availability = _context.WorkingAbsences.Include(x => x.AbsenceType)
                .FirstOrDefault(x => !x.IsDeleted && x.StartDate.Date >= DateTime.Now.Date);

            UserProfileDto result = new UserProfileDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                ImageUrl = user.ImageUrl ?? "assets/user.jpg",
                About = user.About ?? "No data.",
                DateOfBirth = user.DateOfBirth,
                JobPosition = position != null ? System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(position.Position.Name.ToLower()) : "Unknown",
                Residence = residence,
                Availability = availability?.AbsenceType?.Name ?? "Available",
            };
            return result;
        }

        public List<UsersDesktopDto> GetUsersDesktop()
        {
            var workingAbsences = _context.WorkingAbsences.Include(x => x.AbsenceType)
                .Where(x => !x.IsDeleted && x.StartDate.Date >= DateTime.Now.Date).ToList();

            var userPositions = _context.UserPositions
              .Include(x => x.Position)
              .Where(x => !x.IsDeleted)
              .ToList();

            List<PositionsDto> positions = userPositions.Select(x => new PositionsDto
            {
                Id = x.Position.Id,
                UserId = x.UserId,
                Code = x.Position.Code,
                Name = x.Position.Name,
                ContractType = Enum.GetName(typeof(ContractType), int.Parse(x.ContractTypeCode)),
                ContractExpireDate = x.ContractExpireDate
            }).ToList();

            var result = _context.Users.Where(x => !x.IsDeleted).AsEnumerable().Select(x =>
            {

                var position = positions.FirstOrDefault(y => y.UserId == x.Id);
                return new UsersDesktopDto
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    ImageUrl = x.ImageUrl ?? "assets/user.jpg",
                    Position = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(position.Name.ToLower()),
                    ContractType = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(position.ContractType.ToLower()),
                    ContractExpireDate = position.ContractExpireDate ?? null,
                    Availability = "Available"
                };
            }).ToList();

            return result;
        }

        public List<SelectListHelper> GetSelectLists()
        {
            var result = _context.Users.Select(x => new SelectListHelper
            {
                Id = x.Id,
                Name = x.FullName,
                Code = "none"
            }).ToList();

            return result;
        }
    }
}
