using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Constants
{
    public class Enumerations
    {
        public enum AccessType
        {
            DEVELOPMENT = 1,
            PRODUCTION = 2
        };

        public enum Role
        {
            ADMINISTRATOR = 1,
            EMPLOYEE
        }

        public enum ShiftType
        {
            FIRST = 1,
            SECOND,
            THIRD
        }

        public enum EventStatus
        {
            UPCOMING = 1, //event is in future
            ONGOING, //start time of event is in past, but end date is in future
            FINISHED, //start and end date are in the past
            CANCELLED, //event cancelledf
        }

        public enum AbsenceStatus
        {
            PENDING = 1,
            APPROVED, 
            CANCELLED,
            REJECTED
        }

        public enum TaskPriority
        {
            LOW = 1,
            MEDIUM,
            HIGH
        }

        public enum TaskStatus
        {
            PENDING = 1,
            IN_PROGRESS,
            FINISHED,
            CANCELLED,
        }

        public enum AbsenceType
        {
            SICK_LEAVE = 1,
            VACATION_LEAVE,
            PERSONAL_LEAVE,
            PARENTAL_LEAVE,
            BEREAVEMENT_LEAVE,
            JURY_DUTY,
            MILITARY_LEAVE,
            UNPAID_LEAVE,
            PUBLIC_HOLIDAY,
            STUDY_LEAVE,
            SABBATICAL,
            COMPENSATORY_LEAVE,
            VOLUNTEER_LEAVE,
            FAMILY_AND_MEDICAL_LEAVE,
            HALF_DAY_LEAVE,
            EMERGENCY_LEAVE,
            CASUAL_LEAVE,
            ADMINISTRATIVE_LEAVE,
            FLOATING_HOLIDAY,
            RELIGIOUS_LEAVE
        }

        public enum RepeatState
        {
            ONCE = 1,
            ALWAYS
        }

    }
}
