
#### Staff Table:
	* StaffId (int, primary key)
	* FirstName (varchar(30), NOT NULL)
	* LastName (varchar(30), NOT NULL)
	* Email (varchar(60), UNIQUE, , NOT NULL)
	* LeaveBalance (float, NOT NULL)

#### LeaveRequest Table:
	* LeaveRequestId (int, primary key)
	* FkStaffId (int, foreign key to Staff table)
	* FkLeaveTypeId (int, foreign key to LeaveType table)
	* RequestStartDate (DateTime, NOT NULL)
	* RequestEndDate (DateTime, NOT NULL)
	* RequestedDays AS DATEDIFF(day, RequestStartDate, RequestEndDate) + 1 PERSISTED
	* FkStatusId (int) (int, foreign key to Status table)

#### LeaveType Table:
	* LeaveTypeId (int, primary key)
	* LeaveTypeName (varchar(30), UNIQUE, NOT NULL)
	* LeaveTypeDescription (varchar(100))

#### Status Table:
	* StatusId (int, primary key)
	* StatusName (varchar(15), UNIQUE, NOT NULL) // e.g. 1 = Pending, 2 = Approved, 3 = Rejected

#### Trigger:
	* Name: Update_LeaveBalance_On_LeaveRequest_Approval
	* Event: AFTER UPDATE
	* Condition: Status = 2
		###Action:
		- Calculate the number of days approved by subtracting the previous RequestedDays value from the updated RequestedDays value.
		- Update the corresponding staff member's LeaveBalance by subtracting the calculated number of days.
