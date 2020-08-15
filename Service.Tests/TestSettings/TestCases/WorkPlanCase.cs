using System;
using System.Collections.Generic;
using System.Text;
using DB.Entity;
using NUnit.Framework;

namespace Service.Tests.TestSettings.TestCases
{
    class WorkPlanCase
    {
        private static IList<WorkPlan> workPlansList = new List<WorkPlan>()
        {
            new WorkPlan()
            {
                Id = 1,
                DeskGuaranteed = true,
                MaxOfficeDay = 30,
                MinOfficeDay = 12,
                Plan = "plan",
                PlanDescription = "desc",
                Priority = 1
            },
            new WorkPlan()
            {
                Id = 2,
                DeskGuaranteed = false,
                MaxOfficeDay = 30,
                MinOfficeDay = 12,
                Plan = "plan",
                PlanDescription = "desc",
                Priority = 2
            }
        };

        public static IEnumerable<TestCaseData> ReadAll
        {
            get
            {
                yield return new TestCaseData(workPlansList).Returns(2);
                yield return new TestCaseData(new List<WorkPlan>()).Returns(0);
                yield return new TestCaseData(null).Returns(0);
            }
        }

        public static IEnumerable<TestCaseData> Update
        {
            get
            {
                yield return new TestCaseData(workPlansList).Returns("Test plan");
                yield return new TestCaseData(new List<WorkPlan>()).Returns(typeof(NullReferenceException));
                yield return new TestCaseData(null).Returns(typeof(NullReferenceException));
            }
        }

        public static IEnumerable<TestCaseData> Delete
        {
            get
            {
                yield return new TestCaseData(workPlansList).Returns(workPlansList.Count - 1);
                yield return new TestCaseData(new List<WorkPlan>()).Returns(0);
                yield return new TestCaseData(null).Returns(0);
            }
        }
    }

    
}
