using Microsoft.EntityFrameworkCore;
using pcAPI.DTOs;
using pcAPI.Exceptions;
using pcAPI.Infrastructure;
using pcAPI.Models;

namespace pcAPI.Service;

public class PcService(DatabaseContext ctx) : IPcService
{
    public async Task<IEnumerable<PCDTO>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await ctx.PCs
            .Select(pc => new PCDTO(
                pc.Id,
                pc.Name,
                pc.Weight,
                pc.Warranty,
                pc.CreatedAt,
                pc.Stock
            ))
            .ToListAsync(cancellationToken);
    }

    public async Task<PCDetailsDTO> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var pc = await ctx.PCs
            .Where(p => p.Id == id)
            .Select(p => new PCDetailsDTO(
                p.Id,
                p.Name,
                p.Weight,
                p.Warranty,
                p.CreatedAt,
                p.Stock,
                p.PCComponents.Select(c => new ComponentDTO(
                    c.Component.Code,
                    c.Component.Name,
                    c.Component.Description,
                    c.Component.ComponentManufacturer.Abbreviation,
                    c.Component.ComponentType.Abbreviation,
                    c.Amount
                ))
            ))
            .FirstOrDefaultAsync(cancellationToken);

        if (pc is null)
            throw new NotFoundException($"PC with id {id} not found");

        return pc;
    }

    public async Task<PCDTO> AddAsync(CreatePCDTO request, CancellationToken cancellationToken)
    {
        var pc = new PC
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock
        };

        ctx.PCs.Add(pc);
        await ctx.SaveChangesAsync(cancellationToken);

        return new PCDTO(
            pc.Id,
            pc.Name,
            pc.Weight,
            pc.Warranty,
            pc.CreatedAt,
            pc.Stock
        );
    }

    public async Task UpdateAsync(int id, UpdatePCDTO request, CancellationToken cancellationToken)
    {
        var affected = await ctx.PCs
            .Where(p => p.Id == id)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(p => p.Name, request.Name)
                .SetProperty(p => p.Weight, request.Weight)
                .SetProperty(p => p.Warranty, request.Warranty)
                .SetProperty(p => p.CreatedAt, request.CreatedAt)
                .SetProperty(p => p.Stock, request.Stock),
                cancellationToken
            );

        if (affected == 0)
            throw new NotFoundException($"PC with id {id} not found");
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var affected = await ctx.PCs
            .Where(p => p.Id == id)
            .ExecuteDeleteAsync(cancellationToken);

        if (affected == 0)
            throw new NotFoundException($"PC with id {id} not found");
    }
}