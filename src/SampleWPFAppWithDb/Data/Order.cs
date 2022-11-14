using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleWPFAppWithDb.Data;

public class Order
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Created { get; set; }
}