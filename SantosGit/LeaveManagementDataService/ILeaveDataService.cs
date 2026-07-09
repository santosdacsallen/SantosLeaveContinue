using System;
using System.Collections.Generic;
using System.Text;
using LeaveManagementModels;
namespace LeaveManagementDataService
{
    public interface ILeaveDataService
    {
        void Add(Leave leave);
        List<Leave> GetLeaves();
        Leave? GetById(Guid id);
        void Update(Leave leave);
        void Delete(Guid id);
    }
}
