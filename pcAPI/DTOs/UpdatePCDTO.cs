using System.ComponentModel.DataAnnotations;

namespace pcAPI.DTOs;

public record UpdatePCDTO(
    [MaxLength(50)] string Name,
    double Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);