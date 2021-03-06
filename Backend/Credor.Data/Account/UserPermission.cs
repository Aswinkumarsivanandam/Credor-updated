using System;
using System.Collections.Generic;
using System.Text;

namespace Credor.Data.Entities
{
    public class UserPermission
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AccessGrantedTo { get; set; }
        public int Permission { get; set; }
        public bool IsNotificationEnabled { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }        
    }
}
