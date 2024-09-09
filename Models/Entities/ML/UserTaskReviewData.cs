using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.ML
{
    public class UserTaskReviewData
    {
        [KeyType(count: 2000)]
        public uint UserId { get; set; }
        [KeyType(count: 2000)]
        public uint TaskId { get; set; }
        public float Review { get; set; }
    }

    public class TaskReviewPrediction
    {
        public float Score { get; set; }
    }
}
