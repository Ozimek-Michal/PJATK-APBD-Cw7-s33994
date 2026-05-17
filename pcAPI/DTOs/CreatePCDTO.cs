using System.ComponentModel.DataAnnotations;

namespace pcAPI.DTOs;

public record CreatePCDTO(
    [MaxLength(50)] string Name,
    double Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);