using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace RCFeedback.Models { 
public class Feedback
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string OrderNumber { get; set; }

    public int QualityRating { get; set; }
    public int DesignRating { get; set; }
    public int PraiceRating { get; set; }
    public int DeliveryRating { get; set; }

    public string Comment { get; set; }

}
}

