namespace pcAPI.DTOs;

public record ComponentDTO(
    string Code,
    string Name,
    string? Description,
    string Manufacturer,
    string Type,
    int Amount
);