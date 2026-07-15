using Domain.Dto;
using Domain.Tables;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class DbRepository
    {
        internal ApplicationDbContext _dbContext;
        public DbRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public async Task<List<ManifestDto>> GetManifestAsync()
        {
            var response = new List<ManifestDto>();
            try
            {
                response = await _dbContext.Manifests.Select(data => new ManifestDto()
                {
                    Code = data.Code,
                    LabId = data.LabId,
                    ManifestId = data.Id,
                    SentAt = data.SentAt,
                    Status = data.Status
                }).ToListAsync();
            }
            catch (Exception ex)
            {
            }
            return response;
        }

        public async Task<List<SpecimenDto>?> GetSpecimenAsync(int manifestId)
        {
            var response = new List<SpecimenDto>();
            try
            {
                response = await (from spec in _dbContext.Specimens
                                  join mani in _dbContext.Manifests
                                  on spec.ManifestId equals mani.Id
                                  join lab in _dbContext.Labs
                                  on mani.LabId equals lab.Id
                                  where spec.ManifestId == manifestId
                                  select new SpecimenDto()
                                  {
                                      SpecimenId = spec.Id,
                                      Code = spec.Code,
                                      ManifestId = spec.ManifestId,
                                      Patient = spec.Patient,
                                      Provider = spec.Provider,
                                      ReceivedAt = spec.ReceivedAt,
                                      Status = spec.Status,
                                      LabId = lab.Id,
                                      LabName = lab.Name
                                  }).ToListAsync();
            }
            catch (Exception ex)
            {

            }
            return response;
        }

        public async Task<Manifest?> GetManifestByIdAsync(int id)
        {
            return await _dbContext.Manifests.FirstOrDefaultAsync(data => data.Id == id);
        }

        public async Task<bool> IsResolved(int manifestId)
        {
            return await _dbContext.Discrepancies.AnyAsync(x => x.ManifestId == manifestId && x.Status == Domain.Enums.DiscrepancyStatus.Open);
        }

        public async Task<Specimen> GetSpecimenByIdAsync(int id, int manifestId)
        {
            return await _dbContext.Specimens.FirstAsync(data => data.Id == id && data.ManifestId == manifestId);
        }

        public async Task RaiseDscrepancy(Discrepancy model)
        {
            await _dbContext.Discrepancies.AddAsync(model);
        }

        public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();
    }
}
