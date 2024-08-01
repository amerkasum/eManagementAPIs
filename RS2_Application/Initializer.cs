using Helpers.Constants;
using Models.Entities;
using System.Collections.Generic;
using System;

namespace RS2_Application
{
    public class Initializer
    {
        public void InitializeData()
        {
            //shifts
            List<Shifts> shifts = new List<Shifts>
            {
                new Shifts { Name = nameof(Enumerations.ShiftType.FIRST), TimeFrom = new DateTime(1,1,2000, 8,0,0), TimeTo = new DateTime(1,1,2000,16,0,0) },
                new Shifts { Name = nameof(Enumerations.ShiftType.SECOND), TimeFrom = new DateTime(1,1,2000,16,0,0), TimeTo = new DateTime(1,1,2000,0,0,0) },
                new Shifts { Name = nameof(Enumerations.ShiftType.THIRD), TimeFrom = new DateTime(1,1,2000, 0,0,0), TimeTo = new DateTime(1,1,2000,8,0,0) }
            };

            //roles

            List<Roles> roles = new List<Roles>
            {
                new Roles { Name = nameof(Enumerations.Roles.ADMINISTRATOR) },
                new Roles { Name = nameof(Enumerations.Roles.EMPLOYEE) },
            };

            //event statuses

            List<EventStatuses> eventStatuses = new List<EventStatuses> {
                new EventStatuses { Name = nameof(Enumerations.EventStatus.UPCOMING) },
                new EventStatuses { Name = nameof(Enumerations.EventStatus.ONGOING) },
                new EventStatuses { Name = nameof(Enumerations.EventStatus.FINISHED) },

                new EventStatuses { Name = nameof(Enumerations.EventStatus.CANCELLED) }
            };

            List<TaskStatuses> taskStatuses = new List<TaskStatuses>
            {
                new TaskStatuses { Name = nameof(Enumerations.TaskStatus.PENDING) },
                new TaskStatuses { Name = nameof(Enumerations.TaskStatus.INPROGRESS) },
                new TaskStatuses { Name = nameof(Enumerations.TaskStatus.FINISHED) },
                new TaskStatuses { Name = nameof(Enumerations.TaskStatus.CANCELLED) }
            };
        }
    }
}
