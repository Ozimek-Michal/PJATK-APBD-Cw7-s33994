namespace pcAPI.DTOs;

public record PCDTO(
    int Id,
    string Name,
    double Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);