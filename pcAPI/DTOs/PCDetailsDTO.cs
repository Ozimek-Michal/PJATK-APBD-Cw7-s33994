namespace pcAPI.DTOs;

public record PCDetailsDTO(
    int Id,
    string Name,
    double Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock,
    IEnumerable<ComponentDTO> Components
);