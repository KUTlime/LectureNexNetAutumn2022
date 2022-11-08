using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParsingCsv.Data;

public class Order
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public string Name { get; set; }
    public DateTime Created { get; set; }
}