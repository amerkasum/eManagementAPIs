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

        public enum Roles
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
            INPROGRESS,
            FINISHED,
            CANCELLED,
        }

    }
}
