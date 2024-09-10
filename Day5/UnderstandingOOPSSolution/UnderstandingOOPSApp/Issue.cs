using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace UnderstandingOOPSApp
{

    
    internal class Issue 
    {
       
        //ctor
        public Issue()
        {

        }
        public Issue(int id, string title, string description, int reportedBy)
        {
            Id = id;
            Title = title;
            Description = description;
            ReportedBy = reportedBy;
            CreatedDate = DateTime.Now;
            Status = "Just Created";
            ClosedDate = null;
        }

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ReportedBy { get; set; }
        public int? AssignedTo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; private set; } = string.Empty;
        public DateTime? ClosedDate { get; set; }
        public bool ChangeStatus(string newStatus)
        {
            if (Status == "Closed")
            {
                Console.WriteLine("Cannot change staus as the issue is closed. Please raise a new Issue");
                return false;
            }
            Status = newStatus;
            if (newStatus == "Closed")
            {
                ClosedDate = DateTime.Now;
                Console.WriteLine($"Issue with {Id} is maked as Closed");
            }
            return true;
        }
        public bool AssignIssue(int assignedTo)
        {
            if (Status == "Closed")
            {
                Console.WriteLine("Cannot assign issue as the issue is closed. Please raise a new Issue");
                return false;
            }
            if (ReportedBy == assignedTo)
            {
                Console.WriteLine("Cannot assign issue to the same person who reported the issue");
                return false;
            }
            AssignedTo = assignedTo;
            Console.WriteLine($"Issue with {Id} successfully Assigned to {AssignedTo}");
            return true;
        }
        public void PrintIssueDetails()
        {
            var issueDetails = $"Issue Id: {Id}\nTitle: {Title}\nDescription: {Description}\nReported By: {ReportedBy}\nAssigned To: {AssignedTo}\nCreated Date: {CreatedDate}\nStatus: {Status}\nClosed Date: ";
            issueDetails += ClosedDate == null ? "-" : ClosedDate;//ternary operator
            Console.WriteLine(issueDetails);

        }
        public override string ToString()
        {
            var issueDetails = $"Issue Id: {Id}\nTitle: {Title}\nDescription: {Description}\nReported By: {ReportedBy}\nAssigned To: {AssignedTo}\nCreated Date: {CreatedDate}\nStatus: {Status}\nClosed Date: ";
            issueDetails += ClosedDate == null ? "-" : ClosedDate;//ternary operator
            return issueDetails;

        }
    }
}
