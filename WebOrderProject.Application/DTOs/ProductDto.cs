using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace WebOrderProject.Application.DTOs;

public class ProductDto
{
    [SwaggerSchema(ReadOnly = true, Description = "Unique identifier of the product")]
    public Guid ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    [SwaggerSchema(ReadOnly = true, Description = "Date and time when the product was created")]
    [JsonIgnore]
    public DateTime CreatedAt { get; set; }
}
