using System.Collections.Generic;
using DB.Entity;
using NUnit.Framework;
using Service.AdminService.Realization;
using Service.Tests.TestSettings;
using Service.Tests.TestSettings.TestCases;

namespace Service.Tests.AdminServiceTest
{
    public class WorkPlanServiceTests
    {
        private WorkPlanService workPlanService;

        public void SetUp(IList<WorkPlan> workPlans)
        {
            var repositoryDescriptor = new RepositoryDescriptor()
            {
                WorkPlans = workPlans,
            };

            var result = ServiceTestHelper.MockRepository(repositoryDescriptor);

            workPlanService = new WorkPlanService(result.UnitOfWorkMock.Object);
        }

        [Test, TestCaseSource(typeof(WorkPlanCase), nameof(WorkPlanCase.ReadAll))]
        public int ReadAllTest_TestCase(IList<WorkPlan> workPlans)
        {
            SetUp(workPlans);
            var result = workPlanService.ReadAll();
            return result.Count;
        }

        [Test, TestCaseSource(typeof(WorkPlanCase), nameof(WorkPlanCase.Update))]
        public string UpdateTest_TestCase(IList<WorkPlan> workPlans)
        {
            SetUp(workPlans);
            var workPlan = new WorkPlan()
            {
                Id = 1,
                DeskGuaranteed = true,
                MaxOfficeDay = 30,
                MinOfficeDay = 12,
                Plan = "Test plan",
                PlanDescription = "desc",
                Priority = 1
            };
            var result = workPlanService.Update(workPlan);
            return result.Find(x => x.Id == workPlan.Id)?.Plan;
        }

        [Test, TestCaseSource(typeof(WorkPlanCase), nameof(WorkPlanCase.Delete))]
        public int Delete_TestCase(IList<WorkPlan> workPlans)
        {
            SetUp(workPlans);

            var workPlan = new WorkPlan()
            {
                Id = 1,
                DeskGuaranteed = true,
                MaxOfficeDay = 30,
                MinOfficeDay = 12,
                Plan = "plan",
                PlanDescription = "desc",
                Priority = 1
            };
            
            var result = workPlanService.Delete(workPlan);

            return result.Count;
        }
    }
}
