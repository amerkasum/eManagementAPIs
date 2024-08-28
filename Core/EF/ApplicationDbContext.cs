﻿using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers.Constants;
using static Helpers.Constants.Enumerations;

namespace Core.DatabaseContext
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Shifts>().HasData(
                new Shifts { Id = 1, Name = nameof(Enumerations.ShiftType.FIRST), TimeFrom = new DateTime(2000, 1, 1, 8, 0, 0), TimeTo = new DateTime(2000, 1, 1, 16, 0, 0), Code = ((int)Enumerations.ShiftType.FIRST).ToString() },
                new Shifts { Id = 2, Name = nameof(Enumerations.ShiftType.SECOND), TimeFrom = new DateTime(2000, 1, 1, 16, 0, 0), TimeTo = new DateTime(2000, 1, 1, 0, 0, 0), Code = ((int)Enumerations.ShiftType.SECOND).ToString() },
                new Shifts { Id = 3, Name = nameof(Enumerations.ShiftType.THIRD), TimeFrom = new DateTime(2000, 1, 1, 0, 0, 0), TimeTo = new DateTime(2000, 1, 1, 8, 0, 0), Code = ((int)Enumerations.ShiftType.THIRD).ToString() }
            );

            modelBuilder.Entity<Roles>().HasData(
                new Roles { Id = 1, Name = nameof(Enumerations.Role.ADMINISTRATOR), Code = ((int)Enumerations.Role.ADMINISTRATOR).ToString() },
                new Roles { Id = 2, Name = nameof(Enumerations.Role.EMPLOYEE), Code = ((int)Enumerations.Role.EMPLOYEE).ToString() }
            );

            modelBuilder.Entity<EventStatuses>().HasData(
                new EventStatuses { Id = 1, Name = nameof(Enumerations.EventStatus.UPCOMING), Code = ((int)Enumerations.EventStatus.UPCOMING).ToString() },
                new EventStatuses { Id = 2, Name = nameof(Enumerations.EventStatus.ONGOING), Code = ((int)Enumerations.EventStatus.ONGOING).ToString() },
                new EventStatuses { Id = 3, Name = nameof(Enumerations.EventStatus.FINISHED), Code = ((int)Enumerations.EventStatus.FINISHED).ToString() },
                new EventStatuses { Id = 4, Name = nameof(Enumerations.EventStatus.CANCELLED), Code = ((int)Enumerations.EventStatus.CANCELLED).ToString() }
            );

            modelBuilder.Entity<TaskStatuses>().HasData(
                new TaskStatuses { Id = 1, Name = nameof(Enumerations.TaskStatus.PENDING), Code = ((int)Enumerations.TaskStatus.PENDING).ToString() },
                new TaskStatuses { Id = 2, Name = nameof(Enumerations.TaskStatus.IN_PROGRESS).Replace("_", " "), Code = ((int)Enumerations.TaskStatus.IN_PROGRESS).ToString() },
                new TaskStatuses { Id = 3, Name = nameof(Enumerations.TaskStatus.FINISHED), Code = ((int)Enumerations.TaskStatus.FINISHED).ToString() },
                new TaskStatuses { Id = 4, Name = nameof(Enumerations.TaskStatus.CANCELLED), Code = ((int)Enumerations.TaskStatus.CANCELLED).ToString() }
            );

            modelBuilder.Entity<ContractTypes>().HasData(
                new ContractTypes { Id = 1, Name = nameof(ContractType.FULL_TIME).Replace("_", " "), Code = ((int)ContractType.FULL_TIME).ToString() },
                new ContractTypes { Id = 2, Name = nameof(ContractType.PART_TIME).Replace("_", " "), Code = ((int)ContractType.PART_TIME).ToString() },
                new ContractTypes { Id = 3, Name = nameof(ContractType.TEMPORARY).Replace("_", " "), Code = ((int)ContractType.TEMPORARY).ToString() },
                new ContractTypes { Id = 4, Name = nameof(ContractType.CONTRACTOR).Replace("_", " "), Code = ((int)ContractType.CONTRACTOR).ToString() },
                new ContractTypes { Id = 5, Name = nameof(ContractType.INTERNSHIP).Replace("_", " "), Code = ((int)ContractType.INTERNSHIP).ToString() },
                new ContractTypes { Id = 6, Name = nameof(ContractType.CONSULTANT).Replace("_", " "), Code = ((int)ContractType.CONSULTANT).ToString() },
                new ContractTypes { Id = 7, Name = nameof(ContractType.FIXED_TERM).Replace("_", " "), Code = ((int)ContractType.FIXED_TERM).ToString() },
                new ContractTypes { Id = 8, Name = nameof(ContractType.ZERO_HOUR).Replace("_", " "), Code = ((int)ContractType.ZERO_HOUR).ToString() },
                new ContractTypes { Id = 9, Name = nameof(ContractType.SEASONAL).Replace("_", " "), Code = ((int)ContractType.SEASONAL).ToString() },
                new ContractTypes { Id = 10, Name = nameof(ContractType.PROBATIONARY).Replace("_", " "), Code = ((int)ContractType.PROBATIONARY).ToString() },
                new ContractTypes { Id = 11, Name = nameof(ContractType.REMOTE).Replace("_", " "), Code = ((int)ContractType.REMOTE).ToString() },
                new ContractTypes { Id = 12, Name = nameof(ContractType.ON_CALL).Replace("_", " "), Code = ((int)ContractType.ON_CALL).ToString() }
            );

            modelBuilder.Entity<TaskPriorities>().HasData(
                new TaskPriorities { Id = 1, Name = nameof(TaskPriority.LOW), Code = ((int)TaskPriority.LOW).ToString() },
                new TaskPriorities { Id = 2, Name = nameof(TaskPriority.MEDIUM), Code = ((int)TaskPriority.MEDIUM).ToString() },
                new TaskPriorities { Id = 3, Name = nameof(TaskPriority.HIGH), Code = ((int)TaskPriority.HIGH).ToString() }
            );

            modelBuilder.Entity<Positions>().HasData(
                 new Positions { Id = 1, Name = nameof(JobPosition.SOFTWARE_DEVELOPER).Replace("_", " "), Code = ((int)JobPosition.SOFTWARE_DEVELOPER).ToString() },
                 new Positions { Id = 2, Name = nameof(JobPosition.DATA_SCIENTIST).Replace("_", " "), Code = ((int)JobPosition.DATA_SCIENTIST).ToString() },
                 new Positions { Id = 3, Name = nameof(JobPosition.PRODUCT_MANAGER).Replace("_", " "), Code = ((int)JobPosition.PRODUCT_MANAGER).ToString() },
                 new Positions { Id = 4, Name = nameof(JobPosition.GRAPHIC_DESIGNER).Replace("_", " "), Code = ((int)JobPosition.GRAPHIC_DESIGNER).ToString() },
                 new Positions { Id = 5, Name = nameof(JobPosition.SYSTEM_ADMINISTRATOR).Replace("_", " "), Code = ((int)JobPosition.SYSTEM_ADMINISTRATOR).ToString() },
                 new Positions { Id = 6, Name = nameof(JobPosition.MARKETING_SPECIALIST).Replace("_", " "), Code = ((int)JobPosition.MARKETING_SPECIALIST).ToString() },
                 new Positions { Id = 7, Name = nameof(JobPosition.UX_RESEARCHER).Replace("_", " "), Code = ((int)JobPosition.UX_RESEARCHER).ToString() },
                 new Positions { Id = 8, Name = nameof(JobPosition.SALES_MANAGER).Replace("_", " "), Code = ((int)JobPosition.SALES_MANAGER).ToString() },
                 new Positions { Id = 9, Name = nameof(JobPosition.BUSINESS_ANALYST).Replace("_", " "), Code = ((int)JobPosition.BUSINESS_ANALYST).ToString() },
                 new Positions { Id = 10, Name = nameof(JobPosition.NETWORK_ENGINEER).Replace("_", " "), Code = ((int)JobPosition.NETWORK_ENGINEER).ToString() },
                 new Positions { Id = 11, Name = nameof(JobPosition.DATABASE_ADMINISTRATOR).Replace("_", " "), Code = ((int)JobPosition.DATABASE_ADMINISTRATOR).ToString() },
                 new Positions { Id = 12, Name = nameof(JobPosition.FRONTEND_DEVELOPER).Replace("_", " "), Code = ((int)JobPosition.FRONTEND_DEVELOPER).ToString() },
                 new Positions { Id = 13, Name = nameof(JobPosition.BACKEND_DEVELOPER).Replace("_", " "), Code = ((int)JobPosition.BACKEND_DEVELOPER).ToString() },
                 new Positions { Id = 14, Name = nameof(JobPosition.DEVOPS_ENGINEER).Replace("_", " "), Code = ((int)JobPosition.DEVOPS_ENGINEER).ToString() },
                 new Positions { Id = 15, Name = nameof(JobPosition.QUALITY_ASSURANCE_TESTER).Replace("_", " "), Code = ((int)JobPosition.QUALITY_ASSURANCE_TESTER).ToString() },
                 new Positions { Id = 16, Name = nameof(JobPosition.TECHNICAL_SUPPORT_SPECIALIST).Replace("_", " "), Code = ((int)JobPosition.TECHNICAL_SUPPORT_SPECIALIST).ToString() },
                 new Positions { Id = 17, Name = nameof(JobPosition.HUMAN_RESOURCES_MANAGER).Replace("_", " "), Code = ((int)JobPosition.HUMAN_RESOURCES_MANAGER).ToString() },
                 new Positions { Id = 18, Name = nameof(JobPosition.CONTENT_CREATOR).Replace("_", " "), Code = ((int)JobPosition.CONTENT_CREATOR).ToString() },
                 new Positions { Id = 19, Name = nameof(JobPosition.IT_CONSULTANT).Replace("_", " "), Code = ((int)JobPosition.IT_CONSULTANT).ToString() },
                 new Positions { Id = 20, Name = nameof(JobPosition.WEB_DESIGNER).Replace("_", " "), Code = ((int)JobPosition.WEB_DESIGNER).ToString() }
            );

            modelBuilder.Entity<AbsenceTypes>().HasData(
                new AbsenceTypes { Id = 1, Name = nameof(Enumerations.AbsenceType.SICK_LEAVE).Replace("_", " "), Code = ((int)Enumerations.AbsenceType.SICK_LEAVE).ToString() },
                new AbsenceTypes { Id = 2, Name = nameof(Enumerations.AbsenceType.VACATION_LEAVE).Replace("_", " "), Code = ((int)Enumerations.AbsenceType.VACATION_LEAVE).ToString() },
                new AbsenceTypes { Id = 3, Name = nameof(Enumerations.AbsenceType.PERSONAL_LEAVE).Replace("_", " "), Code = ((int)Enumerations.AbsenceType.PERSONAL_LEAVE).ToString() },
                new AbsenceTypes { Id = 4, Name = nameof(Enumerations.AbsenceType.PARENTAL_LEAVE).Replace("_", " "), Code = ((int)Enumerations.AbsenceType.PARENTAL_LEAVE).ToString() },
                new AbsenceTypes { Id = 5, Name = nameof(Enumerations.AbsenceType.BEREAVEMENT_LEAVE).Replace("_", " "), Code = ((int)Enumerations.AbsenceType.BEREAVEMENT_LEAVE).ToString() },
                new AbsenceTypes { Id = 6, Name = nameof(Enumerations.AbsenceType.JURY_DUTY).Replace("_", " "), Code = ((int)Enumerations.AbsenceType.JURY_DUTY).ToString() },
                new AbsenceTypes { Id = 7, Name = nameof(Enumerations.AbsenceType.MILITARY_LEAVE).Replace("_", " "), Code = ((int)Enumerations.AbsenceType.MILITARY_LEAVE).ToString() },
                new AbsenceTypes { Id = 8, Name = nameof(Enumerations.AbsenceType.UNPAID_LEAVE).Replace("_", " "), Code = ((int)Enumerations.AbsenceType.UNPAID_LEAVE).ToString() },
                new AbsenceTypes { Id = 9, Name = nameof(Enumerations.AbsenceType.PUBLIC_HOLIDAY).Replace("_", " "), Code = ((int)Enumerations.AbsenceType.PUBLIC_HOLIDAY).ToString() },
                new AbsenceTypes { Id = 10, Name = nameof(Enumerations.AbsenceType.STUDY_LEAVE).Replace("_", " "), Code = ((int)Enumerations.AbsenceType.STUDY_LEAVE).ToString() },
                new AbsenceTypes { Id = 11, Name = nameof(Enumerations.AbsenceType.SABBATICAL).Replace("_", " "), Code = ((int)Enumerations.AbsenceType.SABBATICAL).ToString() },
                new AbsenceTypes { Id = 12, Name = nameof(Enumerations.AbsenceType.COMPENSATORY_LEAVE).Replace("_", " "), Code = ((int)Enumerations.AbsenceType.COMPENSATORY_LEAVE).ToString() },
                new AbsenceTypes { Id = 13, Name = nameof(Enumerations.AbsenceType.VOLUNTEER_LEAVE).Replace("_", " "), Code = ((int)Enumerations.AbsenceType.VOLUNTEER_LEAVE).ToString() },
                new AbsenceTypes { Id = 14, Name = nameof(Enumerations.AbsenceType.FAMILY_AND_MEDICAL_LEAVE).Replace("_", " "), Code = ((int)Enumerations.AbsenceType.FAMILY_AND_MEDICAL_LEAVE).ToString() },
                new AbsenceTypes { Id = 15, Name = nameof(Enumerations.AbsenceType.HALF_DAY_LEAVE).Replace("_", " "), Code = ((int)Enumerations.AbsenceType.HALF_DAY_LEAVE).ToString() },
                new AbsenceTypes { Id = 16, Name = nameof(Enumerations.AbsenceType.EMERGENCY_LEAVE).Replace("_", " "), Code = ((int)Enumerations.AbsenceType.EMERGENCY_LEAVE).ToString() },
                new AbsenceTypes { Id = 17, Name = nameof(Enumerations.AbsenceType.CASUAL_LEAVE).Replace("_", " "), Code = ((int)Enumerations.AbsenceType.CASUAL_LEAVE).ToString() },
                new AbsenceTypes { Id = 18, Name = nameof(Enumerations.AbsenceType.ADMINISTRATIVE_LEAVE).Replace("_", " "), Code = ((int)Enumerations.AbsenceType.ADMINISTRATIVE_LEAVE).ToString() },
                new AbsenceTypes { Id = 19, Name = nameof(Enumerations.AbsenceType.FLOATING_HOLIDAY).Replace("_", " "), Code = ((int)Enumerations.AbsenceType.FLOATING_HOLIDAY).ToString() },
                new AbsenceTypes { Id = 20, Name = nameof(Enumerations.AbsenceType.RELIGIOUS_LEAVE).Replace("_", " "), Code = ((int)Enumerations.AbsenceType.RELIGIOUS_LEAVE).ToString() }
            );

            modelBuilder.Entity<Countries>().HasData(
                new Countries { Id = 1, Name = "Afghanistan", Iso = "AF" },
                new Countries { Id = 2, Name = "Albania", Iso = "AL" },
                new Countries { Id = 3, Name = "Algeria", Iso = "DZ" },
                new Countries { Id = 4, Name = "Andorra", Iso = "AD" },
                new Countries { Id = 5, Name = "Angola", Iso = "AO" },
                new Countries { Id = 6, Name = "Antigua and Barbuda", Iso = "AG" },
                new Countries { Id = 7, Name = "Argentina", Iso = "AR" },
                new Countries { Id = 8, Name = "Armenia", Iso = "AM" },
                new Countries { Id = 9, Name = "Australia", Iso = "AU" },
                new Countries { Id = 10, Name = "Austria", Iso = "AT" },
                new Countries { Id = 11, Name = "Azerbaijan", Iso = "AZ" },
                new Countries { Id = 12, Name = "Bahamas", Iso = "BS" },
                new Countries { Id = 13, Name = "Bahrain", Iso = "BH" },
                new Countries { Id = 14, Name = "Bangladesh", Iso = "BD" },
                new Countries { Id = 15, Name = "Barbados", Iso = "BB" },
                new Countries { Id = 16, Name = "Belarus", Iso = "BY" },
                new Countries { Id = 17, Name = "Belgium", Iso = "BE" },
                new Countries { Id = 18, Name = "Belize", Iso = "BZ" },
                new Countries { Id = 19, Name = "Benin", Iso = "BJ" },
                new Countries { Id = 20, Name = "Bhutan", Iso = "BT" },
                new Countries { Id = 21, Name = "Bolivia", Iso = "BO" },
                new Countries { Id = 22, Name = "Bosnia and Herzegovina", Iso = "BA" },
                new Countries { Id = 23, Name = "Botswana", Iso = "BW" },
                new Countries { Id = 24, Name = "Brazil", Iso = "BR" },
                new Countries { Id = 25, Name = "Brunei Darussalam", Iso = "BN" },
                new Countries { Id = 26, Name = "Bulgaria", Iso = "BG" },
                new Countries { Id = 27, Name = "Burkina Faso", Iso = "BF" },
                new Countries { Id = 28, Name = "Burundi", Iso = "BI" },
                new Countries { Id = 29, Name = "Cabo Verde", Iso = "CV" },
                new Countries { Id = 30, Name = "Cambodia", Iso = "KH" },
                new Countries { Id = 31, Name = "Cameroon", Iso = "CM" },
                new Countries { Id = 32, Name = "Canada", Iso = "CA" },
                new Countries { Id = 33, Name = "Central African Republic", Iso = "CF" },
                new Countries { Id = 34, Name = "Chad", Iso = "TD" },
                new Countries { Id = 35, Name = "Chile", Iso = "CL" },
                new Countries { Id = 36, Name = "China", Iso = "CN" },
                new Countries { Id = 37, Name = "Colombia", Iso = "CO" },
                new Countries { Id = 38, Name = "Comoros", Iso = "KM" },
                new Countries { Id = 39, Name = "Congo", Iso = "CG" },
                new Countries { Id = 40, Name = "Congo (Democratic Republic)", Iso = "CD" },
                new Countries { Id = 41, Name = "Costa Rica", Iso = "CR" },
                new Countries { Id = 42, Name = "Croatia", Iso = "HR" },
                new Countries { Id = 43, Name = "Cuba", Iso = "CU" },
                new Countries { Id = 44, Name = "Cyprus", Iso = "CY" },
                new Countries { Id = 45, Name = "Czech Republic", Iso = "CZ" },
                new Countries { Id = 46, Name = "Denmark", Iso = "DK" },
                new Countries { Id = 47, Name = "Djibouti", Iso = "DJ" },
                new Countries { Id = 48, Name = "Dominica", Iso = "DM" },
                new Countries { Id = 49, Name = "Dominican Republic", Iso = "DO" },
                new Countries { Id = 50, Name = "Ecuador", Iso = "EC" },
                new Countries { Id = 51, Name = "Egypt", Iso = "EG" },
                new Countries { Id = 52, Name = "El Salvador", Iso = "SV" },
                new Countries { Id = 53, Name = "Equatorial Guinea", Iso = "GQ" },
                new Countries { Id = 54, Name = "Eritrea", Iso = "ER" },
                new Countries { Id = 55, Name = "Estonia", Iso = "EE" },
                new Countries { Id = 56, Name = "Eswatini", Iso = "SZ" },
                new Countries { Id = 57, Name = "Ethiopia", Iso = "ET" },
                new Countries { Id = 58, Name = "Fiji", Iso = "FJ" },
                new Countries { Id = 59, Name = "Finland", Iso = "FI" },
                new Countries { Id = 60, Name = "France", Iso = "FR" },
                new Countries { Id = 61, Name = "Gabon", Iso = "GA" },
                new Countries { Id = 62, Name = "Gambia", Iso = "GM" },
                new Countries { Id = 63, Name = "Georgia", Iso = "GE" },
                new Countries { Id = 64, Name = "Germany", Iso = "DE" },
                new Countries { Id = 65, Name = "Ghana", Iso = "GH" },
                new Countries { Id = 66, Name = "Greece", Iso = "GR" },
                new Countries { Id = 67, Name = "Grenada", Iso = "GD" },
                new Countries { Id = 68, Name = "Guatemala", Iso = "GT" },
                new Countries { Id = 69, Name = "Guinea", Iso = "GN" },
                new Countries { Id = 70, Name = "Guinea-Bissau", Iso = "GW" },
                new Countries { Id = 71, Name = "Guyana", Iso = "GY" },
                new Countries { Id = 72, Name = "Haiti", Iso = "HT" },
                new Countries { Id = 73, Name = "Honduras", Iso = "HN" },
                new Countries { Id = 74, Name = "Hungary", Iso = "HU" },
                new Countries { Id = 75, Name = "Iceland", Iso = "IS" },
                new Countries { Id = 76, Name = "India", Iso = "IN" },
                new Countries { Id = 77, Name = "Indonesia", Iso = "ID" },
                new Countries { Id = 78, Name = "Iran", Iso = "IR" },
                new Countries { Id = 79, Name = "Iraq", Iso = "IQ" },
                new Countries { Id = 80, Name = "Ireland", Iso = "IE" },
                new Countries { Id = 81, Name = "Israel", Iso = "IL" },
                new Countries { Id = 82, Name = "Italy", Iso = "IT" },
                new Countries { Id = 83, Name = "Jamaica", Iso = "JM" },
                new Countries { Id = 84, Name = "Japan", Iso = "JP" },
                new Countries { Id = 85, Name = "Jordan", Iso = "JO" },
                new Countries { Id = 86, Name = "Kazakhstan", Iso = "KZ" },
                new Countries { Id = 87, Name = "Kenya", Iso = "KE" },
                new Countries { Id = 88, Name = "Kiribati", Iso = "KI" },
                new Countries { Id = 89, Name = "Korea (North)", Iso = "KP" },
                new Countries { Id = 90, Name = "Korea (South)", Iso = "KR" },
                new Countries { Id = 91, Name = "Kuwait", Iso = "KW" },
                new Countries { Id = 92, Name = "Kyrgyzstan", Iso = "KG" },
                new Countries { Id = 93, Name = "Laos", Iso = "LA" },
                new Countries { Id = 94, Name = "Latvia", Iso = "LV" },
                new Countries { Id = 95, Name = "Lebanon", Iso = "LB" },
                new Countries { Id = 96, Name = "Lesotho", Iso = "LS" },
                new Countries { Id = 97, Name = "Liberia", Iso = "LR" },
                new Countries { Id = 98, Name = "Libya", Iso = "LY" },
                new Countries { Id = 99, Name = "Liechtenstein", Iso = "LI" },
                new Countries { Id = 100, Name = "Lithuania", Iso = "LT" },
                new Countries { Id = 101, Name = "Luxembourg", Iso = "LU" },
                new Countries { Id = 102, Name = "Madagascar", Iso = "MG" },
                new Countries { Id = 103, Name = "Malawi", Iso = "MW" },
                new Countries { Id = 104, Name = "Malaysia", Iso = "MY" },
                new Countries { Id = 105, Name = "Maldives", Iso = "MV" },
                new Countries { Id = 106, Name = "Mali", Iso = "ML" },
                new Countries { Id = 107, Name = "Malta", Iso = "MT" },
                new Countries { Id = 108, Name = "Marshall Islands", Iso = "MH" },
                new Countries { Id = 109, Name = "Mauritania", Iso = "MR" },
                new Countries { Id = 110, Name = "Mauritius", Iso = "MU" },
                new Countries { Id = 111, Name = "Mexico", Iso = "MX" },
                new Countries { Id = 112, Name = "Micronesia", Iso = "FM" },
                new Countries { Id = 113, Name = "Moldova", Iso = "MD" },
                new Countries { Id = 114, Name = "Monaco", Iso = "MC" },
                new Countries { Id = 115, Name = "Mongolia", Iso = "MN" },
                new Countries { Id = 116, Name = "Montenegro", Iso = "ME" },
                new Countries { Id = 117, Name = "Morocco", Iso = "MA" },
                new Countries { Id = 118, Name = "Mozambique", Iso = "MZ" },
                new Countries { Id = 119, Name = "Myanmar", Iso = "MM" },
                new Countries { Id = 120, Name = "Namibia", Iso = "NA" },
                new Countries { Id = 121, Name = "Nauru", Iso = "NR" },
                new Countries { Id = 122, Name = "Nepal", Iso = "NP" },
                new Countries { Id = 123, Name = "Netherlands", Iso = "NL" },
                new Countries { Id = 124, Name = "New Zealand", Iso = "NZ" },
                new Countries { Id = 125, Name = "Nicaragua", Iso = "NI" },
                new Countries { Id = 126, Name = "Niger", Iso = "NE" },
                new Countries { Id = 127, Name = "Nigeria", Iso = "NG" },
                new Countries { Id = 128, Name = "North Macedonia", Iso = "MK" },
                new Countries { Id = 129, Name = "Norway", Iso = "NO" },
                new Countries { Id = 130, Name = "Oman", Iso = "OM" },
                new Countries { Id = 131, Name = "Pakistan", Iso = "PK" },
                new Countries { Id = 132, Name = "Palau", Iso = "PW" },
                new Countries { Id = 133, Name = "Panama", Iso = "PA" },
                new Countries { Id = 134, Name = "Papua New Guinea", Iso = "PG" },
                new Countries { Id = 135, Name = "Paraguay", Iso = "PY" },
                new Countries { Id = 136, Name = "Peru", Iso = "PE" },
                new Countries { Id = 137, Name = "Philippines", Iso = "PH" },
                new Countries { Id = 138, Name = "Poland", Iso = "PL" },
                new Countries { Id = 139, Name = "Portugal", Iso = "PT" },
                new Countries { Id = 140, Name = "Qatar", Iso = "QA" },
                new Countries { Id = 141, Name = "Romania", Iso = "RO" },
                new Countries { Id = 142, Name = "Russia", Iso = "RU" },
                new Countries { Id = 143, Name = "Rwanda", Iso = "RW" },
                new Countries { Id = 144, Name = "Saint Kitts and Nevis", Iso = "KN" },
                new Countries { Id = 145, Name = "Saint Lucia", Iso = "LC" },
                new Countries { Id = 146, Name = "Saint Vincent and the Grenadines", Iso = "VC" },
                new Countries { Id = 147, Name = "Samoa", Iso = "WS" },
                new Countries { Id = 148, Name = "San Marino", Iso = "SM" },
                new Countries { Id = 149, Name = "Sao Tome and Principe", Iso = "ST" },
                new Countries { Id = 150, Name = "Saudi Arabia", Iso = "SA" },
                new Countries { Id = 151, Name = "Senegal", Iso = "SN" },
                new Countries { Id = 152, Name = "Serbia", Iso = "RS" },
                new Countries { Id = 153, Name = "Seychelles", Iso = "SC" },
                new Countries { Id = 154, Name = "Sierra Leone", Iso = "SL" },
                new Countries { Id = 155, Name = "Singapore", Iso = "SG" },
                new Countries { Id = 156, Name = "Slovakia", Iso = "SK" },
                new Countries { Id = 157, Name = "Slovenia", Iso = "SI" },
                new Countries { Id = 158, Name = "Solomon Islands", Iso = "SB" },
                new Countries { Id = 159, Name = "Somalia", Iso = "SO" },
                new Countries { Id = 160, Name = "South Africa", Iso = "ZA" },
                new Countries { Id = 161, Name = "South Sudan", Iso = "SS" },
                new Countries { Id = 162, Name = "Spain", Iso = "ES" },
                new Countries { Id = 163, Name = "Sri Lanka", Iso = "LK" },
                new Countries { Id = 164, Name = "Sudan", Iso = "SD" },
                new Countries { Id = 165, Name = "Suriname", Iso = "SR" },
                new Countries { Id = 166, Name = "Sweden", Iso = "SE" },
                new Countries { Id = 167, Name = "Switzerland", Iso = "CH" },
                new Countries { Id = 168, Name = "Syria", Iso = "SY" },
                new Countries { Id = 169, Name = "Taiwan", Iso = "TW" },
                new Countries { Id = 170, Name = "Tajikistan", Iso = "TJ" },
                new Countries { Id = 171, Name = "Tanzania", Iso = "TZ" },
                new Countries { Id = 172, Name = "Thailand", Iso = "TH" },
                new Countries { Id = 173, Name = "Timor-Leste", Iso = "TL" },
                new Countries { Id = 174, Name = "Togo", Iso = "TG" },
                new Countries { Id = 175, Name = "Tonga", Iso = "TO" },
                new Countries { Id = 176, Name = "Trinidad and Tobago", Iso = "TT" },
                new Countries { Id = 177, Name = "Tunisia", Iso = "TN" },
                new Countries { Id = 178, Name = "Turkey", Iso = "TR" },
                new Countries { Id = 179, Name = "Turkmenistan", Iso = "TM" },
                new Countries { Id = 180, Name = "Tuvalu", Iso = "TV" },
                new Countries { Id = 181, Name = "Uganda", Iso = "UG" },
                new Countries { Id = 182, Name = "Ukraine", Iso = "UA" },
                new Countries { Id = 183, Name = "United Arab Emirates", Iso = "AE" },
                new Countries { Id = 184, Name = "United Kingdom", Iso = "GB" },
                new Countries { Id = 185, Name = "United States", Iso = "US" },
                new Countries { Id = 186, Name = "Uruguay", Iso = "UY" },
                new Countries { Id = 187, Name = "Uzbekistan", Iso = "UZ" },
                new Countries { Id = 188, Name = "Vanuatu", Iso = "VU" },
                new Countries { Id = 189, Name = "Vatican City", Iso = "VA" },
                new Countries { Id = 190, Name = "Venezuela", Iso = "VE" },
                new Countries { Id = 191, Name = "Vietnam", Iso = "VN" },
                new Countries { Id = 192, Name = "Yemen", Iso = "YE" },
                new Countries { Id = 193, Name = "Zambia", Iso = "ZM" },
                new Countries { Id = 194, Name = "Zimbabwe", Iso = "ZW" }
            );
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added))
            {
                entry.Property("CreatedDateTime").CurrentValue = DateTime.Now;
                entry.Property("IsDeleted").CurrentValue = false;
            }

            return base.SaveChanges();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer("Server=.;Database=RS2_ApplicationDb;MultipleActiveresultsets=True;Trusted_Connection=True");
        //}

        public DbSet<Users> Users { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<UserLogger> UserLogger { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<WorkingDays> WorkingDays { get; set; }
        public DbSet<Shifts> Shifts { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<EventStatuses> EventStatuses { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TaskStatuses> TaskStatuses { get; set; }
        public DbSet<UserTasks> UserTasks { get; set; }
        public DbSet<WorkingAbsences> WorkingAbsences { get; set; }
        public DbSet<AbsenceTypes> AbsenceTypes { get; set; }
        public DbSet<UserResidence> UserResidence { get; set; }
        public DbSet<TaskReview> TaskReviews { get; set; }
        public DbSet<Positions> Positions { get; set; }
        public DbSet<UserPositions> UserPositions { get; set; }
        public DbSet<ContractTypes> ContractTypes { get; set; }
        public DbSet<TaskPriorities> TaskPriorities { get; set; }



    }
}
