using System;
using System.Collections.Generic;
using System.Text;
using LeaveManagementModels;
using Microsoft.Data.SqlClient;
namespace LeaveManagementDataService
{
    public class LeaveDBData : ILeaveDataService
    {
        private string connectionString =
        "Data Source=localhost\\SQLEXPRESS;Initial Catalog=LeaveManagementDB;Integrated Security=True;TrustServerCertificate=True;";
SqlConnection sqlConnection;
        public LeaveDBData()
        {
            sqlConnection = new SqlConnection(connectionString);
            AddSeeds();
        }
        private void AddSeeds()
        {
            var example = GetLeaves();

            if (example.Count == 0)
            {
                Leave shipment = new Leave
                {
                    LeaveId = Guid.NewGuid(),
                    EmployeeName = "clark",
                    LeaveType = "sick",
                    DaysFiled = 2,
                    MaxDays = 5,
                    RemainingDays = 3,
                    IsApproved = true
                };

                Add(shipment);
            }
        }
        public void Add(Leave leave)
        {
            string insert = "INSERT INTO Leaves VALUES (@LeaveId,@EmployeeName,@LeaveType,@DaysFiled,@MaxDays,@RemainingDays,@IsApproved)";
            SqlCommand cmd = new SqlCommand(insert, sqlConnection);
            cmd.Parameters.AddWithValue("@LeaveId", leave.LeaveId);
            cmd.Parameters.AddWithValue("@EmployeeName", leave.EmployeeName);
            cmd.Parameters.AddWithValue("@LeaveType", leave.LeaveType);
            cmd.Parameters.AddWithValue("@DaysFiled", leave.DaysFiled);
            cmd.Parameters.AddWithValue("@MaxDays", leave.MaxDays);
            cmd.Parameters.AddWithValue("@RemainingDays", leave.RemainingDays);
            cmd.Parameters.AddWithValue("@IsApproved", leave.IsApproved);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public List<Leave> GetLeaves()
        {
            List<Leave> leaves = new List<Leave>();
            string select = "SELECT * FROM Leaves";
            SqlCommand cmd = new SqlCommand(select, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                leaves.Add(new Leave
                {
                    LeaveId = Guid.Parse(reader["LeaveId"].ToString()),
                    EmployeeName = reader["EmployeeName"].ToString(),
                    LeaveType = reader["LeaveType"].ToString(),
                    DaysFiled = Convert.ToInt32(reader["DaysFiled"]),
                    MaxDays = Convert.ToInt32(reader["MaxDays"]),
                    RemainingDays = Convert.ToInt32(reader["RemainingDays"]),
                    IsApproved = Convert.ToBoolean(reader["IsApproved"])
                });
            }
            sqlConnection.Close();
            return leaves;
        }
        public Leave? GetById(Guid id)
        {
            string select = "SELECT * FROM Leaves WHERE LeaveId=@LeaveId";
            SqlCommand cmd = new SqlCommand(select, sqlConnection);
            cmd.Parameters.AddWithValue("@LeaveId", id);
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Leave leave = null;
            if (reader.Read())
            {
                leave = new Leave
                {
                    LeaveId = Guid.Parse(reader["LeaveId"].ToString()),
                    EmployeeName = reader["EmployeeName"].ToString(),
                    LeaveType = reader["LeaveType"].ToString(),
                    DaysFiled = Convert.ToInt32(reader["DaysFiled"]),
                    MaxDays = Convert.ToInt32(reader["MaxDays"]),
                    RemainingDays = Convert.ToInt32(reader["RemainingDays"]),
                    IsApproved = Convert.ToBoolean(reader["IsApproved"])
                };
            }
            sqlConnection.Close();
            return leave;
        }
        public void Update(Leave leave)
        {
            string update =
            @"UPDATE Leaves
SET EmployeeName=@EmployeeName,
LeaveType=@LeaveType,
DaysFiled=@DaysFiled,
MaxDays=@MaxDays,
RemainingDays=@RemainingDays,
IsApproved=@IsApproved
WHERE LeaveId=@LeaveId";
            SqlCommand cmd = new SqlCommand(update, sqlConnection);
            cmd.Parameters.AddWithValue("@EmployeeName", leave.EmployeeName);
            cmd.Parameters.AddWithValue("@LeaveType", leave.LeaveType);
            cmd.Parameters.AddWithValue("@DaysFiled", leave.DaysFiled);
            cmd.Parameters.AddWithValue("@MaxDays", leave.MaxDays);
            cmd.Parameters.AddWithValue("@RemainingDays", leave.RemainingDays);
            cmd.Parameters.AddWithValue("@IsApproved", leave.IsApproved);
            cmd.Parameters.AddWithValue("@LeaveId", leave.LeaveId);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void Delete(Guid id)
        {
            string delete = "DELETE FROM Leaves WHERE LeaveId=@LeaveId";
            SqlCommand cmd = new SqlCommand(delete, sqlConnection);
            cmd.Parameters.AddWithValue("@LeaveId", id);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
