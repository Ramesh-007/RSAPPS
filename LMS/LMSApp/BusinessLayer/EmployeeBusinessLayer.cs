using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessEntities;
using System.Data.Entity.Core.Objects;

namespace BusinessLayer
{
    public class EmployeeBusinessLayer
    {
        public List<EmployeeAttendance> GetEmployeeAttendance(int Id, int Week)
        {
            LMSAppDAL lmsDAL = new LMSAppDAL();
            List<EmployeeAttendance> listToReturn = new List<EmployeeAttendance>();
            List<EmployeeAttendance> listAttend = lmsDAL.EmployeeAttendanceList.ToList();
            foreach (EmployeeAttendance ed in listAttend)
            {
                if (ed.EmployeeId == Id && Week ==  ed.Week)
                {
                    listToReturn.Add(ed);
                }
            }
            return listToReturn;
        }

        public void SaveEmployeeAttendance(EmployeeAttendance iEmpAtt)
        {
            LMSAppDAL lmsDAL = new LMSAppDAL();
            List<EmployeeAttendance> listAtt = lmsDAL.EmployeeAttendanceList.ToList();
            if (listAtt != null)
            {
                EmployeeAttendance attendance = listAtt.Last();
                if (attendance.EmployeeId == iEmpAtt.EmployeeId && attendance.Date != iEmpAtt.Date)
                {
                    lmsDAL.EmployeeAttendanceList.Add(iEmpAtt);
                    lmsDAL.SaveChanges();
                }
                else
                {
                    attendance.Status = iEmpAtt.Status;
                    lmsDAL.SaveChanges();
                }
            }
        }

        public int GetUserId(string UserName)
        {
            int Id = 0;
            LMSAppDAL lmsDAL = new LMSAppDAL();
            List<Employee> EmplList = lmsDAL.Employees.ToList();
            foreach(Employee emp in EmplList)
            {
                if (emp.Name == UserName)
                {
                    Id = emp.Id;
                    break;
                }
            }

            return Id;
        }
        
    }
}
